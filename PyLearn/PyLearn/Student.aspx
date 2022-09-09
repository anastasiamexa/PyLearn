<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="PyLearn.Student" %>

<!DOCTYPE html>

<html style="font-size: 16px;" lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <meta name="keywords" content="Οι συμμαθητές μου, Η πρόοδος μου, Αποτελέσματα Τεστ Αξιολόγησης">
    <meta name="description" content="">
    <title>Πρόοδος</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
<link rel="stylesheet" href="Πρόοδος.css" media="screen">
    <script class="u-script" type="text/javascript" src="jquery.js" defer=""></script>
    <script class="u-script" type="text/javascript" src="nicepage.js" defer=""></script>
    <meta name="generator" content="Nicepage 4.13.1, nicepage.com">
    <link id="u_theme_google_font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i">
    <link id="u_page_google_font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i">
    <meta name="theme-color" content="#478ac9">
    <meta property="og:title" content="Πρόοδος">
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
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-palette-3-light-1 u-text-hover-palette-4-base" href="Login.aspx" style="padding: 10px 20px;">Αποσύνδεση</a>
</li></ul>
          </div>
          <div class="u-custom-menu u-nav-container-collapse">
            <div class="u-black u-container-style u-inner-container-layout u-opacity u-opacity-95 u-sidenav">
              <div class="u-inner-container-layout u-sidenav-overflow">
                <div class="u-menu-close"></div>
                <ul class="u-align-center u-nav u-popupmenu-items u-unstyled u-nav-2"><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Home.aspx">Αρχική</a>
                    </li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="online_help.chm">Βοήθεια</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Student.aspx">Πρόοδος</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Login.aspx">Αποσύνδεση</a>
