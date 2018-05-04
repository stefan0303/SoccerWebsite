<%@ Page Title="Import Teams" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ImportTeams.aspx.cs" Inherits="ImportTeams" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function ImportTeam(e) {
            let teamName = $('#team').val();
            let competitionName = $('#MainContent_DropDownCompetitions').val()
            let townName = $('#MainContent_DropDownTowns').val();
            let primaryKitColour = $('#MainContent_DropDownListPrimaryKitColour').val();
            let secondaryKitColour = $('#MainContent_DropDownListSecondaryKitColour').val();

            $.ajax({
                type: "POST",
                url: "/ImportTeams.aspx/ImportTeam",
                data: JSON.stringify({
                    teamName: teamName, competitionName: competitionName
                    , townName: townName, primaryKitColour: primaryKitColour,
                    secondaryKitColour: secondaryKitColour
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (responce) {
                    let responceFromServer = responce.d;
                    alert(responceFromServer);
                }
                ,
                failure: function (response) {
                    alert('There is problem with Team!');
                }

            })

            $('#team').val('');
            return false;
        }
        $(document).ready(function () {
            $('#MainContent_importTeamID').click(ImportTeam);

        });

    </script>
    <link href="CSS/Default.css" rel="stylesheet" runat="server"/>
    <link href="CSS/ImportTeams.css" rel="stylesheet" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h5>Select Competition:</h5>
                <asp:DropDownList ID="DropDownCompetitions" name="competitionName" CssClass="textbox" runat="server" Width="100px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h5>Select Town:</h5>
                <asp:DropDownList ID="DropDownTowns" name="townName" CssClass="textbox" runat="server" Width="100px">
                </asp:DropDownList>
            </div>
        </div>
       
        <div class="row">
            <div class="col-xs-12">
                <h5>Team Primary Kit Colour:</h5>
                <asp:DropDownList ID="DropDownListPrimaryKitColour" name="primaryColour" runat="server" CssClass="textbox" Width="100px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h5>Team Secondary Kit Colour</h5>
                <asp:DropDownList ID="DropDownListSecondaryKitColour" CssClass="textbox" name="secondaryColour" runat="server" Width="100px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h5>Team Name:</h5>
                <input type="text" name="team" id="team" class="textbox" placeholder="Type Team Name" />
                <asp:Button ID="importTeamID" class="btn btn-primary" runat="server"  Text="Import Team" />
            </div>
        </div>
    </div>
</asp:Content>
