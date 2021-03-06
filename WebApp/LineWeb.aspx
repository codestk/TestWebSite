<%@ Page Title="Line" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LineWeb.aspx.cs" Inherits="WebApp.LineWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/Line.js"></script>
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
if (CheckEmtyp($("#txtLineID"))) output = false;
if (CheckEmtyp($("#txtLineName"))) output = false;
if (CheckEmtyp($("#txtLineDetail"))) output = false;
if (output == false)
Materialize.toast('please validate your input.', 3000, 'toastCss');
return output;
}
 function CheckDuplicate() {

// Check Duplicate =============================================
var LineID = $("#txtLineID").val();
var itemRow = LineService.Select((LineID));
if (itemRow != null) {
Materialize.toast('LineID นี้มีอยู่ในระบบแล้ว', 5000, 'toastCss');
AddInvalidControl($("#txtLineID"));return true;
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
var  LineID =$('#txtLineID').val();
var  LineName =$('#txtLineName').val();
var  LineDetail =$('#txtLineDetail').val();
var result = LineService.Save(LineID,LineName,LineDetail);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtLineID').val(result);
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
var  LineID =$('#txtLineID').val();
var  LineName =$('#txtLineName').val();
var  LineDetail =$('#txtLineDetail').val();
var result = LineService.Update(LineID,LineName,LineDetail);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
var  LineID =$('#txtLineID').val();
var  LineName =$('#txtLineName').val();
var  LineDetail =$('#txtLineDetail').val();
var result = LineService.Delete(LineID,LineName,LineDetail);

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

var LineID = getQuerystring('Q');
if (LineID != '') {
var _Line = LineService.Select(LineID);

$('#txtLineID').prop('disabled', true );
$('#txtLineID').val(_Line.LineID);
$('#txtLineName').val(_Line.LineName);
$('#txtLineDetail').val(_Line.LineDetail);
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
<input  id="txtLineID" type="text" data-column-id="LineID"  class="validate LineID"   length="2"   maxlength="2"                /> 
<label for="txtLineID">LineID </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtLineName" type="text" data-column-id="LineName"  class="validate LineName"   length="2147483647"   maxlength="2147483647"                /> 
<label for="txtLineName">LineName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtLineDetail" type="text" data-column-id="LineDetail"  class="validate LineDetail"   length="2147483647"   maxlength="2147483647"                /> 
<label for="txtLineDetail">LineDetail </label> 
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
