<%@ Page Title="ProductLine" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductLineWeb.aspx.cs" Inherits="WebApp.ProductLineWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Js_U/ProductLine.js"></script>
<script src="Js_U/Source.js"></script>
<script src="Js_U/Line.js"></script>
<script src="Js_U/TestFormula.js"></script>
<script src="Js_U/Contain.js"></script>
<script src="Js_U/LineSize.js"></script>
<script src="Js_U/CustomerBrand.js"></script>
<script type="text/javascript"> 
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
 $(document).ready(function () 
{
$('.modal-trigger').leanModal();
ForceNumberTextBox(); 
$('select').material_select(); 
$('.datepicker').pickadate({
selectMonths: true, // Creates a dropdown to control month
selectYears: 15 ,// Creates a dropdown of 15 years to control year,
format: 'd mmm yyyy',
});
//For dropdown
SetSelectSourceID('#drpSourceID');
SetSelectLineID('#drpLineID');
SetSelectTestFormulaID('#drpTestFormulaID');
SetSelectContainID('#drpContainID');
SetSelectLineSizeID('#drpLineSizeID');
SetSelectCustomerBrandID('#drpCustomerBrandID');
BindQueryString();
$('select').material_select(); 
 }); 
function ForceNumberTextBox() 
{
$("#txtExpectItems").ForceNumericOnly();
$("#txtProcessItems").ForceNumericOnly();
}
function Validate() {
var output=true;
if(($("#drpSourceID").prop('selectedIndex')==0)||($("#drpSourceID").prop('selectedIndex')==-1)){
output=false;

$("#drpSourceID").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpSourceID").prev().prev().removeClass('CustomInvalid');
$("#drpSourceID").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpLineID").prop('selectedIndex')==0)||($("#drpLineID").prop('selectedIndex')==-1)){
output=false;

$("#drpLineID").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpLineID").prev().prev().removeClass('CustomInvalid');
$("#drpLineID").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpTestFormulaID").prop('selectedIndex')==0)||($("#drpTestFormulaID").prop('selectedIndex')==-1)){
output=false;

$("#drpTestFormulaID").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpTestFormulaID").prev().prev().removeClass('CustomInvalid');
$("#drpTestFormulaID").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpContainID").prop('selectedIndex')==0)||($("#drpContainID").prop('selectedIndex')==-1)){
output=false;

$("#drpContainID").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpContainID").prev().prev().removeClass('CustomInvalid');
$("#drpContainID").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpLineSizeID").prop('selectedIndex')==0)||($("#drpLineSizeID").prop('selectedIndex')==-1)){
output=false;

$("#drpLineSizeID").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpLineSizeID").prev().prev().removeClass('CustomInvalid');
$("#drpLineSizeID").prev().prev().addClass('CustomValid');
 
 
}
if(($("#drpCustomerBrandID").prop('selectedIndex')==0)||($("#drpCustomerBrandID").prop('selectedIndex')==-1)){
output=false;

$("#drpCustomerBrandID").prev().prev().addClass('CustomInvalid');

}
else { 
$("#drpCustomerBrandID").prev().prev().removeClass('CustomInvalid');
$("#drpCustomerBrandID").prev().prev().addClass('CustomValid');
 
 
}
if (CheckEmtyp($("#txtManufacturingDate"))) output = false;
if (CheckEmtyp($("#txtExpectItems"))) output = false;
if (CheckEmtyp($("#txtProcessItems"))) output = false;
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
var  ProductLineId =$('#txtProductLineId').val();
var  SourceID =$('#drpSourceID').val();
var  LineID =$('#drpLineID').val();
var  TestFormulaID =$('#drpTestFormulaID').val();
var  ContainID =$('#drpContainID').val();
var  LineSizeID =$('#drpLineSizeID').val();
var  CustomerBrandID =$('#drpCustomerBrandID').val();
var  ManufacturingDate =$('#txtManufacturingDate').val();
var  ExpectItems =$('#txtExpectItems').val();
var  ProcessItems =$('#txtProcessItems').val();
var  CreateDate =$('#txtCreateDate').val();
var result = ProductLineService.Save(ProductLineId,SourceID,LineID,TestFormulaID,ContainID,LineSizeID,CustomerBrandID,ManufacturingDate,ExpectItems,ProcessItems);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
 $('#txtProductLineId').val(result);
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
var  ProductLineId =$('#txtProductLineId').val();
var  SourceID =$('#drpSourceID').val();
var  LineID =$('#drpLineID').val();
var  TestFormulaID =$('#drpTestFormulaID').val();
var  ContainID =$('#drpContainID').val();
var  LineSizeID =$('#drpLineSizeID').val();
var  CustomerBrandID =$('#drpCustomerBrandID').val();
var  ManufacturingDate =$('#txtManufacturingDate').val();
var  ExpectItems =$('#txtExpectItems').val();
var  ProcessItems =$('#txtProcessItems').val();
var  CreateDate =$('#txtCreateDate').val();
var result = ProductLineService.Update(ProductLineId,SourceID,LineID,TestFormulaID,ContainID,LineSizeID,CustomerBrandID,ManufacturingDate,ExpectItems,ProcessItems);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
function Delete() {
var  ProductLineId =$('#txtProductLineId').val();
var  SourceID =$('#drpSourceID').val();
var  LineID =$('#drpLineID').val();
var  TestFormulaID =$('#drpTestFormulaID').val();
var  ContainID =$('#drpContainID').val();
var  LineSizeID =$('#drpLineSizeID').val();
var  CustomerBrandID =$('#drpCustomerBrandID').val();
var  ManufacturingDate =$('#txtManufacturingDate').val();
var  ExpectItems =$('#txtExpectItems').val();
var  ProcessItems =$('#txtProcessItems').val();
var  CreateDate =$('#txtCreateDate').val();
var result = ProductLineService.Delete(ProductLineId,SourceID,LineID,TestFormulaID,ContainID,LineSizeID,CustomerBrandID,ManufacturingDate,ExpectItems,ProcessItems,CreateDate);

  if (result != null) {

Materialize.toast('Your data has been saved.', 3000, 'toastCss');
$('#modalConfirm').closeModal();
   setInterval(function () { this.close() }, 2000);
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}
} 
 function SetSelectSourceID(control) {

var innitOption = '<option value="">Please Select</option>';
var resultSource = SourceService.SelectAll();
$(control).append(innitOption);
$.each(resultSource, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectLineID(control) {

var innitOption = '<option value="">Please Select</option>';
var resultLine = LineService.SelectAll();
$(control).append(innitOption);
$.each(resultLine, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectTestFormulaID(control) {

var innitOption = '<option value="">Please Select</option>';
var resultTestFormula = TestFormulaService.SelectAll();
$(control).append(innitOption);
$.each(resultTestFormula, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectContainID(control) {

var innitOption = '<option value="">Please Select</option>';
var resultContain = ContainService.SelectAll();
$(control).append(innitOption);
$.each(resultContain, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectLineSizeID(control) {

var innitOption = '<option value="">Please Select</option>';
var resultLineSize = LineSizeService.SelectAll();
$(control).append(innitOption);
$.each(resultLineSize, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectCustomerBrandID(control) {

var innitOption = '<option value="">Please Select</option>';
var resultCustomerBrand = CustomerBrandService.SelectAll();
$(control).append(innitOption);
$.each(resultCustomerBrand, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
function BindQueryString() {

var ProductLineId = getQuerystring('Q');
if (ProductLineId != '') {
var _ProductLine = ProductLineService.Select(ProductLineId);

$('#txtProductLineId').prop('disabled', true );
$('#txtProductLineId').val(_ProductLine.ProductLineId);
$('#drpSourceID').val(_ProductLine.SourceID);
$('#drpLineID').val(_ProductLine.LineID);
$('#drpTestFormulaID').val(_ProductLine.TestFormulaID);
$('#drpContainID').val(_ProductLine.ContainID);
$('#drpLineSizeID').val(_ProductLine.LineSizeID);
$('#drpCustomerBrandID').val(_ProductLine.CustomerBrandID);
var $input = $('#txtManufacturingDate').pickadate() 
// Use the picker object directly. 
var picker = $input.pickadate('picker'); 
picker.set('select',_ProductLine.ManufacturingDate) 
$('#txtExpectItems').val(_ProductLine.ExpectItems);
$('#txtProcessItems').val(_ProductLine.ProcessItems);
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
<label>แหล่งที่มา </label> 
<input  id ="txtProductLineId" type="text" class="validate" ReadOnly="true"   >
 </div> 
<div class="input-field col s9"> 
<select id="drpSourceID" > 
 
</select>
<label for="drpSourceID">SourceID</label>
</div>
<div class="input-field col s9"> 
<select id="drpLineID" > 
 
</select>
<label for="drpLineID">LineID</label>
</div>
<div class="input-field col s9"> 
<select id="drpTestFormulaID" > 
 
</select>
<label for="drpTestFormulaID">TestFormulaID</label>
</div>
<div class="input-field col s9"> 
<select id="drpContainID" > 
 
</select>
<label for="drpContainID">ContainID</label>
</div>
<div class="input-field col s9"> 
<select id="drpLineSizeID" > 
 
</select>
<label for="drpLineSizeID">LineSizeID</label>
</div>
<div class="input-field col s9"> 
<select id="drpCustomerBrandID" > 
 
</select>
<label for="drpCustomerBrandID">CustomerBrandID</label>
</div>
<div class="input-field col s9"> 
<input  id="txtManufacturingDate"  class="datepicker" type ="date"   />
<label for="txtManufacturingDate">ManufacturingDate </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtExpectItems" type="text" data-column-id="ExpectItems"  Class="validate ExpectItems" length="9"        maxlength="9"     />
<label for="txtExpectItems">ExpectItems </label> 
 </div> 
<div class="input-field col s9"> 
<input  id="txtProcessItems" type="text" data-column-id="ProcessItems"  Class="validate ProcessItems" length="9"        maxlength="9"     />
<label for="txtProcessItems">ProcessItems </label> 
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
