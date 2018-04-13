<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Games.aspx.cs" EnableEventValidation="false" Inherits="Games" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script id=" ">
        $(document).ready(function () {
            $('#MainContent_DropDownListCompetitions').change(function (event) {
          
        
                let $selectedCompetition = $(this).val();
                //Remove all From dropDown Teams
                //There is bug In Competitions !!! When we select two different competitions we have all teams of them in dropDown Teams
                //$('#MainContent_DropDownListHomeTeam').empty();
                //$('#MainContent_DropDownListAwayTeam').empty();
                if ($selectedCompetition != '') {
                    

                    $('#MainContent_DropDownListHomeTeam').prop('disabled', false);
                    $('#MainContent_DropDownListAwayTeam').prop('disabled', false);
                    TeamsDropDown($selectedCompetition);
                }             
       
                return false;
            });

            $('#MainContent_DropDownListAwayTeam').change(function () {
                let $selectedTeam = $(this).val();
                if ($selectedTeam != '') {
                    $('#MainContent_DropDownListHomeTeam option').prop('disabled', false)
                    $('#MainContent_DropDownListHomeTeam option[value="' + $selectedTeam + '"]').prop('disabled', true);
                }
            })

            $('#MainContent_DropDownListHomeTeam').change(function () {
                let $selectedTeam = $(this).val();
                if ($selectedTeam != '') {
                    $('#MainContent_DropDownListAwayTeam option').prop('disabled', false)
                    $('#MainContent_DropDownListAwayTeam option[value="' + $selectedTeam + '"]').prop('disabled', true);
                }
            })
            //OnClick SubmitButton
            $('#submit').click(function () {
                let $selectedCompetition = $('#MainContent_DropDownListCompetitions').val();
                let $homeTeam = $('#MainContent_DropDownListHomeTeam').val();
                let $awayTeam = $('#MainContent_DropDownListAwayTeam').val();
                let $data = $('#MainContent_TxtDob').val();
                if ($selectedCompetition == '') {
                    alert('Select Competition!')
                }
                else if ($homeTeam == '') {
                    alert('Select Home Team!')
                }
                else if ($awayTeam == '') {
                    alert('Select Away Team!')
                }
                else if ($data == '') {
                    alert('Select Data!')
                }
                else
                {
                    let $homeTeamGoals = $('#MainContent_DropDownListHomeTeamGoals').val();
                    let $awayTeamGoals = $('#MainContent_DropDownListAwayTeamGoals').val();

                    $.ajax({
                        type: "POST",
                        url: "/Games.aspx/AddGameToData",
                        data: JSON.stringify({
                            competition: $selectedCompetition, homeTeam: $homeTeam, awayTeam: $awayTeam,
                            homeTeamGoals: $homeTeamGoals, awayTeamGoals: $awayTeamGoals, dateOfGame: $data
                        }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (responce) {
                            alert('The game is add to the Data!')

                        }
                        ,
                        failure: function (response) {
                            alert('There is problem with Game!')
                        }
                    })
       
                }

               
                return false;
            })
        });
      

        function TeamsDropDown(competitionUi) {
            $.ajax({
                type: "POST",
                url: "/Games.aspx/TeamsFromSelectedCompetition",
                data: JSON.stringify({ competitionUi: competitionUi }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (responce, status, data) { 
                    
                    let responceFromServer = responce.d;


                    $('#MainContent_DropDownListHomeTeam').append(responce.d)
                    $('#MainContent_DropDownListAwayTeam').append(responce.d)
                }
                ,
                failure: function (response) {
                    alert('There is problem with Team!')
                }

            })
        }
    </script>

        

    <div class="container">
        <div class="row-sm-3">
            <h5>Select Competition</h5>
          <%--  AutoPostBack="True"--%>
            <asp:DropDownList ID="DropDownListCompetitions" onselectedindexchanged="DropDownList_SelectedIndexChaged" runat="server"  DataValueField="name"  name="competitions"  Width="100px">

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
         <input type="submit" id="submit" name="submitGame" value="Submit" />
          <%=DateTime.Now.Date.ToString()%>
    </div>

</asp:Content>
