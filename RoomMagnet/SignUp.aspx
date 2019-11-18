﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
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
    <title>Sign Up</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="sub-banner overview-bgi">
        <div class="container">

            <div class="headingg">
                <h1>Sign Up</h1>
            </div>

        </div>
    </div>

    <!-- Sign Up -->



    <section id="tabs" class="project-tab">
        <div class="container">
            <div class="row">
                <div class="col-2">
                </div>
                <div class="col-md-8">
                    <nav>
                        <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                            
                            <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">House Owner</a>
                             <a class="nav-item nav-link " id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Tenant</a>
                           

                        </div>
                    </nav>
                      <br>

                     <div class="center-page">

                     
                          <div class="form-row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbName">First Name</label>
                                    <asp:TextBox ID="tbFirstName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                                </div>
                                </div>
                                 <div class="col">
                                  <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbName1">Last Name</label>
                                    <asp:TextBox ID="tbLastName" runat="server" Class="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                                     </div>
                              </div>
                               <%-- <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbUname">Username</label>

                                    <asp:TextBox ID="tbUserName" runat="server" Class="form-control" placeholder="Usename"></asp:TextBox>--%>

                               <%-- </div>--%>
                          <div class="form-row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbPass">Password</label>

                                    <asp:TextBox ID="tbPassWord" runat="server" Class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>
                                </div>
                                <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbCPass">Confirm Password</label>

                                    <asp:TextBox ID="tbConfirmPassword" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                </div>
                                    </div>
                              </div>
                         <div class="form-row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbEmail">Email address</label>
                                    <asp:TextBox ID="tbEmail" runat="server" Class="form-control" aria-describedby="emailHelp" placeholder="Enter email" TextMode="Email"></asp:TextBox>
                                    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                                </div>
                                </div>

                               <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbPhone">Phone Number</label>
                                    <asp:TextBox ID="tbPhoneNumber" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
            
                                </div>
                                </div>

                            </div>


                    <div class="tab-content" id="nav-tabContent">
                      
                        <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
         
                          <div class="form-group">
                 <label for="inputAddress">Address</label>
       
             <asp:TextBox ID="tbAddress" runat="server" Class="form-control" placeholder="1234 Main St"></asp:TextBox>
           </div>
                          <div class="form-group">
    <label for="inputAddress2">Date of Birth</label>

                               <asp:TextBox ID="tbDOB" runat="server" Class="form-control" type="date"></asp:TextBox>
  </div>
                          <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <asp:TextBox ID="tbCity" runat="server" Class="form-control" placeholder="City"></asp:TextBox>
    </div>
    <div class="form-group col-md-3">
      <label for="inputState">State</label>
    
    
   <asp:DropDownList ID="ddState" runat="server" CssClass="form-control" style="height:auto">
              
	<asp:ListItem Value="AL">AL</asp:ListItem>
	<asp:ListItem Value="AK">AK</asp:ListItem>
	<asp:ListItem Value="AZ">AZ</asp:ListItem>
	<asp:ListItem Value="AR">AR</asp:ListItem>
	<asp:ListItem Value="CA">CA</asp:ListItem>
	<asp:ListItem Value="CO">CO</asp:ListItem>
	<asp:ListItem Value="CT">CT</asp:ListItem>
	<asp:ListItem Value="DC">DC</asp:ListItem>
	<asp:ListItem Value="DE">DE</asp:ListItem>
	<asp:ListItem Value="FL">FL</asp:ListItem>
	<asp:ListItem Value="GA">GA</asp:ListItem>
	<asp:ListItem Value="HI">HI</asp:ListItem>
	<asp:ListItem Value="ID">ID</asp:ListItem>
	<asp:ListItem Value="IL">IL</asp:ListItem>
	<asp:ListItem Value="IN">IN</asp:ListItem>
	<asp:ListItem Value="IA">IA</asp:ListItem>
	<asp:ListItem Value="KS">KS</asp:ListItem>
	<asp:ListItem Value="KY">KY</asp:ListItem>
	<asp:ListItem Value="LA">LA</asp:ListItem>
	<asp:ListItem Value="ME">ME</asp:ListItem>
	<asp:ListItem Value="MD">MD</asp:ListItem>
	<asp:ListItem Value="MA">MA</asp:ListItem>
	<asp:ListItem Value="MI">MI</asp:ListItem>
	<asp:ListItem Value="MN">MN</asp:ListItem>
	<asp:ListItem Value="MS">MS</asp:ListItem>
	<asp:ListItem Value="MO">MO</asp:ListItem>
	<asp:ListItem Value="MT">MT</asp:ListItem>
	<asp:ListItem Value="NE">NE</asp:ListItem>
	<asp:ListItem Value="NV">NV</asp:ListItem>
	<asp:ListItem Value="NH">NH</asp:ListItem>
	<asp:ListItem Value="NJ">NJ</asp:ListItem>
	<asp:ListItem Value="NM">NM</asp:ListItem>
	<asp:ListItem Value="NY">NY</asp:ListItem>
	<asp:ListItem Value="NC">NC</asp:ListItem>
	<asp:ListItem Value="ND">ND</asp:ListItem>
	<asp:ListItem Value="OH">OH</asp:ListItem>
	<asp:ListItem Value="OK">OK</asp:ListItem>
	<asp:ListItem Value="OR">OR</asp:ListItem>
	<asp:ListItem Value="PA">PA</asp:ListItem>
	<asp:ListItem Value="RI">RI</asp:ListItem>
	<asp:ListItem Value="SC">SC</asp:ListItem>
	<asp:ListItem Value="SD">SD</asp:ListItem>
	<asp:ListItem Value="TN">TN</asp:ListItem>
	<asp:ListItem Value="TX">TX</asp:ListItem>
	<asp:ListItem Value="UT">UT</asp:ListItem>
	<asp:ListItem Value="VT">VT</asp:ListItem>
	<asp:ListItem Value="VA">VA</asp:ListItem>
	<asp:ListItem Value="WA">WA</asp:ListItem>
	<asp:ListItem Value="WV">WV</asp:ListItem>
	<asp:ListItem Value="WI">WI</asp:ListItem>
	<asp:ListItem Value="WY">WY</asp:ListItem>

                    </asp:DropDownList>
                    
    </div>
    <div class="form-group col-md-3">
      <label for="inputZip">Zip</label>
      <asp:TextBox ID="tbZip" runat="server" Class="form-control" placeholder="Zip"></asp:TextBox>
    </div>
  </div>
                        
                         <asp:button ID="btnSingupHouseOwner"  runat="server" class="btn btn-primary" Text="Sign Up" OnClick="btnSingupHouseOwner_Click"></asp:button>
                           
                        </div>

                        <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                           
                                <asp:Button ID="btnSingupTenant" runat="server" Class="btn btn-primary" Text="Sign Up" OnClick="btnSingupTenant_Click" />
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </div>
                      
                    </div>
                </div>
            </div>
        </div>
            </div>
    </section>


    <!-- Sign Up -->
</asp:Content>
