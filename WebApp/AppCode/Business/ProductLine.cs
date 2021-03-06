using System;
using WebApp.Code.Utility;
using FluentValidation;
using WebApp.Business;
namespace WebApp.Business
{
public class  ProductLine
 : BaseProperties{
Decimal? _ProductLineId; 
public Decimal? ProductLineId { get { return _ProductLineId; } set { _ProductLineId = value; } } 
 
String _SourceID; 
public String SourceID { get { return _SourceID; } set { _SourceID = value; } } 
 
String _LineID; 
public String LineID { get { return _LineID; } set { _LineID = value; } } 
 
String _TestFormulaID; 
public String TestFormulaID { get { return _TestFormulaID; } set { _TestFormulaID = value; } } 
 
String _ContainID; 
public String ContainID { get { return _ContainID; } set { _ContainID = value; } } 
 
String _LineSizeID; 
public String LineSizeID { get { return _LineSizeID; } set { _LineSizeID = value; } } 
 
String _CustomerBrandID; 
public String CustomerBrandID { get { return _CustomerBrandID; } set { _CustomerBrandID = value; } } 
 
DateTime? _ManufacturingDate; 
public DateTime? ManufacturingDate { get { return _ManufacturingDate; } set { _ManufacturingDate = value; } } 
 
Int32? _ExpectItems; 
public Int32? ExpectItems { get { return _ExpectItems; } set { _ExpectItems = value; } } 
 
Int32? _ProcessItems; 
public Int32? ProcessItems { get { return _ProcessItems; } set { _ProcessItems = value; } } 
 
DateTime? _CreateDate; 
public DateTime? CreateDate { get { return _CreateDate; } set { _CreateDate = value; } } 
 
} }
