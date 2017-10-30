// <copyright file="Momojo.js" company="CodeStk">
// Copyright (c) 2007, 2008 All Right Reserved, http://CodeStk.com/
//
// This source is subject to the Microsoft Permissive License.
// Please see the License.txt file for more information.
// All other rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// </copyright>
// <author>momojojo</author>
// <email>codestk@gmail.com</email>
// <date>19-07-2012</date>
// <summary>Contains a base, abstract class for an AuthorisationPolicyProvider</summary>

/**=================================================================================Match===================================================================================
* Random int
* update 18/1/2013
**/
function getRandomInt(lower, upper) {
    //to create an even sample distribution
    return Math.floor(lower + (Math.random() * (upper - lower + 1)));

    //to produce an uneven sample distribution
    //return Math.round(lower + (Math.random() * (upper - lower)));

    //to exclude the max value from the possible values
    //return Math.floor(lower + (Math.random() * (upper - lower)));
}

/*
* Check isEven or odd
*/
function isEven(value) {
    if (value % 2 == 0)
        return true;
    else
        return false;
}

/**
* Performs the Decrease Key operation
* @param index Index of the node in the RefArray whose key is to be decreased
* @param amount Amount by which key is to be reduced
* Use By var aArray = new Array; aArray.sort(AscComparString);
**/
function AscComparString(sV1, sV2) {
    var s_v1 = sV1.cells[0].firstChild.nodeValue;
    var s_v2 = sV2.cells[0].firstChild.nodeValue;

    return s_v1.localeCompare(s_v2);
}

/**
*  Performs the Decrease Key operation
*  @param index Index of the node in the RefArray whose key is to be decreased
*  @param amount Amount by which key is to be reduced
*  Use By var aArray = new Array; aArray.sort(DscCompaString);
*/
function DscCompaString(sV1, sV2) {
    var s_v1 = sV1.cells[0].firstChild.nodeValue;
    var s_v2 = sV2.cells[0].firstChild.nodeValue;
    return -s_v1.localeCompare(s_v2);
}

/*==========================================================================Array==========================================================================================*/

/* 31/1/2556
* GetUniqOneColumn(arr, 'prop');
* arr = msg.d
* prop=Cloumn name of .d
* flage 0 = Get Distrinct All Column
*          1 = Get One Column Follow By prop
*/
function MsgUniq(arr, prop, flage) {
    var new_arr = [];
    var lookup = {};
    for (var i in arr) {
        lookup[arr[i][prop]] = arr[i];
    }

    for (i in lookup) {
        // new_arr.push(lookup[i]); //filter All coloumn
        if (flage == 0) {
            new_arr.push(lookup[i]);
        } else {
            new_arr.push({
                prop: lookup[i][prop]
            });
        }
    }
    var Msg;
    Msg = {
        d: new_arr
    };
    return Msg;
}

/*Array Filter
* 24/1/2556
* Filter Array
* USE
* function isBigEnough(element, index, array) {
* return (element = 10);
* }
* var filtered = [12, 5, 8, 130, 44].filter(isBigEnough);
* filtered is [12, 130, 44]
*/
if (!Array.prototype.filter) {
    Array.prototype.filter = function (fun /*, thisp */) {
        "use strict";

        if (this == null) throw new TypeError();

        var t = Object(this);
        var len = t.length >>> 0;
        if (typeof fun != "function") throw new TypeError();

        var res = [];
        var thisp = arguments[1];
        for (var i = 0; i < len; i++) {
            if (i in t) {
                var val = t[i]; // in case fun mutates this
                if (fun.call(thisp, val, i, t)) res.push(val);
            }
        }

        return res;
    };
}

/*==================Msg Json===========================================================================================================================================*/
// 20/08/2556
//console.log(removeFunction(obj.results, "id", "460"));
// Remove Some Object    OderiTems= RemoveMsgObject(OderiTems, "AutoId", id);
// id =properties
// 460 = Value
function RemoveMsgObject(myObjects, prop, value) {
    return myObjects.filter(function (val) {
        //return val[prop] !== valu;
        return val[prop] != value;
    });
}

/*==================================================================================Date===================================================================================*/
/**
 * convert Date OBject to String m/d/yyyy
 * @fxdate is Date Object
 * Remark is Real month
 */
function DateToText(oDate) {
    var sdateText = oDate.getDate() + '/' + (oDate.getMonth() + 1) + '/' + oDate.getFullYear();
    return sdateText;
}

/** UPDATE 30/1/2012
 * Convert Text ToDate Time
 * dateString 30/01/2013 16:26:03"
 **/
function TextToDate(dateString) {
    //var dateString = "2010-08-09 01:02:03";
    //var reggie = /(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})/;
    var reggie = /(\d{2})\/(\d{2})\/(\d{4}) (\d{2}):(\d{2}):(\d{2})/;
    var dateArray = reggie.exec(dateString);
    var dateObject = new Date(
    (+dateArray[3]), (+dateArray[2]) - 1, // Careful, month starts at 0!
    (+dateArray[1]), (+dateArray[4]), (+dateArray[5]), (+dateArray[6]));
    return dateObject;
}

/**  text for Db 30/1/2013 (fireBrid)
 * Return yyyy/mm/dd 12:12:2013
 **/
