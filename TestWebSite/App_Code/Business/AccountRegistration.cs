using System;
public class  AccountRegistration
 : BaseProperties{
Int32? _RequestId; 
public Int32? RequestId { get { return _RequestId; } set { _RequestId = value; } } 
 
String _UserName; 
public String UserName { get { return _UserName; } set { _UserName = value; } } 
 
String _Password; 
public String Password { get { return _Password; } set { _Password = value; } } 
 
String _FirstName; 
public String FirstName { get { return _FirstName; } set { _FirstName = value; } } 
 
String _LastName; 
public String LastName { get { return _LastName; } set { _LastName = value; } } 
 
String _Department; 
public String Department { get { return _Department; } set { _Department = value; } } 
 
String _Phone; 
public String Phone { get { return _Phone; } set { _Phone = value; } } 
 
String _Fax; 
public String Fax { get { return _Fax; } set { _Fax = value; } } 
 
String _Status; 
public String Status { get { return _Status; } set { _Status = value; } } 
 
}

