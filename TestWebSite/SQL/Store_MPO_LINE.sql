DROP PROCEDURE [dbo].[Sp_GetMPO_LINEPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_LINEPageWise]
/* Optional Filters for Dynamic Search*/
@PR_LINE  [nvarchar](255) =null,
@LINE_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_LINE',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_LINE  [nvarchar](255) =null,
@lLINE_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_LINE = LTRIM(RTRIM(@PR_LINE))
SET @lLINE_DEC = LTRIM(RTRIM(@LINE_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_LINEResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_LINE' AND @SortOrder='ASC')
                   THEN PR_LINE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_LINE' AND @SortOrder='DESC')
                  THEN PR_LINE
       END DESC,
CASE WHEN (@lSortCol = 'LINE_DEC' AND @SortOrder='ASC')
                   THEN LINE_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'LINE_DEC' AND @SortOrder='DESC')
                  THEN LINE_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_LINE,
 LINE_DEC
 FROM MPO_LINE
WHERE
(@lPR_LINE IS NULL OR PR_LINE LIKE '%' +@lPR_LINE + '%') AND 
(@lLINE_DEC IS NULL OR LINE_DEC LIKE '%' +@lLINE_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_LINE,
LINE_DEC FROM MPO_LINEResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_LINE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_LINE_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_LINE] As KetText 
        
  FROM [MPO_LINE] where [PR_LINE] like ''+@Key_word+'%' 
union all
SELECT  
      [LINE_DEC] As KetText 
        
  FROM [MPO_LINE] where [LINE_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_LINE_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_LINE_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_LINE') THEN CONVERT(varchar, PR_LINE )  WHEN (@Column = 'LINE_DEC') THEN CONVERT(varchar, LINE_DEC )END As KetText 
        
  FROM [MPO_LINE] where CASE  WHEN (@Column = 'PR_LINE') THEN CONVERT(varchar, PR_LINE )  WHEN (@Column = 'LINE_DEC') THEN CONVERT(varchar, LINE_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_LINE_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_LINE_UpdateColumn] 
        @PR_LINE  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'LINE_DEC'
           BEGIN 
           UPDATE   MPO_LINE SET LINE_DEC=@Data where PR_LINE = @PR_LINE;  
         END 
       END     

go


