<%@ Page Title="STK_USER_FLAG" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="STK_USER_FLAGWeb.aspx.cs" Inherits="STK_USER_FLAGWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/STK_USER_FLAG.js"></script>
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
format: 'd mmmm yyyy',
});
 }); 
function ForceNumberTextBox() 
{
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtEM_FLAG"))) output = false;
if (CheckEmtyp($("#txtEM_DES"))) output = false;
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
var  EM_FLAG =$('#txtEM_FLAG').val();
var  EM_DES =$('#txtEM_DES').val();
var result = STK_USER_FLAGService.Save(EM_FLAG,EM_DES);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtEM_FLAG').val(result);
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
var  EM_FLAG =$('#txtEM_FLAG').val();
var  EM_DES =$('#txtEM_DES').val();
var result = STK_USER_FLAGService.Update(EM_FLAG,EM_DES);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  EM_FLAG =$('#txtEM_FLAG').val();
var  EM_DES =$('#txtEM_DES').val();
var result = STK_USER_FLAGService.Delete(EM_FLAG,EM_DES);

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

var EM_FLAG = GetQueryString('Q');
if (EM_FLAG != '') {
var _STK_USER_FLAG = STK_USER_FLAGService.Select(EM_FLAG);

$('#txtEM_FLAG').prop('disabled', true );
$('#txtEM_FLAG').val(_STK_USER_FLAG.EM_FLAG);
$('#txtEM_DES').val(_STK_USER_FLAG.EM_DES);
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
<div class="container">
<div class="row"><div class="input-field col s12"> 
<input  id="txtEM_FLAG" type="text" data-column-id="EM_FLAG"  class="validate EM_FLAG"   length="10"  /> 
<label for="txtEM_FLAG">EM_FLAG </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="txtEM_DES" type="text" data-column-id="EM_DES"  class="validate EM_DES"   length="50"  /> 
<label for="txtEM_DES">EM_DES </label> 
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

