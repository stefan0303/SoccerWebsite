<%@ Page Title="Import Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ImportData.aspx.cs" Inherits="ImportData" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row-sm-3">
            <h5>Import Colour:</h5>
            <select name="colours">
                <option value="red">Red</option>
                <option value="blue">Blue</option>
                <option value="green">Green</option>
                <option value="yellow">Yellow</option>
            </select>
            <input type="submit" value="Submit">
        </div>
        <div class="row-sm-5">
          <h5>Import Competition:</h5>
            <input type="text" name="competition" id="inputCompetition" placeholder="Type Competition Name" />
            <input type="submit" value="Submit" />
        </div>
        <div class="row-sm-4">
           <h5>Import Country:</h5> 
            <input type="text" name="country" id="country" placeholder="Type ColourName" />
            <input type="submit" value="Submit" />
        </div>
         <div class="row-sm-4">
           <h5>Import Town:</h5> 
             <h6>Select Country from list:</h6>
              <asp:DropDownList ID="DropDownCountry"  name="countryInput" runat="server" Width="100px">
            </asp:DropDownList>
            <input type="text" name="town" id="town" placeholder="Type Town Name" />
            <input type="submit" value="Submit" />
        </div>
    </div>
    <div class="row">
  
</div>
</asp:Content>
