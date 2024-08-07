﻿## Tables

### MyTable

```sql
CREATE TABLE [dbo].[MyTable](
	[Value] [int] NULL
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [MyIndex] ON [dbo].[MyTable]
(
	[Value] ASC
) ON [PRIMARY]

CREATE TRIGGER MyTrigger
ON MyTable
AS RAISERROR ('Notify Customer Relations', 16, 10);

ALTER TABLE [dbo].[MyTable] ENABLE TRIGGER [MyTrigger]
```

## Views

### MyView

```sql
CREATE VIEW MyView
AS
  SELECT Value
  FROM MyTable
  WHERE (Value > 10);
```

## StoredProcedures

### MyProcedure

```sql
CREATE PROCEDURE MyProcedure
AS
BEGIN
  SET NOCOUNT ON;
  SELECT Value
  FROM MyTable
  WHERE (Value > 10);
END;
```

## UserDefinedFunctions

### MyFunction

```sql
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
```

## Synonyms

### synonym1

```sql
CREATE SYNONYM [dbo].[synonym1] FOR [MyTable]
```