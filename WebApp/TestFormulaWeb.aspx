<%@ Page Title="TestFormula" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestFormulaWeb.aspx.cs" Inherits="WebApp.TestFormulaWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/TestFormula.js"></script>
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
if (CheckEmtyp($("#txtTestFormulaID"))) output = false;
if (CheckEmtyp($("#txtTestFormulaName"))) output = false;
if (CheckEmtyp($("#txtTestFormulaDetail"))) output = false;
if (output == false)
Materialize.toast('please validate your input.', 3000, 'toastCss');
return output;
}
 function CheckDuplicate() {

// Check Duplicate =============================================
var TestFormulaID = $("#txtTestFormulaID").val();
var itemRow = TestFormulaService.Select((TestFormulaID));
if (itemRow != null) {
Materialize.toast('TestFormulaID นี้มีอยู่ในระบบแล้ว', 5000, 'toastCss');
AddInvalidControl($("#txtTestFormulaID"));return true;
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
var  TestFormulaID =$('#txtTestFormulaID').val();
var  TestFormulaName =$('#txtTestFormulaName').val();
var  TestFormulaDetail =$('#txtTestFormulaDetail').val();
var result = TestFormulaService.Save(TestFormulaID,TestFormulaName,TestFormulaDetail);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtTestFormulaID').val(result);
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
var  TestFormulaID =$('#txtTestFormulaID').val();
var  TestFormulaName =$('#txtTestFormulaName').val();
var  TestFormulaDetail =$('#txtTestFormulaDetail').val();
var result = TestFormulaService.Update(TestFormulaID,TestFormulaName,TestFormulaDetail);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
var  TestFormulaID =$('#txtTestFormulaID').val();
var  TestFormulaName =$('#txtTestFormulaName').val();
var  TestFormulaDetail =$('#txtTestFormulaDetail').val();
var result = TestFormulaService.Delete(TestFormulaID,TestFormulaName,TestFormulaDetail);

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

var TestFormulaID = getQuerystring('Q');
if (TestFormulaID != '') {
var _TestFormula = TestFormulaService.Select(TestFormulaID);

$('#txtTestFormulaID').prop('disabled', true );
$('#txtTestFormulaID').val(_TestFormula.TestFormulaID);
$('#txtTestFormulaName').val(_TestFormula.TestFormulaName);
$('#txtTestFormulaDetail').val(_TestFormula.TestFormulaDetail);
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
<input  id="txtTestFormulaID" type="text" data-column-id="TestFormulaID"  class="validate TestFormulaID"   length="4"   maxlength="4"                /> 
<label for="txtTestFormulaID">TestFormulaID </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtTestFormulaName" type="text" data-column-id="TestFormulaName"  class="validate TestFormulaName"   length="2147483647"   maxlength="2147483647"                /> 
<label for="txtTestFormulaName">TestFormulaName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtTestFormulaDetail" type="text" data-column-id="TestFormulaDetail"  class="validate TestFormulaDetail"   length="2147483647"   maxlength="2147483647"                /> 
<label for="txtTestFormulaDetail">TestFormulaDetail </label> 
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
