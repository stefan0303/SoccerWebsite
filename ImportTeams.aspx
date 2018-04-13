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
                    alert('There is problem with Team!')
                }

            })

            $('#team').val('');
            return false;
        }
        $(document).ready(function () {
            $('#MainContent_importTeamID').click(ImportTeam);

        });

    </script>
    <div class="container">
        <div class="row-sm-5">
            <h5>Select Competition:</h5>
            <div class="div">
                <asp:DropDownList ID="DropDownCompetitions" name="competitionName" runat="server" Width="100px">
                </asp:DropDownList>
            </div>
            <h5>Select Town:</h5>
            <div class="div">
                <asp:DropDownList ID="DropDownTowns" name="townName" runat="server" Width="100px">
                </asp:DropDownList>
            </div>

        </div>
        <div class="row-sm-4">
            <h5>Team Primary Kit Colour:</h5>
            <asp:DropDownList ID="DropDownListPrimaryKitColour" name="primaryColour" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
        <div class="row-sm-4">
            <h5>Team Secondary Kit Colour</h5>
            <asp:DropDownList ID="DropDownListSecondaryKitColour" name="secondaryColour" runat="server" Width="100px">
            </asp:DropDownList>

        </div>
        <div class="row-sm-3">
            <h5>Team Name:</h5>
            <input type="text" name="team" id="team" placeholder="Type Team Name" />
        </div>
        <div>

            <asp:Button ID="importTeamID" class="btn btn-primary" runat="server" Text="Import Team" />
        </div>

    </div>

    <div class="row">
    </div>
</asp:Content>
