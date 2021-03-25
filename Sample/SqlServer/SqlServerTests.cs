﻿using System.Threading.Tasks;
using LocalDb;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class SqlServerTests
{
    static SqlInstance sqlInstance;

    static SqlServerTests()
    {
        #region Enable

        VerifySqlServer.Enable();

        #endregion

        sqlInstance = new(
            "VerifySqlServer",
            connection =>
            {
                var sqlConnection = (SqlConnection) connection;
                Server server = new(new ServerConnection(sqlConnection));
                server.ConnectionContext.ExecuteNonQuery(@"
CREATE TABLE
MyTable(Value int);
GO

CREATE INDEX MyIndex
ON MyTable (Value);
GO

INSERT INTO MyTable (Value)
VALUES (42);
GO

CREATE TRIGGER MyTrigger
ON MyTable
AFTER UPDATE
AS RAISERROR ('Notify Customer Relations', 16, 10);
GO

CREATE VIEW MyView
AS
  SELECT Value
  FROM MyTable
  WHERE (Value > 10);
GO

create synonym synonym1
    for MyTable;
GO

CREATE PROCEDURE MyProcedure
AS
BEGIN
  SET NOCOUNT ON;
  SELECT Value
  FROM MyTable
  WHERE (Value > 10);
END;
GO

CREATE FUNCTION MyFunction(
  @quantity INT,
  @list_price DEC(10,2),
  @discount DEC(4,2)
)
RETURNS DEC(10,2)
AS
BEGIN
    RETURN @quantity * @list_price * (1 - @discount);
END;");
                return Task.CompletedTask;
            });
    }

    [Fact]
    public async Task SqlServerSchema()
    {
        await using var database = await sqlInstance.Build();
        var connection = database.Connection;

        #region SqlServerSchema

        await Verifier.Verify(connection);

        #endregion
    }

    [Fact]
    public async Task Recording()
    {
        await using var database = await sqlInstance.Build();
        var connectionString = database.ConnectionString;

        #region SqlRecording

        SqlRecording.StartRecording();
        var value = await MethodUnderTest(connectionString);
        await Verifier.Verify(value);

        #endregion
    }

    static async Task<int> MethodUnderTest(string connectionString)
    {
        await using SqlConnection connection = new(connectionString);
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = "select Value from MyTable";
        var value = await command.ExecuteScalarAsync();
        return (int)value!;
    }
}