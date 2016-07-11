DROP PROCEDURE [dbo].[Sp_GetTradeFromFilePageWise]; 
go 
CREATE PROCEDURE [dbo].[Sp_GetTradeFromFilePageWise] 
/* Optional Filters for Dynamic Search*/ 
@FileId  [float] =null, 
@FileName  [nvarchar](255) =null, 
@FileDescription  [nvarchar](255) =null, 
@CategoryID  [float] =null, 
@TermId  [float] =null, 
/*– Pagination Parameters */ 
@PageIndex INT = 1 , 
@PageSize INT = 10 , 
/*– Sorting Parameters */ 
@SortColumn NVARCHAR(20) = 'FileId', 
@SortOrder NVARCHAR(4) ='ASC' 
AS   
BEGIN   
 SET NOCOUNT ON;   
  
   
  
  
/*–Declaring Local Variables corresponding to parameters for modification */ 
DECLARE @lFileId  [float] =null, 
@lFileName  [nvarchar](255) =null, 
@lFileDescription  [nvarchar](255) =null, 
@lCategoryID  [float] =null, 
@lTermId  [float] =null, 
@lPageNbr INT, 
@lPageSize INT, 
@lSortCol NVARCHAR(20), 
@lFirstRec INT, 
@lLastRec INT, 
@lTotalRows INT 
/*Setting Local Variables*/ 
SET @lFileId = LTRIM(RTRIM(@FileId)) 
SET @lFileName = LTRIM(RTRIM(@FileName)) 
SET @lFileDescription = LTRIM(RTRIM(@FileDescription)) 
SET @lCategoryID = LTRIM(RTRIM(@CategoryID)) 
SET @lTermId = LTRIM(RTRIM(@TermId)) 
SET @lPageNbr = @PageIndex 
    SET @lPageSize = @PageSize 
    SET @lSortCol = LTRIM(RTRIM(@SortColumn)) 
  
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize 
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 ) 
    SET @lTotalRows = @lFirstRec - @lLastRec + 1 
; WITH TradeFromFileResult 
AS( 
SELECT ROW_NUMBER() OVER(ORDER BY  
 
CASE WHEN (@lSortCol = 'FileId' AND @SortOrder='ASC') 
                   THEN FileId 
       END ASC, 
       CASE WHEN (@lSortCol = 'FileId' AND @SortOrder='DESC') 
                  THEN FileId 
       END DESC, 
CASE WHEN (@lSortCol = 'FileName' AND @SortOrder='ASC') 
                   THEN FileName 
       END ASC, 
       CASE WHEN (@lSortCol = 'FileName' AND @SortOrder='DESC') 
                  THEN FileName 
       END DESC, 
CASE WHEN (@lSortCol = 'FileDescription' AND @SortOrder='ASC') 
                   THEN FileDescription 
       END ASC, 
       CASE WHEN (@lSortCol = 'FileDescription' AND @SortOrder='DESC') 
                  THEN FileDescription 
       END DESC, 
CASE WHEN (@lSortCol = 'CategoryID' AND @SortOrder='ASC') 
                   THEN CategoryID 
       END ASC, 
       CASE WHEN (@lSortCol = 'CategoryID' AND @SortOrder='DESC') 
                  THEN CategoryID 
       END DESC, 
CASE WHEN (@lSortCol = 'TermId' AND @SortOrder='ASC') 
                   THEN TermId 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermId' AND @SortOrder='DESC') 
                  THEN TermId 
       END DESC  ) AS ROWNUM, 
Count(*) over() AS RecordCount, 
 
 FileId, 
 FileName, 
 FileDescription, 
 CategoryID, 
 TermId 
 FROM TradeFromFile 
WHERE 
(@lFileId IS NULL OR FileId = @lFileId) AND 
(@lFileName IS NULL OR FileName LIKE '%' +@lFileName + '%') AND  
(@lFileDescription IS NULL OR FileDescription LIKE '%' +@lFileDescription + '%') AND  
(@lCategoryID IS NULL OR CategoryID = @lCategoryID) AND 
(@lTermId IS NULL OR TermId = @lTermId) 
) 
SELECT   RecordCount, 
 ROWNUM, 
 
