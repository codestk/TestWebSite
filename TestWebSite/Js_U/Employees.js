var EmployeesService = {}; 
(function () { 
    var url = "EmployeesService.asmx/"; 
 
    this.SaveColumn =  function (id, column, value) { 
            var result; 
            ////data "{ssss:1,ddddd:1}" 
            var tag = '{id:"' + id + '",column:"' + column + '",value:"' + value + '"}'; 
            var F = CallServices(url + "SaveColumn", tag, false, function (msg) { 
                result = msg.d; 
            }); 
            return result; 
        };//SaveColumn 
   
   
 this.GetKeyWordsAllColumn = function (keyword) { 
        var result; 
        ////data "{ssss:1,ddddd:1}"   
        var tag = '{keyword:"' + keyword + '"}'; 
        var F = CallServices(url + "GetKeyWordsAllColumn", tag, false, function (msg) { 
            result = msg.d; 
        }); 
        return result; 
    };//GetKeyWordsAllColumn  
   
   
 this.GetKeyWordsOneColumn = function (column,keyword) { 
        var result; 
        ////data "{ssss:1,ddddd:1}"   
 var tag = '{column:"' + column + '",keyword:"' + keyword + '"}';
        var F = CallServices(url + "GetKeyWordsOneColumn", tag, false, function (msg) { 
            result = msg.d; 
        }); 
        return result; 
    };//GetKeyWordsOneColumn  
   
  this.Search = function (PageIndex,PageSize,SortExpression,SortDirection,EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath,RederTable_Pagger) {
        var result;

        var tag = '{PageIndex:"'+PageIndex+'",PageSize:"'+PageSize+'",SortExpression:"'+SortExpression+'",SortDirection:"'+SortDirection+'",EmployeeID:"' + EmployeeID + '",LastName:"' + LastName + '",FirstName:"' + FirstName + '",Title:"' + Title + '",TitleOfCourtesy:"' + TitleOfCourtesy + '",BirthDate:"' + BirthDate + '",HireDate:"' + HireDate + '",Address:"' + Address + '",City:"' + City + '",Region:"' + Region + '",PostalCode:"' + PostalCode + '",Country:"' + Country + '",HomePhone:"' + HomePhone + '",Extension:"' + Extension + '",ReportsTo:"' + ReportsTo + '",PhotoPath:"' + PhotoPath + '"}';
        var F = CallServices(url + "Search", tag, true, function (msg) {
            result = msg.d;

            RederTable_Pagger(result);
        });
        return result;
    };//Save
this.Save = function(EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath)
{

            var result;

            var tag = '{EmployeeID:"' + EmployeeID + '",LastName:"' + LastName + '",FirstName:"' + FirstName + '",Title:"' + Title + '",TitleOfCourtesy:"' + TitleOfCourtesy + '",BirthDate:"' + BirthDate + '",HireDate:"' + HireDate + '",Address:"' + Address + '",City:"' + City + '",Region:"' + Region + '",PostalCode:"' + PostalCode + '",Country:"' + Country + '",HomePhone:"' + HomePhone + '",Extension:"' + Extension + '",ReportsTo:"' + ReportsTo + '",PhotoPath:"' + PhotoPath + '"}';
            var F = CallServices(url + "Save", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Save
this.Update = function(EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath)
{

            var result;

            var tag = '{EmployeeID:"' + EmployeeID + '",LastName:"' + LastName + '",FirstName:"' + FirstName + '",Title:"' + Title + '",TitleOfCourtesy:"' + TitleOfCourtesy + '",BirthDate:"' + BirthDate + '",HireDate:"' + HireDate + '",Address:"' + Address + '",City:"' + City + '",Region:"' + Region + '",PostalCode:"' + PostalCode + '",Country:"' + Country + '",HomePhone:"' + HomePhone + '",Extension:"' + Extension + '",ReportsTo:"' + ReportsTo + '",PhotoPath:"' + PhotoPath + '"}';
            var F = CallServices(url + "Update", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Update
this.Delete = function(EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath)
{

            var result;

            var tag = '{EmployeeID:"' + EmployeeID + '",LastName:"' + LastName + '",FirstName:"' + FirstName + '",Title:"' + Title + '",TitleOfCourtesy:"' + TitleOfCourtesy + '",BirthDate:"' + BirthDate + '",HireDate:"' + HireDate + '",Address:"' + Address + '",City:"' + City + '",Region:"' + Region + '",PostalCode:"' + PostalCode + '",Country:"' + Country + '",HomePhone:"' + HomePhone + '",Extension:"' + Extension + '",ReportsTo:"' + ReportsTo + '",PhotoPath:"' + PhotoPath + '"}';
            var F = CallServices(url + "Delete", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Delete

    this.SelectAll = function () {
        var result;

        var tag = '{}';
        var F = CallServices(url + "SelectAll", tag, false, function (msg) {
            result = msg.d;
        });
        return result;
    };//SelectAll

    this.Select = function (EmployeeID) {
        var result;

 var tag = '{EmployeeID:"'+EmployeeID+'"}';
        var F = CallServices(url + "Select", tag, false, function (msg) {
            result = msg.d;
        });
        return result;
    };//SelectAll
}).apply(EmployeesService); 

