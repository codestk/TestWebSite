DROP PROCEDURE [dbo].[Sp_GetAccountRegistrationPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetAccountRegistrationPageWise]
/* Optional Filters for Dynamic Search*/
@RequestId  [int] =null,
@UserName  [nvarchar](255) =null,
@Password  [nvarchar](255) =null,
@FirstName  [nvarchar](255) =null,
@LastName  [nvarchar](255) =null,
@Department  [nvarchar](255) =null,
@Phone  [nvarchar](255) =null,
@Fax  [nvarchar](255) =null,
@Status  [nvarchar](255) =null,
@CreateDate  [datetime] =null,
@DeleteDate  [datetime] =null,
@CancelDate  [datetime] =null,
@ApprovedDate  [datetime] =null,
@LastUpdate  [datetime] =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'RequestId',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lRequestId  [int] =null,
@lUserName  [nvarchar](255) =null,
@lPassword  [nvarchar](255) =null,
@lFirstName  [nvarchar](255) =null,
@lLastName  [nvarchar](255) =null,
@lDepartment  [nvarchar](255) =null,
@lPhone  [nvarchar](255) =null,
@lFax  [nvarchar](255) =null,
@lStatus  [nvarchar](255) =null,
@lCreateDate  [datetime] =null,
@lDeleteDate  [datetime] =null,
@lCancelDate  [datetime] =null,
@lApprovedDate  [datetime] =null,
@lLastUpdate  [datetime] =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lRequestId =@RequestId
SET @lUserName = LTRIM(RTRIM(@UserName))
SET @lPassword = LTRIM(RTRIM(@Password))
SET @lFirstName = LTRIM(RTRIM(@FirstName))
SET @lLastName = LTRIM(RTRIM(@LastName))
SET @lDepartment = LTRIM(RTRIM(@Department))
SET @lPhone = LTRIM(RTRIM(@Phone))
SET @lFax = LTRIM(RTRIM(@Fax))
SET @lStatus = LTRIM(RTRIM(@Status))
SET @lCreateDate = LTRIM(RTRIM(@CreateDate))
SET @lDeleteDate = LTRIM(RTRIM(@DeleteDate))
SET @lCancelDate = LTRIM(RTRIM(@CancelDate))
SET @lApprovedDate = LTRIM(RTRIM(@ApprovedDate))
SET @lLastUpdate = LTRIM(RTRIM(@LastUpdate))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH AccountRegistrationResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'RequestId' AND @SortOrder='ASC')
                   THEN RequestId
       END ASC,
       CASE WHEN (@lSortCol = 'RequestId' AND @SortOrder='DESC')
                  THEN RequestId
       END DESC,
CASE WHEN (@lSortCol = 'UserName' AND @SortOrder='ASC')
                   THEN UserName
       END ASC,
       CASE WHEN (@lSortCol = 'UserName' AND @SortOrder='DESC')
                  THEN UserName
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
CASE WHEN (@lSortCol = 'Department' AND @SortOrder='ASC')
                   THEN Department
       END ASC,
       CASE WHEN (@lSortCol = 'Department' AND @SortOrder='DESC')
                  THEN Department
       END DESC,
CASE WHEN (@lSortCol = 'Phone' AND @SortOrder='ASC')
                   THEN Phone
       END ASC,
       CASE WHEN (@lSortCol = 'Phone' AND @SortOrder='DESC')
                  THEN Phone
       END DESC,
CASE WHEN (@lSortCol = 'Fax' AND @SortOrder='ASC')
                   THEN Fax
       END ASC,
       CASE WHEN (@lSortCol = 'Fax' AND @SortOrder='DESC')
                  THEN Fax
       END DESC,
CASE WHEN (@lSortCol = 'Status' AND @SortOrder='ASC')
                   THEN Status
       END ASC,
       CASE WHEN (@lSortCol = 'Status' AND @SortOrder='DESC')
                  THEN Status
       END DESC,
CASE WHEN (@lSortCol = 'CreateDate' AND @SortOrder='ASC')
                   THEN CreateDate
       END ASC,
       CASE WHEN (@lSortCol = 'CreateDate' AND @SortOrder='DESC')
                  THEN CreateDate
       END DESC,
