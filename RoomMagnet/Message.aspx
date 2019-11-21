<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="message-box">
                <div class="row">
                       <h5><%# String.Concat(Eval("FirstName"), " ", Eval("Message"))%></h5>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
--%>
