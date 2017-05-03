
//var password = "TEstpass1aaaaaaa$$";
//console.log(isOkPass(password));
//work P@ssw0rd
function PasswordIsComplex(p) {
    var anUpperCase = /[A-Z]/;
    var aLowerCase = /[a-z]/;
    var aNumber = /[0-9]/;
    var aSpecial = /[!|@|#|$|%|^|&|*|(|)|-|_]/;
    var obj = {};
    obj.result = true;
     
    if (p.length < 6) {
        obj.result = false;
        obj.error = "Not long enough!"
        return obj;
    }

    var numUpper = 0;
    var numLower = 0;
    var numNums = 0;
    var numSpecials = 0;
    for (var i = 0; i < p.length; i++) {
        if (anUpperCase.test(p[i]))
            numUpper++;
        else if (aLowerCase.test(p[i]))
            numLower++;
        else if (aNumber.test(p[i]))
            numNums++;
        else if (aSpecial.test(p[i]))
            numSpecials++;
    }

    if (numUpper < 1 || numLower < 1 || numNums < 1 || numSpecials < 1) {
        obj.result = false;
        obj.error = "Wrong Format!";
        return obj;
    }
    return obj;
}