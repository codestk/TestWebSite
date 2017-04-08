DROP PROCEDURE [dbo].[Sp_GetAccountStatusPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetAccountStatusPageWise]
/* Optional Filters for Dynamic Search*/
@Status  [nvarchar](255) =null,
@StatusName  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'Status',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lStatus  [nvarchar](255) =null,
@lStatusName  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lStatus = LTRIM(RTRIM(@Status))
SET @lStatusName = LTRIM(RTRIM(@StatusName))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH AccountStatusResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'Status' AND @SortOrder='ASC')
                   THEN Status
       END ASC,
       CASE WHEN (@lSortCol = 'Status' AND @SortOrder='DESC')
                  THEN Status
       END DESC,
CASE WHEN (@lSortCol = 'StatusName' AND @SortOrder='ASC')
                   THEN StatusName
       END ASC,
       CASE WHEN (@lSortCol = 'StatusName' AND @SortOrder='DESC')
                  THEN StatusName
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 Status,
 StatusName
 FROM AccountStatus
WHERE
(@lStatus IS NULL OR Status LIKE '%' +@lStatus + '%') AND 
(@lStatusName IS NULL OR StatusName LIKE '%' +@lStatusName + '%') 
)
SELECT   RecordCount,
 ROWNUM,

Status,
StatusName FROM AccountStatusResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetAccountStatus_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetAccountStatus_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [Status] As KetText 
        
  FROM [AccountStatus] where [Status] like ''+@Key_word+'%' 
union all
SELECT  
      [StatusName] As KetText 
        
  FROM [AccountStatus] where [StatusName] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetAccountStatus_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetAccountStatus_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'Status') THEN CONVERT(varchar, Status )  WHEN (@Column = 'StatusName') THEN CONVERT(varchar, StatusName )END As KetText 
        
  FROM [AccountStatus] where CASE  WHEN (@Column = 'Status') THEN CONVERT(varchar, Status )  WHEN (@Column = 'StatusName') THEN CONVERT(varchar, StatusName )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetAccountStatus_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetAccountStatus_UpdateColumn] 
        @Status  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'StatusName'
           BEGIN 
           UPDATE   AccountStatus SET StatusName=@Data where Status = @Status;  
         END 
       END     

go


