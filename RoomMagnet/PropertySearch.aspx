<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropertySearch.aspx.cs" Inherits="PropertySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

            <!-- css and js -->

    
<style>
    .form-control {
        margin-top: 1px;
    }

    .filter-lable {
        text-align: right;
        margin-top: 3px;
    }

    .propertybox {
        width: 80%;
        padding-top: 0px;
        padding-left: 0px;
        padding-right: 0px;
        box-shadow: 2px 2px 2px 2px grey;
        margin: 12px;
        margin-bottom: 12px;
        text-align: justify;
        border-radius: 5px;
    }

        .propertybox .btn {
            width: 100px;
            font-size: 12px;
            text-align: center;
            background-color: palevioletred;
            border-radius: 7px;
            
        }

    .thumbnail {
        padding: 0px;
    }

    .propertybox img {
        height: 200px;
        width: 100%;
    }

    @media (max-width: 1200px) {
        .propertybox {
            flex: 0 0 50%;
            max-width: 60%;
        }
    }

        @media (min-width: 800px) {
            .propertybox {
                flex: 0 0 46%;
                max-width: 80%;
            }

                .propertybox img {
                    width: 100%;
                }
        }

        @media (min-width: 768px) {
            .col-md-8 {
                -ms-flex: 0 0 66.666667%;
                flex: 0 0 66.666667%;
                max-width: 80%;
            }
            /* Set the size of the div element that contains the map */
            #map {
                height: 500px; /* The height is 400 pixels */
                width: 500px; /* The width is the width of the web page */
                border: 1px;
                background-color: red;
                border-color: rebeccapurple;
            }
        }

    .option-bar {
    margin-bottom: 30px;
    padding: 10px 15px;
    background: #fff;
    box-shadow: 0 0 35px rgba(0, 0, 0, 0.1);
}

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="sub-banner overview-bgi">
    <div class="container">
       
        <div class="headingg">
            <h1>Search Properties</h1>
          </div>
       
    </div>
</div>
         <div class="container" style="padding-top:20px;margin:0px;padding-left:80px" >
           <div class="row">

             <div class="col-8">
                 <div class="input-group" ">
               <asp:TextBox ID="txt_search" runat="server" CssClass="form-control" style="border-top-left-radius: 10px; border-bottom-left-radius: 10px;" placeholder="Richard VA"></asp:TextBox>
     
      <span class="input-group-btn">
          
       
          <asp:linkbutton ID="btnSearch" runat="server" onclick="btnSearch_Click" CssClass="btn btn-default glyphicon glyphicon-search"  style="border-top-right-radius: 10px; border-bottom-right-radius: 10px;" />
   
          </span>
          </div>
                 <!-- /input-group -->
                
             </div>
             <div class="col-2 filter-lable">
          
              <asp:Label ID="Label1" runat="server" Text="Filter By" Font-Size="Large" Font-Bold="True"></asp:Label> 
             </div>
             <div class="col-2 " >
              <asp:DropDownList ID="ddlFilters" CssClass="btn btn-default" runat="server">
                <asp:ListItem>Most Recent</asp:ListItem>
                <asp:ListItem>Lowest Price</asp:ListItem>
                <asp:ListItem>heighest Price</asp:ListItem>
              </asp:DropDownList>
             </div>
          
             <div class="col-2">

             </div>
        
            </div>

        </div>
       
         <div class="container-fluid" style="padding-left: 50px; padding-top:35px">

        <div class="col-md-8" style="width: 60%;">
        <div class="option-bar d-none d-xl-block d-lg-block d-md-block d-sm-block">
                    <div class="row">
                        <div class="col-lg-6 col-md-7 col-sm-7">
                            <div class="sorting-options2">
                                <span class="sort">Sort by:</span>
                                <div class="dropdown bootstrap-select search-fields"><select class="selectpicker search-fields" name="default-order" tabindex="-98">
                                    <option>Default Order</option>
                                    <option>Price High to Low</option>
                                    <option>Price: Low to High</option>
                                    <option>Newest Properties</option>
                                    <option>Oldest Properties</option>
                                </select>
                                    <button type="button" class="btn dropdown-toggle btn-light" data-toggle="dropdown" role="button" title="Default Order" style="display:none">
                                        <div class="filter-option"><div class="filter-option-inner">Default Order</div></div>&nbsp;<span class="bs-caret"><span class="caret"></span></span>

                                    </button>
                                    <div class="dropdown-menu " role="combobox"><div class="inner show" role="listbox" aria-expanded="false" tabindex="-1"><ul class="dropdown-menu inner show"></ul></div></div></div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-5 col-sm-5">
                            <div class="sorting-options">
                      
                               
                                <a href="properties-grid-rightside.html" class="change-view-btn active-view-btn"><i class="fa fa-th-large"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            <div class="row">
      <asp:Repeater ID="Repeater1" runat="server">

    <ItemTemplate>
             <div class="col-sm-6 col-md-5 propertybox">
                <div class="thumbnail">
                    <img src='<%#    "data:Image.jpg;base64," + Convert.ToBase64String( (byte[])Eval("image")  ) %>' alt="" />
                    <div class="caption" style="padding: 15px;">

                        <div class="row">

                          <div class="col-7" style="text-align:center">
                            <h5><%#Eval("Capacity") %> "1 bedroom 1 bath"</h5>
                             <h5><%#Eval("Zip") %>Northen Va,2280</h5>
                              <h5><strong>$<%#Eval("Price") %>per month</strong></h5>

                          </div>
                          
                          <div class="col-md-5" style="padding-top:10px">
                              <p><a href="#" class="btn btn-primary ">Description</a></p>
                              <p><a href="#" class="btn btn-primary ">Add to Favorites</a></p>
                          </div>
                          
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
</asp:Repeater>





        </div>
        </div>

        <div class="col-md-4">

             <div  id="map">
          
              </div>


            </div>
    </div>
     <script src="js/jquery-2.2.0.min.js"></script>
 <script>

   //  $('.propertybox').each(function(inde){$(this).attr('class', 'col-sm-6 col-md-12 propertybox');$(this).css('flex','100%'); $(this).css('disply:block')});

     function sortA() {
         alert('hi');
     }

   //  $(document).on('scroll', function () {

   //  });
 
   //  $(document).unbind('scroll');
   //  $(window).unbind('scroll');
     
   //  $(document).on('scroll', function () {

   //  });

   //     $('.input-group').hide();
   //     $('.companyName').show();
   //$(document).unbind('scroll');
   //  $(window).unbind('scroll');

     </script>
    


</asp:Content>

