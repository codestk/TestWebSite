<%@ Page Title="Employees" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeesListFilter.aspx.cs" Inherits="EmployeesFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/Employees.js"></script>
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
$(".EmployeeID,.LastName,.FirstName,.Title,.TitleOfCourtesy,.BirthDate,.HireDate,.Address,.City,.Region,.PostalCode,.Country,.HomePhone,.Extension,.ReportsTo,.PhotoPath").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = EmployeesService.GetKeyWordsOneColumn(column, request.term); 
 
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

$('#modal1').openModal();
var result = EmployeesService.Search(PageIndex, PageSize, SortExpression, SortDirection, EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,ReportsTo,PhotoPath,RederTable_Pagger);

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
TrTempplate +="<td class='tdEmployeeID'>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='EmployeesWeb.aspx?Q="+result[key].EmployeeID+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].EmployeeID+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EmployeeID' type='text' class='validate ForceNumber ' value='"+result[key].EmployeeID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdLastName'>";
TrTempplate +="<span class=''>"+result[key].LastName+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='LastName' type='text' MaxLength='20' length='20' class='validate truncateLastName' value='"+result[key].LastName+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdFirstName'>";
TrTempplate +="<span class=''>"+result[key].FirstName+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='FirstName' type='text' MaxLength='10' length='10' class='validate truncateFirstName' value='"+result[key].FirstName+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdTitle'>";
TrTempplate +="<span class=''>"+result[key].Title+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Title' type='text' MaxLength='30' length='30' class='validate truncateTitle' value='"+result[key].Title+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdTitleOfCourtesy'>";
TrTempplate +="<span class=''>"+result[key].TitleOfCourtesy+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='TitleOfCourtesy' type='text' MaxLength='25' length='25' class='validate truncateTitleOfCourtesy' value='"+result[key].TitleOfCourtesy+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdBirthDate'>";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].BirthDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='BirthDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].BirthDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdHireDate'>";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].HireDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='HireDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].HireDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdAddress'>";
TrTempplate +="<span class=''>"+result[key].Address+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Address' type='text' MaxLength='60' length='60' class='validate truncateAddress' value='"+result[key].Address+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCity'>";
TrTempplate +="<span class=''>"+result[key].City+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='City' type='text' MaxLength='15' length='15' class='validate truncateCity' value='"+result[key].City+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdRegion'>";
TrTempplate +="<span class=''>"+result[key].Region+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Region' type='text' MaxLength='15' length='15' class='validate truncateRegion' value='"+result[key].Region+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPostalCode'>";
TrTempplate +="<span class=''>"+result[key].PostalCode+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='PostalCode' type='text' MaxLength='10' length='10' class='validate truncatePostalCode' value='"+result[key].PostalCode+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCountry'>";
TrTempplate +="<span class=''>"+result[key].Country+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Country' type='text' MaxLength='15' length='15' class='validate truncateCountry' value='"+result[key].Country+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdHomePhone'>";
TrTempplate +="<span class=''>"+result[key].HomePhone+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='HomePhone' type='text' MaxLength='24' length='24' class='validate truncateHomePhone' value='"+result[key].HomePhone+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdExtension'>";
TrTempplate +="<span class=''>"+result[key].Extension+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Extension' type='text' MaxLength='4' length='4' class='validate truncateExtension' value='"+result[key].Extension+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPhoto'>";
TrTempplate +="<img id='imgPreview' src='ImageHandler.ashx?Q=" + result[key].CategoryID + "' height='131' width='174' onerror=this.src='Images/no-image.png' alt='Image preview...'>"
TrTempplate +="<div style='display: none'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdReportsTo'>";
TrTempplate +="<span>"+result[key].ReportsTo+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ReportsTo' type='text' class='validate ForceNumber ' value='"+result[key].ReportsTo+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPhotoPath'>";
TrTempplate +="<span class=''>"+result[key].PhotoPath+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='PhotoPath' type='text' MaxLength='255' length='255' class='validate truncatePhotoPath' value='"+result[key].PhotoPath+"' style='height: unset; margin: 0px;'>";
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
$('.tdLastName,.tdFirstName,.tdTitle,.tdTitleOfCourtesy,.tdBirthDate,.tdHireDate,.tdAddress,.tdCity,.tdRegion,.tdPostalCode,.tdCountry,.tdHomePhone,.tdExtension,.tdReportsTo,.tdPhotoPath').dblclick(function () { 
 
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

if (column == "EmployeeID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "LastName")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "FirstName")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Title")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "TitleOfCourtesy")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "BirthDate")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "HireDate")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Address")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "City")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Region")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "PostalCode")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Country")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "HomePhone")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Extension")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ReportsTo")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "PhotoPath")
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
var result = EmployeesService.SaveColumn(id, column, data);

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
 
