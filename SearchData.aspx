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

                        }
                        ,
                        failure: function (response) {
                            alert('There is problem with Table!')
                        }
                    })
                }
                return false;
            })
        })

    </script>

    <div class="container">
        <div class="row-sm-5">
            <h5 id:"test">Select Competition:</h5>
            <div class="row-sm-3">
                <asp:DropDownList ID="DropDownListCompetitions"  runat="server" DataValueField="name" name="competitions" Width="100px">
                </asp:DropDownList>
            </div>
       
                <table>
                    <tr id:"table" style="background-color: #004080; color: White;">
                       <th id:"possition">Posssition</th>
                        <th>Team</th>                       
                        <th>Wins</th>
                        <th>Draws</th>
                        <th>Loses</th>
                        <th>Goal Difference</th>
                        <th>Points</th>
                    </tr>
                   
               <%-- <%=getWhileLoopData()%>--%>
                </table>


        </div>
    </div>
</asp:Content>
