using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  Source
 : BaseProperties{
String _SourceID; 
public String SourceID { get { return _SourceID; } set { _SourceID = value; } } 
 
String _SourceName; 
public String SourceName { get { return _SourceName; } set { _SourceName = value; } } 
 
String _SourceDetail; 
public String SourceDetail { get { return _SourceDetail; } set { _SourceDetail = value; } } 
 
} }
