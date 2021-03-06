   DROP PROCEDURE   [dbo].[Sp_GetLineSizePageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetLineSizePageWise]
/* Optional Filters for Dynamic Search*/
@LineSizeID  [nvarchar](255) =null,
@LineSizeName  [nvarchar](255) =null,
@LineSizeDetail  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'LineSizeID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lLineSizeID  [nvarchar](255) =null,
@lLineSizeName  [nvarchar](255) =null,
@lLineSizeDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lLineSizeID = LTRIM(RTRIM(@LineSizeID))
SET @lLineSizeName = LTRIM(RTRIM(@LineSizeName))
SET @lLineSizeDetail = LTRIM(RTRIM(@LineSizeDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH LineSizeResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'LineSizeID' AND @SortOrder='ASC')
                   THEN LineSizeID
       END ASC,
       CASE WHEN (@lSortCol = 'LineSizeID' AND @SortOrder='DESC')
                  THEN LineSizeID
       END DESC,
CASE WHEN (@lSortCol = 'LineSizeName' AND @SortOrder='ASC')
                   THEN LineSizeName
       END ASC,
       CASE WHEN (@lSortCol = 'LineSizeName' AND @SortOrder='DESC')
                  THEN LineSizeName
       END DESC,
CASE WHEN (@lSortCol = 'LineSizeDetail' AND @SortOrder='ASC')
                   THEN LineSizeDetail
       END ASC,
       CASE WHEN (@lSortCol = 'LineSizeDetail' AND @SortOrder='DESC')
                  THEN LineSizeDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 LineSizeID,
 LineSizeName,
 LineSizeDetail
 FROM LineSize
WHERE
(@lLineSizeID IS NULL OR LineSizeID LIKE '%' +@lLineSizeID + '%') AND 
(@lLineSizeName IS NULL OR LineSizeName LIKE '%' +@lLineSizeName + '%') AND 
(@lLineSizeDetail IS NULL OR LineSizeDetail LIKE '%' +@lLineSizeDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

LineSizeID,
LineSizeName,
LineSizeDetail FROM LineSizeResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetLineSize_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetLineSize_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [LineSizeID] As KetText 
        
  FROM [LineSize] where [LineSizeID] like ''+@Key_word+'%' 
union all
SELECT  
      [LineSizeName] As KetText 
        
  FROM [LineSize] where [LineSizeName] like ''+@Key_word+'%' 
union all
SELECT  
      [LineSizeDetail] As KetText 
        
  FROM [LineSize] where [LineSizeDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetLineSize_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetLineSize_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'LineSizeID') THEN CONVERT(varchar, LineSizeID )  WHEN (@Column = 'LineSizeName') THEN CONVERT(varchar, LineSizeName )  WHEN (@Column = 'LineSizeDetail') THEN CONVERT(varchar, LineSizeDetail )END As KetText 
        
  FROM [LineSize] where CASE  WHEN (@Column = 'LineSizeID') THEN CONVERT(varchar, LineSizeID )  WHEN (@Column = 'LineSizeName') THEN CONVERT(varchar, LineSizeName )  WHEN (@Column = 'LineSizeDetail') THEN CONVERT(varchar, LineSizeDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetLineSize_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetLineSize_UpdateColumn] 
        @LineSizeID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'LineSizeName'
           BEGIN 
           UPDATE   LineSize SET LineSizeName=@Data where LineSizeID = @LineSizeID;  
         END 
         if  @Column = 'LineSizeDetail'
           BEGIN 
           UPDATE   LineSize SET LineSizeDetail=@Data where LineSizeID = @LineSizeID;  
         END 
       END     

go

