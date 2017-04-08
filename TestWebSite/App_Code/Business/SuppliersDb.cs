using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  SuppliersDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Suppliers _Suppliers;
public const string DataKey = "SupplierID";
public const string DataText = "CompanyName";
public const string DataValue = "SupplierID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Suppliers";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Suppliers Select(string SupplierID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Suppliers where SupplierID = @SupplierID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@SupplierID", SupplierID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Suppliers> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Suppliers "; 
sql += string.Format("  where ((''='{0}')or(SupplierID='{0}'))", _Suppliers.SupplierID);
sql += string.Format("  and ((''='{0}')or(CompanyName='{0}'))", _Suppliers.CompanyName);
sql += string.Format("  and ((''='{0}')or(ContactName='{0}'))", _Suppliers.ContactName);
sql += string.Format("  and ((''='{0}')or(ContactTitle='{0}'))", _Suppliers.ContactTitle);
sql += string.Format("  and ((''='{0}')or(Address='{0}'))", _Suppliers.Address);
sql += string.Format("  and ((''='{0}')or(City='{0}'))", _Suppliers.City);
sql += string.Format("  and ((''='{0}')or(Region='{0}'))", _Suppliers.Region);
sql += string.Format("  and ((''='{0}')or(PostalCode='{0}'))", _Suppliers.PostalCode);
sql += string.Format("  and ((''='{0}')or(Country='{0}'))", _Suppliers.Country);
sql += string.Format("  and ((''='{0}')or(Phone='{0}'))", _Suppliers.Phone);
sql += string.Format("  and ((''='{0}')or(Fax='{0}'))", _Suppliers.Fax);
sql += string.Format("  and ((''='{0}')or(HomePage='{0}'))", _Suppliers.HomePage);
if (sortExpression == null){
sql += string.Format(" order by SupplierID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Suppliers> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetSuppliersPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Suppliers(CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage) VALUES (@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax,@HomePage) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@CompanyName",_Suppliers.CompanyName)); prset.Add(Db.CreateParameterDb("@ContactName",_Suppliers.ContactName)); prset.Add(Db.CreateParameterDb("@ContactTitle",_Suppliers.ContactTitle)); prset.Add(Db.CreateParameterDb("@Address",_Suppliers.Address)); prset.Add(Db.CreateParameterDb("@City",_Suppliers.City)); prset.Add(Db.CreateParameterDb("@Region",_Suppliers.Region)); prset.Add(Db.CreateParameterDb("@PostalCode",_Suppliers.PostalCode)); prset.Add(Db.CreateParameterDb("@Country",_Suppliers.Country)); prset.Add(Db.CreateParameterDb("@Phone",_Suppliers.Phone)); prset.Add(Db.CreateParameterDb("@Fax",_Suppliers.Fax)); prset.Add(Db.CreateParameterDb("@HomePage",_Suppliers.HomePage));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@SupplierID",_Suppliers.SupplierID)); prset.Add(Db.CreateParameterDb("@CompanyName",_Suppliers.CompanyName)); prset.Add(Db.CreateParameterDb("@ContactName",_Suppliers.ContactName)); prset.Add(Db.CreateParameterDb("@ContactTitle",_Suppliers.ContactTitle)); prset.Add(Db.CreateParameterDb("@Address",_Suppliers.Address)); prset.Add(Db.CreateParameterDb("@City",_Suppliers.City)); prset.Add(Db.CreateParameterDb("@Region",_Suppliers.Region)); prset.Add(Db.CreateParameterDb("@PostalCode",_Suppliers.PostalCode)); prset.Add(Db.CreateParameterDb("@Country",_Suppliers.Country)); prset.Add(Db.CreateParameterDb("@Phone",_Suppliers.Phone)); prset.Add(Db.CreateParameterDb("@Fax",_Suppliers.Fax)); prset.Add(Db.CreateParameterDb("@HomePage",_Suppliers.HomePage));
var sql = @"UPDATE   Suppliers SET  CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone,Fax=@Fax,HomePage=@HomePage where SupplierID = @SupplierID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@SupplierID",_Suppliers.SupplierID));
var sql =@"DELETE FROM Suppliers where SupplierID=@SupplierID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Suppliers> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Suppliers> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Suppliers
{
RecordCount = temp.Field<Int32>("RecordCount"),SupplierID= temp.Field<Int32?>("SupplierID"), 
 CompanyName= temp.Field<String>("CompanyName"), 
 ContactName= temp.Field<String>("ContactName"), 
 ContactTitle= temp.Field<String>("ContactTitle"), 
 Address= temp.Field<String>("Address"), 
 City= temp.Field<String>("City"), 
 Region= temp.Field<String>("Region"), 
 PostalCode= temp.Field<String>("PostalCode"), 
 Country= temp.Field<String>("Country"), 
 Phone= temp.Field<String>("Phone"), 
 Fax= temp.Field<String>("Fax"), 
 HomePage= temp.Field<String>("HomePage"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@SupplierID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetSuppliers_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetSuppliers_Autocomplete"; 
        var prset = new List<IDataParameter>(); 
        prset.Add(Db.CreateParameterDb("@Key_word", Keyword)); 
 
        List<string> dataArray = new List<string>(); 
 
        DataSet ds = Db.GetDataSet(sql, prset,CommandType.StoredProcedure); 
        foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    }
  public List<string> GetKeyWordsOneColumn(string column, string keyword) 
  { 
          
 
  string sql = "SELECT  " + column + " FROM Suppliers where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
  List<string> dataArray = new List<string>(); 
 
 
  DataSet ds = Db.GetDataSet(sql); 
  foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    } 
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if ( _Suppliers.SupplierID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (SupplierID='{0}') )", _Suppliers.SupplierID); 
            } 
            if ( _Suppliers.CompanyName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (CompanyName='{0}') )", _Suppliers.CompanyName); 
            } 
            if ( _Suppliers.ContactName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ContactName='{0}') )", _Suppliers.ContactName); 
            } 
            if ( _Suppliers.ContactTitle!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ContactTitle='{0}') )", _Suppliers.ContactTitle); 
            } 
            if ( _Suppliers.Address!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Address='{0}') )", _Suppliers.Address); 
            } 
            if ( _Suppliers.City!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (City='{0}') )", _Suppliers.City); 
            } 
            if ( _Suppliers.Region!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Region='{0}') )", _Suppliers.Region); 
            } 
            if ( _Suppliers.PostalCode!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (PostalCode='{0}') )", _Suppliers.PostalCode); 
            } 
            if ( _Suppliers.Country!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Country='{0}') )", _Suppliers.Country); 
            } 
            if ( _Suppliers.Phone!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Phone='{0}') )", _Suppliers.Phone); 
            } 
            if ( _Suppliers.Fax!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Fax='{0}') )", _Suppliers.Fax); 
            } 
            if ( _Suppliers.HomePage!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (HomePage='{0}') )", _Suppliers.HomePage); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Suppliers.SupplierID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@SupplierID", _Suppliers.SupplierID));

            }
