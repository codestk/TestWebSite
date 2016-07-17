<%@ Page Title="Categories" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoriesWeb.aspx.cs" Inherits="CategoriesWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Js_U/Categories.js"></script>
    <link href="Module/Stk/StkImageUpload/StkImageUpload.css" rel="stylesheet" />
    <script src="Module/Stk/StkImageUpload/StkImageUpload.js"></script>
 
    <script src="Module/Stk/ValidateStk.js"></script>
    <%--<script src="Js_U/CategoriesImage.js"></script>--%>
    <script type="text/javascript">
        var MsgError = 'UPDATE: An unexpected error has occurred. Please contact your system Administrator.';
        var apiService = "api/CatImageController/";
        var handlerService = "ImageHandler.ashx";
        $(document).ready(function () {
            $('.modal-trigger').leanModal();
            ForceNumberTextBox();
           
            BindQueryString();
            $('.datepicker').pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15,    // Creates a dropdown of 15 years to control year,
                format: 'd mmm yyyy',
            });
        });
        function ForceNumberTextBox() {
        }
        function Validate() {
            var output = true;
            if (CheckEmtyp($("#txtCategoryName"))) output = false;
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
            var CategoryID = $('#txtCategoryID').val();
            var CategoryName = $('#txtCategoryName').val();
            var result = CategoriesService.Save(CategoryID, CategoryName);

            if (result != null) {

                Materialize.toast('Your data has been saved.', 3000, 'toastCss');
                $('#txtCategoryID').val(result);
                $('#btnSave').hide();
                $('#btnUpdate').show();
                $('#btnDelete').show();
                $('#drop-area').show();
                var id=  $('#txtCategoryID').val();
              
                DropArea(id, apiService, handlerService);
            }
            else {
                Materialize.toast(MsgError, 5000, 'toastCss');
            }
        }
        function Update() {
            if (Validate() == false) { return false; }
            var CategoryID = $('#txtCategoryID').val();
            var CategoryName = $('#txtCategoryName').val();
            var result = CategoriesService.Update(CategoryID, CategoryName);

            if (result != null) {

                Materialize.toast('Your data has been saved.', 3000, 'toastCss');
            }
            else {
                Materialize.toast(MsgError, 5000, 'toastCss');
            }
        }
        function Delete() {
            if (Validate() == false) { return false; }
            var CategoryID = $('#txtCategoryID').val();
            var CategoryName = $('#txtCategoryName').val();
            var result = CategoriesService.Delete(CategoryID, CategoryName);

            if (result != null) {

                Materialize.toast('Your data has been saved.', 3000, 'toastCss');
                $('#modalConfirm').closeModal();
                setInterval(function () { this.close() }, 2000);
            }
            else {
                Materialize.toast(MsgError, 5000, 'toastCss');
            }
        }
        //No drop/.
        function BindQueryString() {

            var CategoryID = getQuerystring('Q');
            if (CategoryID != '') {
                var _Categories = CategoriesService.Select(CategoryID);

                $('#txtCategoryID').prop('disabled', true);
                $('#txtCategoryID').val(_Categories.CategoryID);
                $('#txtCategoryName').val(_Categories.CategoryName);
                $('#btnSave').hide();


                DropArea(CategoryID, apiService, handlerService);
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
        <div class="row">
            <div class="col s9">
                <label>CategoryID </label>
                <input readonly="true" id="txtCategoryID" type="text" data-column-id="CategoryID" class="validate CategoryID" length="9" maxlength="9" />
            </div>

            <div class="input-field col s9">
                <input id="txtCategoryName" type="text" data-column-id="CategoryName" class="validate CategoryName" length="15" maxlength="15" />
                <label for="txtCategoryName">CategoryName </label>
            </div>

            <div class="input-field col s9">
                <input id="btnSave" type="button" value="Save" class=" btn" onclick="Save();" /><input id="btnUpdate" type="button" value="Update" class=" btn" onclick="    Update();" /><input id="btnDelete" type="button" value="Delete" class=" btn" onclick="    javascript: return Confirm();" />
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
                    <img id="imgPreview" src="" height="131" width="174" alt="Image preview...">
                    <img id="imgRemove" src="Images/Close.png" />
                </div>
                <div id="status"></div>
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
</asp:Content>