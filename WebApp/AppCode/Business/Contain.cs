using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  Contain
 : BaseProperties{
String _ContainID; 
public String ContainID { get { return _ContainID; } set { _ContainID = value; } } 
 
String _ContainName; 
public String ContainName { get { return _ContainName; } set { _ContainName = value; } } 
 
String _ContainDetail; 
public String ContainDetail { get { return _ContainDetail; } set { _ContainDetail = value; } } 
 
} }
