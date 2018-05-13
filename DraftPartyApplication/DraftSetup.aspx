<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DraftSetup.aspx.cs" Inherits="DraftPartyApplication.DraftSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divDraftSetupContainer">
        <div>
            <h2>Draft Setup</h2>
        </div>
        <div>
            <div>
                Choose the number of rounds:
            </div>
            <div>
                <asp:DropDownList runat="server" ID="ddlNumberOfRounds" />
            </div>
            <div id="divDSButtonContainer">
                <asp:Button runat="server" ID="btnDraftSetup" CssClass="btn btn-dark" Text="Next" />
            </div>
        </div>
        <div>
            <div>
                Round Calculator
            </div>
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Position</th>
                            <th>Count</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>QB</td>
                            <td>
                                <input type="number" min="0" class="roundSetupCount" /></td>
                        </tr>
                        <tr>
                            <td>RB</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>WR</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>FLEX</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>TE</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>OP</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>DP</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>DE</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>LB</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>DB</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>D/ST</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>K</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" /></td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td><span id="spanCalcResults">Test</span></td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <div id="divDSCalcBtnContainer">
                <!-- TODO GET BUTTON WORKING -->
                <asp:Button runat="server" ID="btnCalcButton" CssClass="btn btn-dark" Text="Calculate" OnClientClick="calculateRows()" />
            </div>
        </div>

    </div>
</asp:Content>
