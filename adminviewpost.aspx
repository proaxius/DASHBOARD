<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="adminviewpost.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style>
          .rectangle{
            height:auto;
            width:auto;
            background-color:aqua;



        }
        .rectangle2 {
            height: auto;
            width: auto;
            background-color: rgb(242, 215, 126);
        }
        .headcaption{

        }
        
        .containerbox{
            height:50%;
        width:50%;
        padding-top:20px;
            }
        .imagestyle{
            max-height:312px;
            min-height:300px;
            max-width:none;
            min-width:520px;
        }
    </style>
    <div class="container" style="padding-top:50px;padding-left:10px;padding-right:10px;border-top-width: 29px;border-top-style: solid;">
        <div class="row" id="viewposts" runat="server">
          
            
          
        </div>

        
            </div>

</asp:Content>

