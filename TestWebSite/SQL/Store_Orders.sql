DROP PROCEDURE [dbo].[Sp_GetOrdersPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetOrdersPageWise]
/* Optional Filters for Dynamic Search*/
@OrderID  [int] =null,
@CustomerID  [nvarchar](255) =null,
@EmployeeID  [int] =null,
@OrderDate  [datetime] =null,
@RequiredDate  [datetime] =null,
@ShippedDate  [datetime] =null,
@ShipVia  [int] =null,
@Freight  [float] =null,
@ShipName  [nvarchar](255) =null,
@ShipAddress  [nvarchar](255) =null,
@ShipCity  [nvarchar](255) =null,
@ShipRegion  [nvarchar](255) =null,
@ShipPostalCode  [nvarchar](255) =null,
@ShipCountry  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'OrderID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lOrderID  [int] =null,
@lCustomerID  [nvarchar](255) =null,
@lEmployeeID  [int] =null,
@lOrderDate  [datetime] =null,
@lRequiredDate  [datetime] =null,
@lShippedDate  [datetime] =null,
@lShipVia  [int] =null,
@lFreight  [float] =null,
@lShipName  [nvarchar](255) =null,
@lShipAddress  [nvarchar](255) =null,
@lShipCity  [nvarchar](255) =null,
@lShipRegion  [nvarchar](255) =null,
@lShipPostalCode  [nvarchar](255) =null,
@lShipCountry  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lOrderID =@OrderID
SET @lCustomerID = LTRIM(RTRIM(@CustomerID))
SET @lEmployeeID =@EmployeeID
SET @lOrderDate = LTRIM(RTRIM(@OrderDate))
SET @lRequiredDate = LTRIM(RTRIM(@RequiredDate))
SET @lShippedDate = LTRIM(RTRIM(@ShippedDate))
SET @lShipVia =@ShipVia
SET @lFreight = LTRIM(RTRIM(@Freight))
SET @lShipName = LTRIM(RTRIM(@ShipName))
SET @lShipAddress = LTRIM(RTRIM(@ShipAddress))
SET @lShipCity = LTRIM(RTRIM(@ShipCity))
SET @lShipRegion = LTRIM(RTRIM(@ShipRegion))
SET @lShipPostalCode = LTRIM(RTRIM(@ShipPostalCode))
SET @lShipCountry = LTRIM(RTRIM(@ShipCountry))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH OrdersResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'OrderID' AND @SortOrder='ASC')
                   THEN OrderID
       END ASC,
       CASE WHEN (@lSortCol = 'OrderID' AND @SortOrder='DESC')
                  THEN OrderID
       END DESC,
CASE WHEN (@lSortCol = 'CustomerID' AND @SortOrder='ASC')
                   THEN CustomerID
       END ASC,
       CASE WHEN (@lSortCol = 'CustomerID' AND @SortOrder='DESC')
                  THEN CustomerID
       END DESC,
CASE WHEN (@lSortCol = 'EmployeeID' AND @SortOrder='ASC')
                   THEN EmployeeID
       END ASC,
       CASE WHEN (@lSortCol = 'EmployeeID' AND @SortOrder='DESC')
                  THEN EmployeeID
       END DESC,
CASE WHEN (@lSortCol = 'OrderDate' AND @SortOrder='ASC')
                   THEN OrderDate
       END ASC,
       CASE WHEN (@lSortCol = 'OrderDate' AND @SortOrder='DESC')
                  THEN OrderDate
       END DESC,
CASE WHEN (@lSortCol = 'RequiredDate' AND @SortOrder='ASC')
                   THEN RequiredDate
       END ASC,
       CASE WHEN (@lSortCol = 'RequiredDate' AND @SortOrder='DESC')
                  THEN RequiredDate
       END DESC,
CASE WHEN (@lSortCol = 'ShippedDate' AND @SortOrder='ASC')
                   THEN ShippedDate
       END ASC,
       CASE WHEN (@lSortCol = 'ShippedDate' AND @SortOrder='DESC')
                  THEN ShippedDate
       END DESC,
CASE WHEN (@lSortCol = 'ShipVia' AND @SortOrder='ASC')
                   THEN ShipVia
       END ASC,
       CASE WHEN (@lSortCol = 'ShipVia' AND @SortOrder='DESC')
                  THEN ShipVia
       END DESC,
