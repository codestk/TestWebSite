DROP PROCEDURE [dbo].[Sp_GetSTK_USERPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetSTK_USERPageWise]
/* Optional Filters for Dynamic Search*/
@EM_ID  [nvarchar](255) =null,
@EM_PASS  [nvarchar](255) =null,
@EM_NAME  [nvarchar](255) =null,
@EM_SURNAME  [nvarchar](255) =null,
@EM_TEL  [nvarchar](255) =null,
@EM_ADDRESS  [nvarchar](255) =null,
@EM_FLAG  [nvarchar](255) =null,
@EM_ROLE_ADMIN  [int] =null,
@EM_ROLE_USER  [int] =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'EM_ID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lEM_ID  [nvarchar](255) =null,
@lEM_PASS  [nvarchar](255) =null,
@lEM_NAME  [nvarchar](255) =null,
@lEM_SURNAME  [nvarchar](255) =null,
@lEM_TEL  [nvarchar](255) =null,
@lEM_ADDRESS  [nvarchar](255) =null,
@lEM_FLAG  [nvarchar](255) =null,
@lEM_ROLE_ADMIN  [int] =null,
@lEM_ROLE_USER  [int] =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lEM_ID = LTRIM(RTRIM(@EM_ID))
SET @lEM_PASS = LTRIM(RTRIM(@EM_PASS))
SET @lEM_NAME = LTRIM(RTRIM(@EM_NAME))
SET @lEM_SURNAME = LTRIM(RTRIM(@EM_SURNAME))
SET @lEM_TEL = LTRIM(RTRIM(@EM_TEL))
SET @lEM_ADDRESS = LTRIM(RTRIM(@EM_ADDRESS))
SET @lEM_FLAG = LTRIM(RTRIM(@EM_FLAG))
SET @lEM_ROLE_ADMIN = LTRIM(RTRIM(@EM_ROLE_ADMIN))
SET @lEM_ROLE_USER = LTRIM(RTRIM(@EM_ROLE_USER))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH STK_USERResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'EM_ID' AND @SortOrder='ASC')
                   THEN EM_ID
       END ASC,
       CASE WHEN (@lSortCol = 'EM_ID' AND @SortOrder='DESC')
                  THEN EM_ID
       END DESC,
CASE WHEN (@lSortCol = 'EM_PASS' AND @SortOrder='ASC')
                   THEN EM_PASS
       END ASC,
       CASE WHEN (@lSortCol = 'EM_PASS' AND @SortOrder='DESC')
                  THEN EM_PASS
       END DESC,
CASE WHEN (@lSortCol = 'EM_NAME' AND @SortOrder='ASC')
                   THEN EM_NAME
       END ASC,
       CASE WHEN (@lSortCol = 'EM_NAME' AND @SortOrder='DESC')
                  THEN EM_NAME
       END DESC,
CASE WHEN (@lSortCol = 'EM_SURNAME' AND @SortOrder='ASC')
                   THEN EM_SURNAME
       END ASC,
       CASE WHEN (@lSortCol = 'EM_SURNAME' AND @SortOrder='DESC')
                  THEN EM_SURNAME
       END DESC,
CASE WHEN (@lSortCol = 'EM_TEL' AND @SortOrder='ASC')
                   THEN EM_TEL
       END ASC,
       CASE WHEN (@lSortCol = 'EM_TEL' AND @SortOrder='DESC')
                  THEN EM_TEL
       END DESC,
CASE WHEN (@lSortCol = 'EM_ADDRESS' AND @SortOrder='ASC')
                   THEN EM_ADDRESS
       END ASC,
       CASE WHEN (@lSortCol = 'EM_ADDRESS' AND @SortOrder='DESC')
                  THEN EM_ADDRESS
       END DESC,
CASE WHEN (@lSortCol = 'EM_FLAG' AND @SortOrder='ASC')
                   THEN EM_FLAG
       END ASC,
       CASE WHEN (@lSortCol = 'EM_FLAG' AND @SortOrder='DESC')
                  THEN EM_FLAG
       END DESC,
CASE WHEN (@lSortCol = 'EM_ROLE_ADMIN' AND @SortOrder='ASC')
                   THEN EM_ROLE_ADMIN
       END ASC,
       CASE WHEN (@lSortCol = 'EM_ROLE_ADMIN' AND @SortOrder='DESC')
                  THEN EM_ROLE_ADMIN
       END DESC,
CASE WHEN (@lSortCol = 'EM_ROLE_USER' AND @SortOrder='ASC')
                   THEN EM_ROLE_USER
       END ASC,
       CASE WHEN (@lSortCol = 'EM_ROLE_USER' AND @SortOrder='DESC')
                  THEN EM_ROLE_USER
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 EM_ID,
 EM_PASS,
 EM_NAME,
 EM_SURNAME,
 EM_TEL,
 EM_ADDRESS,
 EM_FLAG,
 EM_ROLE_ADMIN,
 EM_ROLE_USER
 FROM STK_USER
