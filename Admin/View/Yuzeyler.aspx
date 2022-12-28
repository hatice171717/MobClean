<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="Yuzeyler.aspx.cs" Inherits="Admin.View.Yüzeyler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Yüzeyler</h1>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="BUTON_ISLEMLERI" runat="server">

            <asp:GridView ID="GrdYuzeyler" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GrdYuzeyler_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="YuzeyId" HeaderText="Yüzey No" />
                    <asp:BoundField DataField="YuzeyAdi" HeaderText="Yüzey Adı" />
                    <asp:BoundField DataField="SertZemin" HeaderText="Sert Zemin" />
                    <asp:BoundField DataField="Tekstil" HeaderText="Tekstil" />
                    <asp:BoundField DataField="Antika" HeaderText="Antika" />
                    <asp:BoundField DataField="Aciklama" HeaderText="Açıklama" />
                    <asp:BoundField DataField="ResimYol" HeaderText="Resim" />
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
                        <%-- yüzey adi--%>
                        <asp:Label ID="lblYuzeyAdi" runat="server" Text="Yüzey Adı"></asp:Label>
                        <asp:TextBox ID="txtYuzeyAdi" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input"></asp:TextBox>
                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <%--yüzey zemin bit--%>
                        <asp:Label ID="lblYuzeyZemin" runat="server" Text="Yüzey Zemin"></asp:Label>



                        <asp:DropDownList ID="ddlZemin" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input">
                            <asp:ListItem Value="true">Sert</asp:ListItem>
                            <asp:ListItem Value="false">Yumuşak</asp:ListItem>
                        </asp:DropDownList>



                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <%--yüzey tekstil bit--%>
                        <asp:Label ID="lblTekstil" runat="server" Text="Tekstil"></asp:Label>
                        <asp:DropDownList ID="ddlTekstil" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input">
                            <asp:ListItem Value="true">Evet</asp:ListItem>
                            <asp:ListItem Value="false">Hayır</asp:ListItem>
                        </asp:DropDownList>


                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <%--yüzey Antika bit--%>
                        <asp:Label ID="lblAntika" runat="server" Text="Antika"></asp:Label>
                        <asp:DropDownList ID="ddlAntika" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input">
                            <asp:ListItem Value="true">Evet</asp:ListItem>
                            <asp:ListItem Value="false">Hayır</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <%--yüzey açıklama--%>
                        <asp:Label ID="lblAcıklama" runat="server" Text="Açıklama"></asp:Label>
                        <asp:TextBox ID="txtAcıklama" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input" Height="75px" TextMode="MultiLine"></asp:TextBox>


                    </div>
                </div>
                <div class="w3-container w3-blue">
                    <div class="row">
                        <%--yüzey ResimYol--%>
                        <asp:Label ID="lblResim" runat="server" Text="Resim"></asp:Label>
                        <asp:FileUpload ID="FileUploadResim" runat="server" CssClass="w3-input w3-border w3-hover-blue w3-animate-input" />

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
