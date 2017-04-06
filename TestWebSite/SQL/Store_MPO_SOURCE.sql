DROP PROCEDURE [dbo].[Sp_GetMPO_SOURCEPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_SOURCEPageWise]
/* Optional Filters for Dynamic Search*/
@PR_SOURCE  [nvarchar](255) =null,
@PR_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_SOURCE',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_SOURCE  [nvarchar](255) =null,
@lPR_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_SOURCE = LTRIM(RTRIM(@PR_SOURCE))
SET @lPR_DEC = LTRIM(RTRIM(@PR_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_SOURCEResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_SOURCE' AND @SortOrder='ASC')
                   THEN PR_SOURCE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_SOURCE' AND @SortOrder='DESC')
                  THEN PR_SOURCE
       END DESC,
CASE WHEN (@lSortCol = 'PR_DEC' AND @SortOrder='ASC')
                   THEN PR_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'PR_DEC' AND @SortOrder='DESC')
                  THEN PR_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_SOURCE,
 PR_DEC
 FROM MPO_SOURCE
WHERE
(@lPR_SOURCE IS NULL OR PR_SOURCE LIKE '%' +@lPR_SOURCE + '%') AND 
(@lPR_DEC IS NULL OR PR_DEC LIKE '%' +@lPR_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_SOURCE,
PR_DEC FROM MPO_SOURCEResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_SOURCE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_SOURCE_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_SOURCE] As KetText 
        
  FROM [MPO_SOURCE] where [PR_SOURCE] like ''+@Key_word+'%' 
union all
SELECT  
      [PR_DEC] As KetText 
        
  FROM [MPO_SOURCE] where [PR_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_SOURCE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_SOURCE_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_SOURCE') THEN CONVERT(varchar, PR_SOURCE )  WHEN (@Column = 'PR_DEC') THEN CONVERT(varchar, PR_DEC )END As KetText 
        
  FROM [MPO_SOURCE] where CASE  WHEN (@Column = 'PR_SOURCE') THEN CONVERT(varchar, PR_SOURCE )  WHEN (@Column = 'PR_DEC') THEN CONVERT(varchar, PR_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_SOURCE_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_SOURCE_UpdateColumn] 
        @PR_SOURCE  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'PR_DEC'
           BEGIN 
           UPDATE   MPO_SOURCE SET PR_DEC=@Data where PR_SOURCE = @PR_SOURCE;  
         END 
       END     

go


