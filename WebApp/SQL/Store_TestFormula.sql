   DROP PROCEDURE   [dbo].[Sp_GetTestFormulaPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetTestFormulaPageWise]
/* Optional Filters for Dynamic Search*/
@TestFormulaID  [nvarchar](255) =null,
@TestFormulaName  [nvarchar](255) =null,
@TestFormulaDetail  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'TestFormulaID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lTestFormulaID  [nvarchar](255) =null,
@lTestFormulaName  [nvarchar](255) =null,
@lTestFormulaDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lTestFormulaID = LTRIM(RTRIM(@TestFormulaID))
SET @lTestFormulaName = LTRIM(RTRIM(@TestFormulaName))
SET @lTestFormulaDetail = LTRIM(RTRIM(@TestFormulaDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH TestFormulaResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'TestFormulaID' AND @SortOrder='ASC')
                   THEN TestFormulaID
       END ASC,
       CASE WHEN (@lSortCol = 'TestFormulaID' AND @SortOrder='DESC')
                  THEN TestFormulaID
       END DESC,
CASE WHEN (@lSortCol = 'TestFormulaName' AND @SortOrder='ASC')
                   THEN TestFormulaName
       END ASC,
       CASE WHEN (@lSortCol = 'TestFormulaName' AND @SortOrder='DESC')
                  THEN TestFormulaName
       END DESC,
CASE WHEN (@lSortCol = 'TestFormulaDetail' AND @SortOrder='ASC')
                   THEN TestFormulaDetail
       END ASC,
       CASE WHEN (@lSortCol = 'TestFormulaDetail' AND @SortOrder='DESC')
                  THEN TestFormulaDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 TestFormulaID,
 TestFormulaName,
 TestFormulaDetail
 FROM TestFormula
WHERE
(@lTestFormulaID IS NULL OR TestFormulaID LIKE '%' +@lTestFormulaID + '%') AND 
(@lTestFormulaName IS NULL OR TestFormulaName LIKE '%' +@lTestFormulaName + '%') AND 
(@lTestFormulaDetail IS NULL OR TestFormulaDetail LIKE '%' +@lTestFormulaDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

TestFormulaID,
TestFormulaName,
TestFormulaDetail FROM TestFormulaResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetTestFormula_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetTestFormula_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [TestFormulaID] As KetText 
        
  FROM [TestFormula] where [TestFormulaID] like ''+@Key_word+'%' 
union all
SELECT  
      [TestFormulaName] As KetText 
        
  FROM [TestFormula] where [TestFormulaName] like ''+@Key_word+'%' 
union all
SELECT  
      [TestFormulaDetail] As KetText 
        
  FROM [TestFormula] where [TestFormulaDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetTestFormula_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetTestFormula_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'TestFormulaID') THEN CONVERT(varchar, TestFormulaID )  WHEN (@Column = 'TestFormulaName') THEN CONVERT(varchar, TestFormulaName )  WHEN (@Column = 'TestFormulaDetail') THEN CONVERT(varchar, TestFormulaDetail )END As KetText 
        
  FROM [TestFormula] where CASE  WHEN (@Column = 'TestFormulaID') THEN CONVERT(varchar, TestFormulaID )  WHEN (@Column = 'TestFormulaName') THEN CONVERT(varchar, TestFormulaName )  WHEN (@Column = 'TestFormulaDetail') THEN CONVERT(varchar, TestFormulaDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetTestFormula_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetTestFormula_UpdateColumn] 
        @TestFormulaID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'TestFormulaName'
           BEGIN 
           UPDATE   TestFormula SET TestFormulaName=@Data where TestFormulaID = @TestFormulaID;  
         END 
         if  @Column = 'TestFormulaDetail'
           BEGIN 
           UPDATE   TestFormula SET TestFormulaDetail=@Data where TestFormulaID = @TestFormulaID;  
         END 
       END     

go

