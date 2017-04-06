using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  EmployeesDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public Employees _Employees;
public const string DataKey = "EmployeeID";
public const string DataText = "LastName";
public const string DataValue = "EmployeeID";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM Employees";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public Employees Select(string EmployeeID) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM Employees where EmployeeID = @EmployeeID; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@EmployeeID", EmployeeID));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<Employees> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM Employees "; 
sql += string.Format("  where ((''='{0}')or(EmployeeID='{0}'))", _Employees.EmployeeID);
sql += string.Format("  and ((''='{0}')or(LastName='{0}'))", _Employees.LastName);
sql += string.Format("  and ((''='{0}')or(FirstName='{0}'))", _Employees.FirstName);
sql += string.Format("  and ((''='{0}')or(Title='{0}'))", _Employees.Title);
sql += string.Format("  and ((''='{0}')or(TitleOfCourtesy='{0}'))", _Employees.TitleOfCourtesy);
sql += string.Format("  and ((''='{0}')or(BirthDate='{0}'))", _Employees.BirthDate);
sql += string.Format("  and ((''='{0}')or(HireDate='{0}'))", _Employees.HireDate);
sql += string.Format("  and ((''='{0}')or(Address='{0}'))", _Employees.Address);
sql += string.Format("  and ((''='{0}')or(City='{0}'))", _Employees.City);
sql += string.Format("  and ((''='{0}')or(Region='{0}'))", _Employees.Region);
sql += string.Format("  and ((''='{0}')or(PostalCode='{0}'))", _Employees.PostalCode);
sql += string.Format("  and ((''='{0}')or(Country='{0}'))", _Employees.Country);
sql += string.Format("  and ((''='{0}')or(HomePhone='{0}'))", _Employees.HomePhone);
sql += string.Format("  and ((''='{0}')or(Extension='{0}'))", _Employees.Extension);
sql += string.Format("  and ((''='{0}')or(Photo='{0}'))", _Employees.Photo);
sql += string.Format("  and ((''='{0}')or(ReportsTo='{0}'))", _Employees.ReportsTo);
sql += string.Format("  and ((''='{0}')or(PhotoPath='{0}'))", _Employees.PhotoPath);
sql += string.Format("  and ((''='{0}')or(Email='{0}'))", _Employees.Email);
if (sortExpression == null){
sql += string.Format(" order by EmployeeID ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<Employees> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetEmployeesPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO Employees(LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath,Email) VALUES (@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@ReportsTo,@PhotoPath,@Email) ;SELECT SCOPE_IDENTITY();";
 prset.Add(Db.CreateParameterDb("@LastName",_Employees.LastName)); prset.Add(Db.CreateParameterDb("@FirstName",_Employees.FirstName)); prset.Add(Db.CreateParameterDb("@Title",_Employees.Title)); prset.Add(Db.CreateParameterDb("@TitleOfCourtesy",_Employees.TitleOfCourtesy)); prset.Add(Db.CreateParameterDb("@BirthDate",_Employees.BirthDate)); prset.Add(Db.CreateParameterDb("@HireDate",_Employees.HireDate)); prset.Add(Db.CreateParameterDb("@Address",_Employees.Address)); prset.Add(Db.CreateParameterDb("@City",_Employees.City)); prset.Add(Db.CreateParameterDb("@Region",_Employees.Region)); prset.Add(Db.CreateParameterDb("@PostalCode",_Employees.PostalCode)); prset.Add(Db.CreateParameterDb("@Country",_Employees.Country)); prset.Add(Db.CreateParameterDb("@HomePhone",_Employees.HomePhone)); prset.Add(Db.CreateParameterDb("@Extension",_Employees.Extension)); prset.Add(Db.CreateParameterDb("@ReportsTo",_Employees.ReportsTo)); prset.Add(Db.CreateParameterDb("@PhotoPath",_Employees.PhotoPath)); prset.Add(Db.CreateParameterDb("@Email",_Employees.Email));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@EmployeeID",_Employees.EmployeeID)); prset.Add(Db.CreateParameterDb("@LastName",_Employees.LastName)); prset.Add(Db.CreateParameterDb("@FirstName",_Employees.FirstName)); prset.Add(Db.CreateParameterDb("@Title",_Employees.Title)); prset.Add(Db.CreateParameterDb("@TitleOfCourtesy",_Employees.TitleOfCourtesy)); prset.Add(Db.CreateParameterDb("@BirthDate",_Employees.BirthDate)); prset.Add(Db.CreateParameterDb("@HireDate",_Employees.HireDate)); prset.Add(Db.CreateParameterDb("@Address",_Employees.Address)); prset.Add(Db.CreateParameterDb("@City",_Employees.City)); prset.Add(Db.CreateParameterDb("@Region",_Employees.Region)); prset.Add(Db.CreateParameterDb("@PostalCode",_Employees.PostalCode)); prset.Add(Db.CreateParameterDb("@Country",_Employees.Country)); prset.Add(Db.CreateParameterDb("@HomePhone",_Employees.HomePhone)); prset.Add(Db.CreateParameterDb("@Extension",_Employees.Extension)); prset.Add(Db.CreateParameterDb("@ReportsTo",_Employees.ReportsTo)); prset.Add(Db.CreateParameterDb("@PhotoPath",_Employees.PhotoPath)); prset.Add(Db.CreateParameterDb("@Email",_Employees.Email));
var sql = @"UPDATE   Employees SET  LastName=@LastName,FirstName=@FirstName,Title=@Title,TitleOfCourtesy=@TitleOfCourtesy,BirthDate=@BirthDate,HireDate=@HireDate,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,HomePhone=@HomePhone,Extension=@Extension,ReportsTo=@ReportsTo,PhotoPath=@PhotoPath,Email=@Email where EmployeeID = @EmployeeID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@EmployeeID",_Employees.EmployeeID));
var sql =@"DELETE FROM Employees where EmployeeID=@EmployeeID";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<Employees> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<Employees> q = (from temp in ds.Tables[0].AsEnumerable()
 select new Employees
{
RecordCount = temp.Field<Int32>("RecordCount"),EmployeeID= temp.Field<Int32?>("EmployeeID"), 
 LastName= temp.Field<String>("LastName"), 
 FirstName= temp.Field<String>("FirstName"), 
 Title= temp.Field<String>("Title"), 
 TitleOfCourtesy= temp.Field<String>("TitleOfCourtesy"), 
 BirthDate= temp.Field<DateTime?>("BirthDate"), 
 HireDate= temp.Field<DateTime?>("HireDate"), 
 Address= temp.Field<String>("Address"), 
 City= temp.Field<String>("City"), 
 Region= temp.Field<String>("Region"), 
 PostalCode= temp.Field<String>("PostalCode"), 
 Country= temp.Field<String>("Country"), 
 HomePhone= temp.Field<String>("HomePhone"), 
 Extension= temp.Field<String>("Extension"), 
 ReportsTo= temp.Field<Int32?>("ReportsTo"), 
 PhotoPath= temp.Field<String>("PhotoPath"), 
 Email= temp.Field<String>("Email"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@EmployeeID", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetEmployees_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetEmployees_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM Employees where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
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
            if ( _Employees.EmployeeID!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (EmployeeID='{0}') )", _Employees.EmployeeID); 
            } 
            if ( _Employees.LastName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (LastName='{0}') )", _Employees.LastName); 
            } 
            if ( _Employees.FirstName!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (FirstName='{0}') )", _Employees.FirstName); 
            } 
            if ( _Employees.Title!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Title='{0}') )", _Employees.Title); 
            } 
            if ( _Employees.TitleOfCourtesy!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (TitleOfCourtesy='{0}') )", _Employees.TitleOfCourtesy); 
            } 
            if ( _Employees.BirthDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (BirthDate='{0}') )", _Employees.BirthDate); 
            } 
            if ( _Employees.HireDate!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (HireDate='{0}') )", _Employees.HireDate); 
            } 
            if ( _Employees.Address!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Address='{0}') )", _Employees.Address); 
            } 
            if ( _Employees.City!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (City='{0}') )", _Employees.City); 
            } 
            if ( _Employees.Region!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Region='{0}') )", _Employees.Region); 
            } 
            if ( _Employees.PostalCode!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (PostalCode='{0}') )", _Employees.PostalCode); 
            } 
            if ( _Employees.Country!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Country='{0}') )", _Employees.Country); 
            } 
            if ( _Employees.HomePhone!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (HomePhone='{0}') )", _Employees.HomePhone); 
            } 
            if ( _Employees.Extension!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Extension='{0}') )", _Employees.Extension); 
            } 
            if ( _Employees.Photo!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Photo='{0}') )", _Employees.Photo); 
            } 
            if ( _Employees.ReportsTo!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (ReportsTo='{0}') )", _Employees.ReportsTo); 
            } 
            if ( _Employees.PhotoPath!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (PhotoPath='{0}') )", _Employees.PhotoPath); 
            } 
            if ( _Employees.Email!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (Email='{0}') )", _Employees.Email); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_Employees.EmployeeID != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@EmployeeID", _Employees.EmployeeID));

            }
