<%@ Page Title="Categories" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoriesListFilter.aspx.cs" Inherits="CategoriesFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/Categories.js"></script>
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
$(".CategoryID,.CategoryName").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = CategoriesService.GetKeyWordsOneColumn(column, request.term); 
 
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
var  CategoryID =$('#txtCategoryID').val();
var  CategoryName =$('#txtCategoryName').val();
var  Picture =$('#txtPicture').val();

$('#modal1').openModal();
var result = CategoriesService.Search(PageIndex, PageSize, SortExpression, SortDirection, CategoryID,CategoryName,RederTable_Pagger);

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
TrTempplate +="<td class='tdCategoryID'>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='CategoriesWeb.aspx?Q="+result[key].CategoryID+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].CategoryID+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='CategoryID' type='text' class='validate ForceNumber ' value='"+result[key].CategoryID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCategoryName'>";
TrTempplate +="<span class=''>"+result[key].CategoryName+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='CategoryName' type='text' MaxLength='15' length='15' class='validate truncateCategoryName' value='"+result[key].CategoryName+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPicture'>";
TrTempplate +="<span>"+result[key].Picture+"</span>";
TrTempplate +="<div style='display: none'>";
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
$('.tdCategoryName,.tdPicture').dblclick(function () { 
 
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

if (column == "CategoryID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "CategoryName")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Picture")
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
var result = CategoriesService.SaveColumn(id, column, data);

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
 
var result = CategoriesService.SaveColumn(id, column, Data); 
 
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
format: 'd mmmm yyyy' 
});
}
//No drop/.
function ForceNumberTextBox() 
{
$("#txtCategoryID").ForceNumericOnly();
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id="txtCategoryID" type="text" data-column-id="CategoryID"  CssClass="validate CategoryID" length="9" />
<label for="txtCategoryID">CategoryID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtCategoryName" type="text" data-column-id="CategoryName"  class="validate CategoryName"   length="15"  /> 
<label for="txtCategoryName">CategoryName </label> 
 </div> 
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('CategoriesWeb.aspx', '_blank');" />
</div> 
</div> 

</div> 
  <table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th style="width:300px;" data-column-id="CategoryID"  onclick="Sort(this);">CategoryID</th>
<th style="width:300px;" data-column-id="CategoryName"  onclick="Sort(this);">CategoryName</th>
<th style="width:300px;" data-column-id="Picture"  onclick="Sort(this);">Picture</th>
</tr>
</thead>
<tbody>
</tbody>
</table>
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
