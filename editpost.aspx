<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="editpost.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <script type="text/javascript" src="http://code.jquery.com/jquery.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="TxtEdtr/jquery-te-1.4.0.min.js" charset="utf-8"></script>
    <link type="text/css"  href="TxtEdtr/jquery-te-1.4.0.css" rel="stylesheet" />
    <div>
   <style>
       
       .myClass {
           background-color: dodgerblue;
           color: white;
           font-weight: bold;
       }

    label{padding:15px;color:red;}
   </style>
    <div class="container-fluid">

<div class="row">
   
    <div class="col-lg-6">
    <div class="form-group">
        <div class="col-md-12">
            <asp:Image ID="Image1" runat="server" />
            <label>Select Image</label>
            <asp:FileUpload ID="Pictures" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-12"><br /><br />
            <label>Image Caption</label>
            <asp:TextBox ID="txt_Caption" runat="server"  CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-12"><br /><br />
            <label>Image Description</label>
            <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control teBox"></asp:TextBox>
        </div>
        <div class="col-md-12 text-center">
            <br /><hr />
            <asp:Button CssClass="btn btn-danger myClass" ID="btnsubmit" runat="server"  Text="Update" Onclick="btnsubmit_Click" />
            
            <asp:Button CssClass="btn  btn-danger myClass" ID="btndelete" runat="server"  Text="Delete" Onclick="btndelete_Click" />

        </div>
        <div class="col-lg-12">
            <div id="divErr" runat="server"></div>
        </div>
    </div>
       </div> 
</div>
     

        </div>
        </div>
<script>
     $('.teBox').jqte();
</script>
</asp:Content>

