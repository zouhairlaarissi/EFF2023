<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EtablissementsGestion.aspx.cs" Inherits="EFF2023.EtablissementsGestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EFF2023</title>
        <style type="text/css">
        .auto-style1 {
            width: 50%;
            margin-right: 0px;
        }
        .auto-style2 {
            margin-right: 73px;
        }
        .auto-style3 {
            width: 428px;
        }
        .auto-style4 {
            width: 47px;
        }
        #lblMessage {
            color: #FF0000;
            font-weight: bold;
            font-size: 50px;
            text-align: center;
            margin: 0 auto;
        }
 
        body {
            background-color: #E6E6FA;  
        }
        #div1 {
            width: 50%;
            margin: 0 auto;
            background-color: #FFFFFF;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
        }
        label {
            font-size: 20px;
            font-weight: bold;
        }
        input[type="text"] {
            width: 200px;
            padding: 5px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }
        .b {
            padding: 5px;
            border-radius: 5px;
            background-color: darkslategrey;
            color: white;
            border: none;
            margin-bottom : 3px;
        }
            .b:hover {
                background-color: lightgray;
                color: black;
                cursor: pointer;
            }
    </style>
</head>
<body>
    <div id="div1">
    <h1 style="text-align: center; color: #0000FF;">GESTION DES ETABLISSEMENTS</h1>
    <form id="form1" runat="server">
        <div>
                        <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="CODE"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtCode" runat="server" Width="198px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="NOM"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtNom" runat="server" Width="198px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="VILLE"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtVille" runat="server" Width="196px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="Button4" Class="b" runat="server" Text="AJOUTER" OnClick="Button4_Click" />
                        <asp:Button ID="Button5" Class="b" runat="server" Text="SUPPRIMER" OnClick="Button5_Click" />
                        <asp:Button ID="Button6" Class="b" runat="server" Text="CHERCHER" OnClick="Button6_Click" />
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="Button7" Class="b" runat="server" OnClick="Button7_Click" Text="EFFACER" Width="80px" />
                        <asp:Button ID="Button8" Class="b" runat="server" OnClick="Button8_Click" Text="FERMER" Width="81px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
                    <br /><br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" CssClass="auto-style2" ForeColor="#333333" GridLines="None" Height="162px" Width="579px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <br />
        <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
        </div>
    </form>
    </div>
</body>
</html>
