using System;
using WebApp.Code.Utility;
namespace WebApp.Business
{
public class  APP_USER
 : BaseProperties{
String _UserID; 
public String UserID { get { return _UserID; } set { _UserID = value; } } 
 
String _Password; 
public String Password { get { return _Password; } set { _Password = value; } } 
 
String _FirstName; 
public String FirstName { get { return _FirstName; } set { _FirstName = value; } } 
 
String _LastName; 
public String LastName { get { return _LastName; } set { _LastName = value; } } 
 
String _Tel; 
public String Tel { get { return _Tel; } set { _Tel = value; } } 
 
Boolean? _FLAG; 
public Boolean? FLAG { get { return _FLAG; } set { _FLAG = value; } } 
 
Boolean? _RoleAdmin; 
public Boolean? RoleAdmin { get { return _RoleAdmin; } set { _RoleAdmin = value; } } 
 
Boolean? _RoleUser; 
public Boolean? RoleUser { get { return _RoleUser; } set { _RoleUser = value; } } 
 
Byte[] _Picture; 
public Byte[] Picture { get { return _Picture; } set { _Picture = value; } } 
 
DateTime? _Created; 
public DateTime? Created { get { return _Created; } set { _Created = value; } } 
 
} }
