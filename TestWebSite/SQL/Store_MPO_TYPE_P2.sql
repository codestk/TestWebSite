DROP PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2PageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2PageWise]
/* Optional Filters for Dynamic Search*/
@PR_TYPE  [nvarchar](255) =null,
@TYPE_DEC  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'PR_TYPE',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lPR_TYPE  [nvarchar](255) =null,
@lTYPE_DEC  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lPR_TYPE = LTRIM(RTRIM(@PR_TYPE))
SET @lTYPE_DEC = LTRIM(RTRIM(@TYPE_DEC))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH MPO_TYPE_P2Result
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'PR_TYPE' AND @SortOrder='ASC')
                   THEN PR_TYPE
       END ASC,
       CASE WHEN (@lSortCol = 'PR_TYPE' AND @SortOrder='DESC')
                  THEN PR_TYPE
       END DESC,
CASE WHEN (@lSortCol = 'TYPE_DEC' AND @SortOrder='ASC')
                   THEN TYPE_DEC
       END ASC,
       CASE WHEN (@lSortCol = 'TYPE_DEC' AND @SortOrder='DESC')
                  THEN TYPE_DEC
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 PR_TYPE,
 TYPE_DEC
 FROM MPO_TYPE_P2
WHERE
(@lPR_TYPE IS NULL OR PR_TYPE LIKE '%' +@lPR_TYPE + '%') AND 
(@lTYPE_DEC IS NULL OR TYPE_DEC LIKE '%' +@lTYPE_DEC + '%') 
)
SELECT   RecordCount,
 ROWNUM,

PR_TYPE,
TYPE_DEC FROM MPO_TYPE_P2Result
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [PR_TYPE] As KetText 
        
  FROM [MPO_TYPE_P2] where [PR_TYPE] like ''+@Key_word+'%' 
union all
SELECT  
      [TYPE_DEC] As KetText 
        
  FROM [MPO_TYPE_P2] where [TYPE_DEC] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'PR_TYPE') THEN CONVERT(varchar, PR_TYPE )  WHEN (@Column = 'TYPE_DEC') THEN CONVERT(varchar, TYPE_DEC )END As KetText 
        
  FROM [MPO_TYPE_P2] where CASE  WHEN (@Column = 'PR_TYPE') THEN CONVERT(varchar, PR_TYPE )  WHEN (@Column = 'TYPE_DEC') THEN CONVERT(varchar, TYPE_DEC )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetMPO_TYPE_P2_UpdateColumn] 
        @PR_TYPE  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'TYPE_DEC'
           BEGIN 
           UPDATE   MPO_TYPE_P2 SET TYPE_DEC=@Data where PR_TYPE = @PR_TYPE;  
         END 
       END     

go