WHERE
(@lEM_ID IS NULL OR EM_ID LIKE '%' +@lEM_ID + '%') AND 
(@lEM_PASS IS NULL OR EM_PASS LIKE '%' +@lEM_PASS + '%') AND 
(@lEM_NAME IS NULL OR EM_NAME LIKE '%' +@lEM_NAME + '%') AND 
(@lEM_SURNAME IS NULL OR EM_SURNAME LIKE '%' +@lEM_SURNAME + '%') AND 
(@lEM_TEL IS NULL OR EM_TEL LIKE '%' +@lEM_TEL + '%') AND 
(@lEM_ADDRESS IS NULL OR EM_ADDRESS LIKE '%' +@lEM_ADDRESS + '%') AND 
(@lEM_FLAG IS NULL OR EM_FLAG LIKE '%' +@lEM_FLAG + '%') AND 
(@lEM_ROLE_ADMIN IS NULL OR EM_ROLE_ADMIN LIKE '%' +@lEM_ROLE_ADMIN + '%') AND 
(@lEM_ROLE_USER IS NULL OR EM_ROLE_USER LIKE '%' +@lEM_ROLE_USER + '%') 
)
SELECT   RecordCount,
 ROWNUM,

EM_ID,
EM_PASS,
EM_NAME,
EM_SURNAME,
EM_TEL,
EM_ADDRESS,
EM_FLAG,
EM_ROLE_ADMIN,
EM_ROLE_USER FROM STK_USERResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetSTK_USER_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetSTK_USER_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [EM_ID] As KetText 
        
  FROM [STK_USER] where [EM_ID] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_PASS] As KetText 
        
  FROM [STK_USER] where [EM_PASS] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_NAME] As KetText 
        
  FROM [STK_USER] where [EM_NAME] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_SURNAME] As KetText 
        
  FROM [STK_USER] where [EM_SURNAME] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_TEL] As KetText 
        
  FROM [STK_USER] where [EM_TEL] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_ADDRESS] As KetText 
        
  FROM [STK_USER] where [EM_ADDRESS] like ''+@Key_word+'%' 
union all
SELECT  
      [EM_FLAG] As KetText 
        
  FROM [STK_USER] where [EM_FLAG] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetSTK_USER_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetSTK_USER_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'EM_ID') THEN CONVERT(varchar, EM_ID )  WHEN (@Column = 'EM_PASS') THEN CONVERT(varchar, EM_PASS )  WHEN (@Column = 'EM_NAME') THEN CONVERT(varchar, EM_NAME )  WHEN (@Column = 'EM_SURNAME') THEN CONVERT(varchar, EM_SURNAME )  WHEN (@Column = 'EM_TEL') THEN CONVERT(varchar, EM_TEL )  WHEN (@Column = 'EM_ADDRESS') THEN CONVERT(varchar, EM_ADDRESS )  WHEN (@Column = 'EM_FLAG') THEN CONVERT(varchar, EM_FLAG )  WHEN (@Column = 'EM_ROLE_ADMIN') THEN CONVERT(varchar, EM_ROLE_ADMIN )  WHEN (@Column = 'EM_ROLE_USER') THEN CONVERT(varchar, EM_ROLE_USER )END As KetText 
        
  FROM [STK_USER] where CASE  WHEN (@Column = 'EM_ID') THEN CONVERT(varchar, EM_ID )  WHEN (@Column = 'EM_PASS') THEN CONVERT(varchar, EM_PASS )  WHEN (@Column = 'EM_NAME') THEN CONVERT(varchar, EM_NAME )  WHEN (@Column = 'EM_SURNAME') THEN CONVERT(varchar, EM_SURNAME )  WHEN (@Column = 'EM_TEL') THEN CONVERT(varchar, EM_TEL )  WHEN (@Column = 'EM_ADDRESS') THEN CONVERT(varchar, EM_ADDRESS )  WHEN (@Column = 'EM_FLAG') THEN CONVERT(varchar, EM_FLAG )  WHEN (@Column = 'EM_ROLE_ADMIN') THEN CONVERT(varchar, EM_ROLE_ADMIN )  WHEN (@Column = 'EM_ROLE_USER') THEN CONVERT(varchar, EM_ROLE_USER )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetSTK_USER_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetSTK_USER_UpdateColumn] 
        @EM_ID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'EM_PASS'
           BEGIN 
           UPDATE   STK_USER SET EM_PASS=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_NAME'
           BEGIN 
           UPDATE   STK_USER SET EM_NAME=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_SURNAME'
           BEGIN 
           UPDATE   STK_USER SET EM_SURNAME=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_TEL'
           BEGIN 
           UPDATE   STK_USER SET EM_TEL=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_ADDRESS'
           BEGIN 
           UPDATE   STK_USER SET EM_ADDRESS=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_FLAG'
           BEGIN 
           UPDATE   STK_USER SET EM_FLAG=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_ROLE_ADMIN'
           BEGIN 
           UPDATE   STK_USER SET EM_ROLE_ADMIN=@Data where EM_ID = @EM_ID;  
         END 
         if  @Column = 'EM_ROLE_USER'
           BEGIN 
           UPDATE   STK_USER SET EM_ROLE_USER=@Data where EM_ID = @EM_ID;  
         END 
       END     

go


