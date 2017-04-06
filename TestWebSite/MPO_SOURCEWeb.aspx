<%@ Page Title="MPO_SOURCE" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MPO_SOURCEWeb.aspx.cs" Inherits="MPO_SOURCEWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
<script src="Js_U/MPO_SOURCE.js"></script>
<script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
 $(document).ready(function () 
{
$('.modal-trigger').leanModal();
ForceNumberTextBox(); 
//For dropdown
BindQueryString();
$('.datepicker').pickadate({
selectMonths: true, // Creates a dropdown to control month
selectYears: 15 ,// Creates a dropdown of 15 years to control year,
format: 'd mmm yyyy',
});
 }); 
function ForceNumberTextBox() 
{
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtPR_SOURCE"))) {output = false;}
if (CheckEmtyp($("#txtPR_DEC"))) {output = false;}
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
var  PR_SOURCE =$('#txtPR_SOURCE').val();
var  PR_DEC =$('#txtPR_DEC').val();
var result = MPO_SOURCEService.Save(PR_SOURCE,PR_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtPR_SOURCE').val(result);
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
var  PR_SOURCE =$('#txtPR_SOURCE').val();
var  PR_DEC =$('#txtPR_DEC').val();
var result = MPO_SOURCEService.Update(PR_SOURCE,PR_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  PR_SOURCE =$('#txtPR_SOURCE').val();
var  PR_DEC =$('#txtPR_DEC').val();
var result = MPO_SOURCEService.Delete(PR_SOURCE,PR_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
$('#modalConfirm').closeModal();
   setInterval(function () { this.close() }, 2000);
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
//No drop/.
function BindQueryString() {

var PR_SOURCE = getQuerystring('Q');
if (PR_SOURCE != '') {
var _MPO_SOURCE = MPO_SOURCEService.Select(PR_SOURCE);

$('#txtPR_SOURCE').prop('disabled', true );
$('#txtPR_SOURCE').val(_MPO_SOURCE.PR_SOURCE);
$('#txtPR_DEC').val(_MPO_SOURCE.PR_DEC);
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
<input  id="txtPR_SOURCE" type="text" data-column-id="PR_SOURCE"  class="validate PR_SOURCE"   length="50"   maxlength="50"                /> 
<label for="txtPR_SOURCE">PR_SOURCE </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtPR_DEC" type="text" data-column-id="PR_DEC"  class="validate PR_DEC"   length="255"   maxlength="255"                /> 
<label for="txtPR_DEC">PR_DEC </label> 
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

