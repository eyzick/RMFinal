<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSignUp.aspx.cs" Inherits="AdminSignUp" %>

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


        <div class="container">
            <div class="row">
                <div class="col-2">
                </div>
                <div class="col-md-8">
                   
                    <br>

                    <div class="center-page">

                        <div class="tab-content" id="nav-tabContent">

                            <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">

                                <div class="form-row">
                                    <div class="col">
                                        <div class="form-group">
                                            <label for="ContentPlaceHolder1_tbName">First Name</label>
                                            <asp:TextBox ID="tbFirstName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbFirstName" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$" ValidationGroup="HouseOwner">invalid name</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbFirstName" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your first name</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-group">
                                            <label for="ContentPlaceHolder1_tbName1">Last Name</label>
                                            <asp:TextBox ID="tbLastName" runat="server" Class="form-control" placeholder="Last Name"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbLastName" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$" ValidationGroup="HouseOwner">invalid name</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbLastName" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your last name</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbUname">tbEmail</label>

                                    <asp:TextBox ID="tbtbEmail" runat="server" Class="form-control" placeholder="Usename"></asp:TextBox>--%>

                                <%-- </div>--%>
                                <div class="form-row">
                                    <div class="col">
                                        <div class="form-group">
                                            <label for="ContentPlaceHolder1_tbPass">Password</label>

                                            <asp:TextBox ID="tbPassWord" runat="server" Class="form-control" placeholder="Password" TextMode="Password" MaxLength="30"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbPassWord" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,30}$" ValidationGroup="HouseOwner">Passwords must be at least 8 characters, and least contains 1 lower case, 1 upper case, 1 numeric, 1 non-word and no whitespace</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbPassWord" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your password</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-group">
                                            <label for="ContentPlaceHolder1_tbCPass">Confirm Password</label>

                                            <asp:TextBox ID="tbConfirmPassword" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPassWord" ControlToValidate="tbConfirmPassword" Display="Dynamic" ErrorMessage="CompareValidator" ForeColor="Red" ValidationGroup="HouseOwner">Passwords must match</asp:CompareValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col">
                                        <div class="form-group">
                                            <label for="ContentPlaceHolder1_tbEmail">Email address</label>
                                            <asp:TextBox ID="tbEmail" runat="server" Class="form-control" aria-describedby="emailHelp" placeholder="Enter email"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your email address</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="HouseOwner">Invalid Email</asp:RegularExpressionValidator>
                                            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                                        </div>
                                    </div>

                                    <div class="col">
                                        <div class="form-group">
                                            <label for="ContentPlaceHolder1_tbPhone">Phone Number</label>
                                            <asp:TextBox ID="tbPhoneNumber" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="Phone Number" MaxLength="10" TextMode="Number"></asp:TextBox>



                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbPhoneNumber" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your phone number</asp:RequiredFieldValidator>



                                        </div>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label for="inputAddress">Address</label>

                                    <asp:TextBox ID="tbAddress" runat="server" Class="form-control" placeholder="1234 Main St"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbAddress" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your address</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ControlToValidate="tbAddress" ValidationGroup="HouseOwner" ForeColor="Red"  Text="Invalid address" ValidationExpression="^\w+\s\w+\s\w+$"></asp:RegularExpressionValidator>

                                </div>
                                <div class="form-group">
                                    <label for="inputAddress2">Date of Birth</label>

                                    <asp:TextBox ID="tbDOB" runat="server" Class="form-control" type="date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbDOB" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please choose your birthday</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label for="inputCity">City</label>
                                        <asp:TextBox ID="tbCity" runat="server" Class="form-control" placeholder="City"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbCity" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your city name</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbCity" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$" ValidationGroup="HouseOwner">Invalid city name</asp:RegularExpressionValidator>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label for="inputState">State</label>


                                        <asp:DropDownList ID="ddState" runat="server" CssClass="form-control" Style="height: auto">

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
                                        <asp:TextBox ID="tbZip" runat="server" Class="form-control" placeholder="Zip" MaxLength="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbZip" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter your Zip code</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbZip" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?" ValidationGroup="HouseOwner">Invalid ZIP</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCode">Administration Code</label>
                                    <asp:TextBox ID="AdminCode" runat="server" Class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="AdminCode" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="HouseOwner">Please enter admin code</asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnSingupAdmin" runat="server" class="btn btn-primary" Text="Sign Up" OnClick="btnSingupAdmin_Click" ValidationGroup="HouseOwner"></asp:Button>

                            </div>
                        </div>
                    </div>
                    <%-- center page --%>
                </div>
            </div>
        </div>

     </asp:Content>
