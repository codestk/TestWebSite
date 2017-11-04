var APP_USERService = {}; 
(function () { 
    var url = "Services/APP_USERService.asmx/"; 
 
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
   
  this.Search = function (PageIndex,PageSize,SortExpression,SortDirection,UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created,RederTable_Pagger) {
        var result;

        var tag = '{PageIndex:"'+PageIndex+'",PageSize:"'+PageSize+'",SortExpression:"'+SortExpression+'",SortDirection:"'+SortDirection+'",UserID:"' + UserID + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Tel:"' + Tel + '",FLAG:"' + FLAG + '",RoleAdmin:"' + RoleAdmin + '",RoleUser:"' + RoleUser + '",Created:"' + Created + '"}';
        var F = CallServices(url + "Search", tag, true, function (msg) {
            result = msg.d;

            RederTable_Pagger(result);
        });
        return result;
    };//Save
this.Save = function(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created)
{

            var result;

            var tag = '{UserID:"' + UserID + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Tel:"' + Tel + '",FLAG:"' + FLAG + '",RoleAdmin:"' + RoleAdmin + '",RoleUser:"' + RoleUser + '",Created:"' + Created + '"}';
            var F = CallServices(url + "Save", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Save
this.Update = function(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created)
{

            var result;

            var tag = '{UserID:"' + UserID + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Tel:"' + Tel + '",FLAG:"' + FLAG + '",RoleAdmin:"' + RoleAdmin + '",RoleUser:"' + RoleUser + '",Created:"' + Created + '"}';
            var F = CallServices(url + "Update", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Update
this.Delete = function(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created)
{

            var result;

            var tag = '{UserID:"' + UserID + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Tel:"' + Tel + '",FLAG:"' + FLAG + '",RoleAdmin:"' + RoleAdmin + '",RoleUser:"' + RoleUser + '",Created:"' + Created + '"}';
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

    this.Select = function (UserID) {
        var result;

 var tag = '{UserID:"'+UserID+'"}';
        var F = CallServices(url + "Select", tag, false, function (msg) {
            result = msg.d;
        });
        return result;
    };//SelectAll
}).apply(APP_USERService); 
