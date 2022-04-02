<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="adminmanageposts.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <style>
        .notchedimage{
            border-radius:15px;
            height:220px;
                width:auto;
                align-content:center;
        }
    </style>
     
           <table class="table table-responsive table-hover">
            <thead><tr><th>Sr.No</th> <th>Image</th> <th>Caption</th> <th>Description</th></tr></thead>  
         
 <tbody id="divblog" runat="server">
     <tr>
         <td>1</td>
         <td><img src="image" style="" /></td>
     <td id="title">title</td>
         <td id="Descriptionblog">Descriptionblog</td>
     <td><a href="editblog.aspx" class="danger">Edit|Update|Delete</a></td>
     
     </tr>
 </tbody>

           </table>
    <div id="diverr" runat="server" ></div>
</asp:Content>

