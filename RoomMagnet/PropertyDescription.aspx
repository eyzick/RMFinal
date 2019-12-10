<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropertyDescription.aspx.cs" Inherits="PropertyDescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
<script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/common.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/util.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/map.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/marker.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/infowindow.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/onion.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/stats.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/controls.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/common.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/util.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/map.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/marker.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/onion.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/stats.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/infowindow.js"></script><script type="text/javascript" charset="UTF-8" src="https://maps.googleapis.com/maps-api-v3/api/js/38/11/controls.js"></script></head>

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
            <h1>Description</h1>
          </div>
       
    </div>
</div>
      <div class="properties-details-page content-area" style="padding-top:30px ">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <!-- Heading properties 3 start -->
                    <div class="heading-properties-3">
                        <h1 id="PropertyLocation" runat="server"></h1>
                        <div class="mb-30">
                            <h4><span class="pprice" id="PropertyPrice"  runat="server"> per month</span></h4>
                            <asp:button runat="server" text="Apply" OnClick="Unnamed1_Click" />
                            <span class="rent" id="PropertySaleRent" runat="server">For Rent</span>
<%--                            <span class="location" id="PropertyLocation" runat="server"><i class="flaticon-pin"></i>123 Kathal St. Tampa City,</span></div>--%>
                          
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 col-md-12">
                    <!-- main slider carousel items -->
                    <div id="propertiesDetailsSlider" class="carousel properties-details-sliders slide mb-40">
                        <div class="carousel-inner">
                            <div class="active item carousel-item" data-slide-number="0">
                                <img id="PropertyImage" runat="server" src="img/properties/properties-1.jpg" class="img-fluid" alt="slider-properties" style="width: 100%">
                            </div>
                            

                            <a class="carousel-control left" href="#propertiesDetailsSlider" data-slide="prev"><i class="fa fa-angle-left"></i></a>
                            <a class="carousel-control right" href="#propertiesDetailsSlider" data-slide="next"><i class="fa fa-angle-right"></i></a>

                        </div>
                        <!-- main slider carousel nav controls -->
                     
                        <!-- main slider carousel items -->
                    </div>
                    <!-- Advanced search start -->
                    <div class="widget-2 advanced-search bg-grea-2 d-lg-none d-xl-none">
                        
                        <h3 class="sidebar-title">Specification</h3>
                     <div class="card-body">
                    
                    </div>
                        
                        
                    </div>
                    <!-- Properties description start -->
                    <div class="properties-description mb-40">
                        <h3 class="heading-2">
                            Description
                        </h3>
                        <p id="PropertyDes" runat="server" >Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas in pulvinar neque. Nulla finibus lobortis pulvinar. Donec a consectetur nulla. Nulla posuere sapien vitae lectus suscipit, et pulvinar nisi tincidunt. Aliquam erat
                            volutpat. Curabitur convallis fringilla diam sed aliquam. Sed tempor iaculis massa faucibus feugiat. In fermentum facilisis massa, a consequat purus viverra a. Aliquam pellentesque nibh et nibh feugiat gravida. Maecenas ultricies,
                            diam vitae semper placerat, velit risus accumsan nisl, eget tempor lacus est vel nunc. Proin accumsan elit sed neque euismod fringilla. Curabitur lobortis nunc velit, et fermentum urna dapibus non. Vivamus magna lorem, elementum
                            id gravida ac, laoreet tristique augue. Maecenas dictum lacus eu nunc porttitor, ut hendrerit arcu efficitur.</p>
                    </div>
                    <!-- Properties amenities start -->
                    <div class="properties-amenities mb-40">
                        <h3 class="heading-2">
                            Features
                        </h3>
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                <ul id="PropertyAmenities" runat="server" class="amenities">
                                   
                                </ul>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                <ul class="amenities">
                                  
                                </ul>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                              
                            </div>
                        </div>
                    </div>
                    <!-- Floor plans start -->
                    
                    <!-- Location start -->
                    <div class="location mb-50">
                        <div class="map">
                            <h3 class="heading-2">Property Location</h3>
                            <iframe width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/place?q=place_id:ChIJVXEHP8OStIkRX3u92rllTgg&key=AIzaSyDRRjdpQT52RP-naFTOxmM11eZDgRpy6ZM" allowfullscreen></iframe>
                        </div>
                    </div>
                    <!-- Inside properties start -->
                    
                    <!-- Similar Properties start -->
                    
                    
                </div>
                <div class="col-lg-4 col-md-12">
                    <div class="sidebar-right">
                        <!-- Advanced search start -->
                        <div class="widget advanced-search d-none d-xl-block d-lg-block">
                            <h3 class="sidebar-title" style="text-align:center">Specification</h3>
                            <div class="card-body">
                      <table class="table v1">
                      
                          
                        <tbody><tr>
                          <td>Capacity</td>
                          <td id="PropertyCapacity" runat="server"></td>
                        </tr>
                        <tr>
                          <td id="PropertyAvailablity" runat="server">Availability</td>
                          <td>2</td>
                        </tr>
                        <tr>
                          <td>Room Type</td>
                          <td id="PropertyType" runat="server"></td>
                        </tr>
                       <%--<iframe width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/place?q=place_id:ChIJVXEHP8OStIkRX3u92rllTgg&key=AIzaSyDRRjdpQT52RP-naFTOxmM11eZDgRpy6ZM" allowfullscreen></iframe>--%>
                      </tbody></table>
                    
                    </div>
                            
                        </div>
                        
                        
                        
                        
                        <!-- Our agent sidebar start -->
                        <div class="our-agent-sidebar">
                            <div class="p-20">
                                <h3 class="sidebar-title">Contact Host</h3>
                                <div class="s-border"></div>
                            </div>
                            
                        <div class="team-1">
                                            <div class="team-photo">
                                                <a href="#">
                                               <%-- <img src="img/avatar/avatar-7.jpg" alt="agent-2" class="img-fluid">--%>
                                            </a>
                                               <%-- <ul class="social-list clearfix">
                                                    <li><a href="#" class="facebook"><i class="fa fa-facebook"></i></a></li>
                                                    <li><a href="#" class="twitter"><i class="fa fa-twitter"></i></a></li>
                                                    <li><a href="#" class="instagram"><i class="fa fa-instagram"></i></a></li>
                                                    <li><a href="#" class="linkedin"><i class="fa fa-linkedin"></i></a></li>
                                                </ul>--%>
                                            </div>
                                            <div class="team-details">
                                                <h5 id="HostName" runat="server"><a href="#">Martin Smith</a></h5>
                                                <h6 id="HostLocation" runat="server">7332,Street 3 AL london</h6>
                                                <h4 id="HostPhone" runat="server">+1 204 777 0187</h4>
                                                <asp:hyperlink id="MessageHost" cssClass="btn btn-primary" runat="server">Message Host</asp:hyperlink>
                                                <asp:HyperLink ID="skypeHost" CssClass="btn btn-primary" OnClock="skype_click" runat="server">Video Chat with Host</asp:HyperLink>
                                              
                                            </div>
                                        </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Properties details page end -->







   <%-- <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB0N5pbJN10Y1oYFRd0MJ_v2g8W2QT74JE"></script>
    <script>
        function LoadMap(propertes) {
            var defaultLat = 38.4496;
            var defaultLng = 78.8689;
            var mapOptions = {
                center: new google.maps.LatLng(defaultLat, defaultLng),
                zoom: 15,
                scrollwheel: false,
                styles: [{
                        featureType: "administrative",
                        elementType: "labels",
                        stylers: [{
                            visibility: "off"
                        }]
                    },
                    {
                        featureType: "water",
                        elementType: "labels",
                        stylers: [{
                            visibility: "off"
                        }]
                    },
                    {
                        featureType: 'poi.business',
                        stylers: [{
                            visibility: 'off'
                        }]
                    },
                    {
                        featureType: 'transit',
                        elementType: 'labels.icon',
                        stylers: [{
                            visibility: 'off'
                        }]
                    },
                ]
            };
            var map = new google.maps.Map(document.getElementById("map"), mapOptions);
            var infoWindow = new google.maps.InfoWindow();
            var myLatlng = new google.maps.LatLng(40.7110411, -74.0110326);

            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map
            });
            (function(marker) {
                google.maps.event.addListener(marker, "click", function(e) {
                    infoWindow.setContent("" +
                        "<div class='map-properties contact-map-content'>" +
                        "<div class='map-content'>" +
                        "<p class='address'>20-21 Kathal St. Tampa City, FL</p>" +
                        "<ul class='map-properties-list'> " +
                        "<li><i class='flaticon-phone'></i>  +0477 8556 552</li> " +
                        "<li><i class='flaticon-phone'></i>  info@themevessel.com</li> " +
                        "<li><a href='index.html'><i class='fa fa-globe'></i>  http://www.example.com</li></a> " +
                        "</ul>" +
                        "</div>" +
                        "</div>");
                    infoWindow.open(map, marker);
                });
            })(marker);
        }
        LoadMap();
    </script>--%>

    <script src="js/jquery-2.2.0.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-submenu.js"></script>
    <script src="js/rangeslider.js"></script>
    <script src="js/jquery.mb.YTPlayer.js"></script>
    <script src="js/bootstrap-select.min.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>
    <script src="js/jquery.scrollUp.js"></script>
    <script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="js/leaflet.js"></script>
    <script src="js/leaflet-providers.js"></script>
    <script src="js/leaflet.markercluster.js"></script>
    <script src="js/dropzone.js"></script>
    <script src="js/slick.min.js"></script>
    <script src="js/jquery.filterizr.js"></script>
    <script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/jquery.countdown.js"></script>
    <script src="js/maps.js"></script>
    <script src="js/app.js"></script>

    <script>
window.onscroll = function() {var p = document.querySelector('.sidebar-right'); p.style.width = "365px"; if(window.scrollY > 536){if(window.scrollY > 1122){p.style.position = "absolute"; p.style.transform = "translateY(500px)"; } else {p.style.position = "fixed"; p.style.transform ="translateY(-526px)"};
    } 
    else
    { p.style.position = "absolute"; p.style.transform = "translateY(0px)"; }
};

</script>
</asp:Content>

