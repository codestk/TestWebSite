using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  CustomerBrand
 : BaseProperties{
String _CustomerBrandID; 
public String CustomerBrandID { get { return _CustomerBrandID; } set { _CustomerBrandID = value; } } 
 
String _CustomerBrandName; 
public String CustomerBrandName { get { return _CustomerBrandName; } set { _CustomerBrandName = value; } } 
 
String _CustomerBrandDetail; 
public String CustomerBrandDetail { get { return _CustomerBrandDetail; } set { _CustomerBrandDetail = value; } } 
 
} }
