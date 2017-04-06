using System;
public class  Orders
 : BaseProperties{
Int32? _OrderID; 
public Int32? OrderID { get { return _OrderID; } set { _OrderID = value; } } 
 
String _CustomerID; 
public String CustomerID { get { return _CustomerID; } set { _CustomerID = value; } } 
 
Int32? _EmployeeID; 
public Int32? EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } } 
 
DateTime? _OrderDate; 
public DateTime? OrderDate { get { return _OrderDate; } set { _OrderDate = value; } } 
 
DateTime? _RequiredDate; 
public DateTime? RequiredDate { get { return _RequiredDate; } set { _RequiredDate = value; } } 
 
DateTime? _ShippedDate; 
public DateTime? ShippedDate { get { return _ShippedDate; } set { _ShippedDate = value; } } 
 
Int32? _ShipVia; 
public Int32? ShipVia { get { return _ShipVia; } set { _ShipVia = value; } } 
 
Decimal? _Freight; 
public Decimal? Freight { get { return _Freight; } set { _Freight = value; } } 
 
String _ShipName; 
public String ShipName { get { return _ShipName; } set { _ShipName = value; } } 
 
String _ShipAddress; 
public String ShipAddress { get { return _ShipAddress; } set { _ShipAddress = value; } } 
 
String _ShipCity; 
public String ShipCity { get { return _ShipCity; } set { _ShipCity = value; } } 
 
String _ShipRegion; 
public String ShipRegion { get { return _ShipRegion; } set { _ShipRegion = value; } } 
 
String _ShipPostalCode; 
public String ShipPostalCode { get { return _ShipPostalCode; } set { _ShipPostalCode = value; } } 
 
String _ShipCountry; 
public String ShipCountry { get { return _ShipCountry; } set { _ShipCountry = value; } } 
 
}

