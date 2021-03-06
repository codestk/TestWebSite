   DROP PROCEDURE   [dbo].[Sp_GetProductLinePageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetProductLinePageWise]
/* Optional Filters for Dynamic Search*/
@ProductLineId  [float] =null,
@SourceID  [nvarchar](255) =null,
@LineID  [nvarchar](255) =null,
@TestFormulaID  [nvarchar](255) =null,
@ContainID  [nvarchar](255) =null,
@LineSizeID  [nvarchar](255) =null,
@CustomerBrandID  [nvarchar](255) =null,
@ManufacturingDate  [datetime] =null,
@ExpectItems  [int] =null,
@ProcessItems  [int] =null,
@CreateDate  [datetime] =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'ProductLineId',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lProductLineId  [float] =null,
@lSourceID  [nvarchar](255) =null,
@lLineID  [nvarchar](255) =null,
@lTestFormulaID  [nvarchar](255) =null,
@lContainID  [nvarchar](255) =null,
@lLineSizeID  [nvarchar](255) =null,
@lCustomerBrandID  [nvarchar](255) =null,
@lManufacturingDate  [datetime] =null,
@lExpectItems  [int] =null,
@lProcessItems  [int] =null,
@lCreateDate  [datetime] =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lProductLineId = LTRIM(RTRIM(@ProductLineId))
SET @lSourceID = LTRIM(RTRIM(@SourceID))
SET @lLineID = LTRIM(RTRIM(@LineID))
SET @lTestFormulaID = LTRIM(RTRIM(@TestFormulaID))
SET @lContainID = LTRIM(RTRIM(@ContainID))
SET @lLineSizeID = LTRIM(RTRIM(@LineSizeID))
SET @lCustomerBrandID = LTRIM(RTRIM(@CustomerBrandID))
SET @lManufacturingDate = LTRIM(RTRIM(@ManufacturingDate))
SET @lExpectItems =@ExpectItems
SET @lProcessItems =@ProcessItems
SET @lCreateDate = LTRIM(RTRIM(@CreateDate))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH ProductLineResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'ProductLineId' AND @SortOrder='ASC')
                   THEN ProductLineId
       END ASC,
       CASE WHEN (@lSortCol = 'ProductLineId' AND @SortOrder='DESC')
                  THEN ProductLineId
       END DESC,
CASE WHEN (@lSortCol = 'SourceID' AND @SortOrder='ASC')
                   THEN SourceID
       END ASC,
       CASE WHEN (@lSortCol = 'SourceID' AND @SortOrder='DESC')
                  THEN SourceID
       END DESC,
CASE WHEN (@lSortCol = 'LineID' AND @SortOrder='ASC')
                   THEN LineID
       END ASC,
       CASE WHEN (@lSortCol = 'LineID' AND @SortOrder='DESC')
                  THEN LineID
       END DESC,
CASE WHEN (@lSortCol = 'TestFormulaID' AND @SortOrder='ASC')
                   THEN TestFormulaID
       END ASC,
       CASE WHEN (@lSortCol = 'TestFormulaID' AND @SortOrder='DESC')
                  THEN TestFormulaID
       END DESC,
CASE WHEN (@lSortCol = 'ContainID' AND @SortOrder='ASC')
                   THEN ContainID
       END ASC,
       CASE WHEN (@lSortCol = 'ContainID' AND @SortOrder='DESC')
                  THEN ContainID
       END DESC,
CASE WHEN (@lSortCol = 'LineSizeID' AND @SortOrder='ASC')
                   THEN LineSizeID
       END ASC,
       CASE WHEN (@lSortCol = 'LineSizeID' AND @SortOrder='DESC')
                  THEN LineSizeID
       END DESC,
CASE WHEN (@lSortCol = 'CustomerBrandID' AND @SortOrder='ASC')
                   THEN CustomerBrandID
       END ASC,
       CASE WHEN (@lSortCol = 'CustomerBrandID' AND @SortOrder='DESC')
                  THEN CustomerBrandID
       END DESC,
CASE WHEN (@lSortCol = 'ManufacturingDate' AND @SortOrder='ASC')
                   THEN ManufacturingDate
       END ASC,
       CASE WHEN (@lSortCol = 'ManufacturingDate' AND @SortOrder='DESC')
                  THEN ManufacturingDate
       END DESC,
CASE WHEN (@lSortCol = 'ExpectItems' AND @SortOrder='ASC')
                   THEN ExpectItems
       END ASC,
       CASE WHEN (@lSortCol = 'ExpectItems' AND @SortOrder='DESC')
                  THEN ExpectItems
       END DESC,
CASE WHEN (@lSortCol = 'ProcessItems' AND @SortOrder='ASC')
                   THEN ProcessItems
       END ASC,
       CASE WHEN (@lSortCol = 'ProcessItems' AND @SortOrder='DESC')
                  THEN ProcessItems
       END DESC,
CASE WHEN (@lSortCol = 'CreateDate' AND @SortOrder='ASC')
                   THEN CreateDate
       END ASC,
       CASE WHEN (@lSortCol = 'CreateDate' AND @SortOrder='DESC')
                  THEN CreateDate
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 ProductLineId,
 SourceID,
 LineID,
 TestFormulaID,
 ContainID,
 LineSizeID,
 CustomerBrandID,
 ManufacturingDate,
 ExpectItems,
 ProcessItems,
 CreateDate
 FROM ProductLine
