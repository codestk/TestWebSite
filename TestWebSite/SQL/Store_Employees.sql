DROP PROCEDURE [dbo].[Sp_GetEmployeesPageWise];
go
CREATE PROCEDURE [dbo].[Sp_GetEmployeesPageWise]
/* Optional Filters for Dynamic Search*/
@EmployeeID  [int] =null,
@LastName  [nvarchar](255) =null,
@FirstName  [nvarchar](255) =null,
@Title  [nvarchar](255) =null,
@TitleOfCourtesy  [nvarchar](255) =null,
@BirthDate  [datetime] =null,
@HireDate  [datetime] =null,
@Address  [nvarchar](255) =null,
@City  [nvarchar](255) =null,
@Region  [nvarchar](255) =null,
@PostalCode  [nvarchar](255) =null,
@Country  [nvarchar](255) =null,
@HomePhone  [nvarchar](255) =null,
@Extension  [nvarchar](255) =null,
@ReportsTo  [int] =null,
@PhotoPath  [nvarchar](255) =null,
/*– Pagination Parameters */
@PageIndex INT = 1 ,
@PageSize INT = 10 ,
/*– Sorting Parameters */
@SortColumn NVARCHAR(20) = 'EmployeeID',
@SortOrder NVARCHAR(4) ='ASC'
AS  
BEGIN  
 SET NOCOUNT ON;  
 
  
 
 
/*–Declaring Local Variables corresponding to parameters for modification */
DECLARE @lEmployeeID  [int] =null,
@lLastName  [nvarchar](255) =null,
@lFirstName  [nvarchar](255) =null,
@lTitle  [nvarchar](255) =null,
@lTitleOfCourtesy  [nvarchar](255) =null,
@lBirthDate  [datetime] =null,
@lHireDate  [datetime] =null,
@lAddress  [nvarchar](255) =null,
@lCity  [nvarchar](255) =null,
@lRegion  [nvarchar](255) =null,
@lPostalCode  [nvarchar](255) =null,
@lCountry  [nvarchar](255) =null,
@lHomePhone  [nvarchar](255) =null,
@lExtension  [nvarchar](255) =null,
@lReportsTo  [int] =null,
@lPhotoPath  [nvarchar](255) =null,
@lPageNbr INT,
@lPageSize INT,
@lSortCol NVARCHAR(20),
@lFirstRec INT,
@lLastRec INT,
@lTotalRows INT
/*Setting Local Variables*/
SET @lEmployeeID =@EmployeeID
SET @lLastName = LTRIM(RTRIM(@LastName))
SET @lFirstName = LTRIM(RTRIM(@FirstName))
SET @lTitle = LTRIM(RTRIM(@Title))
SET @lTitleOfCourtesy = LTRIM(RTRIM(@TitleOfCourtesy))
SET @lBirthDate = LTRIM(RTRIM(@BirthDate))
SET @lHireDate = LTRIM(RTRIM(@HireDate))
SET @lAddress = LTRIM(RTRIM(@Address))
SET @lCity = LTRIM(RTRIM(@City))
SET @lRegion = LTRIM(RTRIM(@Region))
SET @lPostalCode = LTRIM(RTRIM(@PostalCode))
SET @lCountry = LTRIM(RTRIM(@Country))
SET @lHomePhone = LTRIM(RTRIM(@HomePhone))
SET @lExtension = LTRIM(RTRIM(@Extension))
SET @lReportsTo =@ReportsTo
SET @lPhotoPath = LTRIM(RTRIM(@PhotoPath))
SET @lPageNbr = @PageIndex
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
 
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLastRec = ( @lPageNbr * @lPageSize + 1 )
    SET @lTotalRows = @lFirstRec - @lLastRec + 1
