
function ApiExistId(token, email) {
    var command = '<iq sid="' + token + '"> <query xmlns="admin:iq:rpc"><commandname>getaccountfolderlist</commandname> <commandparams> <accountemail>' + email + '</accountemail> <onlydefault>TRUE</onlydefault> </commandparams> </query> </iq> ';

    var F = CallServices(serviceUrl, command, false, function (msg) {
        if (msg.iq["0"].query["0"].result == undefined) {
            //no user
            alert('false');
        } else {
            //duplicate
            alert('true');
        }
    });

    return '';
}




function ApiExistId(token, email) {
    var command = '<iq sid="' + token + '"> <query xmlns="admin:iq:rpc"><commandname>getaccountfolderlist</commandname> <commandparams> <accountemail>' + email + '</accountemail> <onlydefault>TRUE</onlydefault> </commandparams> </query> </iq> ';

    var F = CallServices(serviceUrl, command, false, function (msg) {
        if (msg.iq["0"].query["0"].result == undefined) {
            //no user
            alert('false');
        } else {
            //duplicate
            alert('true');
        }
    });

    return '';
}

function ApiCreateUser(token) {
    return '';
}

function ApiDeleteUser(token, user) {
    var command = '<iq sid="' + token + '"> <query xmlns="admin:iq:rpc"> <commandname>deleteaccounts</commandname> <commandparams> <domainstr>quickserv.com</domainstr> <accountlist> <classname>tpropertystringlist</classname> <val> <u_mailbox>' +
      user + '</u_mailbox></val></accountlist><leavedata>TRUE</leavedata></commandparams></query></iq>';

    var F = CallServices(serviceUrl, command, false, function (msg) {
        debugger
    });

    return '';
}

function ApiLogin(email, password) {
    var command = '<iq><query xmlns="admin:iq:rpc"><commandname>authenticate</commandname><commandparams><authtype>0</authtype><email>' + email + '</email><password>' + password +
      '</password><digest>stringval</digest><persistentlogin>True</persistentlogin></commandparams></query></iq>';
    debugger
    //var data=CallApi('http://localhost/icewarpapi/',command,true,callback);
    var F = CallServices(serviceUrl, command, false, function (msg) {
        alert(msg);
    });

    //return F.iq["0"]._attr.sid._value;
    // return  'fff';
}

var ShowError = false;
//Url ManageUsers.aspx/SearchEmployee
//data "{ssss:1,ddddd:1}"
//for Call Back    CallServices(Url, parameter, true, function(myRtn) {});
var processing = false;

function CallServices(url, data, async, callBack) {
    if (processing == true) {
        return;
    }

    $('#input').html(data);
    processing = true;
    $.ajax({
        type: "POST",
        //dataType: "json",
        dataType: 'text',
        beforeSend: function (jqXHR, settings) {
            // console.log(jqXHR.progress)
        },
        url: url,
        data: data,
        //contentType: "application/json; charset=utf-8",
        async: async,
        success: function (msg) {
            output = msg;
            processing = false;
            $('#response').html(msg);
            var json = xmlToJSON.parseString(msg);
            return callBack(json);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            //fix bug error not set false
            processing = false;
            if (ShowError == true)

                alert(errorThrown);

            // return callBack(jqXHR.status);
        },
        complete: function (jqXHR, textStatus) {
            processing = false;
            if (ShowError == true)
                alert(textStatus);
        }
    }); //.ajax
}