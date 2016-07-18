<%@ Page Title="Employees" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeesWeb.aspx.cs" Inherits="EmployeesWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/Employees.js"></script>
    <link href="Module/Stk/StkImageUpload/StkImageUpload.css" rel="stylesheet" />    <script src="Module/Stk/StkImageUpload/StkImageUpload.js"></script>    <script src="Module/Stk/ValidateStk.js"></script><script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
  var apiService = "api/EmployeesImageController/";        var handlerService = "EmployeesImageHandler.ashx"; $(document).ready(function () 
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
$("#txtReportsTo").ForceNumericOnly();
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtLastName"))) output = false;
if (CheckEmtyp($("#txtFirstName"))) output = false;
if (CheckEmtyp($("#txtTitle"))) output = false;
if (CheckEmtyp($("#txtTitleOfCourtesy"))) output = false;
if (CheckEmtyp($("#txtBirthDate"))) output = false;
if (CheckEmtyp($("#txtHireDate"))) output = false;
if (CheckEmtyp($("#txtAddress"))) output = false;
if (CheckEmtyp($("#txtCity"))) output = false;
if (CheckEmtyp($("#txtRegion"))) output = false;
if (CheckEmtyp($("#txtPostalCode"))) output = false;
if (CheckEmtyp($("#txtCountry"))) output = false;
if (CheckEmtyp($("#txtHomePhone"))) output = false;
if (CheckEmtyp($("#txtExtension"))) output = false;
if (CheckEmtyp($("#txtReportsTo"))) output = false;
if (CheckEmtyp($("#txtPhotoPath"))) output = false;
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
var  EmployeeID =$('#txtEmployeeID').val();
var  LastName =$('#txtLastName').val();
var  FirstName =$('#txtFirstName').val();
var  Title =$('#txtTitle').val();
var  TitleOfCourtesy =$('#txtTitleOfCourtesy').val();
var  BirthDate =$('#txtBirthDate').val();
var  HireDate =$('#txtHireDate').val();
var  Address =$('#txtAddress').val();
var  City =$('#txtCity').val();
var  Region =$('#txtRegion').val();
var  PostalCode =$('#txtPostalCode').val();
var  Country =$('#txtCountry').val();
var  HomePhone =$('#txtHomePhone').val();
var  Extension =$('#txtExtension').val();
var  ReportsTo =$('#txtReportsTo').val();
var  PhotoPath =$('#txtPhotoPath').val();
var result = EmployeesService.Save(EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtEmployeeID').val(result);
$('#btnSave').hide();
$('#btnUpdate').show();
$('#btnDelete').show();
 var id =  $('#txtEmployeeID').val();

DropArea(id, apiService, handlerService);
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Update() {
 if (Validate() == false) { return false; }
var  EmployeeID =$('#txtEmployeeID').val();
var  LastName =$('#txtLastName').val();
var  FirstName =$('#txtFirstName').val();
var  Title =$('#txtTitle').val();
var  TitleOfCourtesy =$('#txtTitleOfCourtesy').val();
var  BirthDate =$('#txtBirthDate').val();
var  HireDate =$('#txtHireDate').val();
var  Address =$('#txtAddress').val();
var  City =$('#txtCity').val();
var  Region =$('#txtRegion').val();
var  PostalCode =$('#txtPostalCode').val();
var  Country =$('#txtCountry').val();
var  HomePhone =$('#txtHomePhone').val();
var  Extension =$('#txtExtension').val();
var  ReportsTo =$('#txtReportsTo').val();
var  PhotoPath =$('#txtPhotoPath').val();
var result = EmployeesService.Update(EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  EmployeeID =$('#txtEmployeeID').val();
var  LastName =$('#txtLastName').val();
var  FirstName =$('#txtFirstName').val();
var  Title =$('#txtTitle').val();
var  TitleOfCourtesy =$('#txtTitleOfCourtesy').val();
var  BirthDate =$('#txtBirthDate').val();
var  HireDate =$('#txtHireDate').val();
var  Address =$('#txtAddress').val();
var  City =$('#txtCity').val();
var  Region =$('#txtRegion').val();
var  PostalCode =$('#txtPostalCode').val();
var  Country =$('#txtCountry').val();
var  HomePhone =$('#txtHomePhone').val();
var  Extension =$('#txtExtension').val();
var  ReportsTo =$('#txtReportsTo').val();
var  PhotoPath =$('#txtPhotoPath').val();
var result = EmployeesService.Delete(EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath);

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

var EmployeeID = getQuerystring('Q');
if (EmployeeID != '') {
var _Employees = EmployeesService.Select(EmployeeID);

$('#txtEmployeeID').prop('disabled', true );
$('#txtEmployeeID').val(_Employees.EmployeeID);
$('#txtLastName').val(_Employees.LastName);
$('#txtFirstName').val(_Employees.FirstName);
$('#txtTitle').val(_Employees.Title);
$('#txtTitleOfCourtesy').val(_Employees.TitleOfCourtesy);
$('#txtBirthDate').val(_Employees.BirthDate);
$('#txtHireDate').val(_Employees.HireDate);
$('#txtAddress').val(_Employees.Address);
$('#txtCity').val(_Employees.City);
$('#txtRegion').val(_Employees.Region);
$('#txtPostalCode').val(_Employees.PostalCode);
$('#txtCountry').val(_Employees.Country);
$('#txtHomePhone').val(_Employees.HomePhone);
$('#txtExtension').val(_Employees.Extension);
$('#txtReportsTo').val(_Employees.ReportsTo);
$('#txtPhotoPath').val(_Employees.PhotoPath);
$('#btnSave').hide();
 DropArea(CategoryID, apiService, handlerService);
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
<div class="row"><div class="  col s9"> 
<label>EmployeeID </label> 
<input ReadOnly="true"  id="txtEmployeeID" type="text" data-column-id="EmployeeID"  Class="validate EmployeeID" length="9"        maxlength="9"     />
 </div> 
<div class="input-field col s9"> 
<input  id="txtLastName" type="text" data-column-id="LastName"  class="validate LastName"   length="20"   maxlength="20"                /> 
<label for="txtLastName">LastName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtFirstName" type="text" data-column-id="FirstName"  class="validate FirstName"   length="10"   maxlength="10"                /> 
<label for="txtFirstName">FirstName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtTitle" type="text" data-column-id="Title"  class="validate Title"   length="30"   maxlength="30"                /> 
<label for="txtTitle">Title </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtTitleOfCourtesy" type="text" data-column-id="TitleOfCourtesy"  class="validate TitleOfCourtesy"   length="25"   maxlength="25"                /> 
<label for="txtTitleOfCourtesy">TitleOfCourtesy </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtBirthDate"  class="datepicker" type ="date"   />
<label for="txtBirthDate">BirthDate </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtHireDate"  class="datepicker" type ="date"   />
<label for="txtHireDate">HireDate </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtAddress" type="text" data-column-id="Address"  class="validate Address"   length="60"   maxlength="60"                /> 
<label for="txtAddress">Address </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtCity" type="text" data-column-id="City"  class="validate City"   length="15"   maxlength="15"                /> 
<label for="txtCity">City </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtRegion" type="text" data-column-id="Region"  class="validate Region"   length="15"   maxlength="15"                /> 
<label for="txtRegion">Region </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtPostalCode" type="text" data-column-id="PostalCode"  class="validate PostalCode"   length="10"   maxlength="10"                /> 
<label for="txtPostalCode">PostalCode </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtCountry" type="text" data-column-id="Country"  class="validate Country"   length="15"   maxlength="15"                /> 
<label for="txtCountry">Country </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtHomePhone" type="text" data-column-id="HomePhone"  class="validate HomePhone"   length="24"   maxlength="24"                /> 
<label for="txtHomePhone">HomePhone </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtExtension" type="text" data-column-id="Extension"  class="validate Extension"   length="4"   maxlength="4"                /> 
<label for="txtExtension">Extension </label> 
 </div> 

            <div id="drop-area"  style="display:none">
                <div id="drop-area-detail">

                    <h3 class="drop-text">Drag and Drop Images Here</h3>

                    <div class="progressUpload">
                        <div class="bar"></div>
                        <div class="percent">0%</div>
                    </div>
                </div>
                <div id="drop-area-preview" style="display: none">
                    <img id="imgPreview"   height="131" width="174" alt="Image preview...">
                    <img id="imgRemove" src="Images/Close.png" />
                </div>
                <div id="status"></div>
            </div>
<div class="input-field col s9"> 
<input  id="txtReportsTo" type="text" data-column-id="ReportsTo"  Class="validate ReportsTo" length="9"        maxlength="9"     />
<label for="txtReportsTo">ReportsTo </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtPhotoPath" type="text" data-column-id="PhotoPath"  class="validate PhotoPath"   length="255"   maxlength="255"                /> 
<label for="txtPhotoPath">PhotoPath </label> 
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

