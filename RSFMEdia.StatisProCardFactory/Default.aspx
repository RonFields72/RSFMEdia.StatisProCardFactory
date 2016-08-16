<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSFMEdia.StatisProCardFactory._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Statis-Pro Card Factory</h2>
        <p class="lead">Complete the data inputs below and click create to generate the player/pitcher cards.</p>
    </div>

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
    <br />
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
                    <asp:RequiredFieldValidator ID="rfvManager" runat="server" ControlToValidate="tbManager" ErrorMessage="* required" Font-Italic="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row row-buffer">
                <div class="col-md-1">Wins:</div>
                <div class="col-md-6">
                    <asp:TextBox ID="tbWins" runat="server" Text="" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvWins" runat="server" ControlToValidate="tbWins" ErrorMessage="* required" Font-Italic="true"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvWins" runat="server" ControlToValidate="tbWins" MinimumValue="0" MaximumValue="162" Type="Integer" ErrorMessage="* valid values 0 to 162" Font-Italic="true"></asp:RangeValidator>
                </div>
            </div>
            <div class="row row-buffer">
                <div class="col-md-1">Losses:</div>
                <div class="col-md-6">
                    <asp:TextBox ID="tbLosses" runat="server" Text="" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLosses" runat="server" ControlToValidate="tbLosses" ErrorMessage="* required" Font-Italic="true"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvLosses" runat="server" ControlToValidate="tbLosses" MinimumValue="0" MaximumValue="162" Type="Integer" ErrorMessage="* valid values 0 to 162" Font-Italic="true"></asp:RangeValidator>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">File Uploads</div>
        <div class="panel-body">
            Upload Batting Data File <span class="red-highlight">(.csv format)</span>:
            <asp:FileUpload ID="fuBatting" runat="server" AllowMultiple="false" Width="50%" />
            <br />
            Upload Pitching Data File <span class="red-highlight">(.csv format)</span>:
            <asp:FileUpload ID="fuPitching" runat="server" AllowMultiple="false" Width="50%" />
            <br />
            Upload Fielding Data File <span class="red-highlight">(.csv format)</span>:
             <asp:FileUpload ID="fuFielding" runat="server" AllowMultiple="false" Width="50%" />
        </div>
    </div>
    <br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload Data" CssClass="btn btn-default" />

    <div class="row row-buffer">
        <div class="col-md-6">
        </div>
    </div>
</asp:Content>
