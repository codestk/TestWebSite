var TradeFromTermService = {};  
(function () {  
    var url = "TradeFromTermService.asmx/";  
  
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
    
  this.Search = function (PageIndex,PageSize,SortExpression,SortDirection,TermId,TermName,TermContent,TermCreateDate,TermUpdateDate,TermUpdateCount,RederTable_Pagger) { 
        var result; 
 
        var tag = '{PageIndex:"'+PageIndex+'",PageSize:"'+PageSize+'",SortExpression:"'+SortExpression+'",SortDirection:"'+SortDirection+'",TermId:"' + TermId + '",TermName:"' + TermName + '",TermContent:"' + TermContent + '",TermCreateDate:"' + TermCreateDate + '",TermUpdateDate:"' + TermUpdateDate + '",TermUpdateCount:"' + TermUpdateCount + '"}'; 
        var F = CallServices(url + "Search", tag, true, function (msg) { 
            result = msg.d; 
 
            RederTable_Pagger(result); 
        }); 
        return result; 
    };//Save 
this.Save = function(TermId,TermName,TermContent,TermCreateDate,TermUpdateDate,TermUpdateCount) 
{ 
 
            var result; 
 
            var tag = '{TermId:"' + TermId + '",TermName:"' + TermName + '",TermContent:"' + TermContent + '",TermCreateDate:"' + TermCreateDate + '",TermUpdateDate:"' + TermUpdateDate + '",TermUpdateCount:"' + TermUpdateCount + '"}'; 
            var F = CallServices(url + "Save", tag, false, function(msg) { 
                result = msg.d; 
            }); 
            return result; 
        };//Save 
this.Update = function(TermId,TermName,TermContent,TermCreateDate,TermUpdateDate,TermUpdateCount) 
{ 
 
            var result; 
 
            var tag = '{TermId:"' + TermId + '",TermName:"' + TermName + '",TermContent:"' + TermContent + '",TermCreateDate:"' + TermCreateDate + '",TermUpdateDate:"' + TermUpdateDate + '",TermUpdateCount:"' + TermUpdateCount + '"}'; 
            var F = CallServices(url + "Update", tag, false, function(msg) { 
                result = msg.d; 
            }); 
            return result; 
        };//Update 
this.Delete = function(TermId,TermName,TermContent,TermCreateDate,TermUpdateDate,TermUpdateCount) 
{ 
 
            var result; 
 
            var tag = '{TermId:"' + TermId + '",TermName:"' + TermName + '",TermContent:"' + TermContent + '",TermCreateDate:"' + TermCreateDate + '",TermUpdateDate:"' + TermUpdateDate + '",TermUpdateCount:"' + TermUpdateCount + '"}'; 
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
 
    this.Select = function (TermId) { 
        var result; 
 
 var tag = '{TermId:"'+TermId+'"}'; 
        var F = CallServices(url + "Select", tag, false, function (msg) { 
            result = msg.d; 
        }); 
        return result; 
    };//SelectAll 
}).apply(TradeFromTermService);  