CASE WHEN (@lSortCol = 'DeleteDate' AND @SortOrder='ASC')
                   THEN DeleteDate
       END ASC,
       CASE WHEN (@lSortCol = 'DeleteDate' AND @SortOrder='DESC')
                  THEN DeleteDate
       END DESC,
CASE WHEN (@lSortCol = 'CancelDate' AND @SortOrder='ASC')
                   THEN CancelDate
       END ASC,
       CASE WHEN (@lSortCol = 'CancelDate' AND @SortOrder='DESC')
                  THEN CancelDate
       END DESC,
CASE WHEN (@lSortCol = 'ApprovedDate' AND @SortOrder='ASC')
                   THEN ApprovedDate
       END ASC,
       CASE WHEN (@lSortCol = 'ApprovedDate' AND @SortOrder='DESC')
                  THEN ApprovedDate
       END DESC,
CASE WHEN (@lSortCol = 'LastUpdate' AND @SortOrder='ASC')
                   THEN LastUpdate
       END ASC,
       CASE WHEN (@lSortCol = 'LastUpdate' AND @SortOrder='DESC')
                  THEN LastUpdate
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 RequestId,
 UserName,
 Password,
 FirstName,
 LastName,
 Department,
 Phone,
 Fax,
 Status,
 CreateDate,
 DeleteDate,
 CancelDate,
 ApprovedDate,
 LastUpdate
 FROM AccountRegistration
WHERE
(@lRequestId IS NULL OR RequestId = @lRequestId) AND
(@lUserName IS NULL OR UserName LIKE '%' +@lUserName + '%') AND 
(@lPassword IS NULL OR Password LIKE '%' +@lPassword + '%') AND 
(@lFirstName IS NULL OR FirstName LIKE '%' +@lFirstName + '%') AND 
(@lLastName IS NULL OR LastName LIKE '%' +@lLastName + '%') AND 
(@lDepartment IS NULL OR Department LIKE '%' +@lDepartment + '%') AND 
(@lPhone IS NULL OR Phone LIKE '%' +@lPhone + '%') AND 
(@lFax IS NULL OR Fax LIKE '%' +@lFax + '%') AND 
(@lStatus IS NULL OR Status LIKE '%' +@lStatus + '%') AND 
(@lCreateDate IS NULL OR CreateDate = @lCreateDate) AND
(@lDeleteDate IS NULL OR DeleteDate = @lDeleteDate) AND
(@lCancelDate IS NULL OR CancelDate = @lCancelDate) AND
(@lApprovedDate IS NULL OR ApprovedDate = @lApprovedDate) AND
(@lLastUpdate IS NULL OR LastUpdate = @lLastUpdate)
)
SELECT   RecordCount,
 ROWNUM,

RequestId,
UserName,
Password,
FirstName,
LastName,
Department,
Phone,
Fax,
Status,
CreateDate,
DeleteDate,
CancelDate,
ApprovedDate,
LastUpdate FROM AccountRegistrationResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetAccountRegistration_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetAccountRegistration_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [UserName] As KetText 
        
  FROM [AccountRegistration] where [UserName] like ''+@Key_word+'%' 
union all
SELECT  
      [Password] As KetText 
        
  FROM [AccountRegistration] where [Password] like ''+@Key_word+'%' 
union all
SELECT  
      [FirstName] As KetText 
        
  FROM [AccountRegistration] where [FirstName] like ''+@Key_word+'%' 
union all
SELECT  
      [LastName] As KetText 
        
  FROM [AccountRegistration] where [LastName] like ''+@Key_word+'%' 
union all
SELECT  
      [Department] As KetText 
        
  FROM [AccountRegistration] where [Department] like ''+@Key_word+'%' 
union all
SELECT  
      [Phone] As KetText 
        
  FROM [AccountRegistration] where [Phone] like ''+@Key_word+'%' 
union all
SELECT  
      [Fax] As KetText 
        
  FROM [AccountRegistration] where [Fax] like ''+@Key_word+'%' 
