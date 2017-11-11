DROP PROCEDURE [dbo].[Sp_GetTestValidatePageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetTestValidatePageWise]
/* Optional Filters for Dynamic Search*/
@Id  [int] =null,
@Name  [nvarchar](255) =null,
@NickName  [nvarchar](255) =null,
@Max  [nvarchar](255) =null,
@Item  [int] =null,
@CreateItme  [datetime] =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'Id',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lId  [int] =null,
@lName  [nvarchar](255) =null,
@lNickName  [nvarchar](255) =null,
@lMax  [nvarchar](255) =null,
@lItem  [int] =null,
@lCreateItme  [datetime] =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lId =@Id
SET @lName = LTRIM(RTRIM(@Name))
SET @lNickName = LTRIM(RTRIM(@NickName))
SET @lMax = LTRIM(RTRIM(@Max))
SET @lItem =@Item
SET @lCreateItme = LTRIM(RTRIM(@CreateItme))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH TestValidateResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'Id' AND @SortOrder='ASC')
                   THEN Id
       END ASC,
       CASE WHEN (@lSortCol = 'Id' AND @SortOrder='DESC')
                  THEN Id
       END DESC,
CASE WHEN (@lSortCol = 'Name' AND @SortOrder='ASC')
                   THEN Name
       END ASC,
       CASE WHEN (@lSortCol = 'Name' AND @SortOrder='DESC')
                  THEN Name
       END DESC,
CASE WHEN (@lSortCol = 'NickName' AND @SortOrder='ASC')
                   THEN NickName
       END ASC,
       CASE WHEN (@lSortCol = 'NickName' AND @SortOrder='DESC')
                  THEN NickName
       END DESC,
CASE WHEN (@lSortCol = 'Max' AND @SortOrder='ASC')
                   THEN Max
       END ASC,
       CASE WHEN (@lSortCol = 'Max' AND @SortOrder='DESC')
                  THEN Max
       END DESC,
CASE WHEN (@lSortCol = 'Item' AND @SortOrder='ASC')
                   THEN Item
       END ASC,
       CASE WHEN (@lSortCol = 'Item' AND @SortOrder='DESC')
                  THEN Item
       END DESC,
CASE WHEN (@lSortCol = 'CreateItme' AND @SortOrder='ASC')
                   THEN CreateItme
       END ASC,
       CASE WHEN (@lSortCol = 'CreateItme' AND @SortOrder='DESC')
                  THEN CreateItme
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 Id,
 Name,
 NickName,
 Max,
 Item,
 CreateItme
 FROM TestValidate
WHERE
(@lId IS NULL OR Id = @lId) AND
(@lName IS NULL OR Name LIKE '%' +@lName + '%') AND 
(@lNickName IS NULL OR NickName LIKE '%' +@lNickName + '%') AND 
(@lMax IS NULL OR Max LIKE '%' +@lMax + '%') AND 
(@lItem IS NULL OR Item = @lItem) AND
(@lCreateItme IS NULL OR CreateItme = @lCreateItme)
)
SELECT   RecordCount,
 ROWNUM,

Id,
Name,
NickName,
Max,
Item,
CreateItme FROM TestValidateResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetTestValidate_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetTestValidate_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [Name] As KetText 
        
  FROM [TestValidate] where [Name] like ''+@Key_word+'%' 
union all
SELECT  
      [NickName] As KetText 
        
  FROM [TestValidate] where [NickName] like ''+@Key_word+'%' 
union all
SELECT  
      [Max] As KetText 
        
  FROM [TestValidate] where [Max] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetTestValidate_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetTestValidate_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'Id') THEN CONVERT(varchar, Id )  WHEN (@Column = 'Name') THEN CONVERT(varchar, Name )  WHEN (@Column = 'NickName') THEN CONVERT(varchar, NickName )  WHEN (@Column = 'Max') THEN CONVERT(varchar, Max )  WHEN (@Column = 'Item') THEN CONVERT(varchar, Item )  WHEN (@Column = 'CreateItme') THEN CONVERT(varchar, CreateItme )END As KetText 
        
  FROM [TestValidate] where CASE  WHEN (@Column = 'Id') THEN CONVERT(varchar, Id )  WHEN (@Column = 'Name') THEN CONVERT(varchar, Name )  WHEN (@Column = 'NickName') THEN CONVERT(varchar, NickName )  WHEN (@Column = 'Max') THEN CONVERT(varchar, Max )  WHEN (@Column = 'Item') THEN CONVERT(varchar, Item )  WHEN (@Column = 'CreateItme') THEN CONVERT(varchar, CreateItme )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetTestValidate_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetTestValidate_UpdateColumn] 
        @Id  [int] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'Name'
           BEGIN 
           UPDATE   TestValidate SET Name=@Data where Id = @Id;  
         END 
         if  @Column = 'NickName'
           BEGIN 
           UPDATE   TestValidate SET NickName=@Data where Id = @Id;  
         END 
         if  @Column = 'Max'
           BEGIN 
           UPDATE   TestValidate SET Max=@Data where Id = @Id;  
         END 
         if  @Column = 'Item'
           BEGIN 
           UPDATE   TestValidate SET Item=@Data where Id = @Id;  
         END 
         if  @Column = 'CreateItme'
           BEGIN 
           UPDATE   TestValidate SET CreateItme=@Data where Id = @Id;  
         END 
       END     

go

