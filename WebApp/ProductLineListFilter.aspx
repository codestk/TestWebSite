<%@ Page Title="ProductLine" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductLineListFilter.aspx.cs" Inherits="WebApp.ProductLineFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/ProductLine.js"></script>
<script src="Js_U/Source.js"></script>
<script src="Js_U/Line.js"></script>
<script src="Js_U/TestFormula.js"></script>
<script src="Js_U/Contain.js"></script>
<script src="Js_U/LineSize.js"></script>
<script src="Js_U/CustomerBrand.js"></script>
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
SetSelectSourceID('#drpSourceID');
SetSelectLineID('#drpLineID');
SetSelectTestFormulaID('#drpTestFormulaID');
SetSelectContainID('#drpContainID');
SetSelectLineSizeID('#drpLineSizeID');
SetSelectCustomerBrandID('#drpCustomerBrandID');
$('select').material_select(); 
$('.modal-trigger').leanModal({ 
dismissible: false, // Modal can be dismissed by clicking outside of the modal 
opacity: .5, // Opacity of modal background 
in_duration: 300, // Transition in duration 
out_duration: 200, // Transition out duration 
starting_top: '50%' 

//ready: function () { alert('Ready'); }, // Callback for Modal open 
//complete: function () { alert('Closed'); } // Callback for Modal close 
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

$('#modal1').openModal();
var result = ProductLineService.Search(PageIndex, PageSize, SortExpression, SortDirection, ProductLineId,SourceID,LineID,TestFormulaID,ContainID,LineSizeID,CustomerBrandID,ManufacturingDate,ExpectItems,ProcessItems,CreateDate,RederTable_Pagger);

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
TrTempplate +="<td class='tdProductLineId'  style = 'text-align:center'  >";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='ProductLineWeb.aspx?Q="+result[key].ProductLineId+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].ProductLineId+"</span>";
TrTempplate +="</a>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='ProductLineWeb.aspx?Q="+result[key].ProductLineId+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].ProductLineId+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ProductLineId' type='text' class='validate ForceNumber2Digit' value='"+result[key].ProductLineId+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdSourceID'    >";
TrTempplate +="<span class='truncate'>"+result[key].SourceID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectSourceID' data-column-id='SourceID'  data-column-value='" + result[key].SourceID+"' class='selectSourceID selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdLineID'    >";
TrTempplate +="<span class='truncate'>"+result[key].LineID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectLineID' data-column-id='LineID'  data-column-value='" + result[key].LineID+"' class='selectLineID selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdTestFormulaID'    >";
TrTempplate +="<span class='truncate'>"+result[key].TestFormulaID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectTestFormulaID' data-column-id='TestFormulaID'  data-column-value='" + result[key].TestFormulaID+"' class='selectTestFormulaID selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdContainID'    >";
TrTempplate +="<span class='truncate'>"+result[key].ContainID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectContainID' data-column-id='ContainID'  data-column-value='" + result[key].ContainID+"' class='selectContainID selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdLineSizeID'    >";
TrTempplate +="<span class='truncate'>"+result[key].LineSizeID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectLineSizeID' data-column-id='LineSizeID'  data-column-value='" + result[key].LineSizeID+"' class='selectLineSizeID selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCustomerBrandID'    >";
TrTempplate +="<span class='truncate'>"+result[key].CustomerBrandID+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectCustomerBrandID' data-column-id='CustomerBrandID'  data-column-value='" + result[key].CustomerBrandID+"' class='selectCustomerBrandID selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdManufacturingDate'    >";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].ManufacturingDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ManufacturingDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].ManufacturingDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdExpectItems'    >";
TrTempplate +="<span>"+result[key].ExpectItems+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ExpectItems' type='text' class='validate ForceNumber ' value='"+result[key].ExpectItems+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdProcessItems'    >";
TrTempplate +="<span>"+result[key].ProcessItems+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='ProcessItems' type='text' class='validate ForceNumber ' value='"+result[key].ProcessItems+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCreateDate'    >";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].CreateDate), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='CreateDate'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].CreateDate),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
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
AutoCompleteEditMode();//Set Selectin table
SetSelectSourceID('.selectSourceID');
  $(".selectSourceID").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectLineID('.selectLineID');
  $(".selectLineID").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectTestFormulaID('.selectTestFormulaID');
  $(".selectTestFormulaID").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectContainID('.selectContainID');
  $(".selectContainID").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectLineSizeID('.selectLineSizeID');
  $(".selectLineSizeID").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectCustomerBrandID('.selectCustomerBrandID');
  $(".selectCustomerBrandID").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

}


