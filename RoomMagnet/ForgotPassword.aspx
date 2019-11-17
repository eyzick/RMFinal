<%@ Page  Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Sign In</title>
      <style>
        .sub-banner {
            height: 130px;
        }
          </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="sub-banner overview-bgi">
    <div class="container">
       
        <div class="headingg">
            <h1>Recover Password</h1>
          </div>
       
    </div>
</div>
      <div class="container">
            <div class="form-horizontal">
              
                <h1>Recover</h1>
                <hr/>
                <h4>Please enter your email address, We will send you the instrutions to reset your password.</h4>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" CssClass="col-md-2 control-label" Text="Your Email"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="tbEmailId" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClass="text-danger" runat="server" ErrorMessage="Please enter your email ID !" ControlToValidate="tbEmailId"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btPassRec" runat="server" CssClass="btn btn-default" Text="Send" OnClick="btPassRec_Click" />
                        <asp:Label ID="lblPassRec" runat="server"></asp:Label>
                    </div>
                </div>
                   <hr />
            </div>
        </div>
</asp:Content>

