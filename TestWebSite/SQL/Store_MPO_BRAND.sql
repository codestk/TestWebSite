DROP PROCEDURE [dbo].[Sp_GetMPO_BRANDPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_BRANDPageWise]
/* Optional Filters for Dynamic Search*/
@PR_BRAND  [nvarchar](255) =null,
@BRAND_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_BRAND',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_BRAND  [nvarchar](255) =null,
@lBRAND_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_BRAND = LTRIM(RTRIM(@PR_BRAND))
SET @lBRAND_DEC = LTRIM(RTRIM(@BRAND_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_BRANDResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_BRAND' AND @SortOrder='ASC')
                   THEN PR_BRAND
       END ASC,
       CASE WHEN (@lSortCol = 'PR_BRAND' AND @SortOrder='DESC')
                  THEN PR_BRAND
       END DESC,
CASE WHEN (@lSortCol = 'BRAND_DEC' AND @SortOrder='ASC')
                   THEN BRAND_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'BRAND_DEC' AND @SortOrder='DESC')
                  THEN BRAND_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_BRAND,
 BRAND_DEC
 FROM MPO_BRAND
WHERE
(@lPR_BRAND IS NULL OR PR_BRAND LIKE '%' +@lPR_BRAND + '%') AND 
(@lBRAND_DEC IS NULL OR BRAND_DEC LIKE '%' +@lBRAND_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_BRAND,
BRAND_DEC FROM MPO_BRANDResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_BRAND_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_BRAND_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_BRAND] As KetText 
        
  FROM [MPO_BRAND] where [PR_BRAND] like ''+@Key_word+'%' 
union all
SELECT  
      [BRAND_DEC] As KetText 
        
  FROM [MPO_BRAND] where [BRAND_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_BRAND_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_BRAND_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_BRAND') THEN CONVERT(varchar, PR_BRAND )  WHEN (@Column = 'BRAND_DEC') THEN CONVERT(varchar, BRAND_DEC )END As KetText 
        
  FROM [MPO_BRAND] where CASE  WHEN (@Column = 'PR_BRAND') THEN CONVERT(varchar, PR_BRAND )  WHEN (@Column = 'BRAND_DEC') THEN CONVERT(varchar, BRAND_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_BRAND_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_BRAND_UpdateColumn] 
        @PR_BRAND  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'BRAND_DEC'
           BEGIN 
           UPDATE   MPO_BRAND SET BRAND_DEC=@Data where PR_BRAND = @PR_BRAND;  
         END 
       END     

go


