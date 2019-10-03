<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="ImageUpload.CompanyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper bgColor p-t-100 p-b-50">
        <div class="wrapper wrapper--w900">
            <div class="card card-6">
                <div class="card-heading">
                    <h2 class="title">Register</h2>
                </div>
                <div class="card-body">
                    <form id="registrationForm" runat="server">
                        <div class="form-row">
                            <div class="name">Comapny name</div>
                            <div class="value">
                                <asp:TextBox ID="txtCompnayName" runat="server" class="input--style-6" type="text" PlaceHolder="Comapny Name"></asp:TextBox>
                                <h6 id="companyNameError"></h6>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="name">Date of registration</div>
                            <div class="value">
                                <div class="input-group">
                                    <asp:TextBox ID="txtDateOfRegistration" runat="server" class="input--style-6" placeholder="Enter Registration Date"></asp:TextBox>
                                    <h6 id="dateCheckError"></h6>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="name">Upload logo</div>
                            <div class="value">
                                <div class="input-group js-input-file">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <asp:FileUpload ID="fileUpload" runat="server" class="input-file" type="file" onchange="ShowPreview(this);" />
                                            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                                ControlToValidate="fileUpload"
                                                ErrorMessage="Only JPEG images are allowed"
                                                ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">  
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-md-4 imagePrivew">
                                            <img id="imgPreview" />
                                        </div>
                                    </div>
                                </div>
                                <div class="label--desc">Upload your company logo. Max file size 50 MB</div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class=" input-group">
                                <asp:Button ID="btnSaveDetails" runat="server" class="btn btn--radius-2 btn--blue-2" type="submit" Text="Save Details" OnClick="btnSaveDetails_Click" />
                                <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                            </div>
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