if (_Suppliers.CompanyName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@CompanyName", _Suppliers.CompanyName));

            }
if (_Suppliers.ContactName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ContactName", _Suppliers.ContactName));

            }
if (_Suppliers.ContactTitle != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ContactTitle", _Suppliers.ContactTitle));

            }
if (_Suppliers.Address != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Address", _Suppliers.Address));

            }
if (_Suppliers.City != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@City", _Suppliers.City));

            }
if (_Suppliers.Region != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Region", _Suppliers.Region));

            }
if (_Suppliers.PostalCode != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@PostalCode", _Suppliers.PostalCode));

            }
if (_Suppliers.Country != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Country", _Suppliers.Country));

            }
if (_Suppliers.Phone != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Phone", _Suppliers.Phone));

            }
if (_Suppliers.Fax != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Fax", _Suppliers.Fax));

            }
if (_Suppliers.HomePage != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@HomePage", _Suppliers.HomePage));

            }
/*Sort Order*/
  if (_SortExpression != null)
        {
           
            sqlStorePamameters.Add(Db.CreateParameterDb("@SortColumn", _SortExpression));
            sqlStorePamameters.Add(Db.CreateParameterDb("@SortOrder", _SortDirection));
        }


            return sqlStorePamameters;
        }
}

//Trasaction User
//bool output = false;
//    try
//    {
//        Db.OpenFbData();
//        Db.BeginTransaction();
//        MPO_ORDERS o1 = new MPO_ORDERS();
//o1 = _MPO_ORDERS;
//        int orid = o1.Save();
//MPO_ODERDETAILS o2 = new MPO_ODERDETAILS();
//o2.Save(orid, ODERDETAILS);
//        Db.CommitTransaction();
//        OR_ID = orid;
//        output = true;
//    }
//    catch (System.Exception ex)
//    {
//        Db.RollBackTransaction();
//        ErrorLogging.LogErrorToLogFile(ex, "");
//        throw ex;
//    }
//    return output;

