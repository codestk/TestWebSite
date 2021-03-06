   DROP PROCEDURE   [dbo].[Sp_GetCustomerBrandPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetCustomerBrandPageWise]
/* Optional Filters for Dynamic Search*/
@CustomerBrandID  [nvarchar](255) =null,
@CustomerBrandName  [nvarchar](255) =null,
@CustomerBrandDetail  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'CustomerBrandID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lCustomerBrandID  [nvarchar](255) =null,
@lCustomerBrandName  [nvarchar](255) =null,
@lCustomerBrandDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lCustomerBrandID = LTRIM(RTRIM(@CustomerBrandID))
SET @lCustomerBrandName = LTRIM(RTRIM(@CustomerBrandName))
SET @lCustomerBrandDetail = LTRIM(RTRIM(@CustomerBrandDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH CustomerBrandResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'CustomerBrandID' AND @SortOrder='ASC')
                   THEN CustomerBrandID
       END ASC,
       CASE WHEN (@lSortCol = 'CustomerBrandID' AND @SortOrder='DESC')
                  THEN CustomerBrandID
       END DESC,
CASE WHEN (@lSortCol = 'CustomerBrandName' AND @SortOrder='ASC')
                   THEN CustomerBrandName
       END ASC,
       CASE WHEN (@lSortCol = 'CustomerBrandName' AND @SortOrder='DESC')
                  THEN CustomerBrandName
       END DESC,
CASE WHEN (@lSortCol = 'CustomerBrandDetail' AND @SortOrder='ASC')
                   THEN CustomerBrandDetail
       END ASC,
       CASE WHEN (@lSortCol = 'CustomerBrandDetail' AND @SortOrder='DESC')
                  THEN CustomerBrandDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 CustomerBrandID,
 CustomerBrandName,
 CustomerBrandDetail
 FROM CustomerBrand
WHERE
(@lCustomerBrandID IS NULL OR CustomerBrandID LIKE '%' +@lCustomerBrandID + '%') AND 
(@lCustomerBrandName IS NULL OR CustomerBrandName LIKE '%' +@lCustomerBrandName + '%') AND 
(@lCustomerBrandDetail IS NULL OR CustomerBrandDetail LIKE '%' +@lCustomerBrandDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

CustomerBrandID,
CustomerBrandName,
CustomerBrandDetail FROM CustomerBrandResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetCustomerBrand_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetCustomerBrand_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [CustomerBrandID] As KetText 
        
  FROM [CustomerBrand] where [CustomerBrandID] like ''+@Key_word+'%' 
union all
SELECT  
      [CustomerBrandName] As KetText 
        
  FROM [CustomerBrand] where [CustomerBrandName] like ''+@Key_word+'%' 
union all
SELECT  
      [CustomerBrandDetail] As KetText 
        
  FROM [CustomerBrand] where [CustomerBrandDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetCustomerBrand_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetCustomerBrand_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'CustomerBrandID') THEN CONVERT(varchar, CustomerBrandID )  WHEN (@Column = 'CustomerBrandName') THEN CONVERT(varchar, CustomerBrandName )  WHEN (@Column = 'CustomerBrandDetail') THEN CONVERT(varchar, CustomerBrandDetail )END As KetText 
        
  FROM [CustomerBrand] where CASE  WHEN (@Column = 'CustomerBrandID') THEN CONVERT(varchar, CustomerBrandID )  WHEN (@Column = 'CustomerBrandName') THEN CONVERT(varchar, CustomerBrandName )  WHEN (@Column = 'CustomerBrandDetail') THEN CONVERT(varchar, CustomerBrandDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetCustomerBrand_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetCustomerBrand_UpdateColumn] 
        @CustomerBrandID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'CustomerBrandName'
           BEGIN 
           UPDATE   CustomerBrand SET CustomerBrandName=@Data where CustomerBrandID = @CustomerBrandID;  
         END 
         if  @Column = 'CustomerBrandDetail'
           BEGIN 
           UPDATE   CustomerBrand SET CustomerBrandDetail=@Data where CustomerBrandID = @CustomerBrandID;  
         END 
       END     

go

