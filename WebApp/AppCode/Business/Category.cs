using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  Category
 : BaseProperties{
String _CategoryID; 
public String CategoryID { get { return _CategoryID; } set { _CategoryID = value; } } 
 
String _CategoryName; 
public String CategoryName { get { return _CategoryName; } set { _CategoryName = value; } } 
 
String _CategoryDetail; 
public String CategoryDetail { get { return _CategoryDetail; } set { _CategoryDetail = value; } } 
 
} }
