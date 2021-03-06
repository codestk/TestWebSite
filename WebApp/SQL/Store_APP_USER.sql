DROP PROCEDURE [dbo].[Sp_GetAPP_USERPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetAPP_USERPageWise]
/* Optional Filters for Dynamic Search*/
@UserID  [nvarchar](255) =null,
@Password  [nvarchar](255) =null,
@FirstName  [nvarchar](255) =null,
@LastName  [nvarchar](255) =null,
@Tel  [nvarchar](255) =null,
@FLAG  [bit] =null,
@RoleAdmin  [bit] =null,
@RoleUser  [bit] =null,
@Created  [datetime] =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'UserID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lUserID  [nvarchar](255) =null,
@lPassword  [nvarchar](255) =null,
@lFirstName  [nvarchar](255) =null,
@lLastName  [nvarchar](255) =null,
@lTel  [nvarchar](255) =null,
@lFLAG  [bit] =null,
@lRoleAdmin  [bit] =null,
@lRoleUser  [bit] =null,
@lCreated  [datetime] =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lUserID = LTRIM(RTRIM(@UserID))
SET @lPassword = LTRIM(RTRIM(@Password))
SET @lFirstName = LTRIM(RTRIM(@FirstName))
SET @lLastName = LTRIM(RTRIM(@LastName))
SET @lTel = LTRIM(RTRIM(@Tel))
SET @lFLAG = LTRIM(RTRIM(@FLAG))
SET @lRoleAdmin = LTRIM(RTRIM(@RoleAdmin))
SET @lRoleUser = LTRIM(RTRIM(@RoleUser))
SET @lCreated = LTRIM(RTRIM(@Created))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH APP_USERResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'UserID' AND @SortOrder='ASC')
                   THEN UserID
       END ASC,
       CASE WHEN (@lSortCol = 'UserID' AND @SortOrder='DESC')
                  THEN UserID
       END DESC,
CASE WHEN (@lSortCol = 'Password' AND @SortOrder='ASC')
                   THEN Password
       END ASC,
       CASE WHEN (@lSortCol = 'Password' AND @SortOrder='DESC')
                  THEN Password
       END DESC,
CASE WHEN (@lSortCol = 'FirstName' AND @SortOrder='ASC')
                   THEN FirstName
       END ASC,
       CASE WHEN (@lSortCol = 'FirstName' AND @SortOrder='DESC')
                  THEN FirstName
       END DESC,
CASE WHEN (@lSortCol = 'LastName' AND @SortOrder='ASC')
                   THEN LastName
       END ASC,
       CASE WHEN (@lSortCol = 'LastName' AND @SortOrder='DESC')
                  THEN LastName
       END DESC,
CASE WHEN (@lSortCol = 'Tel' AND @SortOrder='ASC')
                   THEN Tel
       END ASC,
       CASE WHEN (@lSortCol = 'Tel' AND @SortOrder='DESC')
                  THEN Tel
       END DESC,
CASE WHEN (@lSortCol = 'FLAG' AND @SortOrder='ASC')
                   THEN FLAG
       END ASC,
       CASE WHEN (@lSortCol = 'FLAG' AND @SortOrder='DESC')
                  THEN FLAG
       END DESC,
CASE WHEN (@lSortCol = 'RoleAdmin' AND @SortOrder='ASC')
                   THEN RoleAdmin
       END ASC,
       CASE WHEN (@lSortCol = 'RoleAdmin' AND @SortOrder='DESC')
                  THEN RoleAdmin
       END DESC,
CASE WHEN (@lSortCol = 'RoleUser' AND @SortOrder='ASC')
                   THEN RoleUser
       END ASC,
       CASE WHEN (@lSortCol = 'RoleUser' AND @SortOrder='DESC')
                  THEN RoleUser
       END DESC,
CASE WHEN (@lSortCol = 'Created' AND @SortOrder='ASC')
                   THEN Created
       END ASC,
       CASE WHEN (@lSortCol = 'Created' AND @SortOrder='DESC')
                  THEN Created
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 UserID,
 Password,
 FirstName,
 LastName,
 Tel,
 FLAG,
 RoleAdmin,
 RoleUser,
 Created
 FROM APP_USER