; WITH EmployeesResult
AS(
SELECT ROW_NUMBER() OVER(ORDER BY 

CASE WHEN (@lSortCol = 'EmployeeID' AND @SortOrder='ASC')
                   THEN EmployeeID
       END ASC,
       CASE WHEN (@lSortCol = 'EmployeeID' AND @SortOrder='DESC')
                  THEN EmployeeID
       END DESC,
CASE WHEN (@lSortCol = 'LastName' AND @SortOrder='ASC')
                   THEN LastName
       END ASC,
       CASE WHEN (@lSortCol = 'LastName' AND @SortOrder='DESC')
                  THEN LastName
       END DESC,
CASE WHEN (@lSortCol = 'FirstName' AND @SortOrder='ASC')
                   THEN FirstName
       END ASC,
       CASE WHEN (@lSortCol = 'FirstName' AND @SortOrder='DESC')
                  THEN FirstName
       END DESC,
CASE WHEN (@lSortCol = 'Title' AND @SortOrder='ASC')
                   THEN Title
       END ASC,
       CASE WHEN (@lSortCol = 'Title' AND @SortOrder='DESC')
                  THEN Title
       END DESC,
CASE WHEN (@lSortCol = 'TitleOfCourtesy' AND @SortOrder='ASC')
                   THEN TitleOfCourtesy
       END ASC,
       CASE WHEN (@lSortCol = 'TitleOfCourtesy' AND @SortOrder='DESC')
                  THEN TitleOfCourtesy
       END DESC,
CASE WHEN (@lSortCol = 'BirthDate' AND @SortOrder='ASC')
                   THEN BirthDate
       END ASC,
       CASE WHEN (@lSortCol = 'BirthDate' AND @SortOrder='DESC')
                  THEN BirthDate
       END DESC,
CASE WHEN (@lSortCol = 'HireDate' AND @SortOrder='ASC')
                   THEN HireDate
       END ASC,
       CASE WHEN (@lSortCol = 'HireDate' AND @SortOrder='DESC')
                  THEN HireDate
       END DESC,
CASE WHEN (@lSortCol = 'Address' AND @SortOrder='ASC')
                   THEN Address
       END ASC,
       CASE WHEN (@lSortCol = 'Address' AND @SortOrder='DESC')
                  THEN Address
       END DESC,
CASE WHEN (@lSortCol = 'City' AND @SortOrder='ASC')
                   THEN City
       END ASC,
       CASE WHEN (@lSortCol = 'City' AND @SortOrder='DESC')
                  THEN City
       END DESC,
CASE WHEN (@lSortCol = 'Region' AND @SortOrder='ASC')
                   THEN Region
       END ASC,
       CASE WHEN (@lSortCol = 'Region' AND @SortOrder='DESC')
                  THEN Region
       END DESC,
CASE WHEN (@lSortCol = 'PostalCode' AND @SortOrder='ASC')
                   THEN PostalCode
       END ASC,
       CASE WHEN (@lSortCol = 'PostalCode' AND @SortOrder='DESC')
                  THEN PostalCode
       END DESC,
CASE WHEN (@lSortCol = 'Country' AND @SortOrder='ASC')
                   THEN Country
       END ASC,
       CASE WHEN (@lSortCol = 'Country' AND @SortOrder='DESC')
                  THEN Country
       END DESC,
CASE WHEN (@lSortCol = 'HomePhone' AND @SortOrder='ASC')
                   THEN HomePhone
       END ASC,
       CASE WHEN (@lSortCol = 'HomePhone' AND @SortOrder='DESC')
                  THEN HomePhone
       END DESC,
CASE WHEN (@lSortCol = 'Extension' AND @SortOrder='ASC')
                   THEN Extension
       END ASC,
       CASE WHEN (@lSortCol = 'Extension' AND @SortOrder='DESC')
                  THEN Extension
       END DESC,
CASE WHEN (@lSortCol = 'ReportsTo' AND @SortOrder='ASC')
                   THEN ReportsTo
       END ASC,
       CASE WHEN (@lSortCol = 'ReportsTo' AND @SortOrder='DESC')
                  THEN ReportsTo
       END DESC,
CASE WHEN (@lSortCol = 'PhotoPath' AND @SortOrder='ASC')
                   THEN PhotoPath
       END ASC,
       CASE WHEN (@lSortCol = 'PhotoPath' AND @SortOrder='DESC')
                  THEN PhotoPath
       END DESC  ) AS ROWNUM,
Count(*) over() AS RecordCount,

 EmployeeID,
 LastName,
 FirstName,
 Title,
 TitleOfCourtesy,
 BirthDate,
 HireDate,
 Address,
 City,
 Region,
 PostalCode,
 Country,
 HomePhone,
 Extension,
 ReportsTo,
 PhotoPath
 FROM Employees
WHERE
(@lEmployeeID IS NULL OR EmployeeID = @lEmployeeID) AND
(@lLastName IS NULL OR LastName LIKE '%' +@lLastName + '%') AND 
(@lFirstName IS NULL OR FirstName LIKE '%' +@lFirstName + '%') AND 
(@lTitle IS NULL OR Title LIKE '%' +@lTitle + '%') AND 
(@lTitleOfCourtesy IS NULL OR TitleOfCourtesy LIKE '%' +@lTitleOfCourtesy + '%') AND 
(@lBirthDate IS NULL OR BirthDate = @lBirthDate) AND
(@lHireDate IS NULL OR HireDate = @lHireDate) AND
(@lAddress IS NULL OR Address LIKE '%' +@lAddress + '%') AND 
(@lCity IS NULL OR City LIKE '%' +@lCity + '%') AND 
(@lRegion IS NULL OR Region LIKE '%' +@lRegion + '%') AND 
(@lPostalCode IS NULL OR PostalCode LIKE '%' +@lPostalCode + '%') AND 
(@lCountry IS NULL OR Country LIKE '%' +@lCountry + '%') AND 
(@lHomePhone IS NULL OR HomePhone LIKE '%' +@lHomePhone + '%') AND 
(@lExtension IS NULL OR Extension LIKE '%' +@lExtension + '%') AND 
(@lReportsTo IS NULL OR ReportsTo = @lReportsTo) AND
(@lPhotoPath IS NULL OR PhotoPath LIKE '%' +@lPhotoPath + '%') 
)
SELECT   RecordCount,
 ROWNUM,

