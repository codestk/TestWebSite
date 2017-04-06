<%@ Page Title="MPO_TYPE_P2" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MPO_TYPE_P2Web.aspx.cs" Inherits="MPO_TYPE_P2Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
<script src="Js_U/MPO_TYPE_P2.js"></script>
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
if (CheckEmtyp($("#txtPR_TYPE"))) {output = false;}
if (CheckEmtyp($("#txtTYPE_DEC"))) {output = false;}
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
var  PR_TYPE =$('#txtPR_TYPE').val();
var  TYPE_DEC =$('#txtTYPE_DEC').val();
var result = MPO_TYPE_P2Service.Save(PR_TYPE,TYPE_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtPR_TYPE').val(result);
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
var  PR_TYPE =$('#txtPR_TYPE').val();
var  TYPE_DEC =$('#txtTYPE_DEC').val();
var result = MPO_TYPE_P2Service.Update(PR_TYPE,TYPE_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  PR_TYPE =$('#txtPR_TYPE').val();
var  TYPE_DEC =$('#txtTYPE_DEC').val();
var result = MPO_TYPE_P2Service.Delete(PR_TYPE,TYPE_DEC);

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

var PR_TYPE = getQuerystring('Q');
if (PR_TYPE != '') {
var _MPO_TYPE_P2 = MPO_TYPE_P2Service.Select(PR_TYPE);

$('#txtPR_TYPE').prop('disabled', true );
$('#txtPR_TYPE').val(_MPO_TYPE_P2.PR_TYPE);
$('#txtTYPE_DEC').val(_MPO_TYPE_P2.TYPE_DEC);
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
<input  id="txtPR_TYPE" type="text" data-column-id="PR_TYPE"  class="validate PR_TYPE"   length="50"   maxlength="50"                /> 
<label for="txtPR_TYPE">PR_TYPE </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtTYPE_DEC" type="text" data-column-id="TYPE_DEC"  class="validate TYPE_DEC"   length="255"   maxlength="255"                /> 
<label for="txtTYPE_DEC">TYPE_DEC </label> 
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