FileId, 
FileName, 
FileDescription, 
CategoryID, 
TermId FROM TradeFromFileResult 
 WHERE 
         ROWNUM > @lFirstRec 
               AND ROWNUM < @lLastRec 
 ORDER BY ROWNUM ASC 
END 
GO 
 
 
go 
 
DROP PROCEDURE [dbo].[Sp_GetTradeFromFile_Autocomplete]; 
go 
CREATE PROCEDURE [dbo].[Sp_GetTradeFromFile_Autocomplete] 
     @Key_word    nvarchar(50)  
   
   
AS     
BEGIN     
 SET NOCOUNT ON;     
    
 select top 20 KetText,count(*) as NumberOfkey from   
(  
SELECT   
      [FileName] As KetText  
         
  FROM [TradeFromFile] where [FileName] like ''+@Key_word+'%'  
union all 
SELECT   
      [FileDescription] As KetText  
         
  FROM [TradeFromFile] where [FileDescription] like ''+@Key_word+'%'  
 
  )KeyTable   
  group by KetText  
  order by count(*) desc   
  
END     
    
 
 
 
DROP PROCEDURE [dbo].[Sp_GetTradeFromFile_Autocomplete]; 
go 
CREATE PROCEDURE [dbo].[Sp_GetTradeFromFile_Autocomplete] 
@Column  nvarchar(50),@keyword nvarchar(50)   
   
AS     
BEGIN     
SET NOCOUNT ON;     
    
 select top 20 KetText,count(*) as NumberOfkey from   
(  
SELECT   
      CASE  WHEN (@Column = 'FileId') THEN CONVERT(varchar, FileId )  WHEN (@Column = 'FileName') THEN CONVERT(varchar, FileName )  WHEN (@Column = 'FileDescription') THEN CONVERT(varchar, FileDescription )  WHEN (@Column = 'CategoryID') THEN CONVERT(varchar, CategoryID )  WHEN (@Column = 'TermId') THEN CONVERT(varchar, TermId )END As KetText  
         
  FROM [TradeFromFile] where CASE  WHEN (@Column = 'FileId') THEN CONVERT(varchar, FileId )  WHEN (@Column = 'FileName') THEN CONVERT(varchar, FileName )  WHEN (@Column = 'FileDescription') THEN CONVERT(varchar, FileDescription )  WHEN (@Column = 'CategoryID') THEN CONVERT(varchar, CategoryID )  WHEN (@Column = 'TermId') THEN CONVERT(varchar, TermId )END like ''+@keyword+'%'  
  )KeyTable   
  group by KetText  
  order by count(*) desc   
  
END     
    
 
 
 
DROP PROCEDURE [dbo].[Sp_GetTradeFromFile_UpdateColumn]; 
 
go 
 
   
        
      create PROCEDURE [dbo].[Sp_GetTradeFromFile_UpdateColumn]  
        @FileId  [float] ,@Column  nvarchar(max),@Data nvarchar(max)    
   AS      
       BEGIN      
       --SET NOCOUNT ON;      
          
         if  @Column = 'FileName' 
           BEGIN  
           UPDATE   TradeFromFile SET FileName=@Data where FileId = @FileId;   
         END  
         if  @Column = 'FileDescription' 
           BEGIN  
           UPDATE   TradeFromFile SET FileDescription=@Data where FileId = @FileId;   
         END  
         if  @Column = 'CategoryID' 
           BEGIN  
           UPDATE   TradeFromFile SET CategoryID=@Data where FileId = @FileId;   
         END  
         if  @Column = 'TermId' 
           BEGIN  
           UPDATE   TradeFromFile SET TermId=@Data where FileId = @FileId;   
         END  
       END      
 
go 
 

