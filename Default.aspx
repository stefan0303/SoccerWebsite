<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>

        $(document).ready(function () {
            //Drop Down Menu Countries
            dropDownCompetititons();
            function dropDownCompetititons(e) {

                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/DropDownCountries",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        let select = $("#MainContent_DropDownCountry");
                        select.children().remove();
                        if (data.d) {
                            $(data.d).each(function (index, item) {
                                select.append('<option val="' + item.Text + '">' + item.Text + '</option>');
                            });
                        }
                    },
                    failure: function () {
                        alert("Failed!");
                    }
                });
            }

            function addCompetition(e) {

                //To prevent postback from happening as we are ASP.Net TextBox control
                //If we had used input html element, there is no need to use ' e.preventDefault()' as posback will not happen
                //WORKING
                e.preventDefault();

                let textCompetition = $('#MainContent_inputCompetition').val();
                let comp = $("#<%=inputCompetition.ClientID%>").val();


                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/Competition",
                    data: '{competitionName: "' + $("#<%=inputCompetition.ClientID%>").val() + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (responce) {
                        let responceFromServer = responce.d;
                        alert(responceFromServer);

                        $('#MainContent_inputCompetition').val('');
                    }
                    ,
                    failure: function (response) {
                        alert('There is problem with competition!');
                    }
                });

            }

            $('#MainContent_competitionID').click(addCompetition);
            function addCountry() {
                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/Country",
                    //data: '{countryName: "' + $("#<%=inputCountry.ClientID%>").val() + '" }',
                    data: JSON.stringify({ countryName: $("#<%=inputCountry.ClientID%>").val() }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (responce) {

                        let responceFromServer = responce.d;
                        alert(responceFromServer);
                        dropDownCompetititons();
                        $('#MainContent_inputCountry').val('');
                    }
                    ,
                    failure: function (response) {
                        alert('There is problem with country!');
                    }
                });
                return false;
            }
            $('#MainContent_countryId').click(addCountry);

            function addTown() {

                let townName = $("#<%=textBoxTownID.ClientID%>").val();
                let country = $("#<%=DropDownCountry.ClientID%>").val();
                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/Town",
                    data: JSON.stringify({ townName: townName, countryName: country }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (responce) {
                        alert(responce.d);
                        $('#MainContent_textBoxTownID').val('');
                    },
                    failure: function (responce) {
                        alert('There is problem with Town!');
                    }
                })

                return false;
            }
            $('#MainContent_townId').click(addTown);

        });

    </script>


    <link href="CSS/Default.css" rel="stylesheet" />
    <div class="container siteContainer">
        <div class="form-group row">
            <div class="col-md-2"></div>
            <label class="col-xs-12 col-md-2 col-form-label" for="MainContent_inputCompetition">Import Competition:</label>
            <div class="col-xs-12 col-md-6 text-left inline-input">
                <asp:TextBox ID="inputCompetition" CssClass="form-control" placeholder="Competition name" runat="server"></asp:TextBox>
                <asp:Button ID="competitionID" class="btn btn-primary" runat="server" Text="Submit Competition" />
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <h5>Import Country:</h5>
            <asp:TextBox ID="inputCountry" CssClass="textbox" placeholder="Country name" runat="server"></asp:TextBox>
            <asp:Button ID="countryId" class="btn btn-primary" runat="server" Text="Submit Country" />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12" id="list">
            <h5>Select Country from list:</h5>
            <asp:DropDownList ID="DropDownCountry" CssClass="textbox" name="countryInput" runat="server" Width="100px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <h5>Import Town:</h5>
            <asp:TextBox ID="textBoxTownID" CssClass="textbox" placeholder="Town name" runat="server"></asp:TextBox>
            <asp:Button ID="townId" class="btn btn-primary" runat="server" Text="Submit Town" />
        </div>
    </div>

    </div>


</asp:Content>

