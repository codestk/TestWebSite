DROP PROCEDURE [dbo].[Sp_GetTradeFromTermPageWise]; 
go 
CREATE PROCEDURE [dbo].[Sp_GetTradeFromTermPageWise] 
/* Optional Filters for Dynamic Search*/ 
@TermId  [float] =null, 
@TermName  [nvarchar](255) =null, 
@TermContent  [nvarchar](255) =null, 
@TermCreateDate  [datetime] =null, 
@TermUpdateDate  [datetime] =null, 
@TermUpdateCount  [float] =null, 
/*– Pagination Parameters */ 
@PageIndex INT = 1 , 
@PageSize INT = 10 , 
/*– Sorting Parameters */ 
@SortColumn NVARCHAR(20) = 'TermId', 
@SortOrder NVARCHAR(4) ='ASC' 
AS   
BEGIN   
 SET NOCOUNT ON;   
  
   
  
  
/*–Declaring Local Variables corresponding to parameters for modification */ 
DECLARE @lTermId  [float] =null, 
@lTermName  [nvarchar](255) =null, 
@lTermContent  [nvarchar](255) =null, 
@lTermCreateDate  [datetime] =null, 
@lTermUpdateDate  [datetime] =null, 
@lTermUpdateCount  [float] =null, 
@lPageNbr INT, 
@lPageSize INT, 
@lSortCol NVARCHAR(20), 
@lFirstRec INT, 
@lLastRec INT, 
@lTotalRows INT 
/*Setting Local Variables*/ 
SET @lTermId = LTRIM(RTRIM(@TermId)) 
SET @lTermName = LTRIM(RTRIM(@TermName)) 
SET @lTermContent = LTRIM(RTRIM(@TermContent)) 
SET @lTermCreateDate = LTRIM(RTRIM(@TermCreateDate)) 
SET @lTermUpdateDate = LTRIM(RTRIM(@TermUpdateDate)) 
SET @lTermUpdateCount = LTRIM(RTRIM(@TermUpdateCount)) 
SET @lPageNbr = @PageIndex 
    SET @lPageSize = @PageSize 
    SET @lSortCol = LTRIM(RTRIM(@SortColumn)) 
  
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize 
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 ) 
    SET @lTotalRows = @lFirstRec - @lLastRec + 1 
; WITH TradeFromTermResult 
AS( 
SELECT ROW_NUMBER() OVER(ORDER BY  
 
CASE WHEN (@lSortCol = 'TermId' AND @SortOrder='ASC') 
                   THEN TermId 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermId' AND @SortOrder='DESC') 
                  THEN TermId 
       END DESC, 
CASE WHEN (@lSortCol = 'TermName' AND @SortOrder='ASC') 
                   THEN TermName 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermName' AND @SortOrder='DESC') 
                  THEN TermName 
       END DESC, 
CASE WHEN (@lSortCol = 'TermContent' AND @SortOrder='ASC') 
                   THEN TermContent 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermContent' AND @SortOrder='DESC') 
                  THEN TermContent 
       END DESC, 
CASE WHEN (@lSortCol = 'TermCreateDate' AND @SortOrder='ASC') 
                   THEN TermCreateDate 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermCreateDate' AND @SortOrder='DESC') 
                  THEN TermCreateDate 
       END DESC, 
CASE WHEN (@lSortCol = 'TermUpdateDate' AND @SortOrder='ASC') 
                   THEN TermUpdateDate 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermUpdateDate' AND @SortOrder='DESC') 
                  THEN TermUpdateDate 
       END DESC, 
CASE WHEN (@lSortCol = 'TermUpdateCount' AND @SortOrder='ASC') 
                   THEN TermUpdateCount 
       END ASC, 
       CASE WHEN (@lSortCol = 'TermUpdateCount' AND @SortOrder='DESC') 
                  THEN TermUpdateCount 
       END DESC  ) AS ROWNUM, 
Count(*) over() AS RecordCount, 
 
 TermId, 
 TermName, 
 TermContent, 
 TermCreateDate, 
 TermUpdateDate, 
 TermUpdateCount 
 FROM TradeFromTerm 
WHERE 
(@lTermId IS NULL OR TermId = @lTermId) AND 
(@lTermName IS NULL OR TermName LIKE '%' +@lTermName + '%') AND  
(@lTermContent IS NULL OR TermContent LIKE '%' +@lTermContent + '%') AND  
(@lTermCreateDate IS NULL OR TermCreateDate = @lTermCreateDate) AND 
(@lTermUpdateDate IS NULL OR TermUpdateDate = @lTermUpdateDate) AND 
(@lTermUpdateCount IS NULL OR TermUpdateCount = @lTermUpdateCount) 
) 
SELECT   RecordCount, 
 ROWNUM, 
 
