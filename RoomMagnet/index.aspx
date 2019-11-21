<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
    .background {
        background-color: #111;
    }
</style>
         <!--- Carousel -->

       <div class="banner" id="banner">
        <div id="bannerCarousole" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item banner-max-height active">
                    <img class="d-block w-100" src="img/banner/banner-2.jpg" alt="banner">
                    <div class="carousel-caption banner-slider-inner"></div>
                </div>
                <div class="carousel-item banner-max-height">
                    <img class="d-block w-100" src="img/banner/banner-3.jpg" alt="banner">
                    <div class="carousel-caption banner-slider-inner"></div>
                </div>
                <div class="carousel-item banner-max-height">
                    <img class="d-block w-100" src="img/banner/banner-1.jpg" alt="banner"/>
                    <div class="carousel-caption banner-slider-inner"></div>
                </div>
                <div class="carousel-caption d-flex h-100 banner-slider-inner-2">
                    <div class="carousel-content container">
                        <div class="container-fluid" style="margin-top: 100px;">

                              <div class="row">
                                  <div class="col-md-6 col-sm-12">
                                <div class="text-center">
                            <h3>Are you a</h3>
                            <h3>Home Owner?</h3>
                         <asp:Button ID="btnOwner" CssClass="btn btn-primary custom-btn" runat="server" Text="List your property" OnClick="btnOwner_Click" />
                                </div>
                              </div>
                                  <div class="col-md-6 col-sm-12">
                                <div class="text-center">
                            <h3>Are you a</h3>
                            <h3>Renter?</h3>
                                     <asp:Button ID="btnRenter" CssClass="btn btn-primary custom-btn" runat="server" Text="Explore properties" OnClick="btnRenter_Click" />
                                </div>
                        </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#bannerCarousole" role="button" data-slide="prev">
            <span class="slider-mover-left" aria-hidden="true">
                <i class="fa fa-angle-left"></i>
            </span>
        </a>
            <a class="carousel-control-next" href="#bannerCarousole" role="button" data-slide="next">
            <span class="slider-mover-right" aria-hidden="true">
                <i class="fa fa-angle-right"></i>
            </span>
        </a>
        </div>
        <div class="container search-options-btn-area">
            <a class="search-options-btn d-lg-none d-xl-none">
                <div class="search-options d-none d-xl-block d-lg-block">Search Options</div>
                <div class="icon"><i class="fa fa-chevron-up"></i></div>
            </a>
        </div>
    </div>
   <%-- <div class="row background">
        <div class="col-md-4">

        </div>
        <div class="col-md-4">
            <div class='tableauPlaceholder' id='viz1574219697280' style='position: relative'><noscript><a href='#'><img alt=' ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;X3&#47;X3MJRNH2B&#47;1_rss.png' style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='path' value='shared&#47;X3MJRNH2B' /> <param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;X3&#47;X3MJRNH2B&#47;1.png' /> <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /><param name='filter' value='publish=yes' /></object></div>                <script type='text/javascript'>                    var divElement = document.getElementById('viz1574219697280');                    var vizElement = divElement.getElementsByTagName('object')[0];                    vizElement.style.width='100%';vizElement.style.height=(divElement.offsetWidth*0.75)+'px';                    var scriptElement = document.createElement('script');                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';                    vizElement.parentNode.insertBefore(scriptElement, vizElement);                </script>
        </div>
        <div class="col-md-4">

        </div>
    </div>--%>
   
     <!--- Carousel -->

    


</asp:Content>