function DateToDbText(Date) {
    var sdateText = (Date.getMonth() + 1) + '/' + Date.getDate() + '/' + Date.getFullYear() + ' ' + Date.getHours() + ':' + Date.getMinutes() + ':' + Date.getSeconds();
    return sdateText;
}

/** Convert Json Date To Java Date
 *   Update 24 01 2013
 *   JsonDate =  "/Date(1358999164000)/"
 **/
function JsonDateToDate(jsonDate) {
    //var milli = "/Date(1358999164000)/".replace(/\/Date\((-?\d+)\)\//, '$1');
    var milli = jsonDate.replace(/\/Date\((-?\d+)\)\//, '$1');
    var date = new Date(parseInt(milli));
    return date;
}

/*========================================================================================String===========================================================================*/
//” ” (ASCII 32 (0×20)), an ordinary space.
//“ ” (ASCII 9 (0×09)), a tab.
//“ ” (ASCII 10 (0x0A)), a new line (line feed).
//“ ” (ASCII 13 (0x0D)), a carriage return.
//“″ (ASCII 0 (0×00)), the NUL-byte.
//“x0B” (ASCII 11 (0x0B)), a vertical tab.

/*
 * Remove Character
 * Modifier 9/8/2012
 */
// var a= '99**';
// a=trim(a,'*');
//a= 99<<
function trim(str, chars) {
    return ltrim(rtrim(str, chars), chars);
}

function ltrim(str, chars) {
    //Fix Bug ""
    if (chars == '')
        return str;

    chars = chars || "\s";
    return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
}

function rtrim(str, chars) {
    //Fix Bug ""
    if (chars == '')
        return str;

    chars = chars || "\s";
    return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
}

//Trim Space
//var a='ssss';
//a = a.trim();
if (!String.prototype.trim) {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    };
}
if (!String.prototype.trimLeft) {
    String.prototype.trimLeft = function () {
        return this.replace(/^\s+/g, '');
    };
}
if (!String.prototype.trimRight) {
    String.prototype.trimRight = function () {
        return this.replace(/\s+$/g, '');
    };
}

/** 1/2/2013
 *   Padding String
 *   Use
 *   var str = "5";
 *   alert(str.lpad("0", 5)); //result "00005"
 *   alert(str.rpad("0", 5)); //result "50000"
 **/
String.prototype.lpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
}

//pads right
String.prototype.rpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = str + padString;
    return str;
}

/** 9/5/2013
* var str = "Hello World!";
* var PICTURE = str.getBytes();
* var PICTURE = $('#imgPreView')[0].src.getBytes();
 **/
function StringToBytes(_string) {
    var bytes = [];
    for (var i = 0; i < _string.length; ++i) {
        bytes.push(_string.charCodeAt(i));
    }
    return bytes;
};

function BytesToString(bytesArray) {
    var result = "";
    for (var i = 0; i < bytesArray.length; i++) {
        result += String.fromCharCode(parseInt(bytesArray[i]));
    }
    return result;
}

function TextToAscii(c) {
    // restrict input to a single character
    c = c.charAt(0);

    // loop through all possible ASCII values
    var i;
    for (i = 0; i < 256; ++i) {
        // convert i into a 2-digit hex string
        var h = i.toString(16);
        if (h.length == 1) h = "0" + h;

        // insert a % character into the string
        h = "%" + h;

        // determine the character represented by the escape code
        h = unescape(h);

        // if the characters match, we've found the ASCII value
        if (h == c) break;
    }
    return i;
}

// Remove All Html in Html
// Return pure txt
function removeHtml(html) {
    var output = '';
    output = html.replace(/<\/?[a-z][a-z0-9]*[^<>]*>/ig, "");
    return output;
};

/**
 * Performs Check Value
 * @input index Index of the node in the RefArray whose key is to be decreased
 * Use
 * Return boolean is ture when is Number other return false
 */
function IsNumber(input) {
    var output;
    output = isNaN(input);
    output = (!output);
    return output;
}

//*======================================================================HttpUtility=========================================================================================
/*  Update 30 12 2555
*   Querystring
    Use :  var keypara = getQuerystring('q');
**/
function getQuerystring(key, default_) {
    if (default_ == null) default_ = "";
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    if (qs == null) return default_;
    else return qs[1];
}

//*======================================Call Service==============================================================================================
var ShowError = false;
//Url ManageUsers.aspx/SearchEmployee
//data "{ssss:1,ddddd:1}"
//for Call Back    CallServices(Url, parameter, true, function(myRtn) {});
var processing = false;
function CallServices(url, data, async, callBack) {
    if (processing == true) {
        return;
    }
    processing = true;
    $.ajax({
        type: "POST",
        dataType: "json",
        beforeSend: function (jqXHR, settings) {
            // console.log(jqXHR.progress)
        },
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        async: async,
        success: function (msg) {
            output = msg;
            processing = false;
            return callBack(msg);
        }
        , error: function (jqXHR, textStatus, errorThrown) {
            //fix bug error not set false
            processing = false;
            if (ShowError == true)

                alert(errorThrown);

            // return callBack(jqXHR.status);
        }
        , complete: function (jqXHR, textStatus) {
            processing = false;
            if (ShowError == true)
                alert(textStatus);
        }
    });  //.ajax
}