<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAnonymous.master" AutoEventWireup="true" CodeFile="DemoRegister.aspx.cs" Inherits="DemoRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Js_U/AccountRegistration.js"></script>
    <script src="Js_U/AccountStatus.js"></script>
    <script src="Module/Strength.js-master/demo/styled_example/strength.js"></script>
    <link href="Module/Strength.js-master/demo/styled_example/Strength.css" rel="stylesheet" />

    <script type="text/javascript">
        var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
        $(document).ready(function () {
            $('.modal-trigger').leanModal();
            ForceNumberTextBox();
            //For dropdown
            SetSelectStatus('#drpStatus');
            $('select').material_select();
            BindQueryString();
            $('select').material_select();

            $('#txtPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: 'Show Password',
                strengthButtonTextToggle: 'Hide Password'
            });


            $("#txtUserName").ForceEngOnly();
            //$("#txtUserName").keypress(function (event) {
            //    var ew = event.which;
            //    //if (ew == 32)
            //    //    return true;
            //    //if (48 <= ew && ew <= 57)
            //    //    return true;
            //    if (65 <= ew && ew <= 90)
            //        return true;
            //    if (97 <= ew && ew <= 122)
            //        return true;
            //    return false;
            //});




        });
        function ForceNumberTextBox() {
        }
        function Validate() {
            var output = true;
            if (CheckEmtyp($("#txtUserName"))) output = false;
            if (CheckEmtyp($("#txtPassword"))) output = false;
            if (CheckEmtyp($("#txtFirstName"))) output = false;
            if (CheckEmtyp($("#txtLastName"))) output = false;
            if (CheckEmtyp($("#txtDepartment"))) output = false;
            if (CheckEmtyp($("#txtPhone"))) output = false;
            if (CheckEmtyp($("#txtFax"))) output = false;
            //if (($("#drpStatus").prop('selectedIndex') == 0) || ($("#drpStatus").prop('selectedIndex') == -1)) {
            //    output = false;

            //    $("#drpStatus").prev().prev().addClass('CustomInvalid');

            //}
            //else {
            //    $("#drpStatus").prev().prev().removeClass('CustomInvalid');
            //    $("#drpStatus").prev().prev().addClass('CustomValid');

            //}
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
            var RequestId = $('#txtRequestId').val();
            var UserName = $('#txtUserName').val();
            var Password = $('#txtPassword').val();
            var FirstName = $('#txtFirstName').val();
            var LastName = $('#txtLastName').val();
            var Department = $('#txtDepartment').val();
            var Phone = $('#txtPhone').val();
            var Fax = $('#txtFax').val();
            //var Status = $('#drpStatus').val();
            var Status = 'P';
            var result = AccountRegistrationService.Save(RequestId, UserName, Password, FirstName, LastName, Department, Phone, Fax, Status);

            if (result != null) {

                Materialize.toast('Your data has been saved.', 3000, 'toastCss');
                //$('#txtRequestId').val(result);
                $('#txtRequestId').text('Request id : ' + result)
                $('#divRequestId').show();

                $('#btnSave').hide();
                //$('#btnUpdate').show();
                //$('#btnDelete').show();
            }
            else {
                Materialize.toast(MsgError, 5000, 'toastCss');
            }
        }
        function Update() {
            if (Validate() == false) { return false; }
            var RequestId = $('#txtRequestId').val();
            var UserName = $('#txtUserName').val();
            var Password = $('#txtPassword').val();
            var FirstName = $('#txtFirstName').val();
            var LastName = $('#txtLastName').val();
            var Department = $('#txtDepartment').val();
            var Phone = $('#txtPhone').val();
            var Fax = $('#txtFax').val();
            var Status = $('#drpStatus').val();
            var result = AccountRegistrationService.Update(RequestId, UserName, Password, FirstName, LastName, Department, Phone, Fax, Status);

            if (result != null) {

                Materialize.toast('Your data has been saved.', 3000, 'toastCss');
            }
            else {
                Materialize.toast(MsgError, 5000, 'toastCss');
            }
        }
        function Delete() {
            if (Validate() == false) { return false; }
            var RequestId = $('#txtRequestId').val();
            var UserName = $('#txtUserName').val();
            var Password = $('#txtPassword').val();
            var FirstName = $('#txtFirstName').val();
            var LastName = $('#txtLastName').val();
            var Department = $('#txtDepartment').val();
            var Phone = $('#txtPhone').val();
            var Fax = $('#txtFax').val();
            var Status = $('#drpStatus').val();
            var result = AccountRegistrationService.Delete(RequestId, UserName, Password, FirstName, LastName, Department, Phone, Fax, Status);

            if (result != null) {

                Materialize.toast('Your data has been saved.', 3000, 'toastCss');
                $('#modalConfirm').closeModal();
                setInterval(function () { this.close() }, 2000);
            }
            else {
                Materialize.toast(MsgError, 5000, 'toastCss');
            }
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
        function BindQueryString() {

            var RequestId = getQuerystring('Q');
            if (RequestId != '') {
                var _AccountRegistration = AccountRegistrationService.Select(RequestId);

                $('#txtRequestId').prop('disabled', true);
                $('#txtRequestId').val(_AccountRegistration.RequestId);
                $('#txtUserName').val(_AccountRegistration.UserName);
                $('#txtPassword').val(_AccountRegistration.Password);
                $('#txtFirstName').val(_AccountRegistration.FirstName);
                $('#txtLastName').val(_AccountRegistration.LastName);
                $('#txtDepartment').val(_AccountRegistration.Department);
                $('#txtPhone').val(_AccountRegistration.Phone);
                $('#txtFax').val(_AccountRegistration.Fax);
                $('#drpStatus').val(_AccountRegistration.Status);
                $('#btnSave').hide();
            }
            else {
                $('#btnSave').show();
                $('#btnUpdate').hide();
                $('#btnDelete').hide();

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <img src="Images/Logo.png" width="201" style="position: absolute; top: 0px; right: 0px;" />

        <h2 class="header">Create an account
        </h2>

        <div class="row">
            <%--  <div class="  col s9">
                <label>RequestId </label>
                <input readonly="true" id="txtRequestId" type="text" data-column-id="RequestId" class="validate RequestId" length="9" maxlength="9" style="display:none" />
            </div> --%>
            <div class="input-field col s9">
                <input id="txtUserName" type="text" data-column-id="UserName" class="validate UserName" length="50" maxlength="50" />
                <label for="txtUserName">UserName </label>
            </div>
            <%--   <div class="input-field col s9">
                <input id="txtPassword" type="text" data-column-id="Password" class="validate Password" length="50" maxlength="50" />
                <label for="txtPassword">Password </label>
            </div>--%>

            <div class="input-field col s9">

                <label for="txtPassword">Password </label>

                <input id="txtPassword" type="password" name="txtPassword" value="" data-column-id="Password" class="validate Password" length="50" maxlength="50" />
            </div>
            <div class="input-field col s9">
                <input id="txtrePassword" type="password" data-column-id="Reenter password" class="validate Password" length="50" maxlength="50" />
                <label for="txtrePassword">Reenter password </label>
            </div>

            <div class="input-field col s9">

                <blockquote style="color: #00CC99">
                    8-character minimum&nbsp;
                        <br />
                    case sensitive
                    <br />
                    Non-alphanumeric (For example: $, #, or %)
                </blockquote>
            </div>

            <div class="input-field col s9">
                <input id="txtFirstName" type="text" data-column-id="FirstName" class="validate FirstName" length="50" maxlength="50" />
                <label for="txtFirstName">FirstName </label>
            </div>
            <div class="input-field col s9">
                <input id="txtLastName" type="text" data-column-id="LastName" class="validate LastName" length="50" maxlength="50" />
                <label for="txtLastName">LastName </label>
            </div>
            <div class="input-field col s9">
                <input id="txtDepartment" type="text" data-column-id="Department" class="validate Department" length="50" maxlength="50" />
                <label for="txtDepartment">Department </label>
            </div>
            <div class="input-field col s9">
                <input id="txtPhone" type="text" data-column-id="Phone" class="validate Phone" length="50" maxlength="50" />
                <label for="txtPhone">Phone </label>
            </div>
            <div class="input-field col s9">
                <input id="txtFax" type="text" data-column-id="Fax" class="validate Fax" length="50" maxlength="50" />
                <label for="txtFax">Fax </label>
            </div>
            <div class="input-field col s9" style="display: none">
                <select id="drpStatus">
                </select>
                <label for="drpStatus">Status</label>
            </div>
            <div class="input-field col s12">
                <input id="btnSave" type="button" value="Create account" class=" btn" onclick="Save();" style="width: 100%" /><input id="btnUpdate" type="button" value="Update" class=" btn" onclick="    Update();" /><input id="btnDelete" type="button" value="Delete" class=" btn" onclick="    javascript: return Confirm();" />
            </div>

            <div id="divRequestId" class="col s12" style="display: none">

                <h2 id="txtRequestId" class="header" style="color: #6798D3">Navbar</h2>
                <label>Please wait, Application waiting to be approved by admin </label>
            </div>
        </div>
    </div>
    <!-- Modal Trigger -->
    <%--  <a class="waves-effect waves-light btn modal-trigger" href="#modal1">Modal</a>--%>
    <!-- Modal Structure -->
    <div id="modal1" class="modal">
        <div class="modal-content">
            <h4>Message</h4>
            <p id="PmsageAlert">Saved!!!</p>
        </div>
        <div class="modal-footer">
            <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Agree</a>
        </div>
    </div>
    <div id="modalConfirm" class="modal">
        <div class="modal-content">
            <h5>Message</h5>
            <h6>Are you sure?!!!</h6>
        </div>
        <div class="modal-footer">

            <input id="btnConfirm" type="button" value="Confirm" class="modal-action modal-close waves-effect waves-light btn" onclick="javascript: return Delete();" /><input id="btnCancel" type="button" value="Cancel" class="modal-action modal-close waves-effect waves-light btn" />
        </div>
    </div>
    </label>
</asp:Content>