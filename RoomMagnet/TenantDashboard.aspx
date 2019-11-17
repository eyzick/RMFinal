<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenantDashboard.aspx.cs" Inherits="TenantDashboard" %>

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
                <h1>Tenant Panel</h1>
            </div>

        </div>
    </div>


    <section id="tabs" class="project-tab">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <nav>
                        <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">

                            <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">
                                Profile</a>
                            <a class="nav-item nav-link " id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">
                                My Favorities</a>
                        
                        </div>
                    </nav>
                    <br>
                    <div class="tab-content" id="nav-tabContent">

                        <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">

                           <div class="col-md-2">
                            </div>
                            <div class="col-md-8">
                              
           <label>
           <input type="checkbox" id="myCheck" onclick="myFunction()">Update
          </label>

                
  
                           <div class="hostProfile">
                             <div class="form-row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbFirstName">First Name</label>
                                    <asp:TextBox ID="tbName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                                </div>
                                </div>
                                 <div class="col">
                                  <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbLastName">Last Name</label>
                                    <asp:TextBox ID="tbName1" runat="server" Class="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                                     </div>
                              </div>
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbUname">tbEmail</label>

                                    <asp:TextBox ID="tbtbEmail" runat="server" Class="form-control" placeholder="Usename"></asp:TextBox>

                                </div>
                          <div class="form-row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbPass">Password</label>

                                    <asp:TextBox ID="tbPass" runat="server" Class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>
                                </div>
                                <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbCPass">Confirm Password</label>

                                    <asp:TextBox ID="tbCPass" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
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
                                    <asp:TextBox ID="tbPhone" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
            
                                </div>
                                </div>

                            </div>

                                   <div class="form-group">
    <label for="inputAddress">Address</label>
    <input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St">
  </div>
                          <div class="form-group">
    <label for="inputAddress2">Address 2</label>
    <input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor">
  </div>
                          <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity">
    </div>
    <div class="form-group col-md-3">
      <label for="inputState">State</label>
    
    
    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" style="height:auto">
              
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
      <input type="text" class="form-control" id="inputZip">
    </div>
  </div>
                        
                         <button type="submit" class="btn btn-primary">Update </button>

                               </div>
                                </div>
                        </div>

                        <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                            owowo

                        </div>


                        

                    </div>

                </div>
            </div>
        </div>
    </section>
   <script>

    

       function myFunction() {
  // Get the checkbox
  var checkBox = document.getElementById("myCheck");
  // Get the output text
  var text = document.getElementById("text");

  // If the checkbox is checked, display the output text
           if (checkBox.checked == true) {
               $(".hostProfile :input").attr("disabled", false);
  } else {
    $(".hostProfile :input").attr("disabled", true);
  }
       }

         document.getElementById("myCheck").checked = true;

</script>

</asp:Content>