CASE WHEN (@lSortCol = 'Freight' AND @SortOrder='ASC')
                   THEN Freight
       END ASC,
       CASE WHEN (@lSortCol = 'Freight' AND @SortOrder='DESC')
                  THEN Freight
       END DESC,
CASE WHEN (@lSortCol = 'ShipName' AND @SortOrder='ASC')
                   THEN ShipName
       END ASC,
       CASE WHEN (@lSortCol = 'ShipName' AND @SortOrder='DESC')
                  THEN ShipName
       END DESC,
CASE WHEN (@lSortCol = 'ShipAddress' AND @SortOrder='ASC')
                   THEN ShipAddress
       END ASC,
       CASE WHEN (@lSortCol = 'ShipAddress' AND @SortOrder='DESC')
                  THEN ShipAddress
       END DESC,
CASE WHEN (@lSortCol = 'ShipCity' AND @SortOrder='ASC')
                   THEN ShipCity
       END ASC,
       CASE WHEN (@lSortCol = 'ShipCity' AND @SortOrder='DESC')
                  THEN ShipCity
       END DESC,
CASE WHEN (@lSortCol = 'ShipRegion' AND @SortOrder='ASC')
                   THEN ShipRegion
       END ASC,
       CASE WHEN (@lSortCol = 'ShipRegion' AND @SortOrder='DESC')
                  THEN ShipRegion
       END DESC,
CASE WHEN (@lSortCol = 'ShipPostalCode' AND @SortOrder='ASC')
                   THEN ShipPostalCode
       END ASC,
       CASE WHEN (@lSortCol = 'ShipPostalCode' AND @SortOrder='DESC')
                  THEN ShipPostalCode
       END DESC,
CASE WHEN (@lSortCol = 'ShipCountry' AND @SortOrder='ASC')
                   THEN ShipCountry
       END ASC,
       CASE WHEN (@lSortCol = 'ShipCountry' AND @SortOrder='DESC')
                  THEN ShipCountry
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 OrderID,
 CustomerID,
 EmployeeID,
 OrderDate,
 RequiredDate,
 ShippedDate,
 ShipVia,
 Freight,
 ShipName,
 ShipAddress,
 ShipCity,
 ShipRegion,
 ShipPostalCode,
 ShipCountry
 FROM Orders
WHERE
(@lOrderID IS NULL OR OrderID = @lOrderID) AND
(@lCustomerID IS NULL OR CustomerID LIKE '%' +@lCustomerID + '%') AND 
(@lEmployeeID IS NULL OR EmployeeID = @lEmployeeID) AND
(@lOrderDate IS NULL OR OrderDate = @lOrderDate) AND
(@lRequiredDate IS NULL OR RequiredDate = @lRequiredDate) AND
(@lShippedDate IS NULL OR ShippedDate = @lShippedDate) AND
(@lShipVia IS NULL OR ShipVia = @lShipVia) AND
(@lFreight IS NULL OR Freight = @lFreight) AND
(@lShipName IS NULL OR ShipName LIKE '%' +@lShipName + '%') AND 
(@lShipAddress IS NULL OR ShipAddress LIKE '%' +@lShipAddress + '%') AND 
(@lShipCity IS NULL OR ShipCity LIKE '%' +@lShipCity + '%') AND 
(@lShipRegion IS NULL OR ShipRegion LIKE '%' +@lShipRegion + '%') AND 
(@lShipPostalCode IS NULL OR ShipPostalCode LIKE '%' +@lShipPostalCode + '%') AND 
(@lShipCountry IS NULL OR ShipCountry LIKE '%' +@lShipCountry + '%') 
)
SELECT   RecordCount,
 ROWNUM,

OrderID,
CustomerID,
EmployeeID,
OrderDate,
RequiredDate,
ShippedDate,
ShipVia,
Freight,
ShipName,
ShipAddress,
ShipCity,
ShipRegion,
ShipPostalCode,
ShipCountry FROM OrdersResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetOrders_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetOrders_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [CustomerID] As KetText 
        
  FROM [Orders] where [CustomerID] like ''+@Key_word+'%' 
union all
SELECT  
      [ShipName] As KetText 
        
  FROM [Orders] where [ShipName] like ''+@Key_word+'%' 
union all
SELECT  
      [ShipAddress] As KetText 
        
  FROM [Orders] where [ShipAddress] like ''+@Key_word+'%' 
union all
SELECT  
      [ShipCity] As KetText 
        
  FROM [Orders] where [ShipCity] like ''+@Key_word+'%' 