union all
SELECT  
      [Status] As KetText 
        
  FROM [AccountRegistration] where [Status] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetAccountRegistration_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetAccountRegistration_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'RequestId') THEN CONVERT(varchar, RequestId )  WHEN (@Column = 'UserName') THEN CONVERT(varchar, UserName )  WHEN (@Column = 'Password') THEN CONVERT(varchar, Password )  WHEN (@Column = 'FirstName') THEN CONVERT(varchar, FirstName )  WHEN (@Column = 'LastName') THEN CONVERT(varchar, LastName )  WHEN (@Column = 'Department') THEN CONVERT(varchar, Department )  WHEN (@Column = 'Phone') THEN CONVERT(varchar, Phone )  WHEN (@Column = 'Fax') THEN CONVERT(varchar, Fax )  WHEN (@Column = 'Status') THEN CONVERT(varchar, Status )  WHEN (@Column = 'CreateDate') THEN CONVERT(varchar, CreateDate )  WHEN (@Column = 'DeleteDate') THEN CONVERT(varchar, DeleteDate )  WHEN (@Column = 'CancelDate') THEN CONVERT(varchar, CancelDate )  WHEN (@Column = 'ApprovedDate') THEN CONVERT(varchar, ApprovedDate )  WHEN (@Column = 'LastUpdate') THEN CONVERT(varchar, LastUpdate )END As KetText 
        
  FROM [AccountRegistration] where CASE  WHEN (@Column = 'RequestId') THEN CONVERT(varchar, RequestId )  WHEN (@Column = 'UserName') THEN CONVERT(varchar, UserName )  WHEN (@Column = 'Password') THEN CONVERT(varchar, Password )  WHEN (@Column = 'FirstName') THEN CONVERT(varchar, FirstName )  WHEN (@Column = 'LastName') THEN CONVERT(varchar, LastName )  WHEN (@Column = 'Department') THEN CONVERT(varchar, Department )  WHEN (@Column = 'Phone') THEN CONVERT(varchar, Phone )  WHEN (@Column = 'Fax') THEN CONVERT(varchar, Fax )  WHEN (@Column = 'Status') THEN CONVERT(varchar, Status )  WHEN (@Column = 'CreateDate') THEN CONVERT(varchar, CreateDate )  WHEN (@Column = 'DeleteDate') THEN CONVERT(varchar, DeleteDate )  WHEN (@Column = 'CancelDate') THEN CONVERT(varchar, CancelDate )  WHEN (@Column = 'ApprovedDate') THEN CONVERT(varchar, ApprovedDate )  WHEN (@Column = 'LastUpdate') THEN CONVERT(varchar, LastUpdate )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetAccountRegistration_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetAccountRegistration_UpdateColumn] 
        @RequestId  [int] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'UserName'
           BEGIN 
           UPDATE   AccountRegistration SET UserName=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'Password'
           BEGIN 
           UPDATE   AccountRegistration SET Password=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'FirstName'
           BEGIN 
           UPDATE   AccountRegistration SET FirstName=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'LastName'
           BEGIN 
           UPDATE   AccountRegistration SET LastName=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'Department'
           BEGIN 
           UPDATE   AccountRegistration SET Department=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'Phone'
           BEGIN 
           UPDATE   AccountRegistration SET Phone=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'Fax'
           BEGIN 
           UPDATE   AccountRegistration SET Fax=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'Status'
           BEGIN 
           UPDATE   AccountRegistration SET Status=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'CreateDate'
           BEGIN 
           UPDATE   AccountRegistration SET CreateDate=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'DeleteDate'
           BEGIN 
           UPDATE   AccountRegistration SET DeleteDate=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'CancelDate'
           BEGIN 
           UPDATE   AccountRegistration SET CancelDate=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'ApprovedDate'
           BEGIN 
           UPDATE   AccountRegistration SET ApprovedDate=@Data where RequestId = @RequestId;  
         END 
         if  @Column = 'LastUpdate'
           BEGIN 
           UPDATE   AccountRegistration SET LastUpdate=@Data where RequestId = @RequestId;  
         END 
       END     

go


