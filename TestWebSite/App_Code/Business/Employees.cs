using System;
public class  Employees
 : BaseProperties{
Int32? _EmployeeID; 
public Int32? EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } } 
 
String _LastName; 
public String LastName { get { return _LastName; } set { _LastName = value; } } 
 
String _FirstName; 
public String FirstName { get { return _FirstName; } set { _FirstName = value; } } 
 
String _Title; 
public String Title { get { return _Title; } set { _Title = value; } } 
 
String _TitleOfCourtesy; 
public String TitleOfCourtesy { get { return _TitleOfCourtesy; } set { _TitleOfCourtesy = value; } } 
 
DateTime? _BirthDate; 
public DateTime? BirthDate { get { return _BirthDate; } set { _BirthDate = value; } } 
 
DateTime? _HireDate; 
public DateTime? HireDate { get { return _HireDate; } set { _HireDate = value; } } 
 
String _Address; 
public String Address { get { return _Address; } set { _Address = value; } } 
 
String _City; 
public String City { get { return _City; } set { _City = value; } } 
 
String _Region; 
public String Region { get { return _Region; } set { _Region = value; } } 
 
String _PostalCode; 
public String PostalCode { get { return _PostalCode; } set { _PostalCode = value; } } 
 
String _Country; 
public String Country { get { return _Country; } set { _Country = value; } } 
 
String _HomePhone; 
public String HomePhone { get { return _HomePhone; } set { _HomePhone = value; } } 
 
String _Extension; 
public String Extension { get { return _Extension; } set { _Extension = value; } } 
 
Byte[] _Photo; 
public Byte[] Photo { get { return _Photo; } set { _Photo = value; } } 
 
Int32? _ReportsTo; 
public Int32? ReportsTo { get { return _ReportsTo; } set { _ReportsTo = value; } } 
 
String _PhotoPath; 
public String PhotoPath { get { return _PhotoPath; } set { _PhotoPath = value; } } 
 
}

