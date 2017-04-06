DROP PROCEDURE [dbo].[Sp_GetMPO_SIZEPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_SIZEPageWise]
/* Optional Filters for Dynamic Search*/
@PR_SIZE  [nvarchar](255) =null,
@SIZE_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_SIZE',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_SIZE  [nvarchar](255) =null,
@lSIZE_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_SIZE = LTRIM(RTRIM(@PR_SIZE))
SET @lSIZE_DEC = LTRIM(RTRIM(@SIZE_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_SIZEResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_SIZE' AND @SortOrder='ASC')
                   THEN PR_SIZE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_SIZE' AND @SortOrder='DESC')
                  THEN PR_SIZE
       END DESC,
CASE WHEN (@lSortCol = 'SIZE_DEC' AND @SortOrder='ASC')
                   THEN SIZE_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'SIZE_DEC' AND @SortOrder='DESC')
                  THEN SIZE_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_SIZE,
 SIZE_DEC
 FROM MPO_SIZE
WHERE
(@lPR_SIZE IS NULL OR PR_SIZE LIKE '%' +@lPR_SIZE + '%') AND 
(@lSIZE_DEC IS NULL OR SIZE_DEC LIKE '%' +@lSIZE_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_SIZE,
SIZE_DEC FROM MPO_SIZEResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_SIZE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_SIZE_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_SIZE] As KetText 
        
  FROM [MPO_SIZE] where [PR_SIZE] like ''+@Key_word+'%' 
union all
SELECT  
      [SIZE_DEC] As KetText 
        
  FROM [MPO_SIZE] where [SIZE_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_SIZE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_SIZE_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_SIZE') THEN CONVERT(varchar, PR_SIZE )  WHEN (@Column = 'SIZE_DEC') THEN CONVERT(varchar, SIZE_DEC )END As KetText 
        
  FROM [MPO_SIZE] where CASE  WHEN (@Column = 'PR_SIZE') THEN CONVERT(varchar, PR_SIZE )  WHEN (@Column = 'SIZE_DEC') THEN CONVERT(varchar, SIZE_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_SIZE_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_SIZE_UpdateColumn] 
        @PR_SIZE  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'SIZE_DEC'
           BEGIN 
           UPDATE   MPO_SIZE SET SIZE_DEC=@Data where PR_SIZE = @PR_SIZE;  
         END 
       END     

go


