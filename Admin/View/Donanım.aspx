<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="Donanım.aspx.cs" Inherits="Admin.View.Donanım" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Donanım</h1>
     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="BUTON_ISLEMLERI" runat="server">

            <asp:GridView ID="GrdDonanim" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="Black" GridLines="None"  BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" OnRowCommand="GrdDonanim_RowCommand">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="DonanimId" HeaderText="Donanım No" />
                    <asp:BoundField DataField="DonanimAdi" HeaderText="Donanım Adı" />
                    <asp:BoundField DataField="DonanimResim" HeaderText="Donanım Resmi" />
                    <asp:ButtonField ButtonType="Image" CommandName="YENİ" HeaderText="YENİ" ImageUrl="~/Images/Yeni.png" Text="Button" />
                    <asp:ButtonField ButtonType="Image" CommandName="GÜNCELLE" HeaderText="GÜNCELLE" ImageUrl="~/Images/update-icon-18.jpg" Text="Button" />
                    <asp:ButtonField ButtonType="Image" CommandName="SİL" HeaderText="SİL" ImageUrl="~/Images/delete.png" Text="Button" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>

        </asp:View>


        <asp:View ID="CRUD_ISLEMLERI" runat="server">

            <div id="Baslik" runat="server" class="w3-container w3-blue">
                <h2>
                    <asp:Label ID="LblBas" runat="server" Text="Label">YENİ BİNA TİPLERİ GİRİŞİ</asp:Label>
                </h2>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <asp:Label ID="lblDonanimAdi" runat="server" Text="Donanım Adı"></asp:Label>
                        <asp:TextBox ID="txtDonanimAdi" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input"></asp:TextBox>
                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <asp:Label ID="lblDonanımResmi" runat="server" Text="Donanım Resim"></asp:Label>
                        <asp:FileUpload ID="FileUploadResim" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input" />
                        <br />
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
