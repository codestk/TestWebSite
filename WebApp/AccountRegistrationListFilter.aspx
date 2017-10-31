<%@ Page Title="AccountRegistration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountRegistrationListFilter.aspx.cs" Inherits="AccountRegistrationFilter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Module/Pagger/jquery.simplePagination.js"></script>
    <script src="Js_U/AccountRegistration.js"></script>
    <script src="Js_U/AccountStatus.js"></script>
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
            SetSelectStatus('#drpStatus');
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
            $(".RequestId,.UserName,.Password,.FirstName,.LastName,.Department,.Phone,.Fax,.Status").autocomplete({

                source: function (request, response) {

                    var column = this.element[0].attributes["data-column-id"].value;

                    var data = AccountRegistrationService.GetKeyWordsOneColumn(column, request.term);

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
        } function ClearValue() {
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
            $('#tbResult').find('th').each(function () {
                var columnName = $(this).attr("data-column-id");
                $(this).html(columnName);
            });
        }
        function SetTable() {
            var RequestId = $('#txtRequestId').val();
            var UserName = $('#txtUserName').val();
            var Password = $('#txtPassword').val();
            var FirstName = $('#txtFirstName').val();
            var LastName = $('#txtLastName').val();
            var Department = $('#txtDepartment').val();
            var Phone = $('#txtPhone').val();
            var Fax = $('#txtFax').val();
            var Status = $('#drpStatus').val();

            $('#modal1').openModal();
            var result = AccountRegistrationService.Search(PageIndex, PageSize, SortExpression, SortDirection, RequestId, UserName, Password, FirstName, LastName, Department, Phone, Fax, Status, RederTable_Pagger);

        }
        function RederTable_Pagger(result) {
            var totalRecord = 0;

            if (result.length > 0) {
                $('#tbResult').show();
                $('#ulpage').show();
                $('#DivNoresults').hide();
                $("#tbResult > tbody:last").children().remove();
                for (var key in result) {
                    if (result.hasOwnProperty(key)) {
                        totalRecord = result[key].RecordCount;
                        var TrTempplate = "<tr>";
                        TrTempplate += "<td class='tdRequestId'>";
                        TrTempplate += "<a id='btnShowPopup0' target='_blank' href='AccountRegistrationWeb.aspx?Q=" + result[key].RequestId + "'";
                        TrTempplate += "title=''>";
                        TrTempplate += "<span>" + result[key].RequestId + "</span>";
                        TrTempplate += "</a>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='RequestId' type='text' class='validate ForceNumber ' value='" + result[key].RequestId + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "<td class='tdUserName'>";
                        TrTempplate += "<span class=''>" + result[key].UserName + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='UserName' type='text' MaxLength='50' length='50' class='validate truncateUserName' value='" + result[key].UserName + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        //TrTempplate += "<td class='tdPassword'>";
                        //TrTempplate += "<span class=''>" + result[key].Password + "</span>";
                        //TrTempplate += "<div style='display: none'>";
                        //TrTempplate += "<input data-column-id='Password' type='text' MaxLength='50' length='50' class='validate truncatePassword' value='" + result[key].Password + "' style='height: unset; margin: 0px;'>";
                        //TrTempplate += "<label class='lblSave'>Save</label>";
                        //TrTempplate += "<label class='lblCancel'>";
                        //TrTempplate += "Cancel</label>";
                        //TrTempplate += "</div>";
                        //TrTempplate += "</td>";
                        TrTempplate += "<td class='tdFirstName'>";
                        TrTempplate += "<span class=''>" + result[key].FirstName + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='FirstName' type='text' MaxLength='50' length='50' class='validate truncateFirstName' value='" + result[key].FirstName + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "<td class='tdLastName'>";
                        TrTempplate += "<span class=''>" + result[key].LastName + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='LastName' type='text' MaxLength='50' length='50' class='validate truncateLastName' value='" + result[key].LastName + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "<td class='tdDepartment'>";
                        TrTempplate += "<span class=''>" + result[key].Department + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='Department' type='text' MaxLength='50' length='50' class='validate truncateDepartment' value='" + result[key].Department + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "<td class='tdPhone'>";
                        TrTempplate += "<span class=''>" + result[key].Phone + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='Phone' type='text' MaxLength='50' length='50' class='validate truncatePhone' value='" + result[key].Phone + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "<td class='tdFax'>";
                        TrTempplate += "<span class=''>" + result[key].Fax + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<input data-column-id='Fax' type='text' MaxLength='50' length='50' class='validate truncateFax' value='" + result[key].Fax + "' style='height: unset; margin: 0px;'>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "<td class='tdStatus'>";
                        TrTempplate += "<span class='truncate'>" + result[key].Status + "</span>";
                        TrTempplate += "<div style='display: none'>";
                        TrTempplate += "<select id='selectStatus' data-column-id='Status'  data-column-value='" + result[key].Status + "' class='selectStatus selectInputEditMode' ></select>";
                        TrTempplate += "<label class='lblSave'>Save</label>";
                        TrTempplate += "<label class='lblCancel'>";
                        TrTempplate += "Cancel</label>";
                        TrTempplate += "</div>";
                        TrTempplate += "</td>";
                        TrTempplate += "</tr>";
                        $('#tbResult> tbody').append(TrTempplate);
                    }
                }

            }
            else {

                $('#tbResult').hide();
                $('#ulpage').hide();
                $('#DivNoresults').show();

            }

            $('#modal1').closeModal();
            BindEditTable();
            SetPagger(totalRecord);
            //Set Selectin table
            SetSelectStatus('.selectStatus');
            $(".selectStatus").each(function () {
                var selectInput = $(this);
                var DefaultSelected = selectInput.attr('data-column-value');
                selectInput.val(DefaultSelected);

                var selectedText = selectInput.find('option:selected').text();

                $(this).parent().prev()[0].innerText = selectedText

            });

        }

        //Edit table--------------------------------------------------------------------------------------------
        function BindEditTable() {
            $('.tdUserName,.tdPassword,.tdFirstName,.tdLastName,.tdDepartment,.tdPhone,.tdFax,.tdStatus').dblclick(function () {

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

                if (column == "RequestId") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "UserName") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "Password") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "FirstName") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "LastName") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "Department") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "Phone") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "Fax") {
                    if ($(inputBox).val().trim() == '') {
                        $(inputBox).addClass("invalid");
                        Materialize.toast('please validate your input.', 3000, 'toastCss');
                        return;
                    }
                }

                if (column == "Status") {
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
                var result = AccountRegistrationService.SaveColumn(id, column, data);

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

                var result = AccountRegistrationService.SaveColumn(id, column, Data);

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
        function SetDatepicker() {
            $('.datepicker').pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15,// Creates a dropdown of 15 years to control year,
                format: 'd mmm yyyy'
            });
        }
        function SetSelectStatus(control) {

            var innitOption = '<option value="">Please Select</option>';
            var resultAccountStatus = AccountStatusService.SelectAll();
            $(control).append(innitOption);
            $.each(resultAccountStatus, function (index, value) {
                //Appending the json items to the dropdown (select tag)
                //item is the id of your select tag

                var text = value.text;
                var value = value.value;

                $(control).append('<option value="' + value + '">' + text + '</option>');

            });

        }
        function ForceNumberTextBox() {
            $("#txtRequestId").ForceNumericOnly();
        }
    </script>
    <link href="Module/Search/SearchControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="input-field col s6">
                <input id="txtRequestId" type="text" data-column-id="RequestId" class="validate RequestId" length="9" maxlength="9" />
                <label for="txtRequestId">RequestId </label>
            </div>
            <div class="input-field col s6">
                <input id="txtUserName" type="text" data-column-id="UserName" class="validate UserName" length="50" maxlength="50" />
                <label for="txtUserName">UserName </label>
            </div>
            <div class="input-field col s6" style="display: none">
                <input id="txtPassword" type="text" data-column-id="Password" class="validate Password" length="50" maxlength="50" />
                <label for="txtPassword">Password </label>
            </div>
            <div class="input-field col s6">
                <input id="txtFirstName" type="text" data-column-id="FirstName" class="validate FirstName" length="50" maxlength="50" />
                <label for="txtFirstName">FirstName </label>
            </div>
            <div class="input-field col s6">
                <input id="txtLastName" type="text" data-column-id="LastName" class="validate LastName" length="50" maxlength="50" />
                <label for="txtLastName">LastName </label>
            </div>
            <div class="input-field col s6">
                <input id="txtDepartment" type="text" data-column-id="Department" class="validate Department" length="50" maxlength="50" />
                <label for="txtDepartment">Department </label>
            </div>
            <div class="input-field col s6">
                <input id="txtPhone" type="text" data-column-id="Phone" class="validate Phone" length="50" maxlength="50" />
                <label for="txtPhone">Phone </label>
            </div>
            <div class="input-field col s6">
                <input id="txtFax" type="text" data-column-id="Fax" class="validate Fax" length="50" maxlength="50" />
                <label for="txtFax">Fax </label>
            </div>
            <div class="input-field col s6">
                <select id="drpStatus">
                </select>
                <label for="drpStatus">Status</label>
            </div>
            <div class="input-field col s12">

                <input id="btnSearch" class="waves-effect waves-light btn center" type="button" value="Search" onclick="Search();" />
                <input id="btnClear" class="waves-effect waves-light btn center" type="button" value="Clear" onclick="javascript: return ClearValue();" />
  <%--              <input id="btnNew" class="waves-effect waves-light btn center" type="button" value="New" onclick="javascript: window.open('AccountRegistrationWeb.aspx', '_blank');" />--%>
            </div>
        </div>
    </div>
    <div style="overflow: auto">
        <table id="tbResult" class="  bordered  striped " style="display: none;">
            <thead>
                <tr>
                    <th data-column-id="RequestId" onclick="Sort(this);">RequestId</th>
                    <th data-column-id="UserName" onclick="Sort(this);">UserName</th>
                 <%--   <th data-column-id="Password" onclick="Sort(this);">Password</th>--%>
                    <th data-column-id="FirstName" onclick="Sort(this);">FirstName</th>
                    <th data-column-id="LastName" onclick="Sort(this);">LastName</th>
                    <th data-column-id="Department" onclick="Sort(this);">Department</th>
                    <th data-column-id="Phone" onclick="Sort(this);">Phone</th>
                    <th data-column-id="Fax" onclick="Sort(this);">Fax</th>
                    <th data-column-id="Status" onclick="Sort(this);">Status</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <ul id="ulpage" class="pagination">
    </ul>
    <div id="DivNoresults" class="container" style="display: none">
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