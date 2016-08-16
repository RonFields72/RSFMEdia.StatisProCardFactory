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
            <asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                <asp:ListItem Text="2003" Value="2003"></asp:ListItem>
                <asp:ListItem Text="2002" Value="2002"></asp:ListItem>
                <asp:ListItem Text="2001" Value="2001"></asp:ListItem>
                <asp:ListItem Text="2000" Value="2000"></asp:ListItem>
                <asp:ListItem Text="1999" Value="1999"></asp:ListItem>
                <asp:ListItem Text="1998" Value="1998"></asp:ListItem>
                <asp:ListItem Text="1997" Value="1997"></asp:ListItem>
                <asp:ListItem Text="1996" Value="1996"></asp:ListItem>
                <asp:ListItem Text="1995" Value="1995"></asp:ListItem>
                <asp:ListItem Text="1994" Value="1994"></asp:ListItem>
                <asp:ListItem Text="1993" Value="1993"></asp:ListItem>
                <asp:ListItem Text="1992" Value="1992"></asp:ListItem>
                <asp:ListItem Text="1991" Value="1991"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row row-buffer">
        <div class="col-md-1">
            League:
        </div>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlLeague" runat="server">
                <asp:ListItem Text="AL" Value="AL"></asp:ListItem>
                <asp:ListItem Text="NL" Value="NL"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row row-buffer">
        <div class="col-md-1">
            Team:
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlTeam" runat="server">
                <asp:ListItem Text="Arizona Diamondbacks" Value="Arizona Diamondbacks"></asp:ListItem>
                <asp:ListItem Text="Atlanta Braves" Value="Atlanta Braves"></asp:ListItem>
                <asp:ListItem Text="Baltimore Orioles" Value="Baltimore Orioles"></asp:ListItem>
                <asp:ListItem Text="Boston Red Sox" Value="Boston Red Sox"></asp:ListItem>
            </asp:DropDownList>    
        </div>
    </div>
    <div class="row row-buffer">
        <div class="col-md-6">
            Wins: 
            <asp:TextBox ID="tbWins" runat="server" Text="" Width="35px"></asp:TextBox>
            Losses:
            <asp:TextBox ID="tbLosses" runat="server" Text="" Width="35px"></asp:TextBox>
        </div>
        
    </div>
    <hr />
    Upload Player Data File <span class="red-highlight">(.csv format)</span>:
    <asp:FileUpload ID="fuPlayers" runat="server" AllowMultiple="false" Width="50%" />
    <br />
    Upload Pitcher Data File <span class="red-highlight">(.csv format)</span>:
    <asp:FileUpload ID="fuPitchers" runat="server" AllowMultiple="false" Width="50%" />

    <div class="row row-buffer">
        <div class="col-md-6">
        </div>
    </div>
</asp:Content>
