DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2PageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2PageWise]
/* Optional Filters for Dynamic Search*/
@PR_LOT  [int] =null,
@PR_SOURCE  [nvarchar](255) =null,
@PR_PRODUCT_LINE  [nvarchar](255) =null,
@PR_FORMULA_AND_TEST  [nvarchar](255) =null,
@PR_SIZE  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_LOT',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_LOT  [int] =null,
@lPR_SOURCE  [nvarchar](255) =null,
@lPR_PRODUCT_LINE  [nvarchar](255) =null,
@lPR_FORMULA_AND_TEST  [nvarchar](255) =null,
@lPR_SIZE  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_LOT =@PR_LOT
SET @lPR_SOURCE = LTRIM(RTRIM(@PR_SOURCE))
SET @lPR_PRODUCT_LINE = LTRIM(RTRIM(@PR_PRODUCT_LINE))
SET @lPR_FORMULA_AND_TEST = LTRIM(RTRIM(@PR_FORMULA_AND_TEST))
SET @lPR_SIZE = LTRIM(RTRIM(@PR_SIZE))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_PRODUCT_P2Result
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_LOT' AND @SortOrder='ASC')
                   THEN PR_LOT
       END ASC,
       CASE WHEN (@lSortCol = 'PR_LOT' AND @SortOrder='DESC')
                  THEN PR_LOT
       END DESC,
CASE WHEN (@lSortCol = 'PR_SOURCE' AND @SortOrder='ASC')
                   THEN PR_SOURCE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_SOURCE' AND @SortOrder='DESC')
                  THEN PR_SOURCE
       END DESC,
CASE WHEN (@lSortCol = 'PR_PRODUCT_LINE' AND @SortOrder='ASC')
                   THEN PR_PRODUCT_LINE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_PRODUCT_LINE' AND @SortOrder='DESC')
                  THEN PR_PRODUCT_LINE
       END DESC,
CASE WHEN (@lSortCol = 'PR_FORMULA_AND_TEST' AND @SortOrder='ASC')
                   THEN PR_FORMULA_AND_TEST
       END ASC,
       CASE WHEN (@lSortCol = 'PR_FORMULA_AND_TEST' AND @SortOrder='DESC')
                  THEN PR_FORMULA_AND_TEST
       END DESC,
CASE WHEN (@lSortCol = 'PR_SIZE' AND @SortOrder='ASC')
                   THEN PR_SIZE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_SIZE' AND @SortOrder='DESC')
                  THEN PR_SIZE
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_LOT,
 PR_SOURCE,
 PR_PRODUCT_LINE,
 PR_FORMULA_AND_TEST,
 PR_SIZE
 FROM MPO_PRODUCT_P2
WHERE
(@lPR_LOT IS NULL OR PR_LOT = @lPR_LOT) AND
(@lPR_SOURCE IS NULL OR PR_SOURCE LIKE '%' +@lPR_SOURCE + '%') AND 
(@lPR_PRODUCT_LINE IS NULL OR PR_PRODUCT_LINE LIKE '%' +@lPR_PRODUCT_LINE + '%') AND 
(@lPR_FORMULA_AND_TEST IS NULL OR PR_FORMULA_AND_TEST LIKE '%' +@lPR_FORMULA_AND_TEST + '%') AND 
(@lPR_SIZE IS NULL OR PR_SIZE LIKE '%' +@lPR_SIZE + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_LOT,
PR_SOURCE,
PR_PRODUCT_LINE,
PR_FORMULA_AND_TEST,
PR_SIZE FROM MPO_PRODUCT_P2Result
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_SOURCE] As KetText 
        
  FROM [MPO_PRODUCT_P2] where [PR_SOURCE] like ''+@Key_word+'%' 
union all
SELECT  
      [PR_PRODUCT_LINE] As KetText 
        
  FROM [MPO_PRODUCT_P2] where [PR_PRODUCT_LINE] like ''+@Key_word+'%' 
union all
SELECT  
      [PR_FORMULA_AND_TEST] As KetText 
        
  FROM [MPO_PRODUCT_P2] where [PR_FORMULA_AND_TEST] like ''+@Key_word+'%' 
union all
SELECT  
      [PR_SIZE] As KetText 
        
  FROM [MPO_PRODUCT_P2] where [PR_SIZE] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_LOT') THEN CONVERT(varchar, PR_LOT )  WHEN (@Column = 'PR_SOURCE') THEN CONVERT(varchar, PR_SOURCE )  WHEN (@Column = 'PR_PRODUCT_LINE') THEN CONVERT(varchar, PR_PRODUCT_LINE )  WHEN (@Column = 'PR_FORMULA_AND_TEST') THEN CONVERT(varchar, PR_FORMULA_AND_TEST )  WHEN (@Column = 'PR_SIZE') THEN CONVERT(varchar, PR_SIZE )END As KetText 
        
  FROM [MPO_PRODUCT_P2] where CASE  WHEN (@Column = 'PR_LOT') THEN CONVERT(varchar, PR_LOT )  WHEN (@Column = 'PR_SOURCE') THEN CONVERT(varchar, PR_SOURCE )  WHEN (@Column = 'PR_PRODUCT_LINE') THEN CONVERT(varchar, PR_PRODUCT_LINE )  WHEN (@Column = 'PR_FORMULA_AND_TEST') THEN CONVERT(varchar, PR_FORMULA_AND_TEST )  WHEN (@Column = 'PR_SIZE') THEN CONVERT(varchar, PR_SIZE )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_P2_UpdateColumn] 
        @PR_LOT  [int] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'PR_SOURCE'
           BEGIN 
           UPDATE   MPO_PRODUCT_P2 SET PR_SOURCE=@Data where PR_LOT = @PR_LOT;  
         END 
         if  @Column = 'PR_PRODUCT_LINE'
           BEGIN 
           UPDATE   MPO_PRODUCT_P2 SET PR_PRODUCT_LINE=@Data where PR_LOT = @PR_LOT;  
         END 
         if  @Column = 'PR_FORMULA_AND_TEST'
           BEGIN 
           UPDATE   MPO_PRODUCT_P2 SET PR_FORMULA_AND_TEST=@Data where PR_LOT = @PR_LOT;  
         END 
         if  @Column = 'PR_SIZE'
           BEGIN 
           UPDATE   MPO_PRODUCT_P2 SET PR_SIZE=@Data where PR_LOT = @PR_LOT;  
         END 
       END     

go


