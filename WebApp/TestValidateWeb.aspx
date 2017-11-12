<%@ Page Title="TestValidate" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestValidateWeb.aspx.cs" Inherits="WebApp.TestValidateWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/TestValidate.js"></script>
<script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
 $(document).ready(function () 
{
$('.modal-trigger').leanModal();
ForceNumberTextBox(); 
//For dropdown
$('.datepicker').pickadate({
selectMonths: true, // Creates a dropdown to control month
selectYears: 15 ,// Creates a dropdown of 15 years to control year,
format: 'd mmm yyyy',
});
BindQueryString();
 }); 
function ForceNumberTextBox() 
{
$("#txtId").ForceNumericOnly();
$("#txtItem").ForceNumericOnly();
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtId"))) output = false;
if (CheckEmtyp($("#txtName"))) output = false;
if (CheckEmtyp($("#txtNickName"))) output = false;
if (CheckEmtyp($("#txtMax"))) output = false;
if (CheckEmtyp($("#txtItem"))) output = false;
if (CheckEmtyp($("#txtCreateItme"))) output = false;
if (output == false)
Materialize.toast('please validate your input.', 3000, 'toastCss');
return output;
}
 function CheckDuplicate() {

// Check Duplicate =============================================
var Id = $("#txtId").val();
var itemRow = TestValidateService.Select((Id));
if (itemRow != null) {
Materialize.toast('UserID นี้มีอยู่ในระบบแล้ว', 5000, 'toastCss');
return true;
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
var  Id =$('#txtId').val();
var  Name =$('#txtName').val();
var  NickName =$('#txtNickName').val();
var  Max =$('#txtMax').val();
var  Item =$('#txtItem').val();
var  CreateItme =$('#txtCreateItme').val();
var result = TestValidateService.Save(Id,Name,NickName,Max,Item,CreateItme);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtId').val(result);
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
var  Id =$('#txtId').val();
var  Name =$('#txtName').val();
var  NickName =$('#txtNickName').val();
var  Max =$('#txtMax').val();
var  Item =$('#txtItem').val();
var  CreateItme =$('#txtCreateItme').val();
var result = TestValidateService.Update(Id,Name,NickName,Max,Item,CreateItme);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  Id =$('#txtId').val();
var  Name =$('#txtName').val();
var  NickName =$('#txtNickName').val();
var  Max =$('#txtMax').val();
var  Item =$('#txtItem').val();
var  CreateItme =$('#txtCreateItme').val();
var result = TestValidateService.Delete(Id,Name,NickName,Max,Item,CreateItme);

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

var Id = getQuerystring('Q');
if (Id != '') {
var _TestValidate = TestValidateService.Select(Id);

$('#txtId').prop('disabled', true );
$('#txtId').val(_TestValidate.Id);
$('#txtName').val(_TestValidate.Name);
$('#txtNickName').val(_TestValidate.NickName);
$('#txtMax').val(_TestValidate.Max);
$('#txtItem').val(_TestValidate.Item);
var $input = $('#txtCreateItme').pickadate() 
// Use the picker object directly. 
var picker = $input.pickadate('picker'); 
picker.set('select',_TestValidate.CreateItme) 
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
<input  id="txtId" type="text" data-column-id="Id"  Class="validate Id" length="9"        maxlength="9"     />
<label for="txtId">Id </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtName" type="text" data-column-id="Name"  class="validate Name"   length="10"   maxlength="10"                /> 
<label for="txtName">Name </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtNickName" type="text" data-column-id="NickName"  class="validate NickName"   length="10"   maxlength="10"                /> 
<label for="txtNickName">NickName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtMax" type="text" data-column-id="Max"  class="validate Max"   length="10"   maxlength="10"                /> 
<label for="txtMax">Max </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtItem" type="text" data-column-id="Item"  Class="validate Item" length="9"        maxlength="9"     />
<label for="txtItem">Item </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtCreateItme"  class="datepicker" type ="date"   />
<label for="txtCreateItme">CreateItme </label> 
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
