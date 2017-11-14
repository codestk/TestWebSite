//Add On Control
function CheckEmtyp(control) {
    if (control.val() == "") {
        control.addClass("invalid");
        return true
    }

    return false
}



function AddInvalidControl(control) {
    
        control.addClass("invalid");
     

    
}