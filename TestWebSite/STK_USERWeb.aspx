<%@ Page Title="STK_USER" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="STK_USERWeb.aspx.cs" Inherits="STK_USERWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/STK_USER.js"></script>
<script src="Js_U/STK_USER_FLAG.js"></script>
<script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
 $(document).ready(function () 
{
$('.modal-trigger').leanModal();
ForceNumberTextBox(); 
//For dropdown
SetSelectEM_FLAG('#drpEM_FLAG');
$('select').material_select(); 
BindQueryString();
$('select').material_select(); 
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
if (CheckEmtyp($("#txtEM_ID"))) output = false;
if (CheckEmtyp($("#txtEM_PASS"))) output = false;
if (CheckEmtyp($("#txtEM_NAME"))) output = false;
if (CheckEmtyp($("#txtEM_SURNAME"))) output = false;
if (CheckEmtyp($("#txtEM_TEL"))) output = false;
if (CheckEmtyp($("#txtEM_ADDRESS"))) output = false;
if(($("#drpEM_FLAG").prop('selectedIndex')==0)||($("#drpEM_FLAG").prop('selectedIndex')==-1)){
output=false;

$("#drpEM_FLAG").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpEM_FLAG").prev().prev().removeClass('CustomInvalid');
$("#drpEM_FLAG").prev().prev().addClass('CustomValid');
 
 
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
var  EM_ID =$('#txtEM_ID').val();
var  EM_PASS =$('#txtEM_PASS').val();
var  EM_NAME =$('#txtEM_NAME').val();
var  EM_SURNAME =$('#txtEM_SURNAME').val();
var  EM_TEL =$('#txtEM_TEL').val();
var  EM_ADDRESS =$('#txtEM_ADDRESS').val();
var  EM_FLAG =$('#drpEM_FLAG').val();
var  EM_ROLE_ADMIN =$('#chkEM_ROLE_ADMIN').prop('checked');
var  EM_ROLE_USER =$('#chkEM_ROLE_USER').prop('checked');
var result = STK_USERService.Save(EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtEM_ID').val(result);
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
var  EM_ID =$('#txtEM_ID').val();
var  EM_PASS =$('#txtEM_PASS').val();
var  EM_NAME =$('#txtEM_NAME').val();
var  EM_SURNAME =$('#txtEM_SURNAME').val();
var  EM_TEL =$('#txtEM_TEL').val();
var  EM_ADDRESS =$('#txtEM_ADDRESS').val();
var  EM_FLAG =$('#drpEM_FLAG').val();
var  EM_ROLE_ADMIN =$('#chkEM_ROLE_ADMIN').prop('checked');
var  EM_ROLE_USER =$('#chkEM_ROLE_USER').prop('checked');
var result = STK_USERService.Update(EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  EM_ID =$('#txtEM_ID').val();
var  EM_PASS =$('#txtEM_PASS').val();
var  EM_NAME =$('#txtEM_NAME').val();
var  EM_SURNAME =$('#txtEM_SURNAME').val();
var  EM_TEL =$('#txtEM_TEL').val();
var  EM_ADDRESS =$('#txtEM_ADDRESS').val();
var  EM_FLAG =$('#drpEM_FLAG').val();
var  EM_ROLE_ADMIN =$('#chkEM_ROLE_ADMIN').val();
var  EM_ROLE_USER =$('#chkEM_ROLE_USER').val();
var result = STK_USERService.Delete(EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
$('#modalConfirm').closeModal();
   setInterval(function () { this.close() }, 2000);
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
 function SetSelectEM_FLAG(control) {

var innitOption = '<option value="">Please Select</option>';
var resultSTK_USER_FLAG = STK_USER_FLAGService.SelectAll();
$(control).append(innitOption);
$.each(resultSTK_USER_FLAG, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
function BindQueryString() {

var EM_ID = GetQueryString('Q');
if (EM_ID != '') {
var _STK_USER = STK_USERService.Select(EM_ID);

$('#txtEM_ID').prop('disabled', true );
$('#txtEM_ID').val(_STK_USER.EM_ID);
$('#txtEM_PASS').val(_STK_USER.EM_PASS);
$('#txtEM_NAME').val(_STK_USER.EM_NAME);
$('#txtEM_SURNAME').val(_STK_USER.EM_SURNAME);
$('#txtEM_TEL').val(_STK_USER.EM_TEL);
$('#txtEM_ADDRESS').val(_STK_USER.EM_ADDRESS);
$('#drpEM_FLAG').val(_STK_USER.EM_FLAG);
$('#chkEM_ROLE_ADMIN').prop('checked', _STK_USER.EM_ROLE_ADMIN); 
$('#chkEM_ROLE_USER').prop('checked', _STK_USER.EM_ROLE_USER); 
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
<input  id="txtEM_ID" type="text" data-column-id="EM_ID"  class="validate EM_ID"   length="50"  /> 
<label for="txtEM_ID">EM_ID </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="txtEM_PASS" type="text" data-column-id="EM_PASS"  class="validate EM_PASS"   length="50"  /> 
<label for="txtEM_PASS">EM_PASS </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="txtEM_NAME" type="text" data-column-id="EM_NAME"  class="validate EM_NAME"   length="50"  /> 
<label for="txtEM_NAME">EM_NAME </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="txtEM_SURNAME" type="text" data-column-id="EM_SURNAME"  class="validate EM_SURNAME"   length="50"  /> 
<label for="txtEM_SURNAME">EM_SURNAME </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="txtEM_TEL" type="text" data-column-id="EM_TEL"  class="validate EM_TEL"   length="50"  /> 
<label for="txtEM_TEL">EM_TEL </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="txtEM_ADDRESS" type="text" data-column-id="EM_ADDRESS"  class="validate EM_ADDRESS"   length="255"  /> 
<label for="txtEM_ADDRESS">EM_ADDRESS </label> 
 </div> 
<div class="input-field col s12"> 
<select id="drpEM_FLAG" > 
 
</select>
<label for="drpEM_FLAG">EM_FLAG</label>
</div>
<div class="input-field col s12"> 
<input  id="chkEM_ROLE_ADMIN"    type="checkbox" />
<label for="chkEM_ROLE_ADMIN">EM_ROLE_ADMIN </label> 
 </div> 
<div class="input-field col s12"> 
<input  id="chkEM_ROLE_USER"    type="checkbox" />
<label for="chkEM_ROLE_USER">EM_ROLE_USER </label> 
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

