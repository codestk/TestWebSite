DROP PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TESTPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TESTPageWise]
/* Optional Filters for Dynamic Search*/
@PR_FORMULA_AND_TEST  [nvarchar](255) =null,
@FORMULA_AND_TEST_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_FORMULA_AND_TEST',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_FORMULA_AND_TEST  [nvarchar](255) =null,
@lFORMULA_AND_TEST_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_FORMULA_AND_TEST = LTRIM(RTRIM(@PR_FORMULA_AND_TEST))
SET @lFORMULA_AND_TEST_DEC = LTRIM(RTRIM(@FORMULA_AND_TEST_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_FORMULA_AND_TESTResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_FORMULA_AND_TEST' AND @SortOrder='ASC')
                   THEN PR_FORMULA_AND_TEST
       END ASC,
       CASE WHEN (@lSortCol = 'PR_FORMULA_AND_TEST' AND @SortOrder='DESC')
                  THEN PR_FORMULA_AND_TEST
       END DESC,
CASE WHEN (@lSortCol = 'FORMULA_AND_TEST_DEC' AND @SortOrder='ASC')
                   THEN FORMULA_AND_TEST_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'FORMULA_AND_TEST_DEC' AND @SortOrder='DESC')
                  THEN FORMULA_AND_TEST_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_FORMULA_AND_TEST,
 FORMULA_AND_TEST_DEC
 FROM MPO_FORMULA_AND_TEST
WHERE
(@lPR_FORMULA_AND_TEST IS NULL OR PR_FORMULA_AND_TEST LIKE '%' +@lPR_FORMULA_AND_TEST + '%') AND 
(@lFORMULA_AND_TEST_DEC IS NULL OR FORMULA_AND_TEST_DEC LIKE '%' +@lFORMULA_AND_TEST_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_FORMULA_AND_TEST,
FORMULA_AND_TEST_DEC FROM MPO_FORMULA_AND_TESTResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TEST_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TEST_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_FORMULA_AND_TEST] As KetText 
        
  FROM [MPO_FORMULA_AND_TEST] where [PR_FORMULA_AND_TEST] like ''+@Key_word+'%' 
union all
SELECT  
      [FORMULA_AND_TEST_DEC] As KetText 
        
  FROM [MPO_FORMULA_AND_TEST] where [FORMULA_AND_TEST_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TEST_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TEST_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_FORMULA_AND_TEST') THEN CONVERT(varchar, PR_FORMULA_AND_TEST )  WHEN (@Column = 'FORMULA_AND_TEST_DEC') THEN CONVERT(varchar, FORMULA_AND_TEST_DEC )END As KetText 
        
  FROM [MPO_FORMULA_AND_TEST] where CASE  WHEN (@Column = 'PR_FORMULA_AND_TEST') THEN CONVERT(varchar, PR_FORMULA_AND_TEST )  WHEN (@Column = 'FORMULA_AND_TEST_DEC') THEN CONVERT(varchar, FORMULA_AND_TEST_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TEST_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_FORMULA_AND_TEST_UpdateColumn] 
        @PR_FORMULA_AND_TEST  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'FORMULA_AND_TEST_DEC'
           BEGIN 
           UPDATE   MPO_FORMULA_AND_TEST SET FORMULA_AND_TEST_DEC=@Data where PR_FORMULA_AND_TEST = @PR_FORMULA_AND_TEST;  
         END 
       END     

go


