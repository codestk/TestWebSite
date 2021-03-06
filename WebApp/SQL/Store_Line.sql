   DROP PROCEDURE   [dbo].[Sp_GetLinePageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetLinePageWise]
/* Optional Filters for Dynamic Search*/
@LineID  [nvarchar](255) =null,
@LineName  [nvarchar](255) =null,
@LineDetail  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'LineID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lLineID  [nvarchar](255) =null,
@lLineName  [nvarchar](255) =null,
@lLineDetail  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lLineID = LTRIM(RTRIM(@LineID))
SET @lLineName = LTRIM(RTRIM(@LineName))
SET @lLineDetail = LTRIM(RTRIM(@LineDetail))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH LineResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'LineID' AND @SortOrder='ASC')
                   THEN LineID
       END ASC,
       CASE WHEN (@lSortCol = 'LineID' AND @SortOrder='DESC')
                  THEN LineID
       END DESC,
CASE WHEN (@lSortCol = 'LineName' AND @SortOrder='ASC')
                   THEN LineName
       END ASC,
       CASE WHEN (@lSortCol = 'LineName' AND @SortOrder='DESC')
                  THEN LineName
       END DESC,
CASE WHEN (@lSortCol = 'LineDetail' AND @SortOrder='ASC')
                   THEN LineDetail
       END ASC,
       CASE WHEN (@lSortCol = 'LineDetail' AND @SortOrder='DESC')
                  THEN LineDetail
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 LineID,
 LineName,
 LineDetail
 FROM Line
WHERE
(@lLineID IS NULL OR LineID LIKE '%' +@lLineID + '%') AND 
(@lLineName IS NULL OR LineName LIKE '%' +@lLineName + '%') AND 
(@lLineDetail IS NULL OR LineDetail LIKE '%' +@lLineDetail + '%') 
)
SELECT   RecordCount,
 ROWNUM,

LineID,
LineName,
LineDetail FROM LineResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE   [dbo].[Sp_GetLine_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetLine_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [LineID] As KetText 
        
  FROM [Line] where [LineID] like ''+@Key_word+'%' 
union all
SELECT  
      [LineName] As KetText 
        
  FROM [Line] where [LineName] like ''+@Key_word+'%' 
union all
SELECT  
      [LineDetail] As KetText 
        
  FROM [Line] where [LineDetail] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetLine_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetLine_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'LineID') THEN CONVERT(varchar, LineID )  WHEN (@Column = 'LineName') THEN CONVERT(varchar, LineName )  WHEN (@Column = 'LineDetail') THEN CONVERT(varchar, LineDetail )END As KetText 
        
  FROM [Line] where CASE  WHEN (@Column = 'LineID') THEN CONVERT(varchar, LineID )  WHEN (@Column = 'LineName') THEN CONVERT(varchar, LineName )  WHEN (@Column = 'LineDetail') THEN CONVERT(varchar, LineDetail )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE   [dbo].[Sp_GetLine_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetLine_UpdateColumn] 
        @LineID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'LineName'
           BEGIN 
           UPDATE   Line SET LineName=@Data where LineID = @LineID;  
         END 
         if  @Column = 'LineDetail'
           BEGIN 
           UPDATE   Line SET LineDetail=@Data where LineID = @LineID;  
         END 
       END     

go

