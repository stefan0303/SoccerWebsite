<%@ Page Title="Search Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SearchData.aspx.cs" Inherits="SearchData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#MainContent_DropDownListCompetitions').change(function () {
                let $selectedCompetition = $(this).val();

                if ($selectedCompetition != '') {
                    $.ajax({
                        type: "POST",
                        url: "/SearchData.aspx/getWhileLoopData",
                        data: JSON.stringify({ competitionUi: $selectedCompetition }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (responce) {
                            let html = responce.d;

                            $('.container td').remove();
                            $('.container table').append(html);

                        },
                        failure: function (response) {
                            alert('There is problem with Table!');
                        }
                    });
                }
                return false;
            });
        })

    </script>

    <link href="CSS/Default.css" rel="stylesheet" />
    <link href="CSS/SearchData.css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h5>Select Competition:</h5>
                <asp:DropDownList ID="DropDownListCompetitions" CssClass="textbox" runat="server" DataValueField="name" name="competitions" Width="150px">
                </asp:DropDownList>
                <table>
                    <tr class="table" style="background-color: #004080; color: White;">
                        <th>Posssition</th>
                        <th>Team</th>
                        <th>Wins</th>
                        <th>Draws</th>
                        <th>Loses</th>
                        <th>Goal Difference</th>
                        <th>Points</th>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
