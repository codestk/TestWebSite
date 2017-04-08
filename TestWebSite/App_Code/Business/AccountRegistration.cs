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
 
DateTime? _CreateDate; 
public DateTime? CreateDate { get { return _CreateDate; } set { _CreateDate = value; } } 
 
DateTime? _DeleteDate; 
public DateTime? DeleteDate { get { return _DeleteDate; } set { _DeleteDate = value; } } 
 
DateTime? _CancelDate; 
public DateTime? CancelDate { get { return _CancelDate; } set { _CancelDate = value; } } 
 
DateTime? _ApprovedDate; 
public DateTime? ApprovedDate { get { return _ApprovedDate; } set { _ApprovedDate = value; } } 
 
DateTime? _LastUpdate; 
public DateTime? LastUpdate { get { return _LastUpdate; } set { _LastUpdate = value; } } 
 
}

