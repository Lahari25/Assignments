CREATE PROCEDURE  GrandAmount
AS
BEGIN
    DECLARE @grand DECIMAL;
    SET @grand = 0;

 

    DECLARE CursorP CURSOR FOR
        SELECT ProductName, UnitsOnOrder, UnitPrice FROM Products;

 

    OPEN CursorP;

 

    DECLARE @Unitsonorder smallint, @Unitprice MONEY, @Totalamount DECIMAL, @Productname NVARCHAR(40);


 

    FETCH NEXT FROM CursorP INTO @Productname, @Unitsonorder, @Unitprice;

 

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF (@Unitsonorder > 100)
        BEGIN
            SELECT @Totalamount = ((@Unitsonorder * @Unitprice) - ((@Unitsonorder * @Unitprice) * 0.1));
        END
        ELSE IF (@Unitsonorder > 50)
        BEGIN
            SELECT @Totalamount = ((@Unitsonorder * @Unitprice) - ((@Unitsonorder * @Unitprice) * 0.05));
        END
        ELSE 
        BEGIN
            SELECT @Totalamount = (@Unitsonorder * @Unitprice);
        END



        PRINT @Productname + ' - ' + FORMAT(@Totalamount,'N2');
        SET @grand = @grand + @Totalamount;

 

        FETCH NEXT FROM CursorP INTO @Productname, @Unitsonorder, @Unitprice;
    END;

 

 

    CLOSE CursorP;
    DEALLOCATE CursorP;

 

    -- Print the grand total
    PRINT 'GRAND TOTAL : ' + CAST(@grand AS VARCHAR(10))
END;

 

 

EXEC GrandAmount;