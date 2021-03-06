<%@ Page Title="APP_USER" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="APP_USERListFilter.aspx.cs" Inherits="WebApp.APP_USERFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
<script src="Module/Pagger/jquery.simplePagination.js"></script>
<script src="Js_U/APP_USER.js"></script>
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
var  UserID =$('#txtUserID').val();
var  Password =$('#txtPassword').val();
var  FirstName =$('#txtFirstName').val();
var  LastName =$('#txtLastName').val();
var  Tel =$('#txtTel').val();
var  FLAG =$('#chkFLAG').prop('checked');
var  RoleAdmin =$('#chkRoleAdmin').prop('checked');
var  RoleUser =$('#chkRoleUser').prop('checked');
var  Created =$('#txtCreated').val();
 if (FLAG== false)
 {
FLAG = '' }
 if (RoleAdmin== false)
 {
RoleAdmin = '' }
 if (RoleUser== false)
 {
RoleUser = '' }

$('#modal1').openModal();
var result = APP_USERService.Search(PageIndex, PageSize, SortExpression, SortDirection, UserID,Password,FirstName,LastName,Tel,FLAG,RoleAdmin,RoleUser,Created,RederTable_Pagger);

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
TrTempplate +="<td class='tdUserID'>";
TrTempplate +="<a id='btnShowPopup0' target='_blank' href='APP_USERWeb.aspx?Q="+result[key].UserID+"'";
TrTempplate +="title=''>";
TrTempplate +="<span>"+result[key].UserID+"</span>";
TrTempplate +="</a>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='UserID' type='text' MaxLength='50' length='50' class='validate truncate UserID' value='"+result[key].UserID+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdPassword'>";
TrTempplate +="<span class=''>"+result[key].Password+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Password' type='text' MaxLength='50' length='50' class='validate truncate Password' value='"+result[key].Password+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdFirstName'>";
TrTempplate +="<span class=''>"+result[key].FirstName+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='FirstName' type='text' MaxLength='50' length='50' class='validate truncate FirstName' value='"+result[key].FirstName+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdLastName'>";
TrTempplate +="<span class=''>"+result[key].LastName+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='LastName' type='text' MaxLength='50' length='50' class='validate truncate LastName' value='"+result[key].LastName+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdTel'>";
TrTempplate +="<span class=''>"+result[key].Tel+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Tel' type='text' MaxLength='50' length='50' class='validate truncate Tel' value='"+result[key].Tel+"' style='height: unset; margin: 0px;'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
 var statusFLAG ='' ;
if (result[key].FLAG == '1')
{
statusFLAG = 'checked';
} else
{
statusFLAG = '';
}
TrTempplate +="<td class='borderRight chekBoxFLAG'>";
TrTempplate +="<p>";
TrTempplate +="<input name='' type='radio' data-column-id='FLAG' data-column-key='"+result[key].UserID+"' "+statusFLAG+"/><label> </label>"; 
TrTempplate +="</p>"; TrTempplate +="</td> "; var statusRoleAdmin ='' ;
if (result[key].RoleAdmin == '1')
{
statusRoleAdmin = 'checked';
} else
{
statusRoleAdmin = '';
}
TrTempplate +="<td class='borderRight chekBoxRoleAdmin'>";
TrTempplate +="<p>";
TrTempplate +="<input name='' type='radio' data-column-id='RoleAdmin' data-column-key='"+result[key].UserID+"' "+statusRoleAdmin+"/><label> </label>"; 
TrTempplate +="</p>"; TrTempplate +="</td> "; var statusRoleUser ='' ;
if (result[key].RoleUser == '1')
{
statusRoleUser = 'checked';
} else
{
statusRoleUser = '';
}
TrTempplate +="<td class='borderRight chekBoxRoleUser'>";
TrTempplate +="<p>";
TrTempplate +="<input name='' type='radio' data-column-id='RoleUser' data-column-key='"+result[key].UserID+"' "+statusRoleUser+"/><label> </label>"; 
TrTempplate +="</p>"; TrTempplate +="</td> ";TrTempplate +="<td class='tdPicture'>";
TrTempplate +="<img id='imgPreview' src='APP_USERImageHandler.ashx?Q=" + result[key].UserID + "' height='131' width='174' onerror=this.src='Images/no-image.png' alt='Image preview...'>"
TrTempplate +="<div style='display: none'>";
TrTempplate +="<label class='lblSave'>Save</label>";
TrTempplate +="<label class='lblCancel'>";
TrTempplate +="Cancel</label>";
TrTempplate +="</div>";
TrTempplate +="</td>";
TrTempplate +="<td class='tdCreated'>";
TrTempplate +="<span>"+dateFormat(JsonDateToDate(result[key].Created), 'd mmm yyyy')+"</span>";
TrTempplate +="<div style='display: none'>";
TrTempplate +="<input data-column-id='Created'class='datepicker' type='date' value='"+dateFormat(JsonDateToDate(result[key].Created),'d mmm yyyy')+"' style='height: unset; margin: 0px;'>";
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
AutoCompleteEditMode();}


