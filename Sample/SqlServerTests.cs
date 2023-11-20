using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

[UsesVerify]
public class SqlServerTests
{
    static SqlInstance sqlInstance;

    [ModuleInitializer]
    public static void Initialize()
        => VerifySqlServer.Initialize();

    static SqlServerTests() =>
        sqlInstance = new(
            "VerifySqlServer",
            connection =>
            {
                var sqlConnection = (SqlConnection) connection;
                var server = new Server(new ServerConnection(sqlConnection));
                server.ConnectionContext.ExecuteNonQuery(
                    """
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
                    END;
                    """);
                return Task.CompletedTask;
            },
            timestamp: GetTimestamp());

    static DateTime GetTimestamp([CallerFilePath] string path = "")
        => File.GetLastWriteTime(path);

    [Fact]
    [Trait("Category", "Integration")]
    public async Task SqlServerSchema()
    {
        await using var database = await sqlInstance.Build();
        var connection = database.Connection;

        await Verify(connection);
    }

    [Fact]
    public async Task RecordingUsage()
    {
        await using var database = await sqlInstance.Build();

        Recording.Start();
        var value = MethodUnderTest(database.Connection);
        await Verify(value);
    }

    static int MethodUnderTest(SqlConnection connection)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "select Value from MyTable";
        return (int) command.ExecuteScalar();
    }
}