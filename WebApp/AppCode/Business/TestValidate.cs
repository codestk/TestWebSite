using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  TestValidate
 : BaseProperties{
Int32? _Id; 
public Int32? Id { get { return _Id; } set { _Id = value; } } 
 
String _Name; 
public String Name { get { return _Name; } set { _Name = value; } } 
 
String _NickName; 
public String NickName { get { return _NickName; } set { _NickName = value; } } 
 
String _Max; 
public String Max { get { return _Max; } set { _Max = value; } } 
 
Int32? _Item; 
public Int32? Item { get { return _Item; } set { _Item = value; } } 
 
DateTime? _CreateItme; 
public DateTime? CreateItme { get { return _CreateItme; } set { _CreateItme = value; } } 
 
} }
