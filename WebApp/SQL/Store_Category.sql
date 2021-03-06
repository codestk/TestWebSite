   DROP PROCEDURE   [dbo].[Sp_GetCategoryPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetCategoryPageWise]
/* Optional Filters for Dynamic Search*/
@CategoryID  [nvarchar](255) =null,
@CategoryName  [nvarchar](255) =null,
@CategoryDetail  [nvarchar](255) =null,
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
DECLARE @lCategoryID  [nvarchar](255) =null,
@lCategoryName  [nvarchar](255) =null,
@lCategoryDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lCategoryID = LTRIM(RTRIM(@CategoryID))
SET @lCategoryName = LTRIM(RTRIM(@CategoryName))
SET @lCategoryDetail = LTRIM(RTRIM(@CategoryDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH CategoryResult
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
       END DESC,
CASE WHEN (@lSortCol = 'CategoryDetail' AND @SortOrder='ASC')
                   THEN CategoryDetail
       END ASC,
       CASE WHEN (@lSortCol = 'CategoryDetail' AND @SortOrder='DESC')
                  THEN CategoryDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 CategoryID,
 CategoryName,
 CategoryDetail
 FROM Category
WHERE
(@lCategoryID IS NULL OR CategoryID LIKE '%' +@lCategoryID + '%') AND 
(@lCategoryName IS NULL OR CategoryName LIKE '%' +@lCategoryName + '%') AND 
(@lCategoryDetail IS NULL OR CategoryDetail LIKE '%' +@lCategoryDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

CategoryID,
CategoryName,
CategoryDetail FROM CategoryResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetCategory_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetCategory_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [CategoryID] As KetText 
        
  FROM [Category] where [CategoryID] like ''+@Key_word+'%' 
union all
SELECT  
      [CategoryName] As KetText 
        
  FROM [Category] where [CategoryName] like ''+@Key_word+'%' 
union all
SELECT  
      [CategoryDetail] As KetText 
        
  FROM [Category] where [CategoryDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetCategory_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetCategory_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'CategoryID') THEN CONVERT(varchar, CategoryID )  WHEN (@Column = 'CategoryName') THEN CONVERT(varchar, CategoryName )  WHEN (@Column = 'CategoryDetail') THEN CONVERT(varchar, CategoryDetail )END As KetText 
        
  FROM [Category] where CASE  WHEN (@Column = 'CategoryID') THEN CONVERT(varchar, CategoryID )  WHEN (@Column = 'CategoryName') THEN CONVERT(varchar, CategoryName )  WHEN (@Column = 'CategoryDetail') THEN CONVERT(varchar, CategoryDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetCategory_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetCategory_UpdateColumn] 
        @CategoryID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'CategoryName'
           BEGIN 
           UPDATE   Category SET CategoryName=@Data where CategoryID = @CategoryID;  
         END 
         if  @Column = 'CategoryDetail'
           BEGIN 
           UPDATE   Category SET CategoryDetail=@Data where CategoryID = @CategoryID;  
         END 
       END     

go