TermId, 
TermName, 
TermContent, 
TermCreateDate, 
TermUpdateDate, 
TermUpdateCount FROM TradeFromTermResult 
 WHERE 
         ROWNUM > @lFirstRec 
               AND ROWNUM < @lLastRec 
 ORDER BY ROWNUM ASC 
END 
GO 
 
 
go 
 
DROP PROCEDURE [dbo].[Sp_GetTradeFromTerm_Autocomplete]; 
go 
CREATE PROCEDURE [dbo].[Sp_GetTradeFromTerm_Autocomplete] 
     @Key_word    nvarchar(50)  
   
   
AS     
BEGIN     
 SET NOCOUNT ON;     
    
 select top 20 KetText,count(*) as NumberOfkey from   
(  
SELECT   
      [TermName] As KetText  
         
  FROM [TradeFromTerm] where [TermName] like ''+@Key_word+'%'  
union all 
SELECT   
      [TermContent] As KetText  
         
  FROM [TradeFromTerm] where [TermContent] like ''+@Key_word+'%'  
 
  )KeyTable   
  group by KetText  
  order by count(*) desc   
  
END     
    
 
 
 
DROP PROCEDURE [dbo].[Sp_GetTradeFromTerm_Autocomplete]; 
go 
CREATE PROCEDURE [dbo].[Sp_GetTradeFromTerm_Autocomplete] 
@Column  nvarchar(50),@keyword nvarchar(50)   
   
AS     
BEGIN     
SET NOCOUNT ON;     
    
 select top 20 KetText,count(*) as NumberOfkey from   
(  
SELECT   
      CASE  WHEN (@Column = 'TermId') THEN CONVERT(varchar, TermId )  WHEN (@Column = 'TermName') THEN CONVERT(varchar, TermName )  WHEN (@Column = 'TermContent') THEN CONVERT(varchar, TermContent )  WHEN (@Column = 'TermCreateDate') THEN CONVERT(varchar, TermCreateDate )  WHEN (@Column = 'TermUpdateDate') THEN CONVERT(varchar, TermUpdateDate )  WHEN (@Column = 'TermUpdateCount') THEN CONVERT(varchar, TermUpdateCount )END As KetText  
         
  FROM [TradeFromTerm] where CASE  WHEN (@Column = 'TermId') THEN CONVERT(varchar, TermId )  WHEN (@Column = 'TermName') THEN CONVERT(varchar, TermName )  WHEN (@Column = 'TermContent') THEN CONVERT(varchar, TermContent )  WHEN (@Column = 'TermCreateDate') THEN CONVERT(varchar, TermCreateDate )  WHEN (@Column = 'TermUpdateDate') THEN CONVERT(varchar, TermUpdateDate )  WHEN (@Column = 'TermUpdateCount') THEN CONVERT(varchar, TermUpdateCount )END like ''+@keyword+'%'  
  )KeyTable   
  group by KetText  
  order by count(*) desc   
  
END     
    
 
 
 
DROP PROCEDURE [dbo].[Sp_GetTradeFromTerm_UpdateColumn]; 
 
go 
 
   
        
      create PROCEDURE [dbo].[Sp_GetTradeFromTerm_UpdateColumn]  
        @TermId  [float] ,@Column  nvarchar(max),@Data nvarchar(max)    
   AS      
       BEGIN      
       --SET NOCOUNT ON;      
          
         if  @Column = 'TermName' 
           BEGIN  
           UPDATE   TradeFromTerm SET TermName=@Data where TermId = @TermId;   
         END  
         if  @Column = 'TermContent' 
           BEGIN  
           UPDATE   TradeFromTerm SET TermContent=@Data where TermId = @TermId;   
         END  
         if  @Column = 'TermCreateDate' 
           BEGIN  
           UPDATE   TradeFromTerm SET TermCreateDate=@Data where TermId = @TermId;   
         END  
         if  @Column = 'TermUpdateDate' 
           BEGIN  
           UPDATE   TradeFromTerm SET TermUpdateDate=@Data where TermId = @TermId;   
         END  
         if  @Column = 'TermUpdateCount' 
           BEGIN  
           UPDATE   TradeFromTerm SET TermUpdateCount=@Data where TermId = @TermId;   
         END  
       END      
 
go 
 