if (_Employees.LastName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@LastName", _Employees.LastName));

            }
if (_Employees.FirstName != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@FirstName", _Employees.FirstName));

            }
if (_Employees.Title != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Title", _Employees.Title));

            }
if (_Employees.TitleOfCourtesy != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@TitleOfCourtesy", _Employees.TitleOfCourtesy));

            }
if (_Employees.BirthDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@BirthDate", _Employees.BirthDate));

            }
if (_Employees.HireDate != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@HireDate", _Employees.HireDate));

            }
if (_Employees.Address != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Address", _Employees.Address));

            }
if (_Employees.City != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@City", _Employees.City));

            }
if (_Employees.Region != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Region", _Employees.Region));

            }
if (_Employees.PostalCode != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@PostalCode", _Employees.PostalCode));

            }
if (_Employees.Country != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Country", _Employees.Country));

            }
if (_Employees.HomePhone != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@HomePhone", _Employees.HomePhone));

            }
if (_Employees.Extension != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Extension", _Employees.Extension));

            }
if (_Employees.Photo != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Photo", _Employees.Photo));

            }
if (_Employees.ReportsTo != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@ReportsTo", _Employees.ReportsTo));

            }
if (_Employees.PhotoPath != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@PhotoPath", _Employees.PhotoPath));

            }
if (_Employees.Email != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@Email", _Employees.Email));

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

