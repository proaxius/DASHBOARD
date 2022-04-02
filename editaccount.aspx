<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="editaccount.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div class="row">
         <div class="col-lg-12">
             <div id="divedit" runat="server">

                 <asp:Label ID="Label1" runat="server" Text="Account id"></asp:Label>
             <textarea id="userid" cols="20" rows="2" runat="server"></textarea>
                 <asp:Label ID="Label2" runat="server" Text="Acoount-status"></asp:Label>
                 <asp:DropDownList ID="DropDownList1" runat="server">

                 </asp:DropDownList>
             </div>

         </div>
         
     </div>
</asp:Content>

