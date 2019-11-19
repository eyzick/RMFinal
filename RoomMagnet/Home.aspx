<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
   
     <!--- Carousel -->

       
        <br />
        <br />


</asp:Content>

