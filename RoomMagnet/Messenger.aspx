<%@ Page Title="Massenger" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Messenger.aspx.cs" Inherits="Massenger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript" async="" src="http://www.google-analytics.com/ga.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>


    <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-mousewheel/3.1.13/jquery.mousewheel.min.js"></script>
    </head>    
       
    <title>Messenger</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <style type="text/css">
        body, html {
            height: 100%;
            margin: 0;
           
            background: linear-gradient(to right, rgba(0,0,0,0.4), rgba(0,0,0,0.3), rgba(0,0,0,0.4));
        }

        .chat {
            margin-top: auto;
            margin-bottom: auto;
        }

        .card {
            height: 500px;
            border-radius: 15px !important;
            background-color: rgba(0,0,0,0.4) !important;
        }

        .contacts_body {
            padding: 0.75rem 0 !important;
            overflow-y: auto;
            white-space: nowrap;
        }

        .msg_card_body {
            overflow-y: auto;
        }

        .card-header {
            border-radius: 15px 15px 0 0 !important;
            border-bottom: 0 !important;
        }

        .card-footer {
            border-radius: 0 0 15px 15px !important;
            border-top: 0 !important;
        }

        .container {
            align-content: center;
        }

        .search {
            border-radius: 15px 0 0 15px !important;
            background-color: rgba(0,0,0,0.3) !important;
            border: 0 !important;
            color: white !important;
        }

            .search:focus {
                box-shadow: none !important;
                outline: 0px !important;
            }

        .type_msg {
            background-color: rgba(0,0,0,0.3) !important;
            border: 0 !important;
            color: white !important;
            height: 60px !important;
            overflow-y: auto;
        }

            .type_msg:focus {
                box-shadow: none !important;
                outline: 0px !important;
            }

        .attach_btn {
            border-radius: 15px 0 0 15px !important;
            background-color: rgba(0,0,0,0.3) !important;
            border: 0 !important;
            color: white !important;
            cursor: pointer;
        }

        .send_btn {
            border-radius: 0 15px 15px 0 !important;
            background-color: rgba(0,0,0,0.3) !important;
            border: 0 !important;
            color: white !important;
            cursor: pointer;
        }

        .search_btn {
            border-radius: 0 15px 15px 0 !important;
            background-color: rgba(0,0,0,0.3) !important;
            border: 0 !important;
            color: white !important;
            cursor: pointer;
        }

        .contacts {
            list-style: none;
            padding: 0;
        }

            .contacts li {
                width: 100% !important;
                padding: 5px 10px;
                margin-bottom: 15px !important;
            }

        .active {
            background-color: rgba(0,0,0,0.3);
        }

        .user_img {
            height: 70px;
            width: 70px;
            border: 1.5px solid #f5f6fa;
        }

        .user_img_msg {
            height: 40px;
            width: 40px;
            border: 1.5px solid #f5f6fa;
        }

        .img_cont {
            position: relative;
            height: 70px;
            width: 70px;
        }

        .img_cont_msg {
            height: 40px;
            width: 40px;
        }

        .online_icon {
            position: absolute;
            height: 15px;
            width: 15px;
            background-color: #4cd137;
            border-radius: 50%;
            bottom: 0.2em;
            right: 0.4em;
            border: 1.5px solid white;
        }

        .offline {
            background-color: #c23616 !important;
        }

        .user_info {
            margin-top: auto;
            margin-bottom: auto;
            margin-left: 15px;
        }

            .user_info span {
                font-size: 20px;
                color: white;
            }

            .user_info p {
                font-size: 10px;
                color: rgba(255,255,255,0.6);
            }

        .video_cam {
            margin-left: 50px;
            margin-top: 5px;
        }

            .video_cam span {
                color: white;
                font-size: 20px;
                cursor: pointer;
                margin-right: 20px;
            }

        .msg_cotainer {
            margin-top: auto;
            margin-bottom: auto;
            margin-left: 10px;
            border-radius: 25px;
            background-color: #82ccdd;
            padding: 10px;
            position: relative;
        }

        .msg_cotainer_send {
            margin-top: auto;
            margin-bottom: auto;
            margin-right: 10px;
            border-radius: 25px;
            background-color: #78e08f;
            padding: 10px;
            position: relative;
        }

        .msg_time {
            position: absolute;
            left: 0;
            bottom: -15px;
            color: rgba(255,255,255,0.5);
            font-size: 10px;
        }

        .msg_time_send {
            position: absolute;
            right: 0;
            bottom: -15px;
            color: rgba(255,255,255,0.5);
            font-size: 10px;
        }

        .msg_head {
            position: relative;
        }

        #action_menu_btn {
            position: absolute;
            right: 10px;
            top: 10px;
            color: white;
            cursor: pointer;
            font-size: 20px;
        }

        .action_menu {
            z-index: 1;
            position: absolute;
            padding: 15px 0;
            background-color: rgba(0,0,0,0.5);
            color: white;
            border-radius: 15px;
            top: 30px;
            right: 15px;
            display: none;
        }

            .action_menu ul {
                list-style: none;
                padding: 0;
                margin: 0;
            }

                .action_menu ul li {
                    width: 100%;
                    padding: 10px 15px;
                    margin-bottom: 5px;
                }

                    .action_menu ul li i {
                        padding-right: 10px;
                    }

                    .action_menu ul li:hover {
                        cursor: pointer;
                        background-color: rgba(0,0,0,0.2);
                    }

        @media(max-width: 576px) {
            .contacts_card {
                margin-bottom: 15px !important;
            }
        }
    </style>
    <style>
        /* width */
        ::-webkit-scrollbar {
            width: 20px;
        }

        /* Track */
        ::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }

        /* Handle */
        ::-webkit-scrollbar-thumb {
            background: silver;
            border-radius: 10px;
        }

            /* Handle on hover */
            ::-webkit-scrollbar-thumb:hover {
                background: pink;
            }
    </style>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        window.alert = function () { };
        var defaultCSS = document.getElementById('bootstrap-css');
        function changeCSS(css) {
            if (css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="' + css + '" type="text/css" />');
            else $('head > link').filter(':first').replaceWith(defaultCSS);
        }
        $(document).ready(function () {
            var iframe_height = parseInt($('html').height());
            window.parent.postMessage(iframe_height, 'https://bootsnipp.com');
        });
        </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-mousewheel/3.1.13/jquery.mousewheel.min.js"></script>
    <title>Chat</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.5/jquery.mCustomScrollbar.min.css">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.5/jquery.mCustomScrollbar.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid h-100" style="padding-top: 130px; padding-bottom: 70px">
        <div class="row justify-content-center h-100">
            <div class="col-md-4 col-xl-3 chat" style="padding-right: 0px">
                <div class="card mb-sm-3 mb-md-0 contacts_card">
                    <div class="card-header">
                  
                    </div>
                    <div class="card-body contacts_body">
                        <ui class="contacts">
<asp:Repeater ID="rptContacts" runat="server">
   <ItemTemplate>
                            <li id ="li_contacts" runat="server" onclick="">
                                <a id="contactsleft" Name='<%# Eval("UserID") %>' href="#" runat="server"  onserverclick="contactsleft_ServerClick" >
                                <div class="d-flex bd-highlight">
                                    <div class="img_cont">
                                         <asp:PlaceHolder runat="server" Visible='<%# Eval("userType").ToString()=="h" %>'>
                                        <img src = "img/avatar/avatar-7.jpg" class="rounded-circle user_img">
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" Visible='<%# Eval("userType").ToString()=="t" %>'>
                                        <img src = "images/tenantBlank.jpg" " class="rounded-circle user_img">
                                        </asp:PlaceHolder>
                                     
                                        <span class="online_icon"></span>
                                    </div>
                                    <div class="user_info">
                                        <span> <%# Eval("Firstname") %> <%# Eval("LastName") %> </span>
                                    </div>
                                </div>
                                    </a>
                            </li>


                            

       </ItemTemplate>
    </asp:Repeater>
                          
                            </ui>
                    </div>
                    <div class="card-footer"></div>
                </div>
            </div>
            <div class="col-md-8 col-xl-6 chat">
                <div class="card">
                    <div class="card-header msg_head">
                        <div class="d-flex bd-highlight">
                            <div class="img_cont">

                                  <div id="headimgsrc" runat="server">
                                        <img  src ="images/tenantBlank.jpg" class="rounded-circle user_img">
                                        </div>
                               
                              <div id="headimgsrc1" runat="server">
                                        <img  src ="images/tenantBlank.jpg" class="rounded-circle user_img">
                                        </div>
                                
                                <span class="online_icon"></span>
                            </div>
                            <div class="user_info">
                                <span id="msg_header" runat="server">Chat with Me</span>
                             
                            </div>
                        
                        </div>
                       
                    
                    </div>
                    <div class="card-body msg_card_body">

                        <asp:textbox id="togglebox"  runat="server" Visible="False">t</asp:textbox>
                        <asp:repeater id="rptMsgBody" runat="server">


    <ItemTemplate>

        <asp:PlaceHolder runat="server" Visible='<%# Eval("MsgSender").ToString()!=togglebox.Text %>'>
   <div class="d-flex justify-content-start mb-4">
                                    <div class="img_cont_msg">
                                        <asp:PlaceHolder runat="server" Visible='<%# Eval("MsgSender").ToString()=="h" %>'>
                                        <img src = "images/tenantBlank.jpg" class="rounded-circle user_img_msg">
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" Visible='<%# Eval("MsgSender").ToString()=="t" %>'>
                                        <img src = "images/tenantBlank.jpg" " class="rounded-circle user_img_msg">
                                        </asp:PlaceHolder>
                                        
                                            </div>
                                    <div class="msg_cotainer">
                                        <%# Eval("Message") %>
                                        <span class="msg_time"><%# Eval("time") %></span>
                                    </div>
                                </div>
</asp:PlaceHolder>

            <asp:PlaceHolder runat="server" Visible='<%# Eval("MsgSender").ToString()==togglebox.Text %>'>

 <div class="d-flex justify-content-end mb-4">
                            <div class="msg_cotainer_send">
                                <div>
                                 <%# Eval("Message") %>
                                    </div>
                                <span class="msg_time_send"><%# Eval("time") %></span>
                            </div>
                            <div class="img_cont_msg">

                               <asp:PlaceHolder runat="server" Visible='<%# Eval("MsgSender").ToString()=="h" %>'>
                                        <img src = "img/avatar/avatar-7.jpg" class="rounded-circle user_img_msg">
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" Visible='<%# Eval("MsgSender").ToString()=="t" %>'>
                                        <img src = "images/tenantBlank.jpg" " class="rounded-circle user_img_msg">
                                        </asp:PlaceHolder>
                                </div>
                        </div>

</asp:PlaceHolder>
         
      </ItemTemplate>

</asp:repeater>


               
                      

                    </div>
                    <div class="card-footer">
                        <div class="input-group1" style="display:flex">
                         
                            <textarea  runat="server" id="WriteMsgArea" class="form-control type_msg" placeholder="Type your message..." style="margin-top: 0px; margin-bottom: 0px; height: 81px;"></textarea>
                            <div class="input-group-append">
                                <span class="input-group-text send_btn">
                                  
                                     <a href="#" ID="btnSendMsg" onserverclick="btnSendMsgClick" Class="fas fa-location-arrow"  runat="server"></a>
                               
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#action_menu_btn').click(function () {
                $('.action_menu').toggle();
            });
        });	</script>




    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-34731274-1']);
        _gaq.push(['_trackPageview']);
        _gaq.push(['_trackEvent', 'sharing', 'viewed full-screen', 'snippet nNg98', 0, true]);
        (function () {
            var ga = document.createElement('script');
            ga.type = 'text/javascript';
            ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(ga, s);
        })();
    </script>
    <script type="text/javascript">
        (function ($) {
            $('#theme_chooser').change(function () {
                whichCSS = $(this).val();
                document.getElementById('snippet-preview').contentWindow.changeCSS(whichCSS);
            });
        })(jQuery);
    </script>


</asp:Content>

