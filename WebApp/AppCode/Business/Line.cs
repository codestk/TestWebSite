using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  Line
 : BaseProperties{
String _LineID; 
public String LineID { get { return _LineID; } set { _LineID = value; } } 
 
String _LineName; 
public String LineName { get { return _LineName; } set { _LineName = value; } } 
 
String _LineDetail; 
public String LineDetail { get { return _LineDetail; } set { _LineDetail = value; } } 
 
} }
