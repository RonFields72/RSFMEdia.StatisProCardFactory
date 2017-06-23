<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RSFMEdia.StatisProCardFactory.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHEAD" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="jumbotron">
        <img alt="boxArt" src="images/statispro.jpg" />
        <h2>Statis-Pro Card Factory</h2>
        <span class="text-muted spcf-font-90">Complete the data inputs below and click Upload to process the player/pitcher/fielding data necessary to create cards.</span>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Literal ID="litMessage" runat="server" Text=""></asp:Literal>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">League Information</div>
        <div class="panel-body">
            <div class="row row-buffer">
                <div class="col-md-1">
                    Year:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlYear" runat="server" Width="100px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row row-buffer">
                <div class="col-md-1">
                    League:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlLeague" runat="server" Width="100px">
                        <asp:ListItem Text="AL" Value="AL"></asp:ListItem>
                        <asp:ListItem Text="NL" Value="NL"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">Team Information</div>
        <div class="panel-body">
            <div class="row row-buffer">
                <div class="col-md-1">
                    Team:
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlTeam" runat="server" Width="250px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row row-buffer">
                <div class="col-md-1">
                    Manager:
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="tbManager" runat="server" Text="" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvManager" runat="server" ControlToValidate="tbManager" ErrorMessage="* required" Font-Italic="true" CssClass="spcf-error-text"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row row-buffer">
                <div class="col-md-1">Wins:</div>
                <div class="col-md-6">
                    <asp:TextBox ID="tbWins" runat="server" Text="" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvWins" runat="server" ControlToValidate="tbWins" ErrorMessage="* required" Font-Italic="true" CssClass="spcf-error-text"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvWins" runat="server" ControlToValidate="tbWins" MinimumValue="0" MaximumValue="162" Type="Integer" ErrorMessage="* valid values 0 to 162" Font-Italic="true"></asp:RangeValidator>
                </div>
            </div>
            <div class="row row-buffer">
                <div class="col-md-1">Losses:</div>
                <div class="col-md-6">
                    <asp:TextBox ID="tbLosses" runat="server" Text="" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLosses" runat="server" ControlToValidate="tbLosses" ErrorMessage="* required" Font-Italic="true" CssClass="spcf-error-text"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvLosses" runat="server" ControlToValidate="tbLosses" MinimumValue="0" MaximumValue="162" Type="Integer" ErrorMessage="* valid values 0 to 162" Font-Italic="true"></asp:RangeValidator>
                </div>
            </div>
        </div>
    </div>
    
    <div class="panel panel-default">
        <div class="panel-heading">Card Processing Configuration</div>
        <div class="panel-body">
            <label for="tbMinimumAB">Minimum # of ABs</label>
            <asp:TextBox ID="tbMinimumAB" runat="server">Minimum # of AB</asp:TextBox>
            <asp:RangeValidator ID="rvMinimumAB" runat="server" ControlToValidate="tbMinimumAB" MinimumValue="1" MaximumValue="999" Type="Integer" ErrorMessage="* valid values begin at 1" Font-Italic="true"></asp:RangeValidator>
            <br />
            <label for="tbMinimumIP">Minimum # of IP</label>
            <asp:TextBox ID="tbMinimumIP" runat="server">Minimum # of IP</asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbMinimumIP" MinimumValue="1" MaximumValue="999" Type="Integer" ErrorMessage="* valid values begin at 1" Font-Italic="true"></asp:RangeValidator>
            <br />
            <asp:CheckBox ID="cbUseUBR" runat="server" />&nbsp;Use UBR to determine OBR Rating (if provided)
            <br />
            <asp:CheckBox ID="cbUseUZR" runat="server" />&nbsp;Use UZR to determine fielding rating (if provided)
            <br />
            <asp:CheckBox ID="cbUseTZ" runat="server" />&nbsp;Use TZ to determine fielding rating (if provided)
        </div>
    </div>
    
    <div class="panel panel-default">
        <div class="panel-heading">File Uploads</div>
        <div class="panel-body">
            Upload Batting Data File <span class="spcf-info-text">(.csv format)</span>:
            <asp:FileUpload ID="fuBatting" runat="server" AllowMultiple="false" Width="400px" />
            <asp:RegularExpressionValidator
                ID="revBatting"
                runat="server"
                ErrorMessage="* file must must be a .csv"
                Font-Italic="true"
                CssClass="spcf-error-text"
                ValidationExpression="^.+(.csv|.CSV)$"
                ControlToValidate="fuBatting"> 
            </asp:RegularExpressionValidator>
            <br />
            Upload Fielding Data File <span class="spcf-info-text">(.csv format)</span>:
            <asp:FileUpload ID="fuFielding" runat="server" AllowMultiple="false" Width="400px" />
            <asp:RegularExpressionValidator
                ID="revFielding"
                runat="server"
                ErrorMessage="* file must must be a .csv"
                Font-Italic="true"
                CssClass="spcf-error-text"
                ValidationExpression="^.+(.csv|.CSV)$"
                ControlToValidate="fuFielding"> 
            </asp:RegularExpressionValidator>
            <br />
            Upload Pitching Data File <span class="spcf-info-text">(.csv format)</span>:
            <asp:FileUpload ID="fuPitching" runat="server" AllowMultiple="false" Width="400px" />
            <asp:RegularExpressionValidator
                ID="revPitching"
                runat="server"
                ErrorMessage="* file must must be a .csv"
                Font-Italic="true"
                CssClass="spcf-error-text"
                ValidationExpression="^.+(.csv|.CSV)$"
                ControlToValidate="fuPitching"> 
            </asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload Data" CssClass="btn btn-default" OnClick="btnUpload_Click" />
    <div id="testArea">
        <asp:Button ID="btnTest" runat="server" Text="Test Stuff" CssClass="btn btn-info" OnClick="btnTest_Click" CausesValidation="false" />
        <asp:Label ID="lblTestDisplay1" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblTestDisplay2" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblTestDisplay3" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblTestDisplay4" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
