   DROP PROCEDURE   [dbo].[Sp_GetContainPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetContainPageWise]
/* Optional Filters for Dynamic Search*/
@ContainID  [nvarchar](255) =null,
@ContainName  [nvarchar](255) =null,
@ContainDetail  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'ContainID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lContainID  [nvarchar](255) =null,
@lContainName  [nvarchar](255) =null,
@lContainDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lContainID = LTRIM(RTRIM(@ContainID))
SET @lContainName = LTRIM(RTRIM(@ContainName))
SET @lContainDetail = LTRIM(RTRIM(@ContainDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH ContainResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'ContainID' AND @SortOrder='ASC')
                   THEN ContainID
       END ASC,
       CASE WHEN (@lSortCol = 'ContainID' AND @SortOrder='DESC')
                  THEN ContainID
       END DESC,
CASE WHEN (@lSortCol = 'ContainName' AND @SortOrder='ASC')
                   THEN ContainName
       END ASC,
       CASE WHEN (@lSortCol = 'ContainName' AND @SortOrder='DESC')
                  THEN ContainName
       END DESC,
CASE WHEN (@lSortCol = 'ContainDetail' AND @SortOrder='ASC')
                   THEN ContainDetail
       END ASC,
       CASE WHEN (@lSortCol = 'ContainDetail' AND @SortOrder='DESC')
                  THEN ContainDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 ContainID,
 ContainName,
 ContainDetail
 FROM Contain
WHERE
(@lContainID IS NULL OR ContainID LIKE '%' +@lContainID + '%') AND 
(@lContainName IS NULL OR ContainName LIKE '%' +@lContainName + '%') AND 
(@lContainDetail IS NULL OR ContainDetail LIKE '%' +@lContainDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

ContainID,
ContainName,
ContainDetail FROM ContainResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetContain_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetContain_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [ContainID] As KetText 
        
  FROM [Contain] where [ContainID] like ''+@Key_word+'%' 
union all
SELECT  
      [ContainName] As KetText 
        
  FROM [Contain] where [ContainName] like ''+@Key_word+'%' 
union all
SELECT  
      [ContainDetail] As KetText 
        
  FROM [Contain] where [ContainDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetContain_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetContain_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'ContainID') THEN CONVERT(varchar, ContainID )  WHEN (@Column = 'ContainName') THEN CONVERT(varchar, ContainName )  WHEN (@Column = 'ContainDetail') THEN CONVERT(varchar, ContainDetail )END As KetText 
        
  FROM [Contain] where CASE  WHEN (@Column = 'ContainID') THEN CONVERT(varchar, ContainID )  WHEN (@Column = 'ContainName') THEN CONVERT(varchar, ContainName )  WHEN (@Column = 'ContainDetail') THEN CONVERT(varchar, ContainDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetContain_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetContain_UpdateColumn] 
        @ContainID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'ContainName'
           BEGIN 
           UPDATE   Contain SET ContainName=@Data where ContainID = @ContainID;  
         END 
         if  @Column = 'ContainDetail'
           BEGIN 
           UPDATE   Contain SET ContainDetail=@Data where ContainID = @ContainID;  
         END 
       END     

go