EmployeeID,
LastName,
FirstName,
Title,
TitleOfCourtesy,
BirthDate,
HireDate,
Address,
City,
Region,
PostalCode,
Country,
HomePhone,
Extension,
ReportsTo,
PhotoPath FROM EmployeesResult
 WHERE
         ROWNUM > @lFirstRec
               AND ROWNUM < @lLastRec
 ORDER BY ROWNUM ASC
END
GO


go

DROP PROCEDURE [dbo].[Sp_GetEmployees_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetEmployees_Autocomplete]
     @Key_word    nvarchar(50) 
  
  
AS    
BEGIN    
 SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      [LastName] As KetText 
        
  FROM [Employees] where [LastName] like ''+@Key_word+'%' 
union all
SELECT  
      [FirstName] As KetText 
        
  FROM [Employees] where [FirstName] like ''+@Key_word+'%' 
union all
SELECT  
      [Title] As KetText 
        
  FROM [Employees] where [Title] like ''+@Key_word+'%' 
union all
SELECT  
      [TitleOfCourtesy] As KetText 
        
  FROM [Employees] where [TitleOfCourtesy] like ''+@Key_word+'%' 
union all
SELECT  
      [Address] As KetText 
        
  FROM [Employees] where [Address] like ''+@Key_word+'%' 
union all
SELECT  
      [City] As KetText 
        
  FROM [Employees] where [City] like ''+@Key_word+'%' 
union all
SELECT  
      [Region] As KetText 
        
  FROM [Employees] where [Region] like ''+@Key_word+'%' 
union all
SELECT  
      [PostalCode] As KetText 
        
  FROM [Employees] where [PostalCode] like ''+@Key_word+'%' 
union all
SELECT  
      [Country] As KetText 
        
  FROM [Employees] where [Country] like ''+@Key_word+'%' 
union all
SELECT  
      [HomePhone] As KetText 
        
  FROM [Employees] where [HomePhone] like ''+@Key_word+'%' 
union all
SELECT  
      [Extension] As KetText 
        
  FROM [Employees] where [Extension] like ''+@Key_word+'%' 
union all
SELECT  
      [PhotoPath] As KetText 
        
  FROM [Employees] where [PhotoPath] like ''+@Key_word+'%' 

  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetEmployees_Autocomplete];
go
CREATE PROCEDURE [dbo].[Sp_GetEmployees_Autocomplete]
@Column  nvarchar(50),@keyword nvarchar(50)  
  
AS    
BEGIN    
SET NOCOUNT ON;    
   
 select top 20 KetText,count(*) as NumberOfkey from  
