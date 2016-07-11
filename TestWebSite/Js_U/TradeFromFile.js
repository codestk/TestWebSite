var TradeFromFileService = {};  
(function () {  
    var url = "TradeFromFileService.asmx/";  
  
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
    
  this.Search = function (PageIndex,PageSize,SortExpression,SortDirection,FileId,FileName,FileDescription,CategoryID,TermId,RederTable_Pagger) { 
        var result; 
 
        var tag = '{PageIndex:"'+PageIndex+'",PageSize:"'+PageSize+'",SortExpression:"'+SortExpression+'",SortDirection:"'+SortDirection+'",FileId:"' + FileId + '",FileName:"' + FileName + '",FileDescription:"' + FileDescription + '",CategoryID:"' + CategoryID + '",TermId:"' + TermId + '"}'; 
        var F = CallServices(url + "Search", tag, true, function (msg) { 
            result = msg.d; 
 
            RederTable_Pagger(result); 
        }); 
        return result; 
    };//Save 
this.Save = function(FileId,FileName,FileDescription,CategoryID,TermId) 
{ 
 
            var result; 
 
            var tag = '{FileId:"' + FileId + '",FileName:"' + FileName + '",FileDescription:"' + FileDescription + '",CategoryID:"' + CategoryID + '",TermId:"' + TermId + '"}'; 
            var F = CallServices(url + "Save", tag, false, function(msg) { 
                result = msg.d; 
            }); 
            return result; 
        };//Save 
this.Update = function(FileId,FileName,FileDescription,CategoryID,TermId) 
{ 
 
            var result; 
 
            var tag = '{FileId:"' + FileId + '",FileName:"' + FileName + '",FileDescription:"' + FileDescription + '",CategoryID:"' + CategoryID + '",TermId:"' + TermId + '"}'; 
            var F = CallServices(url + "Update", tag, false, function(msg) { 
                result = msg.d; 
            }); 
            return result; 
        };//Update 
this.Delete = function(FileId,FileName,FileDescription,CategoryID,TermId) 
{ 
 
            var result; 
 
            var tag = '{FileId:"' + FileId + '",FileName:"' + FileName + '",FileDescription:"' + FileDescription + '",CategoryID:"' + CategoryID + '",TermId:"' + TermId + '"}'; 
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
 
    this.Select = function (FileId) { 
        var result; 
 
 var tag = '{FileId:"'+FileId+'"}'; 
        var F = CallServices(url + "Select", tag, false, function (msg) { 
            result = msg.d; 
        }); 
        return result; 
    };//SelectAll 
}).apply(TradeFromFileService);  

