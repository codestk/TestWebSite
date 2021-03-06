<%@ Page Title="APP_USER" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="APP_USERWeb.aspx.cs" Inherits="WebApp.APP_USERWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/APP_USER.js"></script>
    <link href="Module/Stk/StkImageUpload/StkImageUpload.css" rel="stylesheet" />    <script src="Module/Stk/StkImageUpload/StkImageUpload.js"></script>    <script src="Module/Stk/ValidateStk.js"></script><script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
  var apiService = "api/APP_USERImageController/";
        var handlerService = "APP_USERImageHandler.ashx";
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
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtUserID"))) output = false;
if (CheckEmtyp($("#txtPassword"))) output = false;
if (CheckEmtyp($("#txtFirstName"))) output = false;
if (CheckEmtyp($("#txtLastName"))) output = false;
if (CheckEmtyp($("#txtTel"))) output = false;
if (CheckEmtyp($("#txtCreated"))) output = false;
if (output == false)
Materialize.toast('please validate your input.', 3000, 'toastCss');
return output;
}
 function CheckDuplicate() {

// Check Duplicate =============================================
var UserID = $("#txtUserID").val();
var itemRow = APP_USERService.Select((UserID));
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
var  UserID =$('#txtUserID').val();
var  Password =$('#txtPassword').val();
var  FirstName =$('#txtFirstName').val();
var  LastName =$('#txtLastName').val();
var  Tel =$('#txtTel').val();
var  FLAG =$('#chkFLAG').prop('checked');
var  RoleAdmin =$('#chkRoleAdmin').prop('checked');
var  RoleUser =$('#chkRoleUser').prop('checked');
var  Created =$('#txtCreated').val();
var result = APP_USERService.Save(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtUserID').val(result);
$('#btnSave').hide();
$('#btnUpdate').show();
$('#btnDelete').show();
 var id =  $('#txtUserID').val();

DropArea(id, apiService, handlerService);
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Update() {
 if (Validate() == false) { return false; }
var  UserID =$('#txtUserID').val();
var  Password =$('#txtPassword').val();
var  FirstName =$('#txtFirstName').val();
var  LastName =$('#txtLastName').val();
var  Tel =$('#txtTel').val();
var  FLAG =$('#chkFLAG').prop('checked');
var  RoleAdmin =$('#chkRoleAdmin').prop('checked');
var  RoleUser =$('#chkRoleUser').prop('checked');
var  Created =$('#txtCreated').val();
var result = APP_USERService.Update(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  UserID =$('#txtUserID').val();
var  Password =$('#txtPassword').val();
var  FirstName =$('#txtFirstName').val();
var  LastName =$('#txtLastName').val();
var  Tel =$('#txtTel').val();
var  FLAG =$('#chkFLAG').val();
var  RoleAdmin =$('#chkRoleAdmin').val();
var  RoleUser =$('#chkRoleUser').val();
var  Created =$('#txtCreated').val();
var result = APP_USERService.Delete(UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created);

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

var UserID = getQuerystring('Q');
if (UserID != '') {
var _APP_USER = APP_USERService.Select(UserID);

$('#txtUserID').prop('disabled', true );
$('#txtUserID').val(_APP_USER.UserID);
$('#txtPassword').val(_APP_USER.Password);
$('#txtFirstName').val(_APP_USER.FirstName);
$('#txtLastName').val(_APP_USER.LastName);
$('#txtTel').val(_APP_USER.Tel);
$('#chkFLAG').prop('checked', _APP_USER.FLAG); 
$('#chkRoleAdmin').prop('checked', _APP_USER.RoleAdmin); 
$('#chkRoleUser').prop('checked', _APP_USER.RoleUser); 
var $input = $('#txtCreated').pickadate() 
// Use the picker object directly. 
var picker = $input.pickadate('picker'); 
picker.set('select',_APP_USER.Created) 
$('#btnSave').hide();
 DropArea(UserID, apiService, handlerService);
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
<input  id="txtUserID" type="text" data-column-id="UserID"  class="validate UserID"   length="50"   maxlength="50"                /> 
<label for="txtUserID">UserID </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtPassword" type="text" data-column-id="Password"  class="validate Password"   length="50"   maxlength="50"                /> 
<label for="txtPassword">Password </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtFirstName" type="text" data-column-id="FirstName"  class="validate FirstName"   length="50"   maxlength="50"                /> 
<label for="txtFirstName">FirstName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtLastName" type="text" data-column-id="LastName"  class="validate LastName"   length="50"   maxlength="50"                /> 
<label for="txtLastName">LastName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtTel" type="text" data-column-id="Tel"  class="validate Tel"   length="50"   maxlength="50"                /> 
<label for="txtTel">Tel </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="chkFLAG"    type="checkbox" />
<label for="chkFLAG">FLAG </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="chkRoleAdmin"    type="checkbox" />
<label for="chkRoleAdmin">RoleAdmin </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="chkRoleUser"    type="checkbox" />
<label for="chkRoleUser">RoleUser </label> 
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
<input  id="txtCreated"  class="datepicker" type ="date"   />
<label for="txtCreated">Created </label> 
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
