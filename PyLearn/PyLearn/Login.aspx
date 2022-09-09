<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PyLearn.Login" %>

<!DOCTYPE html>

<html style="font-size: 16px;" lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <meta name="keywords" content="​Library Education, ​Meet our Principal, ​Helping each child find and follow their best learning path.">
    <meta name="description" content="">
    <title>Σύνδεση</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
<link rel="stylesheet" href="Login.css" media="screen">
    <script class="u-script" type="text/javascript" src="jquery.js" defer=""></script>
    <script class="u-script" type="text/javascript" src="nicepage.js" defer=""></script>
    <meta name="generator" content="Nicepage 4.13.1, nicepage.com">
    <link id="u_theme_google_font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i">
    <link id="u_page_google_font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i">
    <meta name="theme-color" content="#478ac9">
    <meta property="og:title" content="Σύνδεση">
    <meta property="og:type" content="website">
</head>
<body class="u-body u-xl-mode"><header class="u-clearfix u-header u-header" id="sec-9813"><div class="u-clearfix u-sheet u-sheet-1">
        <a href="Home.aspx" class="u-image u-logo u-image-1" data-image-width="503" data-image-height="164">
          <img src="images/pylearn_logo.png" class="u-logo-image u-logo-image-1">
        </a>
        <nav class="u-menu u-menu-dropdown u-offcanvas u-menu-1">
          <div class="menu-collapse" style="font-size: 1rem; letter-spacing: 0px;">
            <a class="u-button-style u-custom-left-right-menu-spacing u-custom-padding-bottom u-custom-text-active-color u-custom-text-hover-color u-custom-top-bottom-menu-spacing u-nav-link u-text-active-palette-1-base u-text-hover-palette-2-base" href="#">
              <svg class="u-svg-link" viewBox="0 0 24 24"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#menu-hamburger"></use></svg>
              <svg class="u-svg-content" version="1.1" id="menu-hamburger" viewBox="0 0 16 16" x="0px" y="0px" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns="http://www.w3.org/2000/svg"><g><rect y="1" width="16" height="2"></rect><rect y="7" width="16" height="2"></rect><rect y="13" width="16" height="2"></rect>
</g></svg>
            </a>
          </div>
          <div class="u-custom-menu u-nav-container">
            <ul class="u-nav u-spacing-60 u-unstyled u-nav-1"><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-palette-3-light-1 u-text-hover-palette-4-base" href="Home.aspx" style="padding: 10px 20px;">Αρχική</a>
                </li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-palette-3-light-1 u-text-hover-palette-4-base" href="online_help.chm" style="padding: 10px 20px;">Βοήθεια</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-palette-3-light-1 u-text-hover-palette-4-base" href="Student.aspx" style="padding: 10px 20px;">Πρόοδος</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-palette-3-light-1 u-text-hover-palette-4-base" href="Login.aspx" style="padding: 10px 20px;">Σύνδεση</a>
</li></ul>
          </div>
          <div class="u-custom-menu u-nav-container-collapse">
            <div class="u-black u-container-style u-inner-container-layout u-opacity u-opacity-95 u-sidenav">
              <div class="u-inner-container-layout u-sidenav-overflow">
                <div class="u-menu-close"></div>
                <ul class="u-align-center u-nav u-popupmenu-items u-unstyled u-nav-2"><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Home.aspx">Αρχική</a>
                    </li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="online_help.chm">Βοήθεια</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Student.aspx">Πρόοδος</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Login.aspx">Σύνδεση</a>
</li></ul>
              </div>
            </div>
            <div class="u-black u-menu-overlay u-opacity u-opacity-70"></div>
          </div>
        </nav>
      </div></header>

    <section class="u-clearfix u-image u-section-1" id="carousel_e379" data-image-width="1600" data-image-height="1067">
	  <div class="u-clearfix u-sheet u-valign-middle-sm u-sheet-1" style="left: 284px; top: 22px">
		<div class="u-container-style u-group u-white u-group-1">
		  <div class="u-container-layout u-container-layout-1">
			<h2 class="u-align-center u-custom-font u-font-oswald u-text u-text-1">Log in</h2>
			<div class="u-form u-form-1"><!--class="u-clearfix u-form-spacing-30 u-form-vertical u-inner-form"-->
			  <form action="#" method="POST" style="padding: 0;" source="custom" id="form1"  runat="server">
								 <div class="u-form-group u-form-name u-form-group-1"><br />
				  <label for="name-d70e" class="u-label u-label-1">Username</label><br />
				  <asp:TextBox placeholder="Enter your Username" ID="Username" name="name" class="u-border-1 u-border-grey-75 u-input u-input-rectangle u-white" required runat="server"></asp:TextBox>
				</div>
				<div class="u-form-group u-form-group-2"><br />
				  <label for="text-28cb" class="u-label u-label-2">Password</label><br />
				  <asp:TextBox  type="password" placeholder="Enter your Password" ID="Password" name="pas" class="u-border-1 u-border-grey-75 u-input u-input-rectangle u-white" required runat="server"></asp:TextBox>
				</div>
				<div class="u-align-left u-form-group u-form-submit u-form-group-3"><br />
				  <a href="/Test.aspx" class="u-border-1 u-border-black u-btn u-btn-submit u-button-style u-hover-black u-none u-text-black u-text-hover-white u-btn-1">Submit</a>
				  <asp:Button id="LogInButton" class="u-form-control-hidden" Text="Submit" onClick="LogInButton_Click" runat="server"  />
				</div>
			  </form>
			</div>
		  </div>
		</div>
	  </div>
	</section>

<footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-0eea"><div class="u-clearfix u-sheet u-sheet-1">
        <p class="u-small-text u-text u-text-variant u-text-1">PyLearn 2022<span style="font-size: 1rem;"></span>℠
        </p>
      </div></footer>
</body>
</html>