function AutoCompleteEditMode() { 
$(".UserID,.Password,.FirstName,.LastName,.Tel,.FLAG,.RoleAdmin,.RoleUser,.Created").autocomplete({ 
 
source: function (request, response) { 
 
var column = this.element[0].attributes["data-column-id"].value; 
 
var data = APP_USERService.GetKeyWordsOneColumn(column, request.term); 
 
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
$('.tdPassword,.tdFirstName,.tdLastName,.tdTel,.tdFLAG,.tdRoleAdmin,.tdRoleUser,.tdCreated').dblclick(function () { 
 
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

if (column == "UserID")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Password")
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

if (column == "LastName")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Tel")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "FLAG")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "RoleAdmin")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "RoleUser")
{
if ($(inputBox).val().trim() == '') {
$(inputBox).addClass("invalid");
 Materialize.toast('please validate your input.', 3000, 'toastCss');  
return;
}
}

if (column == "Created")
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
var result = APP_USERService.SaveColumn(id, column, data);

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
$('.chekBoxFLAG,.chekBoxRoleAdmin,.chekBoxRoleUser').dblclick(function () { 
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
 
var result = APP_USERService.SaveColumn(id, column, Data); 
 
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
}
</script> <link href="Module/Search/SearchControl.css" rel="stylesheet" />
 </asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 
 <div class="container"> 
<div class="row"> 
<div class="input-field col s6"> 
<input  id="txtUserID" type="text" data-column-id="UserID"  class="validate UserID"   length="50"   maxlength="50"                /> 
<label for="txtUserID">UserID </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtPassword" type="text" data-column-id="Password"  class="validate Password"   length="50"   maxlength="50"                /> 
<label for="txtPassword">Password </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtFirstName" type="text" data-column-id="FirstName"  class="validate FirstName"   length="50"   maxlength="50"                /> 
<label for="txtFirstName">FirstName </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtLastName" type="text" data-column-id="LastName"  class="validate LastName"   length="50"   maxlength="50"                /> 
<label for="txtLastName">LastName </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="txtTel" type="text" data-column-id="Tel"  class="validate Tel"   length="50"   maxlength="50"                /> 
<label for="txtTel">Tel </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="chkFLAG"    type="checkbox" />
<label for="chkFLAG">FLAG </label> 
 </div> 
<div class="input-field col s6"> 
<input  id="chkRoleAdmin"    type="checkbox" />
<label for="chkRoleAdmin">RoleAdmin </label> 
 </div> 
<div class="input-field col s6"> 
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
<div class="input-field col s6"> 
<input  id="txtCreated"  class="datepicker" type ="date"   />
<label for="txtCreated">Created </label> 
 </div> 
<div class="input-field col s12"> 
 
<input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
<input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
<input id ="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('APP_USERWeb.aspx', '_blank');" />
</div> 
</div> 

</div> 
   <div style="overflow: auto">
<table id=tbResult class="  bordered  striped "  style="display: none;" > 
  <thead> 
  <tr> 
<th   data-column-id="UserID"  onclick="Sort(this);">UserID</th>
<th   data-column-id="Password"  onclick="Sort(this);">Password</th>
<th   data-column-id="FirstName"  onclick="Sort(this);">FirstName</th>
<th   data-column-id="LastName"  onclick="Sort(this);">LastName</th>
<th   data-column-id="Tel"  onclick="Sort(this);">Tel</th>
<th   data-column-id="FLAG"  onclick="Sort(this);">FLAG</th>
<th   data-column-id="RoleAdmin"  onclick="Sort(this);">RoleAdmin</th>
<th   data-column-id="RoleUser"  onclick="Sort(this);">RoleUser</th>
<th   data-column-id="Picture"  >Picture</th>
<th   data-column-id="Created"  onclick="Sort(this);">Created</th>
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