WHERE
(@lUserID IS NULL OR UserID LIKE '%' +@lUserID + '%') AND 
(@lPassword IS NULL OR Password LIKE '%' +@lPassword + '%') AND 
(@lFirstName IS NULL OR FirstName LIKE '%' +@lFirstName + '%') AND 
(@lLastName IS NULL OR LastName LIKE '%' +@lLastName + '%') AND 
(@lTel IS NULL OR Tel LIKE '%' +@lTel + '%') AND 
(@lFLAG IS NULL OR FLAG = @lFLAG) AND
(@lRoleAdmin IS NULL OR RoleAdmin = @lRoleAdmin) AND
(@lRoleUser IS NULL OR RoleUser = @lRoleUser) AND
(@lCreated IS NULL OR Created = @lCreated)
)
SELECT   RecordCount,
 ROWNUM,

UserID,
Password,
FirstName,
LastName,
Tel,
FLAG,
RoleAdmin,
RoleUser,
Created FROM APP_USERResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetAPP_USER_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetAPP_USER_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [UserID] As KetText 
        
  FROM [APP_USER] where [UserID] like ''+@Key_word+'%' 
union all
SELECT  
      [Password] As KetText 
        
  FROM [APP_USER] where [Password] like ''+@Key_word+'%' 
union all
SELECT  
      [FirstName] As KetText 
        
  FROM [APP_USER] where [FirstName] like ''+@Key_word+'%' 
union all
SELECT  
      [LastName] As KetText 
        
  FROM [APP_USER] where [LastName] like ''+@Key_word+'%' 
union all
SELECT  
      [Tel] As KetText 
        
  FROM [APP_USER] where [Tel] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetAPP_USER_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetAPP_USER_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'UserID') THEN CONVERT(varchar, UserID )  WHEN (@Column = 'Password') THEN CONVERT(varchar, Password )  WHEN (@Column = 'FirstName') THEN CONVERT(varchar, FirstName )  WHEN (@Column = 'LastName') THEN CONVERT(varchar, LastName )  WHEN (@Column = 'Tel') THEN CONVERT(varchar, Tel )  WHEN (@Column = 'FLAG') THEN CONVERT(varchar, FLAG )  WHEN (@Column = 'RoleAdmin') THEN CONVERT(varchar, RoleAdmin )  WHEN (@Column = 'RoleUser') THEN CONVERT(varchar, RoleUser )  WHEN (@Column = 'Created') THEN CONVERT(varchar, Created )END As KetText 
        
  FROM [APP_USER] where CASE  WHEN (@Column = 'UserID') THEN CONVERT(varchar, UserID )  WHEN (@Column = 'Password') THEN CONVERT(varchar, Password )  WHEN (@Column = 'FirstName') THEN CONVERT(varchar, FirstName )  WHEN (@Column = 'LastName') THEN CONVERT(varchar, LastName )  WHEN (@Column = 'Tel') THEN CONVERT(varchar, Tel )  WHEN (@Column = 'FLAG') THEN CONVERT(varchar, FLAG )  WHEN (@Column = 'RoleAdmin') THEN CONVERT(varchar, RoleAdmin )  WHEN (@Column = 'RoleUser') THEN CONVERT(varchar, RoleUser )  WHEN (@Column = 'Created') THEN CONVERT(varchar, Created )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetAPP_USER_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetAPP_USER_UpdateColumn] 
        @UserID  [nvarchar](255) ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'Password'
           BEGIN 
           UPDATE   APP_USER SET Password=@Data where UserID = @UserID;  
         END 
         if  @Column = 'FirstName'
           BEGIN 
           UPDATE   APP_USER SET FirstName=@Data where UserID = @UserID;  
         END 
         if  @Column = 'LastName'
           BEGIN 
           UPDATE   APP_USER SET LastName=@Data where UserID = @UserID;  
         END 
         if  @Column = 'Tel'
           BEGIN 
           UPDATE   APP_USER SET Tel=@Data where UserID = @UserID;  
         END 
         if  @Column = 'FLAG'
           BEGIN 
           UPDATE   APP_USER SET FLAG=@Data where UserID = @UserID;  
         END 
         if  @Column = 'RoleAdmin'
           BEGIN 
           UPDATE   APP_USER SET RoleAdmin=@Data where UserID = @UserID;  
         END 
         if  @Column = 'RoleUser'
           BEGIN 
           UPDATE   APP_USER SET RoleUser=@Data where UserID = @UserID;  
         END 
         if  @Column = 'Created'
           BEGIN 
           UPDATE   APP_USER SET Created=@Data where UserID = @UserID;  
         END 
       END     

go

