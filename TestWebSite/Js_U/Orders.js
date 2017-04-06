var OrdersService = {}; 
(function () { 
    var url = "OrdersService.asmx/"; 
 
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
   
  this.Search = function (PageIndex,PageSize,SortExpression,SortDirection,OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry,RederTable_Pagger) {
        var result;

        var tag = '{PageIndex:"'+PageIndex+'",PageSize:"'+PageSize+'",SortExpression:"'+SortExpression+'",SortDirection:"'+SortDirection+'",OrderID:"' + OrderID + '",CustomerID:"' + CustomerID + '",EmployeeID:"' + EmployeeID + '",OrderDate:"' + OrderDate + '",RequiredDate:"' + RequiredDate + '",ShippedDate:"' + ShippedDate + '",ShipVia:"' + ShipVia + '",Freight:"' + Freight + '",ShipName:"' + ShipName + '",ShipAddress:"' + ShipAddress + '",ShipCity:"' + ShipCity + '",ShipRegion:"' + ShipRegion + '",ShipPostalCode:"' + ShipPostalCode + '",ShipCountry:"' + ShipCountry + '"}';
        var F = CallServices(url + "Search", tag, true, function (msg) {
            result = msg.d;

            RederTable_Pagger(result);
        });
        return result;
    };//Save
this.Save = function(OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)
{

            var result;

            var tag = '{OrderID:"' + OrderID + '",CustomerID:"' + CustomerID + '",EmployeeID:"' + EmployeeID + '",OrderDate:"' + OrderDate + '",RequiredDate:"' + RequiredDate + '",ShippedDate:"' + ShippedDate + '",ShipVia:"' + ShipVia + '",Freight:"' + Freight + '",ShipName:"' + ShipName + '",ShipAddress:"' + ShipAddress + '",ShipCity:"' + ShipCity + '",ShipRegion:"' + ShipRegion + '",ShipPostalCode:"' + ShipPostalCode + '",ShipCountry:"' + ShipCountry + '"}';
            var F = CallServices(url + "Save", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Save
this.Update = function(OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)
{

            var result;

            var tag = '{OrderID:"' + OrderID + '",CustomerID:"' + CustomerID + '",EmployeeID:"' + EmployeeID + '",OrderDate:"' + OrderDate + '",RequiredDate:"' + RequiredDate + '",ShippedDate:"' + ShippedDate + '",ShipVia:"' + ShipVia + '",Freight:"' + Freight + '",ShipName:"' + ShipName + '",ShipAddress:"' + ShipAddress + '",ShipCity:"' + ShipCity + '",ShipRegion:"' + ShipRegion + '",ShipPostalCode:"' + ShipPostalCode + '",ShipCountry:"' + ShipCountry + '"}';
            var F = CallServices(url + "Update", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Update
this.Delete = function(OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)
{

            var result;

            var tag = '{OrderID:"' + OrderID + '",CustomerID:"' + CustomerID + '",EmployeeID:"' + EmployeeID + '",OrderDate:"' + OrderDate + '",RequiredDate:"' + RequiredDate + '",ShippedDate:"' + ShippedDate + '",ShipVia:"' + ShipVia + '",Freight:"' + Freight + '",ShipName:"' + ShipName + '",ShipAddress:"' + ShipAddress + '",ShipCity:"' + ShipCity + '",ShipRegion:"' + ShipRegion + '",ShipPostalCode:"' + ShipPostalCode + '",ShipCountry:"' + ShipCountry + '"}';
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

    this.Select = function (OrderID) {
        var result;

 var tag = '{OrderID:"'+OrderID+'"}';
        var F = CallServices(url + "Select", tag, false, function (msg) {
            result = msg.d;
        });
        return result;
    };//SelectAll
}).apply(OrdersService); 

