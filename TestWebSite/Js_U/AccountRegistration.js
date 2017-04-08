var AccountRegistrationService = {}; 
(function () { 
    var url = "AccountRegistrationService.asmx/"; 
 
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
   
  this.Search = function (PageIndex,PageSize,SortExpression,SortDirection,RequestId,UserName,Password,FirstName,LastName,Department,Phone,Fax,Status,CreateDate,DeleteDate,CancelDate,ApprovedDate,LastUpdate,RederTable_Pagger) {
        var result;

        var tag = '{PageIndex:"'+PageIndex+'",PageSize:"'+PageSize+'",SortExpression:"'+SortExpression+'",SortDirection:"'+SortDirection+'",RequestId:"' + RequestId + '",UserName:"' + UserName + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Department:"' + Department + '",Phone:"' + Phone + '",Fax:"' + Fax + '",Status:"' + Status + '",CreateDate:"' + CreateDate + '",DeleteDate:"' + DeleteDate + '",CancelDate:"' + CancelDate + '",ApprovedDate:"' + ApprovedDate + '",LastUpdate:"' + LastUpdate + '"}';
        var F = CallServices(url + "Search", tag, true, function (msg) {
            result = msg.d;

            RederTable_Pagger(result);
        });
        return result;
    };//Save
this.Save = function(RequestId,UserName,Password,FirstName,LastName,Department,Phone,Fax,Status,CreateDate,DeleteDate,CancelDate,ApprovedDate,LastUpdate)
{

            var result;

            var tag = '{RequestId:"' + RequestId + '",UserName:"' + UserName + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Department:"' + Department + '",Phone:"' + Phone + '",Fax:"' + Fax + '",Status:"' + Status + '",CreateDate:"' + CreateDate + '",DeleteDate:"' + DeleteDate + '",CancelDate:"' + CancelDate + '",ApprovedDate:"' + ApprovedDate + '",LastUpdate:"' + LastUpdate + '"}';
            var F = CallServices(url + "Save", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Save
this.Update = function(RequestId,UserName,Password,FirstName,LastName,Department,Phone,Fax,Status,CreateDate,DeleteDate,CancelDate,ApprovedDate,LastUpdate)
{

            var result;

            var tag = '{RequestId:"' + RequestId + '",UserName:"' + UserName + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Department:"' + Department + '",Phone:"' + Phone + '",Fax:"' + Fax + '",Status:"' + Status + '",CreateDate:"' + CreateDate + '",DeleteDate:"' + DeleteDate + '",CancelDate:"' + CancelDate + '",ApprovedDate:"' + ApprovedDate + '",LastUpdate:"' + LastUpdate + '"}';
            var F = CallServices(url + "Update", tag, false, function(msg) {
                result = msg.d;
            });
            return result;
        };//Update
this.Delete = function(RequestId,UserName,Password,FirstName,LastName,Department,Phone,Fax,Status,CreateDate,DeleteDate,CancelDate,ApprovedDate,LastUpdate)
{

            var result;

            var tag = '{RequestId:"' + RequestId + '",UserName:"' + UserName + '",Password:"' + Password + '",FirstName:"' + FirstName + '",LastName:"' + LastName + '",Department:"' + Department + '",Phone:"' + Phone + '",Fax:"' + Fax + '",Status:"' + Status + '",CreateDate:"' + CreateDate + '",DeleteDate:"' + DeleteDate + '",CancelDate:"' + CancelDate + '",ApprovedDate:"' + ApprovedDate + '",LastUpdate:"' + LastUpdate + '"}';
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

    this.Select = function (RequestId) {
        var result;

 var tag = '{RequestId:"'+RequestId+'"}';
        var F = CallServices(url + "Select", tag, false, function (msg) {
            result = msg.d;
        });
        return result;
    };//SelectAll
}).apply(AccountRegistrationService); 

