<%@ Page Title="STK_USER" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="STK_USERListFilter.aspx.cs" Inherits="STK_USERFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/STK_USER.js"></script>
<script src="Js_U/STK_USER_FLAG.js"></script>
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
SetSelectEM_FLAG('#drpEM_FLAG');
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
$(".EM_ID,.EM_PASS,.EM_NAME,.EM_SURNAME,.EM_TEL,.EM_ADDRESS,.EM_FLAG,.EM_ROLE_ADMIN,.EM_ROLE_USER").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = STK_USERService.GetKeyWordsOneColumn(column, request.term); 
 
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
var  EM_ID =$('#txtEM_ID').val();
var  EM_PASS =$('#txtEM_PASS').val();
var  EM_NAME =$('#txtEM_NAME').val();
var  EM_SURNAME =$('#txtEM_SURNAME').val();
var  EM_TEL =$('#txtEM_TEL').val();
var  EM_ADDRESS =$('#txtEM_ADDRESS').val();
var  EM_FLAG =$('#drpEM_FLAG').val();
var  EM_ROLE_ADMIN =$('#chkEM_ROLE_ADMIN').prop('checked');
var  EM_ROLE_USER =$('#chkEM_ROLE_USER').prop('checked');
EM_ROLE_ADMIN ='';
EM_ROLE_USER ='';

$('#modal1').openModal();
var result = STK_USERService.Search(PageIndex, PageSize, SortExpression, SortDirection, EM_ID,EM_PASS,EM_NAME,EM_SURNAME,EM_TEL,EM_ADDRESS,EM_FLAG,EM_ROLE_ADMIN,EM_ROLE_USER,RederTable_Pagger);

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
TrTempplate +="<td class='tdEM_ID'>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='STK_USERWeb.aspx?Q="+result[key].EM_ID+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].EM_ID+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EM_ID' type='text' MaxLength='50' length='50' class='validate truncateEM_ID' value='"+result[key].EM_ID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEM_PASS'>";
TrTempplate +="<span class=''>"+result[key].EM_PASS+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EM_PASS' type='text' MaxLength='50' length='50' class='validate truncateEM_PASS' value='"+result[key].EM_PASS+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEM_NAME'>";
TrTempplate +="<span class=''>"+result[key].EM_NAME+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EM_NAME' type='text' MaxLength='50' length='50' class='validate truncateEM_NAME' value='"+result[key].EM_NAME+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEM_SURNAME'>";
TrTempplate +="<span class=''>"+result[key].EM_SURNAME+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EM_SURNAME' type='text' MaxLength='50' length='50' class='validate truncateEM_SURNAME' value='"+result[key].EM_SURNAME+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEM_TEL'>";
TrTempplate +="<span class=''>"+result[key].EM_TEL+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EM_TEL' type='text' MaxLength='50' length='50' class='validate truncateEM_TEL' value='"+result[key].EM_TEL+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEM_ADDRESS'>";
TrTempplate +="<span class=''>"+result[key].EM_ADDRESS+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='EM_ADDRESS' type='text' MaxLength='255' length='255' class='validate truncateEM_ADDRESS' value='"+result[key].EM_ADDRESS+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdEM_FLAG'>";
TrTempplate +="<span class='truncate'>"+result[key].EM_FLAG+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate += "<select id='selectEM_FLAG' data-column-id='EM_FLAG'  data-column-value='" + result[key].EM_FLAG+"' class='selectEM_FLAG selectInputEditMode' ></select>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
 var statusEM_ROLE_ADMIN ='' ;
if (result[key].EM_ROLE_ADMIN == '1')
{
statusEM_ROLE_ADMIN = 'checked';
} else
{
statusEM_ROLE_ADMIN = '';
}
TrTempplate +="<td class='borderRight chekBoxEM_ROLE_ADMIN'>";
TrTempplate +="<p>";
TrTempplate +="<input name='' type='radio' data-column-id='EM_ROLE_ADMIN' data-column-key='"+result[key].EM_ID+"' "+statusEM_ROLE_ADMIN+"/><label> </label>"; 
TrTempplate +="</p>"; TrTempplate +="</td> "; var statusEM_ROLE_USER ='' ;
if (result[key].EM_ROLE_USER == '1')
{
statusEM_ROLE_USER = 'checked';
} else
{
statusEM_ROLE_USER = '';
}
TrTempplate +="<td class='borderRight chekBoxEM_ROLE_USER'>";
TrTempplate +="<p>";
TrTempplate +="<input name='' type='radio' data-column-id='EM_ROLE_USER' data-column-key='"+result[key].EM_ID+"' "+statusEM_ROLE_USER+"/><label> </label>"; 
TrTempplate +="</p>"; TrTempplate +="</td> ";TrTempplate +="</tr>";
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
SetSelectEM_FLAG('.selectEM_FLAG');
  $(".selectEM_FLAG").each(function () {
var selectInput = $(this);
var DefaultSelected = selectInput.attr('data-column-value');
selectInput.val(DefaultSelected);

var selectedText = selectInput.find('option:selected').text();

$(this).parent().prev()[0].innerText = selectedText

});

}


