DROP PROCEDURE [dbo].[Sp_GetSTK_USER_FLAGPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetSTK_USER_FLAGPageWise]
/* Optional Filters for Dynamic Search*/
@EM_FLAG  [nvarchar](255) =null,
@EM_DES  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'EM_FLAG',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lEM_FLAG  [nvarchar](255) =null,
@lEM_DES  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lEM_FLAG = LTRIM(RTRIM(@EM_FLAG))
SET @lEM_DES = LTRIM(RTRIM(@EM_DES))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH STK_USER_FLAGResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'EM_FLAG' AND @SortOrder='ASC')
                   THEN EM_FLAG
       END ASC,
       CASE WHEN (@lSortCol = 'EM_FLAG' AND @SortOrder='DESC')
                  THEN EM_FLAG
       END DESC,
CASE WHEN (@lSortCol = 'EM_DES' AND @SortOrder='ASC')
                   THEN EM_DES
       END ASC,
       CASE WHEN (@lSortCol = 'EM_DES' AND @SortOrder='DESC')
                  THEN EM_DES
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 EM_FLAG,
 EM_DES
 FROM STK_USER_FLAG
WHERE
(@lEM_FLAG IS NULL OR EM_FLAG LIKE '%' +@lEM_FLAG + '%') AND 
(@lEM_DES IS NULL OR EM_DES LIKE '%' +@lEM_DES + '%') 
)
SELECT   RecordCount,
 ROWNUM,

EM_FLAG,
EM_DES FROM STK_USER_FLAGResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetSTK_USER_FLAG_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetSTK_USER_FLAG_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [EM_FLAG] As KetText 
        
  FROM [STK_USER_FLAG] where [EM_FLAG] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_DES] As KetText 
        
  FROM [STK_USER_FLAG] where [EM_DES] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetSTK_USER_FLAG_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetSTK_USER_FLAG_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'EM_FLAG') THEN CONVERT(varchar, EM_FLAG )  WHEN (@Column = 'EM_DES') THEN CONVERT(varchar, EM_DES )END As KetText 
        
  FROM [STK_USER_FLAG] where CASE  WHEN (@Column = 'EM_FLAG') THEN CONVERT(varchar, EM_FLAG )  WHEN (@Column = 'EM_DES') THEN CONVERT(varchar, EM_DES )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetSTK_USER_FLAG_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetSTK_USER_FLAG_UpdateColumn] 
        @EM_FLAG  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'EM_DES'
           BEGIN 
           UPDATE   STK_USER_FLAG SET EM_DES=@Data where EM_FLAG = @EM_FLAG;  
         END 
       END     

go


