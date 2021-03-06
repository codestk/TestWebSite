<%@ Page Title="Source" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SourceWeb.aspx.cs" Inherits="WebApp.SourceWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/Source.js"></script>
<script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
 $(document).ready(function () 
{
$('.modal-trigger').leanModal();
ForceNumberTextBox(); 
$('.datepicker').pickadate({
selectMonths: true, // Creates a dropdown to control month
selectYears: 15 ,// Creates a dropdown of 15 years to control year,
format: 'd mmm yyyy',
});
//For dropdown
BindQueryString();
 }); 
function ForceNumberTextBox() 
{
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtSourceID"))) output = false;
if (CheckEmtyp($("#txtSourceName"))) output = false;
if (CheckEmtyp($("#txtSourceDetail"))) output = false;
if (output == false)
Materialize.toast('please validate your input.', 3000, 'toastCss');
return output;
}
 function CheckDuplicate() {

// Check Duplicate =============================================
var SourceID = $("#txtSourceID").val();
var itemRow = SourceService.Select((SourceID));
if (itemRow != null) {
Materialize.toast('SourceID นี้มีอยู่ในระบบแล้ว', 5000, 'toastCss');
AddInvalidControl($("#txtSourceID"));return true;
}//==============================================================
return false;
}
function Confirm() { 
$('#modalConfirm').openModal(); 
return false; 
}
function Save() {
 if (Validate() == false) { return false; }
if (CheckDuplicate() == true) { return false; }
var  SourceID =$('#txtSourceID').val();
var  SourceName =$('#txtSourceName').val();
var  SourceDetail =$('#txtSourceDetail').val();
var result = SourceService.Save(SourceID,SourceName,SourceDetail);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtSourceID').val(result);
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
var  SourceID =$('#txtSourceID').val();
var  SourceName =$('#txtSourceName').val();
var  SourceDetail =$('#txtSourceDetail').val();
var result = SourceService.Update(SourceID,SourceName,SourceDetail);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
var  SourceID =$('#txtSourceID').val();
var  SourceName =$('#txtSourceName').val();
var  SourceDetail =$('#txtSourceDetail').val();
var result = SourceService.Delete(SourceID,SourceName,SourceDetail);

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

var SourceID = getQuerystring('Q');
if (SourceID != '') {
var _Source = SourceService.Select(SourceID);

$('#txtSourceID').prop('disabled', true );
$('#txtSourceID').val(_Source.SourceID);
$('#txtSourceName').val(_Source.SourceName);
$('#txtSourceDetail').val(_Source.SourceDetail);
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
<div class="row"><div class="input-field col s9"> 
<input  id="txtSourceID" type="text" data-column-id="SourceID"  class="validate SourceID"   length="3"   maxlength="3"                /> 
<label for="txtSourceID">SourceID </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtSourceName" type="text" data-column-id="SourceName"  class="validate SourceName"   length="2147483647"   maxlength="2147483647"                /> 
<label for="txtSourceName">SourceName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtSourceDetail" type="text" data-column-id="SourceDetail"  class="validate SourceDetail"   length="2147483647"   maxlength="2147483647"                /> 
<label for="txtSourceDetail">SourceDetail </label> 
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
