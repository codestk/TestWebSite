<%@ Page Title="Orders" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrdersListFilter.aspx.cs" Inherits="OrdersFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/Orders.js"></script>
<script>
var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.'; 
var PageIndex = '1';
var PageSize = '10';
var SortExpression = '';
var SortDirection = '';
$(document).ready(function () { 
ForceNumberTextBox(); 
SetDatepicker();
//For search dropdown
$('.modal-trigger').leanModal({ 
dismissible: false, // Modal can be dismissed by clicking outside of the modal 
opacity: .5, // Opacity of modal background 
in_duration: 300, // Transition in duration 
out_duration: 200, // Transition out duration 
starting_top: '50%' 

//ready: function () { alert('Ready'); }, // Callback for Modal open 
//complete: function () { alert('Closed'); } // Callback for Modal close 
}); 
$(".OrderID,.CustomerID,.EmployeeID,.OrderDate,.RequiredDate,.ShippedDate,.ShipVia,.Freight,.ShipName,.ShipAddress,.ShipCity,.ShipRegion,.ShipPostalCode,.ShipCountry").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = OrdersService.GetKeyWordsOneColumn(column, request.term); 
 
response(data); 

}, 
minLength: 3, 
select: function (event, ui) { 
//log(ui.item ?"Selected: " + ui.item.label :"Nothing selected, input was " + this.value); 
}, 
open: function () { 
$(this).removeClass("ui-corner-all").addClass("ui-corner-top"); 
}, 
close: function () { 
$(this).removeClass("ui-corner-top").addClass("ui-corner-all"); 
} 
});
});//End ready 
//For Validate Type 
function ForceNumberTextBoxEditMode() { 
$(".ForceNumber").ForceNumericOnly();  
$(".ForceNumber2Digit").ForceNumericOnly2Digit(); 
} 
function Search() {
PageIndex = 1;
SortExpression = '';
SortDirection = '';
ClearSort();
SetTable();
}function ClearValue() {
ClearInputValue(".input-field input[type=text],.input-field  input[type=password],.input-field  input[type=checkbox],.input-field  select,.input-field  input[type=radio]");
return false;
}
function Sort(th) {

var ColumnSortName = th.attributes['data-column-id'].value;
ClearSort();
SortExpression = ColumnSortName;
if (SortDirection == 'DESC') {
SortDirection = 'ASC';

$(th).html(ColumnSortName + ' <i class="Small material-icons">arrow_drop_up</i>');
}
else {

SortDirection = 'DESC';
$(th).html(ColumnSortName + ' <i class="Small material-icons">arrow_drop_down</i>');
}

SetTable();
}
function ClearSort() {
$('#tbResult').find('th').each(function() {
var columnName = $(this).attr("data-column-id");
$(this).html(columnName);
});
}
  function SetTable() {
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

$('#modal1').openModal();
var result = OrdersService.Search(PageIndex, PageSize, SortExpression, SortDirection, OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry,RederTable_Pagger);

}
function RederTable_Pagger(result) {
var totalRecord = 0;

if (result.length > 0)
{
$('#tbResult').show();
$('#ulpage').show();
$('#DivNoresults').hide();
$("#tbResult > tbody:last").children().remove();
for (var key in result)
{
if (result.hasOwnProperty(key))
{
totalRecord = result[key].RecordCount;
var TrTempplate ="<tr>";
TrTempplate +="<td class='tdOrderID'>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='OrdersWeb.aspx?Q="+result[key].OrderID+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].OrderID+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='OrderID' type='text' class='validate ForceNumber ' value='"+result[key].OrderID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCustomerID'>";
TrTempplate +="<span class=''>"+result[key].CustomerID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='CustomerID' type='text' MaxLength='5' length='5' class='validate truncateCustomerID' value='"+result[key].CustomerID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEmployeeID'>";
TrTempplate +="<span>"+result[key].EmployeeID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EmployeeID' type='text' class='validate ForceNumber ' value='"+result[key].EmployeeID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdOrderDate'>";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].OrderDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='OrderDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].OrderDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdRequiredDate'>";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].RequiredDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='RequiredDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].RequiredDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShippedDate'>";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].ShippedDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShippedDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].ShippedDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipVia'>";
TrTempplate +="<span>"+result[key].ShipVia+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipVia' type='text' class='validate ForceNumber ' value='"+result[key].ShipVia+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdFreight'>";
TrTempplate +="<span>"+result[key].Freight+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Freight' type='text' class='validate ForceNumber2Digit' value='"+result[key].Freight+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipName'>";
TrTempplate +="<span class=''>"+result[key].ShipName+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipName' type='text' MaxLength='40' length='40' class='validate truncateShipName' value='"+result[key].ShipName+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipAddress'>";
TrTempplate +="<span class=''>"+result[key].ShipAddress+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipAddress' type='text' MaxLength='60' length='60' class='validate truncateShipAddress' value='"+result[key].ShipAddress+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipCity'>";
TrTempplate +="<span class=''>"+result[key].ShipCity+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipCity' type='text' MaxLength='15' length='15' class='validate truncateShipCity' value='"+result[key].ShipCity+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipRegion'>";
TrTempplate +="<span class=''>"+result[key].ShipRegion+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipRegion' type='text' MaxLength='15' length='15' class='validate truncateShipRegion' value='"+result[key].ShipRegion+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipPostalCode'>";
TrTempplate +="<span class=''>"+result[key].ShipPostalCode+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipPostalCode' type='text' MaxLength='10' length='10' class='validate truncateShipPostalCode' value='"+result[key].ShipPostalCode+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdShipCountry'>";
TrTempplate +="<span class=''>"+result[key].ShipCountry+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ShipCountry' type='text' MaxLength='15' length='15' class='validate truncateShipCountry' value='"+result[key].ShipCountry+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="</tr>";
$('#tbResult> tbody').append(TrTempplate);
}
}

}
else
{

$('#tbResult').hide();
$('#ulpage').hide();
$('#DivNoresults').show();

}