union all
SELECT  
      [ShipRegion] As KetText 
        
  FROM [Orders] where [ShipRegion] like ''+@Key_word+'%' 
union all
SELECT  
      [ShipPostalCode] As KetText 
        
  FROM [Orders] where [ShipPostalCode] like ''+@Key_word+'%' 
union all
SELECT  
      [ShipCountry] As KetText 
        
  FROM [Orders] where [ShipCountry] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetOrders_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetOrders_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'OrderID') THEN CONVERT(varchar, OrderID )  WHEN (@Column = 'CustomerID') THEN CONVERT(varchar, CustomerID )  WHEN (@Column = 'EmployeeID') THEN CONVERT(varchar, EmployeeID )  WHEN (@Column = 'OrderDate') THEN CONVERT(varchar, OrderDate )  WHEN (@Column = 'RequiredDate') THEN CONVERT(varchar, RequiredDate )  WHEN (@Column = 'ShippedDate') THEN CONVERT(varchar, ShippedDate )  WHEN (@Column = 'ShipVia') THEN CONVERT(varchar, ShipVia )  WHEN (@Column = 'Freight') THEN CONVERT(varchar, Freight )  WHEN (@Column = 'ShipName') THEN CONVERT(varchar, ShipName )  WHEN (@Column = 'ShipAddress') THEN CONVERT(varchar, ShipAddress )  WHEN (@Column = 'ShipCity') THEN CONVERT(varchar, ShipCity )  WHEN (@Column = 'ShipRegion') THEN CONVERT(varchar, ShipRegion )  WHEN (@Column = 'ShipPostalCode') THEN CONVERT(varchar, ShipPostalCode )  WHEN (@Column = 'ShipCountry') THEN CONVERT(varchar, ShipCountry )END As KetText 
        
  FROM [Orders] where CASE  WHEN (@Column = 'OrderID') THEN CONVERT(varchar, OrderID )  WHEN (@Column = 'CustomerID') THEN CONVERT(varchar, CustomerID )  WHEN (@Column = 'EmployeeID') THEN CONVERT(varchar, EmployeeID )  WHEN (@Column = 'OrderDate') THEN CONVERT(varchar, OrderDate )  WHEN (@Column = 'RequiredDate') THEN CONVERT(varchar, RequiredDate )  WHEN (@Column = 'ShippedDate') THEN CONVERT(varchar, ShippedDate )  WHEN (@Column = 'ShipVia') THEN CONVERT(varchar, ShipVia )  WHEN (@Column = 'Freight') THEN CONVERT(varchar, Freight )  WHEN (@Column = 'ShipName') THEN CONVERT(varchar, ShipName )  WHEN (@Column = 'ShipAddress') THEN CONVERT(varchar, ShipAddress )  WHEN (@Column = 'ShipCity') THEN CONVERT(varchar, ShipCity )  WHEN (@Column = 'ShipRegion') THEN CONVERT(varchar, ShipRegion )  WHEN (@Column = 'ShipPostalCode') THEN CONVERT(varchar, ShipPostalCode )  WHEN (@Column = 'ShipCountry') THEN CONVERT(varchar, ShipCountry )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetOrders_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetOrders_UpdateColumn] 
        @OrderID  [int] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'CustomerID'
           BEGIN 
           UPDATE   Orders SET CustomerID=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'EmployeeID'
           BEGIN 
           UPDATE   Orders SET EmployeeID=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'OrderDate'
           BEGIN 
           UPDATE   Orders SET OrderDate=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'RequiredDate'
           BEGIN 
           UPDATE   Orders SET RequiredDate=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShippedDate'
           BEGIN 
           UPDATE   Orders SET ShippedDate=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipVia'
           BEGIN 
           UPDATE   Orders SET ShipVia=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'Freight'
           BEGIN 
           UPDATE   Orders SET Freight=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipName'
           BEGIN 
           UPDATE   Orders SET ShipName=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipAddress'
           BEGIN 
           UPDATE   Orders SET ShipAddress=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipCity'
           BEGIN 
           UPDATE   Orders SET ShipCity=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipRegion'
           BEGIN 
           UPDATE   Orders SET ShipRegion=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipPostalCode'
           BEGIN 
           UPDATE   Orders SET ShipPostalCode=@Data where OrderID = @OrderID;  
         END 
         if  @Column = 'ShipCountry'
           BEGIN 
           UPDATE   Orders SET ShipCountry=@Data where OrderID = @OrderID;  
         END 
       END     

go


