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
            <div id="divDDLNumberOfRoundsContainer">
                <asp:DropDownList runat="server" ID="ddlNumberOfRounds" />
            </div>
            <div id="divDSButtonContainer">
                <asp:Button runat="server" ID="btnDraftSetup" CssClass="btn btn-dark" Text="Next" OnClick="btnDraftSetup_Click" />
            </div>
        </div>
        <div>
            <div id="divTableCalculatorContainer">
                <table id="tableCalculator">
                    <thead>
                        <tr>
                            <th colspan="4">Round Calculator</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>QB</td>
                            <td>
                                <input type="number" min="0" class="roundSetupCount" />
                            </td>
                            <td>DE</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>RB</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                            <td>LB</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>WR</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                            <td>DB</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>FLEX</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                            <td>D/ST</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>TE</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                            <td>K</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>OP</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                            <td>Misc.</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>DP</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                            <td>Bench</td>
                            <td>
                                <input type="number" class="roundSetupCount" min="0" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><strong>Total</strong></td>
                            <td colspan="2"><span id="spanCalcResults"></span></td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <div id="divDSCalcBtnContainer">
                <asp:Button runat="server" ID="btnCalcButton" CssClass="btn btn-dark" Text="Calculate" OnClientClick="calculateRows(); return false;" />
            </div>
        </div>

    </div>
</asp:Content>
