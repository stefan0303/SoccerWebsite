<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Games.aspx.cs" Inherits="Games" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row-sm-3">
            <h5>Select Competition</h5>
            <asp:DropDownList ID="DropDownListCompetitions" onselectedindexchanged="DropDownList_SelectedIndexChaged" runat="server" AutoPostBack="True" DataValueField="name"  name="competitions"  Width="100px">
            </asp:DropDownList>
          
        </div>
        <div class="row-sm-5">
            <h5>Home Team:</h5>
            <asp:DropDownList ID="DropDownListHomeTeam" name="homeTeam" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
        <div class="row-sm-4">
            <h5>Away Team</h5>
            <asp:DropDownList ID="DropDownListAwayTeam" name="awayTeam" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
        <div class="row-sm-4">
            <h5>Home Team Goals</h5>
            <asp:DropDownList ID="DropDownListHomeTeamGoals" name="homeTeamGoals" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
        <div class="row-sm-4">
            <h5>Away Team Goals</h5>
            <asp:DropDownList ID="DropDownListAwayTeamGoals" name="awayTeamGoals" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
        <div class="row-sm-4">
            <h5>Date of Game</h5>
        <asp:Label ID="LblDob" runat="server" Text='<%# Bind("DateofBirth") %>'></asp:Label>
        <asp:TextBox ID="TxtDob" runat="server" Text='<%# Bind("DateofBirth") %>' TextMode="Date"></asp:TextBox>
            
        </div>
         <input type="submit" name="submitGames" value="Submit" />
          <%=DateTime.Now.Date.ToString()%>
    </div>

</asp:Content>