$('#modal1').closeModal();
BindEditTable();
SetPagger(totalRecord);
}


//Edit table-------------------------------------------------------------------------------------------- 
function BindEditTable() {
$('.tdCustomerID,.tdEmployeeID,.tdOrderDate,.tdRequiredDate,.tdShippedDate,.tdShipVia,.tdFreight,.tdShipName,.tdShipAddress,.tdShipCity,.tdShipRegion,.tdShipPostalCode,.tdShipCountry').dblclick(function () { 
 
var sp = $(this).find("span"); 
var di = $(this).find("div"); 
sp.hide(); 
di.show(); 
 
di.focus(); 
}); 
 
$(".lblCancel").click(function (event) { 
$(this).parent().parent().find("span").show(); 
$(this).parent().parent().find("div").hide(); 
 
}); 
 

$(".lblSave").click(function (event) {
var tdContent = $(this).parent().parent();
var inputBox = tdContent.find("input,select")[0]; //Get Data inputbox
//if (inputBox == undefined) {

//inputBox = tdContent.find("select")[0];
//}

var id = $(this).parent().parent().parent().find("span")[0].outerText; //Get first Td (ID1)
var column = inputBox.attributes['data-column-id'].value;
var data = inputBox.value;

if (column == "OrderID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "CustomerID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EmployeeID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "OrderDate")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "RequiredDate")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShippedDate")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipVia")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Freight")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipName")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipAddress")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipCity")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipRegion")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipPostalCode")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ShipCountry")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


var txtspan = tdContent.find("span")[0];
var oldData = trim(txtspan.innerText, " ");

if (data == oldData) {
//CalCell
tdContent.find("span").show();
tdContent.find("div").hide();
return;
//
}

//Save Data To CodeBehide
var result = OrdersService.SaveColumn(id, column, data);

//Convert Select
if (inputBox.tagName == 'SELECT') {
data = $(inputBox).find('option:selected').text();
}

if (result == true) {
tdContent.find("span").show();
tdContent.find("div").hide();
tdContent.removeClass("widthEditBig");
tdContent.removeClass("widthEditSmall");
//tdContent.addClass("saved");

//tdContent.find("span")[0].innerText = data; //Swap Value
//tdContent.find("span")[0].className += "saved";

txtspan.innerText = data;
txtspan.className = "saved";
Materialize.toast('Your data has been saved.', 3000, 'toastCss');
}
else {
Materialize.toast(MsgError, 5000, 'toastCss');
}

});
$('').dblclick(function () { 
// <p><input name = '' type = 'radio' id = 'test1'  checked= 'true' /><label for= 'test1'></label></p> 
var chk = $(this).find('input:radio')[0]; 
 
//  var id = $(this).parent().parent().parent().find("td:first")[0].outerText; //Get first Td (ID1) 
var id = chk.attributes['data-column-key'].value; 
var column = chk.attributes['data-column-id'].value; 
var Data = ""; 
 
var status = false; 
if (chk.checked) { 
status = false; 
Data = "0"; 
} 
else { 
status = true; 
Data = "1"; 
} 
 
var result = OrdersService.SaveColumn(id, column, Data); 
 
if (result == true) { 
//Display Message Display Checkbox 
chk.checked = status; 
Materialize.toast('Your data has been saved.', 3000, 'toastCss'); 
} 
else { 
Materialize.toast(MsgError, 5000, 'toastCss'); 
} 
 
}); 
ForceNumberTextBoxEditMode();
SetDatepicker();//
 }
