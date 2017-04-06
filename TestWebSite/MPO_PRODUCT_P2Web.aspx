<%@ Page Title="MPO_PRODUCT_P2" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MPO_PRODUCT_P2Web.aspx.cs" Inherits="MPO_PRODUCT_P2Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
<script src="Js_U/MPO_PRODUCT_P2.js"></script>
<script src="Js_U/MPO_SOURCE.js"></script>
<script src="Js_U/MPO_PRODUCT_LINE.js"></script>
<script src="Js_U/MPO_FORMULA_AND_TEST.js"></script>
<script src="Js_U/MPO_SIZE.js"></script>
<script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
 $(document).ready(function () 
{
$('.modal-trigger').leanModal();
ForceNumberTextBox(); 
//For dropdown
SetSelectPR_SOURCE('#drpPR_SOURCE');
SetSelectPR_PRODUCT_LINE('#drpPR_PRODUCT_LINE');
SetSelectPR_FORMULA_AND_TEST('#drpPR_FORMULA_AND_TEST');
SetSelectPR_SIZE('#drpPR_SIZE');
$('select').material_select(); 
BindQueryString();
$('select').material_select(); 
$('.datepicker').pickadate({
selectMonths: true, // Creates a dropdown to control month
selectYears: 15 ,// Creates a dropdown of 15 years to control year,
format: 'd mmm yyyy',
});
 }); 