//Edit table-------------------------------------------------------------------------------------------- 
function BindEditTable() {
$('.tdEM_PASS,.tdEM_NAME,.tdEM_SURNAME,.tdEM_TEL,.tdEM_ADDRESS,.tdEM_FLAG,.tdEM_ROLE_ADMIN,.tdEM_ROLE_USER').dblclick(function () { 
 
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

if (column == "EM_ID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_PASS")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_NAME")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_SURNAME")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_TEL")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_ADDRESS")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}


if (column == "EM_FLAG")
{
if ($(inputBox).prop('selectedIndex') == 0) {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_ROLE_ADMIN")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "EM_ROLE_USER")
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
var result = STK_USERService.SaveColumn(id, column, data);

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
$('.chekBoxEM_ROLE_ADMIN,.chekBoxEM_ROLE_USER').dblclick(function () { 
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
 
var result = STK_USERService.SaveColumn(id, column, Data); 
 
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
 function SetSelectEM_FLAG(control) {

var innitOption = '<option value="">Please Select</option>';
var resultSTK_USER_FLAG = STK_USER_FLAGService.SelectAll();
$(control).append(innitOption);
$.each(resultSTK_USER_FLAG, function (index, value) {
//Appending the json items to the dropdown (select tag)
//item is the id of your select tag

var text = value.text;
var value = value.value;

$(control).append('<option value="' + value + '">' + text + '</option>');

});

   

}
function ForceNumberTextBox() 
{
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id="txtEM_ID" type="text" data-column-id="EM_ID"  class="validate EM_ID"   length="50"  /> 
<label for="txtEM_ID">EM_ID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtEM_PASS" type="text" data-column-id="EM_PASS"  class="validate EM_PASS"   length="50"  /> 
<label for="txtEM_PASS">EM_PASS </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtEM_NAME" type="text" data-column-id="EM_NAME"  class="validate EM_NAME"   length="50"  /> 
<label for="txtEM_NAME">EM_NAME </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtEM_SURNAME" type="text" data-column-id="EM_SURNAME"  class="validate EM_SURNAME"   length="50"  /> 
<label for="txtEM_SURNAME">EM_SURNAME </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtEM_TEL" type="text" data-column-id="EM_TEL"  class="validate EM_TEL"   length="50"  /> 
<label for="txtEM_TEL">EM_TEL </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtEM_ADDRESS" type="text" data-column-id="EM_ADDRESS"  class="validate EM_ADDRESS"   length="255"  /> 
<label for="txtEM_ADDRESS">EM_ADDRESS </label> 
 </div> 
<div class="input-field col s6"> 
<select id="drpEM_FLAG" > 
 
</select>
<label for="drpEM_FLAG">EM_FLAG</label>
</div>
<div class="input-field col s6"> 
<input  id="chkEM_ROLE_ADMIN"    type="checkbox" />
<label for="chkEM_ROLE_ADMIN">EM_ROLE_ADMIN </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="chkEM_ROLE_USER"    type="checkbox" />
<label for="chkEM_ROLE_USER">EM_ROLE_USER </label> 
 </div> 
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('STK_USERWeb.aspx', '_blank');" />
</div> 
</div> 

</div> 
  <table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th style="width:300px;" data-column-id="EM_ID"  onclick="Sort(this);">EM_ID</th>
<th style="width:300px;" data-column-id="EM_PASS"  onclick="Sort(this);">EM_PASS</th>
<th style="width:300px;" data-column-id="EM_NAME"  onclick="Sort(this);">EM_NAME</th>
<th style="width:300px;" data-column-id="EM_SURNAME"  onclick="Sort(this);">EM_SURNAME</th>
<th style="width:300px;" data-column-id="EM_TEL"  onclick="Sort(this);">EM_TEL</th>
<th style="width:300px;" data-column-id="EM_ADDRESS"  onclick="Sort(this);">EM_ADDRESS</th>
<th style="width:300px;" data-column-id="EM_FLAG"  onclick="Sort(this);">EM_FLAG</th>
<th style="width:300px;" data-column-id="EM_ROLE_ADMIN"  onclick="Sort(this);">EM_ROLE_ADMIN</th>
<th style="width:300px;" data-column-id="EM_ROLE_USER"  onclick="Sort(this);">EM_ROLE_USER</th>
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

