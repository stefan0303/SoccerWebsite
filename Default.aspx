<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $('#MainContent_competitionId').click(function () {
                let input = $('#inputCompetition').val();

                console.log(input);

                $.ajax({
                    url: 'default.aspx',
                    data: { 'ajax_call': 'true', 'input': $('#inputCompetition').val()},
                    complete: function (data) {
                        console.log(data);
                    }
                });

                return false;
            });

        });
    </script>
    <div class="data">

        <div class="row-sm-4">
            <h5>Import Competition:</h5>
            <input type="text" name="competition" id="inputCompetition" placeholder="Type Competition Name" />

            <asp:Button ID="competitionId" class="btn btn-primary" runat="server" Text="Submit Competition" OnClick="OnClick_Competition" />

        </div>
        <div class="row-sm-4">
            <h5>Import Country:</h5>
            <input type="text" name="country" id="country" placeholder="Type Country Name" />

            <asp:Button ID="countryId" class="btn btn-primary" runat="server" Text="Submit Country" OnClick="OnClick_Country" />
        </div>
        <div class="row-sm-4">
            <h5>Import Town:</h5>
            <h6>Select Country from list:</h6>
            <asp:DropDownList ID="DropDownCountry" name="countryInput" runat="server" Width="100px">
            </asp:DropDownList>

            <input type="text" name="town" id="inputTown" placeholder="Type Town Name" />
            <asp:Button ID="townId" class="btn btn-primary" runat="server" Text="Submit Town" OnClick="OnClick_Town" />
        </div>

    </div>

</asp:Content>

