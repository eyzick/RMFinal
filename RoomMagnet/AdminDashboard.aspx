<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .sub-banner {
            height: 130px;
        }

        .project-tab {
            padding: 10%;
            margin-top: -8%;
        }

            .project-tab #tabs {
                background: #007b5e;
                color: #eee;
            }

                .project-tab #tabs h6.section-title {
                    color: #eee;
                }

                .project-tab #tabs .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link.active {
                    color: #0062cc;
                    background-color: transparent;
                    border-color: transparent transparent #f3f3f3;
                    border-bottom: 3px solid !important;
                    font-size: 16px;
                    font-weight: bold;
                }

            .project-tab .nav-link {
                border: 1px solid transparent;
                border-top-left-radius: .25rem;
                border-top-right-radius: .25rem;
                color: #d8dce0;
                font-size: 16px;
                font-weight: 600;
            }

                .project-tab .nav-link:hover {
                    border: none;
                }

            .project-tab thead {
                background: #f3f3f3;
                color: #333;
            }

            .project-tab a {
                text-decoration: none;
                color: #333;
                font-weight: 600;
            }

        .tabbing-box .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link:hover {
            background-color: #17a2b8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="sub-banner overview-bgi">
        <div class="container">

            <div class="headingg">
                <h1>Admin Panel</h1>
            </div>

        </div>
    </div>


    <section id="tabs" class="project-tab">
        <div class="container-fluid">
            <div class="row">

                <div class="col-md-12">
                    <nav>
                        <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">

                            <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Tenants</a>
                            <a class="nav-item nav-link " id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Hosts</a>


                        </div>
                    </nav>
                    <br>
                    <div class="tab-content" id="nav-tabContent">

                        <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">

                            <h1>Tenants</h1>
                            <asp:Repeater ID="rptrTenant" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>User ID</th>
                                                <th>First Name</th>
                                                <th>Last Name</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th><asp:Label ID="lbltenantid" runat="server" Text='<%# Eval("tenantid") %>' /></th>
                                        <td><%# Eval("FirstName") %></td>
                                        <td><%# Eval("LastName") %></td>
                                        <td><asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                        <td>
                                            <div class="form-row">
                                                <div class="col">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Style="height: auto">
                                                        <asp:ListItem Value="0">Pending</asp:ListItem>
                                                        <asp:ListItem Value="1">Approve</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col">

                                                    <asp:Button ID="BtnStatusChange" CssClass="btn btn-success" OnClick="BtnStatusChange_Click" runat="server" Text="Update" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
            </table>
               
                                </FooterTemplate>
                            </asp:Repeater>


                        </div>

                        <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                            <h1>Hosts</h1>
                            <asp:Repeater ID="rptrHost" runat="server">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>User ID</th>
                                                <th>First Name</th>
                                                <th>Last Name</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th>
                                            <asp:Label ID="lblhostid" runat="server" Text='<%# Eval("hostid") %>' /></th>
                                        <td><%# Eval("FirstName") %></td>
                                        <td><%# Eval("LastName") %></td>
                                        <td><asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                        <td>
                                            <div class="form-row">
                                                <div class="col">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Style="height: auto">
                                                        <asp:ListItem Value="0">Pending</asp:ListItem>
                                                        <asp:ListItem Value="1">Approve</asp:ListItem>
                                                        <asp:ListItem Value="2">Deactivate User</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col">
                                                    <asp:Button ID="BtnStatusChange" CssClass="btn btn-success" OnClick="BtnStatusChange_Click1" runat="server" Text="Update" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
            </table>
               
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>

                    </div>

                </div>
            </div>
        </div>
    </section>


</asp:Content>

