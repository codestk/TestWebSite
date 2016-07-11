DROP PROCEDURE [dbo].[Sp_GetCategoriesPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetCategoriesPageWise]
/* Optional Filters for Dynamic Search*/
@CategoryID  [int] =null,
@CategoryName  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'CategoryID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lCategoryID  [int] =null,
@lCategoryName  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lCategoryID =@CategoryID
SET @lCategoryName = LTRIM(RTRIM(@CategoryName))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH CategoriesResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'CategoryID' AND @SortOrder='ASC')
                   THEN CategoryID
       END ASC,
       CASE WHEN (@lSortCol = 'CategoryID' AND @SortOrder='DESC')
                  THEN CategoryID
       END DESC,
CASE WHEN (@lSortCol = 'CategoryName' AND @SortOrder='ASC')
                   THEN CategoryName
       END ASC,
       CASE WHEN (@lSortCol = 'CategoryName' AND @SortOrder='DESC')
                  THEN CategoryName
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 CategoryID,
 CategoryName
 FROM Categories
WHERE
(@lCategoryID IS NULL OR CategoryID = @lCategoryID) AND
(@lCategoryName IS NULL OR CategoryName LIKE '%' +@lCategoryName + '%') 
)
SELECT   RecordCount,
 ROWNUM,

CategoryID,
CategoryName FROM CategoriesResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetCategories_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetCategories_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [CategoryName] As KetText 
        
  FROM [Categories] where [CategoryName] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetCategories_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetCategories_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'CategoryID') THEN CONVERT(varchar, CategoryID )  WHEN (@Column = 'CategoryName') THEN CONVERT(varchar, CategoryName )END As KetText 
        
  FROM [Categories] where CASE  WHEN (@Column = 'CategoryID') THEN CONVERT(varchar, CategoryID )  WHEN (@Column = 'CategoryName') THEN CONVERT(varchar, CategoryName )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetCategories_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetCategories_UpdateColumn] 
        @CategoryID  [int] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'CategoryName'
           BEGIN 
           UPDATE   Categories SET CategoryName=@Data where CategoryID = @CategoryID;  
         END 
       END     

go