var result = EmployeesService.SaveColumn(id, column, Data); 
 
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
$("#txtEmployeeID").ForceNumericOnly();
$("#txtReportsTo").ForceNumericOnly();
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id="txtEmployeeID" type="text" data-column-id="EmployeeID"  Class="validate EmployeeID" length="9"        maxlength="9"     />
<label for="txtEmployeeID">EmployeeID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtLastName" type="text" data-column-id="LastName"  class="validate LastName"   length="20"   maxlength="20"                /> 
<label for="txtLastName">LastName </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtFirstName" type="text" data-column-id="FirstName"  class="validate FirstName"   length="10"   maxlength="10"                /> 
<label for="txtFirstName">FirstName </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtTitle" type="text" data-column-id="Title"  class="validate Title"   length="30"   maxlength="30"                /> 
<label for="txtTitle">Title </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtTitleOfCourtesy" type="text" data-column-id="TitleOfCourtesy"  class="validate TitleOfCourtesy"   length="25"   maxlength="25"                /> 
<label for="txtTitleOfCourtesy">TitleOfCourtesy </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtBirthDate"  class="datepicker" type ="date"   />
<label for="txtBirthDate">BirthDate </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtHireDate"  class="datepicker" type ="date"   />
<label for="txtHireDate">HireDate </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtAddress" type="text" data-column-id="Address"  class="validate Address"   length="60"   maxlength="60"                /> 
<label for="txtAddress">Address </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtCity" type="text" data-column-id="City"  class="validate City"   length="15"   maxlength="15"                /> 
<label for="txtCity">City </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtRegion" type="text" data-column-id="Region"  class="validate Region"   length="15"   maxlength="15"                /> 
<label for="txtRegion">Region </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtPostalCode" type="text" data-column-id="PostalCode"  class="validate PostalCode"   length="10"   maxlength="10"                /> 
<label for="txtPostalCode">PostalCode </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtCountry" type="text" data-column-id="Country"  class="validate Country"   length="15"   maxlength="15"                /> 
<label for="txtCountry">Country </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtHomePhone" type="text" data-column-id="HomePhone"  class="validate HomePhone"   length="24"   maxlength="24"                /> 
<label for="txtHomePhone">HomePhone </label> 
 </div> 
<div class="input-field col s6"> 
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
<div class="input-field col s6"> 
<input  id="txtReportsTo" type="text" data-column-id="ReportsTo"  Class="validate ReportsTo" length="9"        maxlength="9"     />
<label for="txtReportsTo">ReportsTo </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtPhotoPath" type="text" data-column-id="PhotoPath"  class="validate PhotoPath"   length="255"   maxlength="255"                /> 
<label for="txtPhotoPath">PhotoPath </label> 
 </div> 
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('EmployeesWeb.aspx', '_blank');" />
</div> 
</div> 

</div> 
   <div style="overflow: auto">
<table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th   data-column-id="EmployeeID"  onclick="Sort(this);">EmployeeID</th>
<th   data-column-id="LastName"  onclick="Sort(this);">LastName</th>
<th   data-column-id="FirstName"  onclick="Sort(this);">FirstName</th>
<th   data-column-id="Title"  onclick="Sort(this);">Title</th>
<th   data-column-id="TitleOfCourtesy"  onclick="Sort(this);">TitleOfCourtesy</th>
<th   data-column-id="BirthDate"  onclick="Sort(this);">BirthDate</th>
<th   data-column-id="HireDate"  onclick="Sort(this);">HireDate</th>
<th   data-column-id="Address"  onclick="Sort(this);">Address</th>
<th   data-column-id="City"  onclick="Sort(this);">City</th>
<th   data-column-id="Region"  onclick="Sort(this);">Region</th>
<th   data-column-id="PostalCode"  onclick="Sort(this);">PostalCode</th>
<th   data-column-id="Country"  onclick="Sort(this);">Country</th>
<th   data-column-id="HomePhone"  onclick="Sort(this);">HomePhone</th>
<th   data-column-id="Extension"  onclick="Sort(this);">Extension</th>
<th   data-column-id="Photo"  >Photo</th>
<th   data-column-id="ReportsTo"  onclick="Sort(this);">ReportsTo</th>
<th   data-column-id="PhotoPath"  onclick="Sort(this);">PhotoPath</th>
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