</li></ul>
              </div>
            </div>
            <div class="u-black u-menu-overlay u-opacity u-opacity-70"></div>
          </div>
        </nav>
      </div></header>
    <section class="u-align-center u-clearfix u-section-1" id="carousel_a678">
      <div class="u-clearfix u-sheet u-sheet-1">
        <h2 class="u-align-center u-text u-text-default u-text-1">Οι συμμαθητές μου</h2>
        <div class="u-table u-table-responsive u-table-1">
          <asp:Table ID="Table1" runat="server" class="u-table-entity u-table-entity-1">

            <asp:TableHeaderRow class="u-custom-font u-font-courier-new u-palette-4-base u-table-header u-table-header-1" style="height: 58px;">
                <asp:TableHeaderCell class="u-table-cell">Όνομα</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Επώνυμο</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow class="u-table-alt-palette-4-light-3 u-table-body">
              
            </asp:TableRow>
		  </asp:Table>
        </div>
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
        <div class="u-image u-image-circle u-preserve-proportions u-image-1" alt="" data-image-width="1280" data-image-height="1280"></div>
        <h5 id="usernameLabel" runat="server" class="u-align-center u-text u-text-default u-text-2">Username</h5>
      </div>
    </section>
    <section class="u-clearfix u-gradient u-section-2" id="sec-7f9e">
      <div class="u-clearfix u-sheet u-valign-middle u-sheet-1">
        <div class="u-expanded-width u-list u-list-1">
          <div class="u-repeater u-repeater-1">
            <div class="u-align-center u-container-style u-list-item u-repeater-item">
              <div class="u-container-layout u-similar-container u-valign-middle u-container-layout-1">
                <h1 id="syntaxErrorLabel" runat="server" class="u-text u-text-default u-text-palette-3-light-1 u-title u-text-1" data-animation-name="counter" data-animation-event="scroll" data-animation-duration="3000">72</h1>
                <p class="u-text u-text-2">Συντακτικά Λάθη</p>
              </div>
            </div>
            <div class="u-align-center u-container-style u-list-item u-repeater-item">
              <div class="u-container-layout u-similar-container u-valign-middle u-container-layout-2">
                <h1 id="logicalErrorLabel" runat="server" class="u-text u-text-default u-text-palette-3-light-1 u-title u-text-3" data-animation-name="counter" data-animation-event="scroll" data-animation-duration="3000">100</h1>
                <p class="u-text u-text-4">Λογικά Λάθη</p>
              </div>
            </div>
            <div class="u-align-center u-container-style u-list-item u-repeater-item">
              <div class="u-container-layout u-similar-container u-valign-middle u-container-layout-3">
                <h1 id="combErrorLabel" runat="server" class="u-text u-text-default u-text-palette-3-light-1 u-title u-text-5" data-animation-name="counter" data-animation-event="scroll" data-animation-duration="3000">87</h1>
                <p class="u-text u-text-6">Συνδιασμός Τύπου Λαθών</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="u-clearfix u-gradient u-section-3" id="carousel_2e5a">
      <div class="u-clearfix u-sheet u-valign-bottom-md u-valign-bottom-sm u-valign-bottom-xs u-sheet-1">
        <div class="u-clearfix u-expanded-width u-layout-wrap u-layout-wrap-1">
          <div class="u-layout">
            <div class="u-layout-row">
              <div class="u-align-center u-container-style u-layout-cell u-size-60 u-white u-layout-cell-1">
                <div class="u-container-layout u-container-layout-1"><span class="u-file-icon u-icon u-icon-circle u-palette-2-base u-icon-1"><img src="images/497789.png" alt=""></span>
                  <h2 class="u-custom-font u-font-montserrat u-text u-text-1"> Κεφάλαια που πρέπει να ξαναδιαβάσεις!</h2>
                  <h6 id="chapterErrors" runat="server" class="u-custom-font u-font-montserrat u-text u-text-2">Κεφάλαιο 1,2,3<br>
                  </h6>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="u-align-center u-clearfix u-section-4" id="carousel_8935">
      <div class="u-clearfix u-sheet u-sheet-1">
        <h2 class="u-align-center u-text u-text-default u-text-1">Η πρόοδος μου</h2>
        <div class="u-expanded-width u-table u-table-responsive u-table-1">
            <asp:Table ID="Table2" runat="server" class="u-table-entity u-table-entity-1">

            <asp:TableHeaderRow class="u-custom-font u-font-courier-new u-palette-4-base u-table-header u-table-header-1" style="height: 58px;">
                <asp:TableHeaderCell class="u-table-cell">Username</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Κεφάλαιο</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Δυσκολία</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Id1</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Id2</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Id3</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Id4</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Id5</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans1</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans2</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans3</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans4</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans5</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow class="u-table-alt-palette-4-light-3 u-table-body">
              
            </asp:TableRow>
		  </asp:Table>
        </div>
      </div>
    </section>
    <section class="u-align-center u-clearfix u-section-5" id="carousel_ab04">
      <div class="u-clearfix u-sheet u-sheet-1">
        <h2 class="u-align-center u-text u-text-default u-text-1">Αποτελέσματα Τεστ Αξιολόγησης</h2>
        <div class="u-table u-table-responsive u-table-1">
            <asp:Table ID="Table3" runat="server" class="u-table-entity u-table-entity-1">

            <asp:TableHeaderRow class="u-custom-font u-font-courier-new u-palette-4-base u-table-header u-table-header-1" style="height: 58px;">
                <asp:TableHeaderCell class="u-table-cell">Username</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ημερομηνία</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans1</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans2</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans3</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans4</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans5</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans6</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans7</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans8</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans9</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans10</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans11</asp:TableHeaderCell>
                <asp:TableHeaderCell class="u-table-cell">Ans12</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow class="u-table-alt-palette-4-light-3 u-table-body">
              
            </asp:TableRow>
		  </asp:Table>
        </div>
      </div>
    </section>
    
    
    <footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-0eea"><div class="u-clearfix u-sheet u-sheet-1">
        <p class="u-small-text u-text u-text-variant u-text-1">PyLearn 2022<span style="font-size: 1rem;"></span>℠
        </p>
      </div></footer>
</body></html>
