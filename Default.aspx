<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Default.aspx.cs" Inherits="_Default"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
      

        //EnableEventValidation="false"!!! is this Ok
        $(document).ready(function () {
            //Drop Down Menu Countries
            //WORKING
            dropDownCompetititons();
            function dropDownCompetititons(e) {

                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/DropDownCountries",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        let responce = data.d;
                        // $("#MainContent_DropDownCountry option").remove();
                        let select = $("#MainContent_DropDownCountry");
                        select.children().remove();
                        if (data.d) {
                            $(data.d).each(function (index, item) {
                                select.append('<option val="' + item.Text + '">' + item.Text + '</option>');
                                //select.append($("<option>").val(item.Value).text(item.Text));
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
                         alert('There is problem with competition!')
                     }
                 });

             }
                
            $('#MainContent_competitionID').click(addCompetition);
            function addCountry() {
                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/Country",
                    //data: '{countryName: "' + $("#<%=inputCountry.ClientID%>").val() + '" }',
                    data: JSON.stringify({countryName: $("#<%=inputCountry.ClientID%>").val()}),
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
                         alert('There is problem with country!')
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
                    data: JSON.stringify({ townName: townName, countryName:country }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (responce) {
                        alert(responce.d);
                        $('#MainContent_textBoxTownID').val('');
                    },
                    failure: function (responce) {
                        alert('There is problem with Town!')
                    }
                })
                
                return false;
            }
            $('#MainContent_townId').click(addTown);

        });

    </script>
  
    <div class="data">

        <div class="row-sm-4">
            <h5>Import Competition:</h5>
            <asp:TextBox ID="inputCompetition" runat="server"></asp:TextBox>
            <asp:Button ID="competitionID" class="btn btn-primary" runat="server" Text="Submit Competition" />
        </div>
        <div class="row-sm-4">
            <h5>Import Country:</h5>
             <asp:TextBox ID="inputCountry" runat="server"></asp:TextBox>

            <asp:Button ID="countryId" class="btn btn-primary" runat="server" Text="Submit Country"/>
        </div>
        <div class="row-sm-4">
            <h5>Import Town:</h5>
            <h6>Select Country from list:</h6>
            <asp:DropDownList ID="DropDownCountry" name="countryInput" runat="server" Width="100px">
            </asp:DropDownList>

            <asp:TextBox ID="textBoxTownID" runat="server"></asp:TextBox>
            <asp:Button ID="townId" class="btn btn-primary" runat="server" Text="Submit Town"/>
        </div>

    </div>
   
</asp:Content>

