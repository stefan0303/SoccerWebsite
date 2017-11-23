<%@ Page Title="Search Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SearchData.aspx.cs" Inherits="SearchData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row-sm-5">
            <h5>Select Competition:</h5>
            <div class="row-sm-3">
                <asp:DropDownList ID="DropDownListCompetitions" OnSelectedIndexChanged="DropDownList_SelectedIndexChaged" runat="server" AutoPostBack="True" DataValueField="name" name="competitions" Width="100px">
                </asp:DropDownList>
            </div>
         <%--   <div>
                <table class="table" style="width: 50%">
                    <tr>
                        <th>Posssition</th>
                        <th>Team</th>
                        <th>Wins</th>
                        <th>Draws</th>
                        <th>Loses</th>
                        <th>Goal Difference</th>
                        <th>Points</th>
                    </tr>
                    <%=getWhileLoopData()%>
               

                </table>
            </div>--%>
            
                <table>
                    <tr style="background-color: #004080; color: White;">
                       <th>Posssition</th>
                        <th>Team</th>                       
                        <th>Wins</th>
                        <th>Draws</th>
                        <th>Loses</th>
                        <th>Goal Difference</th>
                        <th>Points</th>
                    </tr>
                    <%=getWhileLoopData()%>
                </table>


        </div>
    </div>
</asp:Content>
