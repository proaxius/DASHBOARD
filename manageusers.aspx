<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="manageusers.aspx.cs" Inherits="admin_Default" %>

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
    <div class="row">
 
     
        <div class="col-12">
           <table class="table table-responsive table-hover">
            <thead><tr><th>Sr.No</th> <th>Name</th> <th>Date-Registered</th> <th>Account-status</th></tr></thead>  
         
 <tbody id="divtable" runat="server">
     <tr>
         <td>1</td>
         <td><img src="image" style="" /></td>
     <td id="title">title</td>
         <td id="Descriptionblog">Description</td>
     <td><a href="editblog.aspx" class="danger">Edit|Update|Delete</a></td>
     
     </tr>
 </tbody>
  <div id="diverr" runat="server" ></div>
           </table>
  
        </div>
        </div>
</asp:Content>

