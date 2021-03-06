   DROP PROCEDURE   [dbo].[Sp_GetSourcePageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetSourcePageWise]
/* Optional Filters for Dynamic Search*/
@SourceID  [nvarchar](255) =null,
@SourceName  [nvarchar](255) =null,
@SourceDetail  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'SourceID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lSourceID  [nvarchar](255) =null,
@lSourceName  [nvarchar](255) =null,
@lSourceDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lSourceID = LTRIM(RTRIM(@SourceID))
SET @lSourceName = LTRIM(RTRIM(@SourceName))
SET @lSourceDetail = LTRIM(RTRIM(@SourceDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH SourceResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'SourceID' AND @SortOrder='ASC')
                   THEN SourceID
       END ASC,
       CASE WHEN (@lSortCol = 'SourceID' AND @SortOrder='DESC')
                  THEN SourceID
       END DESC,
CASE WHEN (@lSortCol = 'SourceName' AND @SortOrder='ASC')
                   THEN SourceName
       END ASC,
       CASE WHEN (@lSortCol = 'SourceName' AND @SortOrder='DESC')
                  THEN SourceName
       END DESC,
CASE WHEN (@lSortCol = 'SourceDetail' AND @SortOrder='ASC')
                   THEN SourceDetail
       END ASC,
       CASE WHEN (@lSortCol = 'SourceDetail' AND @SortOrder='DESC')
                  THEN SourceDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 SourceID,
 SourceName,
 SourceDetail
 FROM Source
WHERE
(@lSourceID IS NULL OR SourceID LIKE '%' +@lSourceID + '%') AND 
(@lSourceName IS NULL OR SourceName LIKE '%' +@lSourceName + '%') AND 
(@lSourceDetail IS NULL OR SourceDetail LIKE '%' +@lSourceDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

SourceID,
SourceName,
SourceDetail FROM SourceResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetSource_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetSource_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [SourceID] As KetText 
        
  FROM [Source] where [SourceID] like ''+@Key_word+'%' 
union all
SELECT  
      [SourceName] As KetText 
        
  FROM [Source] where [SourceName] like ''+@Key_word+'%' 
union all
SELECT  
      [SourceDetail] As KetText 
        
  FROM [Source] where [SourceDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetSource_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetSource_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'SourceID') THEN CONVERT(varchar, SourceID )  WHEN (@Column = 'SourceName') THEN CONVERT(varchar, SourceName )  WHEN (@Column = 'SourceDetail') THEN CONVERT(varchar, SourceDetail )END As KetText 
        
  FROM [Source] where CASE  WHEN (@Column = 'SourceID') THEN CONVERT(varchar, SourceID )  WHEN (@Column = 'SourceName') THEN CONVERT(varchar, SourceName )  WHEN (@Column = 'SourceDetail') THEN CONVERT(varchar, SourceDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetSource_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetSource_UpdateColumn] 
        @SourceID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'SourceName'
           BEGIN 
           UPDATE   Source SET SourceName=@Data where SourceID = @SourceID;  
         END 
         if  @Column = 'SourceDetail'
           BEGIN 
           UPDATE   Source SET SourceDetail=@Data where SourceID = @SourceID;  
         END 
       END     

go

