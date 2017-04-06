DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINEPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINEPageWise]
/* Optional Filters for Dynamic Search*/
@PR_PRODUCT_LINE  [nvarchar](255) =null,
@PRODUCT_LINE_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_PRODUCT_LINE',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_PRODUCT_LINE  [nvarchar](255) =null,
@lPRODUCT_LINE_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_PRODUCT_LINE = LTRIM(RTRIM(@PR_PRODUCT_LINE))
SET @lPRODUCT_LINE_DEC = LTRIM(RTRIM(@PRODUCT_LINE_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_PRODUCT_LINEResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_PRODUCT_LINE' AND @SortOrder='ASC')
                   THEN PR_PRODUCT_LINE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_PRODUCT_LINE' AND @SortOrder='DESC')
                  THEN PR_PRODUCT_LINE
       END DESC,
CASE WHEN (@lSortCol = 'PRODUCT_LINE_DEC' AND @SortOrder='ASC')
                   THEN PRODUCT_LINE_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'PRODUCT_LINE_DEC' AND @SortOrder='DESC')
                  THEN PRODUCT_LINE_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_PRODUCT_LINE,
 PRODUCT_LINE_DEC
 FROM MPO_PRODUCT_LINE
WHERE
(@lPR_PRODUCT_LINE IS NULL OR PR_PRODUCT_LINE LIKE '%' +@lPR_PRODUCT_LINE + '%') AND 
(@lPRODUCT_LINE_DEC IS NULL OR PRODUCT_LINE_DEC LIKE '%' +@lPRODUCT_LINE_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_PRODUCT_LINE,
PRODUCT_LINE_DEC FROM MPO_PRODUCT_LINEResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINE_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_PRODUCT_LINE] As KetText 
        
  FROM [MPO_PRODUCT_LINE] where [PR_PRODUCT_LINE] like ''+@Key_word+'%' 
union all
SELECT  
      [PRODUCT_LINE_DEC] As KetText 
        
  FROM [MPO_PRODUCT_LINE] where [PRODUCT_LINE_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINE_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_PRODUCT_LINE') THEN CONVERT(varchar, PR_PRODUCT_LINE )  WHEN (@Column = 'PRODUCT_LINE_DEC') THEN CONVERT(varchar, PRODUCT_LINE_DEC )END As KetText 
        
  FROM [MPO_PRODUCT_LINE] where CASE  WHEN (@Column = 'PR_PRODUCT_LINE') THEN CONVERT(varchar, PR_PRODUCT_LINE )  WHEN (@Column = 'PRODUCT_LINE_DEC') THEN CONVERT(varchar, PRODUCT_LINE_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINE_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_PRODUCT_LINE_UpdateColumn] 
        @PR_PRODUCT_LINE  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'PRODUCT_LINE_DEC'
           BEGIN 
           UPDATE   MPO_PRODUCT_LINE SET PRODUCT_LINE_DEC=@Data where PR_PRODUCT_LINE = @PR_PRODUCT_LINE;  
         END 
       END     

go


