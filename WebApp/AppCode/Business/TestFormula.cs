using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  TestFormula
 : BaseProperties{
String _TestFormulaID; 
public String TestFormulaID { get { return _TestFormulaID; } set { _TestFormulaID = value; } } 
 
String _TestFormulaName; 
public String TestFormulaName { get { return _TestFormulaName; } set { _TestFormulaName = value; } } 
 
String _TestFormulaDetail; 
public String TestFormulaDetail { get { return _TestFormulaDetail; } set { _TestFormulaDetail = value; } } 
 
} }