//Edit table===================================================================================================================== 
  function SetPagger(RecordCount) {
$('#ulpage').pagination({
items: RecordCount,
itemsOnPage: PageSize,

prevText: '<img class="iconDirection" src="Images/1457020750_arrow-left-01.svg" />',
nextText: '<img class="iconDirection" src="Images/1457020740_arrow-right-01.svg" />',

currentPage: PageIndex,//cssStyle: 'light-theme',
onPageClick: function (event) {

if (event < 10) {
PageIndex = '0' + event;
}
else {
PageIndex = event;
}
SetTable();
}

});

}
function SetDatepicker()
{
$('.datepicker').pickadate({ 
selectMonths: true, // Creates a dropdown to control month  
selectYears: 15,// Creates a dropdown of 15 years to control year,  
format: 'd mmm yyyy' 
});
}
//No drop/.
function ForceNumberTextBox() 
{
$("#txtOrderID").ForceNumericOnly();
$("#txtEmployeeID").ForceNumericOnly();
$("#txtShipVia").ForceNumericOnly();
$("#txtFreight").ForceNumericOnly2Digit();
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id="txtOrderID" type="text" data-column-id="OrderID"  Class="validate OrderID" length="9"        maxlength="9"     />
<label for="txtOrderID">OrderID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtCustomerID" type="text" data-column-id="CustomerID"  class="validate CustomerID"   length="5"   maxlength="5"                /> 
<label for="txtCustomerID">CustomerID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtEmployeeID" type="text" data-column-id="EmployeeID"  Class="validate EmployeeID" length="9"        maxlength="9"     />
<label for="txtEmployeeID">EmployeeID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtOrderDate"  class="datepicker" type ="date"   />
<label for="txtOrderDate">OrderDate </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtRequiredDate"  class="datepicker" type ="date"   />
<label for="txtRequiredDate">RequiredDate </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShippedDate"  class="datepicker" type ="date"   />
<label for="txtShippedDate">ShippedDate </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipVia" type="text" data-column-id="ShipVia"  Class="validate ShipVia" length="9"        maxlength="9"     />
<label for="txtShipVia">ShipVia </label> 
 </div> 
<div class="input-field col s6"> 
<input  id ="txtFreight" type="text" class="validate"   >
<label for="txtFreight">Freight </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipName" type="text" data-column-id="ShipName"  class="validate ShipName"   length="40"   maxlength="40"                /> 
<label for="txtShipName">ShipName </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipAddress" type="text" data-column-id="ShipAddress"  class="validate ShipAddress"   length="60"   maxlength="60"                /> 
<label for="txtShipAddress">ShipAddress </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipCity" type="text" data-column-id="ShipCity"  class="validate ShipCity"   length="15"   maxlength="15"                /> 
<label for="txtShipCity">ShipCity </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipRegion" type="text" data-column-id="ShipRegion"  class="validate ShipRegion"   length="15"   maxlength="15"                /> 
<label for="txtShipRegion">ShipRegion </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipPostalCode" type="text" data-column-id="ShipPostalCode"  class="validate ShipPostalCode"   length="10"   maxlength="10"                /> 
<label for="txtShipPostalCode">ShipPostalCode </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtShipCountry" type="text" data-column-id="ShipCountry"  class="validate ShipCountry"   length="15"   maxlength="15"                /> 
<label for="txtShipCountry">ShipCountry </label> 
 </div> 
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('OrdersWeb.aspx', '_blank');" />
</div> 
</div> 

</div> 
   <div style="overflow: auto">
<table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th   data-column-id="OrderID"  onclick="Sort(this);">OrderID</th>
<th   data-column-id="CustomerID"  onclick="Sort(this);">CustomerID</th>
<th   data-column-id="EmployeeID"  onclick="Sort(this);">EmployeeID</th>
<th   data-column-id="OrderDate"  onclick="Sort(this);">OrderDate</th>
<th   data-column-id="RequiredDate"  onclick="Sort(this);">RequiredDate</th>
<th   data-column-id="ShippedDate"  onclick="Sort(this);">ShippedDate</th>
<th   data-column-id="ShipVia"  onclick="Sort(this);">ShipVia</th>
<th   data-column-id="Freight"  onclick="Sort(this);">Freight</th>
<th   data-column-id="ShipName"  onclick="Sort(this);">ShipName</th>
<th   data-column-id="ShipAddress"  onclick="Sort(this);">ShipAddress</th>
<th   data-column-id="ShipCity"  onclick="Sort(this);">ShipCity</th>
<th   data-column-id="ShipRegion"  onclick="Sort(this);">ShipRegion</th>
<th   data-column-id="ShipPostalCode"  onclick="Sort(this);">ShipPostalCode</th>
<th   data-column-id="ShipCountry"  onclick="Sort(this);">ShipCountry</th>
</tr>
</thead>
<tbody>
</tbody>
</table>
</div>
<ul id="ulpage" class="pagination"> 
</ul> <div id="DivNoresults" class="container"  style="display: none" > 
<p class="flow-text">No results found. Try the following:</p> 
<p> 
Make sure all words are spelled correctly. 
</p> 
<p> 
Try different keywords. 
</p> 
<p> 
Try more general keywords. 
</p> 
</div> 
<!-- Modal Structure --> 
<div id="modal1" class="modal"> 
<div class="modal-content"> 
<p>Loading</p> 
<div class="progress"> 
<div class="indeterminate"></div> 
</div> 
</div> 
  
</div>
</asp:Content>

