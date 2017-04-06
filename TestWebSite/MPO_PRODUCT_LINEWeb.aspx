<%@ Page Title="MPO_PRODUCT_LINE" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MPO_PRODUCT_LINEWeb.aspx.cs" Inherits="MPO_PRODUCT_LINEWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
<script src="Js_U/MPO_PRODUCT_LINE.js"></script>
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
if (CheckEmtyp($("#txtPR_PRODUCT_LINE"))) {output = false;}
if (CheckEmtyp($("#txtPRODUCT_LINE_DEC"))) {output = false;}
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
var  PR_PRODUCT_LINE =$('#txtPR_PRODUCT_LINE').val();
var  PRODUCT_LINE_DEC =$('#txtPRODUCT_LINE_DEC').val();
var result = MPO_PRODUCT_LINEService.Save(PR_PRODUCT_LINE,PRODUCT_LINE_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtPR_PRODUCT_LINE').val(result);
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
var  PR_PRODUCT_LINE =$('#txtPR_PRODUCT_LINE').val();
var  PRODUCT_LINE_DEC =$('#txtPRODUCT_LINE_DEC').val();
var result = MPO_PRODUCT_LINEService.Update(PR_PRODUCT_LINE,PRODUCT_LINE_DEC);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  PR_PRODUCT_LINE =$('#txtPR_PRODUCT_LINE').val();
var  PRODUCT_LINE_DEC =$('#txtPRODUCT_LINE_DEC').val();
var result = MPO_PRODUCT_LINEService.Delete(PR_PRODUCT_LINE,PRODUCT_LINE_DEC);

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

var PR_PRODUCT_LINE = getQuerystring('Q');
if (PR_PRODUCT_LINE != '') {
var _MPO_PRODUCT_LINE = MPO_PRODUCT_LINEService.Select(PR_PRODUCT_LINE);

$('#txtPR_PRODUCT_LINE').prop('disabled', true );
$('#txtPR_PRODUCT_LINE').val(_MPO_PRODUCT_LINE.PR_PRODUCT_LINE);
$('#txtPRODUCT_LINE_DEC').val(_MPO_PRODUCT_LINE.PRODUCT_LINE_DEC);
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
<input  id="txtPR_PRODUCT_LINE" type="text" data-column-id="PR_PRODUCT_LINE"  class="validate PR_PRODUCT_LINE"   length="50"   maxlength="50"                /> 
<label for="txtPR_PRODUCT_LINE">PR_PRODUCT_LINE </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtPRODUCT_LINE_DEC" type="text" data-column-id="PRODUCT_LINE_DEC"  class="validate PRODUCT_LINE_DEC"   length="255"   maxlength="255"                /> 
<label for="txtPRODUCT_LINE_DEC">PRODUCT_LINE_DEC </label> 
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

