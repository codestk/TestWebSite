using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  LineSize
 : BaseProperties{
String _LineSizeID; 
public String LineSizeID { get { return _LineSizeID; } set { _LineSizeID = value; } } 
 
String _LineSizeName; 
public String LineSizeName { get { return _LineSizeName; } set { _LineSizeName = value; } } 
 
String _LineSizeDetail; 
public String LineSizeDetail { get { return _LineSizeDetail; } set { _LineSizeDetail = value; } } 
 
} }