function AutoCompleteEditMode() { 
$(".ProductLineId,.SourceID,.LineID,.TestFormulaID,.ContainID,.LineSizeID,.CustomerBrandID,.ManufacturingDate,.ExpectItems,.ProcessItems,.CreateDate").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = ProductLineService.GetKeyWordsOneColumn(column, request.term); 
 
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
} 
//Edit table-------------------------------------------------------------------------------------------- 
function BindEditTable() {
$('.tdSourceID,.tdLineID,.tdTestFormulaID,.tdContainID,.tdLineSizeID,.tdCustomerBrandID,.tdManufacturingDate,.tdExpectItems,.tdProcessItems').dblclick(function () { 
 
var sp = $(this).find("span"); 
var di = $(this).find("div"); 
 var $input =$(this).find(".datepicker").pickadate();
if ($input.length != 0) {
    // Use the picker object directly.
   var picker = $input.pickadate('picker');

    picker.set('select', sp["0"].innerText);
 }
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

if (column == "ProductLineId")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "SourceID")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "LineID")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "TestFormulaID")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "ContainID")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "LineSizeID")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "CustomerBrandID")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ManufacturingDate")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ExpectItems")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "ProcessItems")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "CreateDate")
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
var result = ProductLineService.SaveColumn(id, column, data);

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
 
var result = ProductLineService.SaveColumn(id, column, Data); 
 
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
function ForceNumberTextBox() 
{
$("#txtProductLineId").ForceNumericOnly2Digit();
$("#txtExpectItems").ForceNumericOnly();
$("#txtProcessItems").ForceNumericOnly();
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id ="txtProductLineId" type="text" class="validate"   >
<label for="txtProductLineId">ProductLineId </label> 
 </div> 
<div class="input-field col s6"> 
<select id="drpSourceID" > 
 
</select>
<label for="drpSourceID">SourceID</label>
</div>
<div class="input-field col s6"> 
<select id="drpLineID" > 
 
</select>
<label for="drpLineID">LineID</label>
</div>
<div class="input-field col s6"> 
<select id="drpTestFormulaID" > 
 
</select>
<label for="drpTestFormulaID">TestFormulaID</label>
</div>
<div class="input-field col s6"> 
<select id="drpContainID" > 
 
</select>
<label for="drpContainID">ContainID</label>
</div>
<div class="input-field col s6"> 
<select id="drpLineSizeID" > 
 
</select>
<label for="drpLineSizeID">LineSizeID</label>
</div>
<div class="input-field col s6"> 
<select id="drpCustomerBrandID" > 
 
</select>
<label for="drpCustomerBrandID">CustomerBrandID</label>
</div>
<div class="input-field col s6"> 
<input  id="txtManufacturingDate"  class="datepicker" type ="date"   />
<label for="txtManufacturingDate">ManufacturingDate </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtExpectItems" type="text" data-column-id="ExpectItems"  Class="validate ExpectItems" length="9"        maxlength="9"     />
<label for="txtExpectItems">ExpectItems </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtProcessItems" type="text" data-column-id="ProcessItems"  Class="validate ProcessItems" length="9"        maxlength="9"     />
<label for="txtProcessItems">ProcessItems </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtCreateDate"  class="datepicker" type ="date"   />
<label for="txtCreateDate">CreateDate </label> 
 </div> 
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('ProductLineWeb.aspx', '_blank');" />
</div> 
</div> 

</div> 
   <div style="overflow: auto">
<table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th   data-column-id="ProductLineId"  onclick="Sort(this);">ProductLineId</th>
<th   data-column-id="SourceID"  onclick="Sort(this);">SourceID</th>
<th   data-column-id="LineID"  onclick="Sort(this);">LineID</th>
<th   data-column-id="TestFormulaID"  onclick="Sort(this);">TestFormulaID</th>
<th   data-column-id="ContainID"  onclick="Sort(this);">ContainID</th>
<th   data-column-id="LineSizeID"  onclick="Sort(this);">LineSizeID</th>
<th   data-column-id="CustomerBrandID"  onclick="Sort(this);">CustomerBrandID</th>
<th   data-column-id="ManufacturingDate"  onclick="Sort(this);">ManufacturingDate</th>
<th   data-column-id="ExpectItems"  onclick="Sort(this);">ExpectItems</th>
<th   data-column-id="ProcessItems"  onclick="Sort(this);">ProcessItems</th>
<th   data-column-id="CreateDate"  onclick="Sort(this);">CreateDate</th>
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
