<%@ Page Title="MPO_PRODUCT_P2" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MPO_PRODUCT_P2ListFilter.aspx.cs" Inherits="MPO_PRODUCT_P2Filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/MPO_PRODUCT_P2.js"></script>
<script src="Js_U/MPO_SOURCE.js"></script>
<script src="Js_U/MPO_PRODUCT_LINE.js"></script>
<script src="Js_U/MPO_FORMULA_AND_TEST.js"></script>
<script src="Js_U/MPO_SIZE.js"></script>
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
SetSelectPR_SOURCE('#drpPR_SOURCE');
SetSelectPR_PRODUCT_LINE('#drpPR_PRODUCT_LINE');
SetSelectPR_FORMULA_AND_TEST('#drpPR_FORMULA_AND_TEST');
SetSelectPR_SIZE('#drpPR_SIZE');
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
$(".PR_LOT,.PR_SOURCE,.PR_PRODUCT_LINE,.PR_FORMULA_AND_TEST,.PR_SIZE").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = MPO_PRODUCT_P2Service.GetKeyWordsOneColumn(column, request.term); 
 
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
var  PR_LOT =$('#txtPR_LOT').val();
var  PR_SOURCE =$('#drpPR_SOURCE').val();
var  PR_PRODUCT_LINE =$('#drpPR_PRODUCT_LINE').val();
var  PR_FORMULA_AND_TEST =$('#drpPR_FORMULA_AND_TEST').val();
var  PR_SIZE =$('#drpPR_SIZE').val();

$('#modal1').openModal();
var result = MPO_PRODUCT_P2Service.Search(PageIndex, PageSize, SortExpression, SortDirection, PR_LOT,PR_SOURCE,PR_PRODUCT_LINE,PR_FORMULA_AND_TEST,PR_SIZE,RederTable_Pagger);

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
TrTempplate +="<td class='tdPR_LOT'>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='MPO_PRODUCT_P2Web.aspx?Q="+result[key].PR_LOT+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].PR_LOT+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='PR_LOT' type='text' class='validate ForceNumber ' value='"+result[key].PR_LOT+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPR_SOURCE'>";
TrTempplate +="<span class='truncate'>"+result[key].PR_SOURCE+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectPR_SOURCE' data-column-id='PR_SOURCE'  data-column-value='" + result[key].PR_SOURCE+"' class='selectPR_SOURCE selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPR_PRODUCT_LINE'>";
TrTempplate +="<span class='truncate'>"+result[key].PR_PRODUCT_LINE+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectPR_PRODUCT_LINE' data-column-id='PR_PRODUCT_LINE'  data-column-value='" + result[key].PR_PRODUCT_LINE+"' class='selectPR_PRODUCT_LINE selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPR_FORMULA_AND_TEST'>";
TrTempplate +="<span class='truncate'>"+result[key].PR_FORMULA_AND_TEST+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectPR_FORMULA_AND_TEST' data-column-id='PR_FORMULA_AND_TEST'  data-column-value='" + result[key].PR_FORMULA_AND_TEST+"' class='selectPR_FORMULA_AND_TEST selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPR_SIZE'>";
TrTempplate +="<span class='truncate'>"+result[key].PR_SIZE+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectPR_SIZE' data-column-id='PR_SIZE'  data-column-value='" + result[key].PR_SIZE+"' class='selectPR_SIZE selectInputEditMode' ></select>";
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
//Set Selectin table
SetSelectPR_SOURCE('.selectPR_SOURCE');
  $(".selectPR_SOURCE").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectPR_PRODUCT_LINE('.selectPR_PRODUCT_LINE');
  $(".selectPR_PRODUCT_LINE").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectPR_FORMULA_AND_TEST('.selectPR_FORMULA_AND_TEST');
  $(".selectPR_FORMULA_AND_TEST").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

//Set Selectin table
SetSelectPR_SIZE('.selectPR_SIZE');
  $(".selectPR_SIZE").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

}


//Edit table-------------------------------------------------------------------------------------------- 
function BindEditTable() {
$('.tdPR_SOURCE,.tdPR_PRODUCT_LINE,.tdPR_FORMULA_AND_TEST,.tdPR_SIZE').dblclick(function () { 
 
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

if (column == "PR_LOT")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "PR_SOURCE")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "PR_PRODUCT_LINE")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "PR_FORMULA_AND_TEST")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "PR_SIZE")
{
if ($(inputBox).prop('selectedIndex') == 0) {
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
var result = MPO_PRODUCT_P2Service.SaveColumn(id, column, data);

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
 
var result = MPO_PRODUCT_P2Service.SaveColumn(id, column, Data); 
 
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
 function SetSelectPR_SOURCE(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_SOURCE = MPO_SOURCEService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_SOURCE, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectPR_PRODUCT_LINE(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_PRODUCT_LINE = MPO_PRODUCT_LINEService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_PRODUCT_LINE, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectPR_FORMULA_AND_TEST(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_FORMULA_AND_TEST = MPO_FORMULA_AND_TESTService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_FORMULA_AND_TEST, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
 function SetSelectPR_SIZE(control) {

var innitOption = '<option value="">Please Select</option>';
var resultMPO_SIZE = MPO_SIZEService.SelectAll();
$(control).append(innitOption);
$.each(resultMPO_SIZE, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
function ForceNumberTextBox() 
{
$("#txtPR_LOT").ForceNumericOnly();
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id="txtPR_LOT" type="text" data-column-id="PR_LOT"  Class="validate PR_LOT" length="9"        maxlength="9"     />
<label for="txtPR_LOT">PR_LOT </label> 
 </div> 
<div class="input-field col s6"> 
<select id="drpPR_SOURCE" > 
 
</select>
<label for="drpPR_SOURCE">PR_SOURCE</label>
</div>
<div class="input-field col s6"> 
<select id="drpPR_PRODUCT_LINE" > 
 
</select>
<label for="drpPR_PRODUCT_LINE">PR_PRODUCT_LINE</label>
</div>
<div class="input-field col s6"> 
<select id="drpPR_FORMULA_AND_TEST" > 
 
</select>
<label for="drpPR_FORMULA_AND_TEST">PR_FORMULA_AND_TEST</label>
</div>
<div class="input-field col s6"> 
<select id="drpPR_SIZE" > 
 
</select>
<label for="drpPR_SIZE">PR_SIZE</label>
</div>
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('MPO_PRODUCT_P2Web.aspx', '_blank');" />
</div> 
</div> 

</div> 
   <div style="overflow: auto">
<table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th   data-column-id="PR_LOT"  onclick="Sort(this);">PR_LOT</th>
<th   data-column-id="PR_SOURCE"  onclick="Sort(this);">PR_SOURCE</th>
<th   data-column-id="PR_PRODUCT_LINE"  onclick="Sort(this);">PR_PRODUCT_LINE</th>
<th   data-column-id="PR_FORMULA_AND_TEST"  onclick="Sort(this);">PR_FORMULA_AND_TEST</th>
<th   data-column-id="PR_SIZE"  onclick="Sort(this);">PR_SIZE</th>
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