WHERE
(@lProductLineId IS NULL OR ProductLineId = @lProductLineId) AND
(@lSourceID IS NULL OR SourceID LIKE '%' +@lSourceID + '%') AND 
(@lLineID IS NULL OR LineID LIKE '%' +@lLineID + '%') AND 
(@lTestFormulaID IS NULL OR TestFormulaID LIKE '%' +@lTestFormulaID + '%') AND 
(@lContainID IS NULL OR ContainID LIKE '%' +@lContainID + '%') AND 
(@lLineSizeID IS NULL OR LineSizeID LIKE '%' +@lLineSizeID + '%') AND 
(@lCustomerBrandID IS NULL OR CustomerBrandID LIKE '%' +@lCustomerBrandID + '%') AND 
(@lManufacturingDate IS NULL OR ManufacturingDate = @lManufacturingDate) AND
(@lExpectItems IS NULL OR ExpectItems = @lExpectItems) AND
(@lProcessItems IS NULL OR ProcessItems = @lProcessItems) AND
(@lCreateDate IS NULL OR CreateDate = @lCreateDate)
)
SELECT   RecordCount,
 ROWNUM,

ProductLineId,
SourceID,
LineID,
TestFormulaID,
ContainID,
LineSizeID,
CustomerBrandID,
ManufacturingDate,
ExpectItems,
ProcessItems,
CreateDate FROM ProductLineResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetProductLine_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetProductLine_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [SourceID] As KetText 
        
  FROM [ProductLine] where [SourceID] like ''+@Key_word+'%' 
union all
SELECT  
      [LineID] As KetText 
        
  FROM [ProductLine] where [LineID] like ''+@Key_word+'%' 
union all
SELECT  
      [TestFormulaID] As KetText 
        
  FROM [ProductLine] where [TestFormulaID] like ''+@Key_word+'%' 
union all
SELECT  
      [ContainID] As KetText 
        
  FROM [ProductLine] where [ContainID] like ''+@Key_word+'%' 
union all
SELECT  
      [LineSizeID] As KetText 
        
  FROM [ProductLine] where [LineSizeID] like ''+@Key_word+'%' 
union all
SELECT  
      [CustomerBrandID] As KetText 
        
  FROM [ProductLine] where [CustomerBrandID] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetProductLine_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetProductLine_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'ProductLineId') THEN CONVERT(varchar, ProductLineId )  WHEN (@Column = 'SourceID') THEN CONVERT(varchar, SourceID )  WHEN (@Column = 'LineID') THEN CONVERT(varchar, LineID )  WHEN (@Column = 'TestFormulaID') THEN CONVERT(varchar, TestFormulaID )  WHEN (@Column = 'ContainID') THEN CONVERT(varchar, ContainID )  WHEN (@Column = 'LineSizeID') THEN CONVERT(varchar, LineSizeID )  WHEN (@Column = 'CustomerBrandID') THEN CONVERT(varchar, CustomerBrandID )  WHEN (@Column = 'ManufacturingDate') THEN CONVERT(varchar, ManufacturingDate )  WHEN (@Column = 'ExpectItems') THEN CONVERT(varchar, ExpectItems )  WHEN (@Column = 'ProcessItems') THEN CONVERT(varchar, ProcessItems )  WHEN (@Column = 'CreateDate') THEN CONVERT(varchar, CreateDate )END As KetText 
        
  FROM [ProductLine] where CASE  WHEN (@Column = 'ProductLineId') THEN CONVERT(varchar, ProductLineId )  WHEN (@Column = 'SourceID') THEN CONVERT(varchar, SourceID )  WHEN (@Column = 'LineID') THEN CONVERT(varchar, LineID )  WHEN (@Column = 'TestFormulaID') THEN CONVERT(varchar, TestFormulaID )  WHEN (@Column = 'ContainID') THEN CONVERT(varchar, ContainID )  WHEN (@Column = 'LineSizeID') THEN CONVERT(varchar, LineSizeID )  WHEN (@Column = 'CustomerBrandID') THEN CONVERT(varchar, CustomerBrandID )  WHEN (@Column = 'ManufacturingDate') THEN CONVERT(varchar, ManufacturingDate )  WHEN (@Column = 'ExpectItems') THEN CONVERT(varchar, ExpectItems )  WHEN (@Column = 'ProcessItems') THEN CONVERT(varchar, ProcessItems )  WHEN (@Column = 'CreateDate') THEN CONVERT(varchar, CreateDate )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetProductLine_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetProductLine_UpdateColumn] 
        @ProductLineId  [float] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'SourceID'
           BEGIN 
           UPDATE   ProductLine SET SourceID=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'LineID'
           BEGIN 
           UPDATE   ProductLine SET LineID=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'TestFormulaID'
           BEGIN 
           UPDATE   ProductLine SET TestFormulaID=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'ContainID'
           BEGIN 
           UPDATE   ProductLine SET ContainID=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'LineSizeID'
           BEGIN 
           UPDATE   ProductLine SET LineSizeID=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'CustomerBrandID'
           BEGIN 
           UPDATE   ProductLine SET CustomerBrandID=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'ManufacturingDate'
           BEGIN 
           UPDATE   ProductLine SET ManufacturingDate=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'ExpectItems'
           BEGIN 
           UPDATE   ProductLine SET ExpectItems=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'ProcessItems'
           BEGIN 
           UPDATE   ProductLine SET ProcessItems=@Data where ProductLineId = @ProductLineId;  
         END 
         if  @Column = 'CreateDate'
           BEGIN 
           UPDATE   ProductLine SET CreateDate=@Data where ProductLineId = @ProductLineId;  
         END 
       END     

go

