<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="admincreatepost.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style>
      .myClass{ background-color:dodgerblue;color:white;font-weight:bold;}

    label{padding:15px;color:red;}
   </style>
    <div class="container-fluid">

<div class="row">
   
    <div class="col-lg-6">
    <div class="form-group">
        <div class="col-md-12">
            <label>Select Image</label>
            <asp:FileUpload ID="Pictures" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-12"><br /><br />
            <label>Image Caption</label>
            <asp:TextBox ID="txt_Caption" runat="server"  CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-12"><br /><br />
            <label>Image Description</label>
            <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-12 text-center">
            <br /><hr />
            <asp:Button CssClass="btn btn-danger myClass" ID="btnsubmit" runat="server"  Text="Upload" Onclick="btnsubmit_Click" />

        </div>
        <div class="col-lg-12">
            <div id="divErr" runat="server"></div>
        </div>
    </div>
       </div> 
</div>
     

        </div>
</asp:Content>

