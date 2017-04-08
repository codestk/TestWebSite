using System;
public class  Products
 : BaseProperties{
Int32? _ProductID; 
public Int32? ProductID { get { return _ProductID; } set { _ProductID = value; } } 
 
String _ProductName; 
public String ProductName { get { return _ProductName; } set { _ProductName = value; } } 
 
Int32? _SupplierID; 
public Int32? SupplierID { get { return _SupplierID; } set { _SupplierID = value; } } 
 
Int32? _CategoryID; 
public Int32? CategoryID { get { return _CategoryID; } set { _CategoryID = value; } } 
 
String _QuantityPerUnit; 
public String QuantityPerUnit { get { return _QuantityPerUnit; } set { _QuantityPerUnit = value; } } 
 
Decimal? _UnitPrice; 
public Decimal? UnitPrice { get { return _UnitPrice; } set { _UnitPrice = value; } } 
 
Int16? _UnitsInStock; 
public Int16? UnitsInStock { get { return _UnitsInStock; } set { _UnitsInStock = value; } } 
 
Int16? _UnitsOnOrder; 
public Int16? UnitsOnOrder { get { return _UnitsOnOrder; } set { _UnitsOnOrder = value; } } 
 
Int16? _ReorderLevel; 
public Int16? ReorderLevel { get { return _ReorderLevel; } set { _ReorderLevel = value; } } 
 
Boolean? _Discontinued; 
public Boolean? Discontinued { get { return _Discontinued; } set { _Discontinued = value; } } 
 
}