function ForceNumberTextBox() 
{
$("#txtPR_LOT").ForceNumericOnly();
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtPR_LOT"))) {output = false;}
if(($("#drpPR_SOURCE").prop('selectedIndex')==0)||($("#drpPR_SOURCE").prop('selectedIndex')==-1)){
output=false;

$("#drpPR_SOURCE").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpPR_SOURCE").prev().prev().removeClass('CustomInvalid');
$("#drpPR_SOURCE").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpPR_PRODUCT_LINE").prop('selectedIndex')==0)||($("#drpPR_PRODUCT_LINE").prop('selectedIndex')==-1)){
output=false;

$("#drpPR_PRODUCT_LINE").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpPR_PRODUCT_LINE").prev().prev().removeClass('CustomInvalid');
$("#drpPR_PRODUCT_LINE").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpPR_FORMULA_AND_TEST").prop('selectedIndex')==0)||($("#drpPR_FORMULA_AND_TEST").prop('selectedIndex')==-1)){
output=false;

$("#drpPR_FORMULA_AND_TEST").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpPR_FORMULA_AND_TEST").prev().prev().removeClass('CustomInvalid');
$("#drpPR_FORMULA_AND_TEST").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpPR_SIZE").prop('selectedIndex')==0)||($("#drpPR_SIZE").prop('selectedIndex')==-1)){
output=false;

$("#drpPR_SIZE").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpPR_SIZE").prev().prev().removeClass('CustomInvalid');
$("#drpPR_SIZE").prev().prev().addClass('CustomValid');
 
 
}
if (output == false)
Materialize.toast('please validate your input.', 3000, 'toastCss');
return output;
}
function Confirm() { 
$('#modalConfirm').openModal(); 
return false; 
}
function Save() {
 if (Validate() == false) { return false; }
var  PR_LOT =$('#txtPR_LOT').val();
var  PR_SOURCE =$('#drpPR_SOURCE').val();
var  PR_PRODUCT_LINE =$('#drpPR_PRODUCT_LINE').val();
var  PR_FORMULA_AND_TEST =$('#drpPR_FORMULA_AND_TEST').val();
var  PR_SIZE =$('#drpPR_SIZE').val();
var result = MPO_PRODUCT_P2Service.Save(PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtPR_LOT').val(result);
$('#btnSave').hide();
$('#btnUpdate').show();
$('#btnDelete').show();
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Update() {
 if (Validate() == false) { return false; }
var  PR_LOT =$('#txtPR_LOT').val();
var  PR_SOURCE =$('#drpPR_SOURCE').val();
var  PR_PRODUCT_LINE =$('#drpPR_PRODUCT_LINE').val();
var  PR_FORMULA_AND_TEST =$('#drpPR_FORMULA_AND_TEST').val();
var  PR_SIZE =$('#drpPR_SIZE').val();
var result = MPO_PRODUCT_P2Service.Update(PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  PR_LOT =$('#txtPR_LOT').val();
var  PR_SOURCE =$('#drpPR_SOURCE').val();
var  PR_PRODUCT_LINE =$('#drpPR_PRODUCT_LINE').val();
var  PR_FORMULA_AND_TEST =$('#drpPR_FORMULA_AND_TEST').val();
var  PR_SIZE =$('#drpPR_SIZE').val();
var result = MPO_PRODUCT_P2Service.Delete(PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
$('#modalConfirm').closeModal();
   setInterval(function () { this.close() }, 2000);
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
 function SetSelectPR_SOURCE(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_SOURCE = MPO_SOURCEService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_SOURCE, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectPR_PRODUCT_LINE(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_PRODUCT_LINE = MPO_PRODUCT_LINEService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_PRODUCT_LINE, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectPR_FORMULA_AND_TEST(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_FORMULA_AND_TEST = MPO_FORMULA_AND_TESTService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_FORMULA_AND_TEST, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectPR_SIZE(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_SIZE = MPO_SIZEService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_SIZE, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
function BindQueryString() {

var PR_LOT = getQuerystring('Q');
if (PR_LOT != '') {
var _MPO_PRODUCT_P2 = MPO_PRODUCT_P2Service.Select(PR_LOT);

$('#txtPR_LOT').prop('disabled', true );
$('#txtPR_LOT').val(_MPO_PRODUCT_P2.PR_LOT);
$('#drpPR_SOURCE').val(_MPO_PRODUCT_P2.PR_SOURCE);
$('#drpPR_PRODUCT_LINE').val(_MPO_PRODUCT_P2.PR_PRODUCT_LINE);
$('#drpPR_FORMULA_AND_TEST').val(_MPO_PRODUCT_P2.PR_FORMULA_AND_TEST);
$('#drpPR_SIZE').val(_MPO_PRODUCT_P2.PR_SIZE);
$('#btnSave').hide();
}
else{
$('#btnSave').show();
$('#btnUpdate').hide();
$('#btnDelete').hide();

}
}
</script>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
<div class="container">
<div class="row"><div class="input-field col s9"> 
<input  id="txtPR_LOT" type="text" data-column-id="PR_LOT"  Class="validate PR_LOT" length="9"        maxlength="9"     />
<label for="txtPR_LOT">PR_LOT </label> 
 </div> 
<div class="input-field col s9"> 
<select id="drpPR_SOURCE" > 
 
</select>
<label for="drpPR_SOURCE">PR_SOURCE</label>
</div>
<div class="input-field col s9"> 
<select id="drpPR_PRODUCT_LINE" > 
 
</select>
<label for="drpPR_PRODUCT_LINE">PR_PRODUCT_LINE</label>
</div>
<div class="input-field col s9"> 
<select id="drpPR_FORMULA_AND_TEST" > 
 
</select>
<label for="drpPR_FORMULA_AND_TEST">PR_FORMULA_AND_TEST</label>
</div>
<div class="input-field col s9"> 
<select id="drpPR_SIZE" > 
 
</select>
<label for="drpPR_SIZE">PR_SIZE</label>
</div>
  <div class="input-field col s12">
<input id="btnSave" type="button" value="Save" class=" btn" onclick="Save();" /><input id="btnUpdate" type="button" value="Update" class=" btn" onclick="Update();" /><input id="btnDelete" type="button" value="Delete" class=" btn" onclick="javascript:return Confirm();" /></div>
  
</div>
</div>
   <!-- Modal Trigger --> 
 <%--  <a class="waves-effect waves-light btn modal-trigger" href="#modal1">Modal</a>--%> 
 <!-- Modal Structure --> 
  <div id = "modal1" class="modal">
   <div class="modal-content">
  <h4>Message</h4>
   <p id="PmsageAlert">Saved!!!</p>
  </div> 
   <div class="modal-footer">
<a href = "#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Agree</a>
   </div>
   </div>
 <div id="modalConfirm" class="modal"> 
 <div class="modal-content"> 
<h5>Message</h5> 
<h6>Are you sure?!!!</h6> 
</div> 
<div class="modal-footer"> 
 
<input id="btnConfirm" type="button" value="Confirm" class="modal-action modal-close waves-effect waves-light btn" onclick="javascript:return Delete();" /><input id="btnCancel" type="button" value="Cancel" class="modal-action modal-close waves-effect waves-light btn"  /> 
</div> 
</div>
</asp:Content>

