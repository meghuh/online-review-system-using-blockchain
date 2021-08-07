<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="OnlineReview.CustomerRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>Online Review</title>
<!-- for-mobile-apps -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Super Market Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- //for-mobile-apps -->
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<!-- font-awesome icons -->
<link href="css/font-awesome.css" rel="stylesheet"> 
<!-- //font-awesome icons -->
<!-- js -->
<script src="js/jquery-1.11.1.min.js"></script>
<!-- //js -->
<link href='//fonts.googleapis.com/css?family=Raleway:400,100,100italic,200,200italic,300,400italic,500,500italic,600,600italic,700,700italic,800,800italic,900,900italic' rel='stylesheet' type='text/css'>
<link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css'>
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="js/move-top.js"></script>
<script type="text/javascript" src="js/easing.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $(".scroll").click(function (event) {
            event.preventDefault();
            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
        });
    });
</script>
<!-- start-smoth-scrolling -->
</head>
	
<body>
<!-- header -->
	<%--<div class="agileits_header">
		<div class="container">
			
			<div class="agile-login">
				<ul>
					<li><a href="RegisterShop.aspx"> Create Account </a></li>
					<li><a href="Login.aspx">Login</a></li>
					<li><a href="contact.html">Help</a></li>
					
				</ul>
			</div>
			
			<div class="clearfix"> </div>
		</div>
	</div>--%>

	<div class="logo_products">
		<div class="container">
		<div class="w3ls_logo_products_left1">
			<%--	<ul class="phone_email">
					<li><i class="fa fa-phone" aria-hidden="true"></i>Order online or call us : (+0123) 234 567</li>
					
				</ul>--%>
			</div>
			<div class="w3ls_logo_products_left">
				<h1><a href="index.aspx">Online Review</a></h1>
			</div>
		
			
			<div class="clearfix"> </div>
		</div>
	</div>
<!-- //header -->
<!-- navigation -->
	<div class="navigation-agileits">
		<div class="container">
			<nav class="navbar navbar-default">
							<!-- Brand and toggle get grouped for better mobile display -->
							<div class="navbar-header nav_2">
								<button type="button" class="navbar-toggle collapsed navbar-toggle1" data-toggle="collapse" data-target="#bs-megadropdown-tabs">
									<span class="sr-only">Toggle navigation</span>
									<span class="icon-bar"></span>
									<span class="icon-bar"></span>
									<span class="icon-bar"></span>
								</button>
							</div> 
							<div class="collapse navbar-collapse" id="bs-megadropdown-tabs">
								<ul class="nav navbar-nav">
									<li><a href="index.aspx" class="act">Home</a></li>	
									<!-- Mega Menu -->
									<li ><a href="RegisterShop.aspx"> Create Account </a></li>
					                <li><a href="Login.aspx">Login</a></li>
                                    <li class="active"><a href="CustomerRegistration.aspx">Customer Registration</a></li>
								</ul>
							</div>
							</nav>
			</div>
		</div>
		
<!-- //navigation -->
<!-- breadcrumbs -->
	
<!-- //breadcrumbs -->
<!-- register -->
	<div class="register" style="background-image: url(images/22.jpg);">
		<div class="container">
			<h2 style="color:White;">Register Here</h2>
			<div class="login-form-grids">
				<h5>Customer information</h5>
				<form id="form1" runat="server">
					
                
                <label>Enter Customer Name</label> &nbsp &nbsp<span><i class="fa fa-user" aria-hidden="true"></i></span>
                <asp:TextBox ID="txtName" runat="server" placeholder="Enter Name"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter  Name"
                                        ControlToValidate="txtName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator><br />
                   <label>Enter Password</label> &nbsp &nbsp<span><i class="fa fa-unlock-alt" aria-hidden="true"></i></span>
                  <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password"></asp:TextBox><br />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password"
                  ControlToValidate="txtPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator><br />
                   <label>Enter MobileNo</label> &nbsp &nbsp<span><i class="fa fa-phone" aria-hidden="true"></i></span>
                 <asp:TextBox ID="txtMobileNo" runat="server" placeholder="Enter MobileNo"></asp:TextBox><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter MobileNo"
                  ControlToValidate="txtMobileNo" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo"
                        ErrorMessage="Only 10 Digits" ValidationExpression="[0-9]{10}" 
                        ValidationGroup="A" ForeColor="#FF3300"></asp:RegularExpressionValidator><br />
                 <label>Enter EmailId</label> &nbsp &nbsp<span><i class="fa fa-phone" aria-hidden="true"></i></span>
                 <asp:TextBox ID="txtEmailId" runat="server" placeholder="Enter Email Id"></asp:TextBox><br />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="EnterEmail Id"
                  ControlToValidate="txtEmailId" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="Invalid Email Id" ControlToValidate="txtEmailId" 
                        ForeColor="#FF3300" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                  
                  <label>Enter Address</label> &nbsp &nbsp<span><i class="far fa-address-book" aria-hidden="true"></i></span>
                  <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address"></asp:TextBox><br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Address"
                  ControlToValidate="txtAddress" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:Button ID="btnRegister" runat="server" Text="Register" ValidationGroup="A"
                        onclick="btnRegister_Click"/>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
				</form>
			</div>
			<div class="register-home">
				<a href="index.aspx">Home</a>
			</div>
		</div>
	</div>
<!-- //register -->
<!-- //footer -->
	
	<div class="footer-botm">
			<div class="container">
				<div class="w3layouts-foot">
					<ul>
						
					</ul>
				</div>
				<div class="payment-w3ls">	
					
				</div>
				<div class="clearfix"> </div>
			</div>
		</div>
<!-- //footer -->	
<!-- Bootstrap Core JavaScript -->
<script src="js/bootstrap.min.js"></script>
<!-- top-header and slider -->
<!-- here stars scrolling icon -->
	<script type="text/javascript">
	    $(document).ready(function () {
	        /*
	        var defaults = {
	        containerID: 'toTop', // fading element id
	        containerHoverID: 'toTopHover', // fading element hover id
	        scrollSpeed: 1200,
	        easingType: 'linear' 
	        };
	        */

	        $().UItoTop({ easingType: 'easeOutQuart' });

	    });
	</script>
<!-- //here ends scrolling icon -->
<script src="js/minicart.min.js"></script>
<script>
    // Mini Cart
    paypal.minicart.render({
        action: '#'
    });

    if (~window.location.search.indexOf('reset=true')) {
        paypal.minicart.reset();
    }
</script>
<!-- main slider-banner -->
<script src="js/skdslider.min.js"></script>
<link href="css/skdslider.css" rel="stylesheet">
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery('#demo1').skdslider({ 'delay': 5000, 'animationSpeed': 2000, 'showNextPrev': true, 'showPlayButton': true, 'autoSlide': true, 'animationType': 'fading' });

        jQuery('#responsive').change(function () {
            $('#responsive_wrapper').width(jQuery(this).val());
        });

    });
</script>	
<!-- //main slider-banner --> 

</body>
</html>
