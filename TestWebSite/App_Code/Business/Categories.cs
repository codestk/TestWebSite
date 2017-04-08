using System;
public class  Categories
 : BaseProperties{
Int32? _CategoryID; 
public Int32? CategoryID { get { return _CategoryID; } set { _CategoryID = value; } } 
 
String _CategoryName; 
public String CategoryName { get { return _CategoryName; } set { _CategoryName = value; } } 
 
Byte[] _Picture; 
public Byte[] Picture { get { return _Picture; } set { _Picture = value; } } 
 
String _Email; 
public String Email { get { return _Email; } set { _Email = value; } } 
 
Int32? _TestIn; 
public Int32? TestIn { get { return _TestIn; } set { _TestIn = value; } } 
 
}

