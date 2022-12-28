<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="BolumTipleri.aspx.cs" Inherits="Admin.View.BolumTipleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bölüm Tipleri</h1>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="BUTON_ISLEMLERI" runat="server">

            <asp:GridView ID="GrdBolumTipleri" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GrdBolumTipleri_RowCommand" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="BolumTipId" HeaderText="Bölüm Tip No" />
                    <asp:BoundField DataField="BolumTipiAdi" HeaderText="Bölüm Tipi Adı" />
                    <asp:BoundField DataField="BolumRiskOrani" HeaderText="Bölüm Risk Oranı" />
                    <asp:ButtonField ButtonType="Image" CommandName="YENİ" HeaderText="YENİ" ImageUrl="~/Images/Yeni.png" Text="Button" />
                    <asp:ButtonField ButtonType="Image" CommandName="GÜNCELLE" HeaderText="GÜNCELLE" ImageUrl="~/Images/update-icon-18.jpg" Text="Button" />
                    <asp:ButtonField ButtonType="Image" CommandName="SİL" HeaderText="SİL" ImageUrl="~/Images/delete.png" Text="Button" />
                </Columns>
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

        </asp:View>


        <asp:View ID="CRUD_ISLEMLERI" runat="server">

            <div id="Baslik" runat="server" class="w3-container w3-blue">
                <h2>
                    <asp:Label ID="LblBas" runat="server" Text="Label">YENİ BÖLÜM TİPİ GİRİŞİ</asp:Label>
                </h2>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <asp:Label ID="lblBolumTipAdi" runat="server" Text="Bölüm Tip Adı"></asp:Label>
                        <asp:TextBox ID="txtBolumTipAdi" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input"></asp:TextBox>
                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <asp:Label ID="lblBolumTipRisk" runat="server" Text="Bölüm Tip Risk Oranı"></asp:Label>
                        <asp:TextBox ID="txtBolumTipRiskOrani" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input" ></asp:TextBox>
                    
                    
                    </div>
                </div>

                <div class="w3-center">
                    <div class="w3-bar">

                        <asp:Button ID="BtnSave" runat="server" CssClass="w3-button w3-blue" Text="Kaydet" OnClick="BtnSave_Click" />
                        <asp:Button ID="BtnCancel" runat="server" CssClass="w3-button w3-red" Text="İptal" OnClick="BtnCancel_Click" />
                        <asp:Label ID="lbltableId" runat="server" Text="" Visible="false"></asp:Label>

                    </div>


                </div>


            </div>
        </asp:View>



    </asp:MultiView>

</asp:Content>
