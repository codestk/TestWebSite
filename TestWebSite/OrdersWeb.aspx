<%@ Page Title="Orders" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrdersWeb.aspx.cs" Inherits="OrdersWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/Orders.js"></script>
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
$("#txtEmployeeID").ForceNumericOnly();
$("#txtShipVia").ForceNumericOnly();
$("#txtFreight").ForceNumericOnly2Digit();
}
function Validate() {
var output=true;
if (CheckEmtyp($("#txtCustomerID"))) {output = false;}
if (CheckEmtyp($("#txtEmployeeID"))) {output = false;}
if (CheckEmtyp($("#txtOrderDate"))) {output = false;}
if (CheckEmtyp($("#txtRequiredDate"))) {output = false;}
if (CheckEmtyp($("#txtShippedDate"))) {output = false;}
if (CheckEmtyp($("#txtShipVia"))) {output = false;}
if (CheckEmtyp($("#txtFreight"))) {output = false;}
if (CheckEmtyp($("#txtShipName"))) {output = false;}
if (CheckEmtyp($("#txtShipAddress"))) {output = false;}
if (CheckEmtyp($("#txtShipCity"))) {output = false;}
if (CheckEmtyp($("#txtShipRegion"))) {output = false;}
if (CheckEmtyp($("#txtShipPostalCode"))) {output = false;}
if (CheckEmtyp($("#txtShipCountry"))) {output = false;}
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
var  OrderID =$('#txtOrderID').val();
var  CustomerID =$('#txtCustomerID').val();
var  EmployeeID =$('#txtEmployeeID').val();
var  OrderDate =$('#txtOrderDate').val();
var  RequiredDate =$('#txtRequiredDate').val();
var  ShippedDate =$('#txtShippedDate').val();
var  ShipVia =$('#txtShipVia').val();
var  Freight =$('#txtFreight').val();
var  ShipName =$('#txtShipName').val();
var  ShipAddress =$('#txtShipAddress').val();
var  ShipCity =$('#txtShipCity').val();
var  ShipRegion =$('#txtShipRegion').val();
var  ShipPostalCode =$('#txtShipPostalCode').val();
var  ShipCountry =$('#txtShipCountry').val();
var result = OrdersService.Save(OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtOrderID').val(result);
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
var  OrderID =$('#txtOrderID').val();
var  CustomerID =$('#txtCustomerID').val();
var  EmployeeID =$('#txtEmployeeID').val();
var  OrderDate =$('#txtOrderDate').val();
var  RequiredDate =$('#txtRequiredDate').val();
var  ShippedDate =$('#txtShippedDate').val();
var  ShipVia =$('#txtShipVia').val();
var  Freight =$('#txtFreight').val();
var  ShipName =$('#txtShipName').val();
var  ShipAddress =$('#txtShipAddress').val();
var  ShipCity =$('#txtShipCity').val();
var  ShipRegion =$('#txtShipRegion').val();
var  ShipPostalCode =$('#txtShipPostalCode').val();
var  ShipCountry =$('#txtShipCountry').val();
var result = OrdersService.Update(OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
 if (Validate() == false) { return false; }
var  OrderID =$('#txtOrderID').val();
var  CustomerID =$('#txtCustomerID').val();
var  EmployeeID =$('#txtEmployeeID').val();
var  OrderDate =$('#txtOrderDate').val();
var  RequiredDate =$('#txtRequiredDate').val();
var  ShippedDate =$('#txtShippedDate').val();
var  ShipVia =$('#txtShipVia').val();
var  Freight =$('#txtFreight').val();
var  ShipName =$('#txtShipName').val();
var  ShipAddress =$('#txtShipAddress').val();
var  ShipCity =$('#txtShipCity').val();
var  ShipRegion =$('#txtShipRegion').val();
var  ShipPostalCode =$('#txtShipPostalCode').val();
var  ShipCountry =$('#txtShipCountry').val();
var result = OrdersService.Delete(OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry);

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

var OrderID = getQuerystring('Q');
if (OrderID != '') {
var _Orders = OrdersService.Select(OrderID);

$('#txtOrderID').prop('disabled', true );
$('#txtOrderID').val(_Orders.OrderID);
$('#txtCustomerID').val(_Orders.CustomerID);
$('#txtEmployeeID').val(_Orders.EmployeeID);
$('#txtOrderDate').val(_Orders.OrderDate);
$('#txtRequiredDate').val(_Orders.RequiredDate);
$('#txtShippedDate').val(_Orders.ShippedDate);
$('#txtShipVia').val(_Orders.ShipVia);
$('#txtFreight').val(_Orders.Freight);
$('#txtShipName').val(_Orders.ShipName);
$('#txtShipAddress').val(_Orders.ShipAddress);
$('#txtShipCity').val(_Orders.ShipCity);
$('#txtShipRegion').val(_Orders.ShipRegion);
$('#txtShipPostalCode').val(_Orders.ShipPostalCode);
$('#txtShipCountry').val(_Orders.ShipCountry);
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
<div class="row"><div class="  col s9"> 
<label>OrderID </label> 
<input ReadOnly="true"  id="txtOrderID" type="text" data-column-id="OrderID"  Class="validate OrderID" length="9"        maxlength="9"     />
 </div> 
<div class="input-field col s9"> 
<input  id="txtCustomerID" type="text" data-column-id="CustomerID"  class="validate CustomerID"   length="5"   maxlength="5"                /> 
<label for="txtCustomerID">CustomerID </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtEmployeeID" type="text" data-column-id="EmployeeID"  Class="validate EmployeeID" length="9"        maxlength="9"     />
<label for="txtEmployeeID">EmployeeID </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtOrderDate"  class="datepicker" type ="date"   />
<label for="txtOrderDate">OrderDate </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtRequiredDate"  class="datepicker" type ="date"   />
<label for="txtRequiredDate">RequiredDate </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShippedDate"  class="datepicker" type ="date"   />
<label for="txtShippedDate">ShippedDate </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipVia" type="text" data-column-id="ShipVia"  Class="validate ShipVia" length="9"        maxlength="9"     />
<label for="txtShipVia">ShipVia </label> 
 </div> 
<div class="input-field col s9"> 
<input  id ="txtFreight" type="text" class="validate"   >
<label for="txtFreight">Freight </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipName" type="text" data-column-id="ShipName"  class="validate ShipName"   length="40"   maxlength="40"                /> 
<label for="txtShipName">ShipName </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipAddress" type="text" data-column-id="ShipAddress"  class="validate ShipAddress"   length="60"   maxlength="60"                /> 
<label for="txtShipAddress">ShipAddress </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipCity" type="text" data-column-id="ShipCity"  class="validate ShipCity"   length="15"   maxlength="15"                /> 
<label for="txtShipCity">ShipCity </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipRegion" type="text" data-column-id="ShipRegion"  class="validate ShipRegion"   length="15"   maxlength="15"                /> 
<label for="txtShipRegion">ShipRegion </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipPostalCode" type="text" data-column-id="ShipPostalCode"  class="validate ShipPostalCode"   length="10"   maxlength="10"                /> 
<label for="txtShipPostalCode">ShipPostalCode </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtShipCountry" type="text" data-column-id="ShipCountry"  class="validate ShipCountry"   length="15"   maxlength="15"                /> 
<label for="txtShipCountry">ShipCountry </label> 
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

