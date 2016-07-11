using System;
public class  STK_USER
 : BaseProperties{
String _EM_ID; 
public String EM_ID { get { return _EM_ID; } set { _EM_ID = value; } } 
 
String _EM_PASS; 
public String EM_PASS { get { return _EM_PASS; } set { _EM_PASS = value; } } 
 
String _EM_NAME; 
public String EM_NAME { get { return _EM_NAME; } set { _EM_NAME = value; } } 
 
String _EM_SURNAME; 
public String EM_SURNAME { get { return _EM_SURNAME; } set { _EM_SURNAME = value; } } 
 
String _EM_TEL; 
public String EM_TEL { get { return _EM_TEL; } set { _EM_TEL = value; } } 
 
String _EM_ADDRESS; 
public String EM_ADDRESS { get { return _EM_ADDRESS; } set { _EM_ADDRESS = value; } } 
 
String _EM_FLAG; 
public String EM_FLAG { get { return _EM_FLAG; } set { _EM_FLAG = value; } } 
 
Int16? _EM_ROLE_ADMIN; 
public Int16? EM_ROLE_ADMIN { get { return _EM_ROLE_ADMIN; } set { _EM_ROLE_ADMIN = value; } } 
 
Int16? _EM_ROLE_USER; 
public Int16? EM_ROLE_USER { get { return _EM_ROLE_USER; } set { _EM_ROLE_USER = value; } } 
 
}