( 
SELECT  
      CASE  WHEN (@Column = 'EmployeeID') THEN CONVERT(varchar, EmployeeID )  WHEN (@Column = 'LastName') THEN CONVERT(varchar, LastName )  WHEN (@Column = 'FirstName') THEN CONVERT(varchar, FirstName )  WHEN (@Column = 'Title') THEN CONVERT(varchar, Title )  WHEN (@Column = 'TitleOfCourtesy') THEN CONVERT(varchar, TitleOfCourtesy )  WHEN (@Column = 'BirthDate') THEN CONVERT(varchar, BirthDate )  WHEN (@Column = 'HireDate') THEN CONVERT(varchar, HireDate )  WHEN (@Column = 'Address') THEN CONVERT(varchar, Address )  WHEN (@Column = 'City') THEN CONVERT(varchar, City )  WHEN (@Column = 'Region') THEN CONVERT(varchar, Region )  WHEN (@Column = 'PostalCode') THEN CONVERT(varchar, PostalCode )  WHEN (@Column = 'Country') THEN CONVERT(varchar, Country )  WHEN (@Column = 'HomePhone') THEN CONVERT(varchar, HomePhone )  WHEN (@Column = 'Extension') THEN CONVERT(varchar, Extension )  WHEN (@Column = 'ReportsTo') THEN CONVERT(varchar, ReportsTo )  WHEN (@Column = 'PhotoPath') THEN CONVERT(varchar, PhotoPath )END As KetText 
        
  FROM [Employees] where CASE  WHEN (@Column = 'EmployeeID') THEN CONVERT(varchar, EmployeeID )  WHEN (@Column = 'LastName') THEN CONVERT(varchar, LastName )  WHEN (@Column = 'FirstName') THEN CONVERT(varchar, FirstName )  WHEN (@Column = 'Title') THEN CONVERT(varchar, Title )  WHEN (@Column = 'TitleOfCourtesy') THEN CONVERT(varchar, TitleOfCourtesy )  WHEN (@Column = 'BirthDate') THEN CONVERT(varchar, BirthDate )  WHEN (@Column = 'HireDate') THEN CONVERT(varchar, HireDate )  WHEN (@Column = 'Address') THEN CONVERT(varchar, Address )  WHEN (@Column = 'City') THEN CONVERT(varchar, City )  WHEN (@Column = 'Region') THEN CONVERT(varchar, Region )  WHEN (@Column = 'PostalCode') THEN CONVERT(varchar, PostalCode )  WHEN (@Column = 'Country') THEN CONVERT(varchar, Country )  WHEN (@Column = 'HomePhone') THEN CONVERT(varchar, HomePhone )  WHEN (@Column = 'Extension') THEN CONVERT(varchar, Extension )  WHEN (@Column = 'ReportsTo') THEN CONVERT(varchar, ReportsTo )  WHEN (@Column = 'PhotoPath') THEN CONVERT(varchar, PhotoPath )END like ''+@keyword+'%' 
  )KeyTable  
  group by KetText 
  order by count(*) desc  
 
END    
   



DROP PROCEDURE [dbo].[Sp_GetEmployees_UpdateColumn];

go

  
       
      create PROCEDURE [dbo].[Sp_GetEmployees_UpdateColumn] 
        @EmployeeID  [int] ,@Column  nvarchar(max),@Data nvarchar(max)   
   AS     
       BEGIN     
       --SET NOCOUNT ON;     
         
         if  @Column = 'LastName'
           BEGIN 
           UPDATE   Employees SET LastName=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'FirstName'
           BEGIN 
           UPDATE   Employees SET FirstName=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'Title'
           BEGIN 
           UPDATE   Employees SET Title=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'TitleOfCourtesy'
           BEGIN 
           UPDATE   Employees SET TitleOfCourtesy=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'BirthDate'
           BEGIN 
           UPDATE   Employees SET BirthDate=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'HireDate'
           BEGIN 
           UPDATE   Employees SET HireDate=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'Address'
           BEGIN 
           UPDATE   Employees SET Address=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'City'
           BEGIN 
           UPDATE   Employees SET City=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'Region'
           BEGIN 
           UPDATE   Employees SET Region=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'PostalCode'
           BEGIN 
           UPDATE   Employees SET PostalCode=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'Country'
           BEGIN 
           UPDATE   Employees SET Country=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'HomePhone'
           BEGIN 
           UPDATE   Employees SET HomePhone=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'Extension'
           BEGIN 
           UPDATE   Employees SET Extension=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'ReportsTo'
           BEGIN 
           UPDATE   Employees SET ReportsTo=@Data where EmployeeID = @EmployeeID;  
         END 
         if  @Column = 'PhotoPath'
           BEGIN 
           UPDATE   Employees SET PhotoPath=@Data where EmployeeID = @EmployeeID;  
         END 
       END     

go


