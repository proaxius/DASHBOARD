<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage/admin/adminMasterPage.master" AutoEventWireup="true" CodeFile="admincreateblog.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
    <style>
       #headbox{
           height:40px;
           width:100%;
           
       }
    </style>
   <br /> <div class="container" style=" background-image:url(../images/gradient_spots_texture_129927_3840x2160.jpg);height:740px;width:100%; padding-top:50px;">
       
      
           
           <div class="row"  />
        <div class="container"  style="background-color:rgba(255, 255, 255, 0.45);" >
           <div class="col-lg-12" style="padding-top:10px;">  
               <asp:Label ID="Label3" runat="server" Text="UPLOAD PICTURE" style="font-size:20px;color:rgb(255, 255, 255);"></asp:Label>
            <asp:FileUpload ID="Blogpic" runat="server" /></div>



        <div class="col-lg-12" style="padding-top:20px;font-size:20px;">
                        <asp:Label ID="Label1" runat="server" Text="ADD A SHORT DESCRIPTION  | CAPTION"  style="color:rgb(255, 255, 255); "></asp:Label>
        <br /><asp:TextBox ID="txt_title" runat="server" CssClass="form-control" style="height:50px;width:250px; margin-top:10px;margin-bottom:10px;">

        </asp:TextBox>
               </div>
          
          
                <div  class="col-lg-12">
                 <asp:Label ID="Label2" runat="server" Text="ADD FULL DESCRIPTION FOR YOUR PIC "  style="color:rgb(255, 255, 255);font-size:20px;"></asp:Label>
                <br />
            <asp:TextBox ID="txt_Descriptionblog" runat="server" TextMode="MultiLine" CssClass="blog-box" style="height:70px;width:350px; margin-top:10px;margin-bottom:10px;"></asp:TextBox>
                    </div>
        
            
            <div class="col-lg-12"  >
        <asp:Button ID="Btnupload" runat="server" Text="Upload" style="margin-bottom:10px;" Onclick="Btnupload_Click" /></div>
    </div>
        <div class="col-lg-12">
            <div id="divErr" runat="server"></div>
        </div>

</div>
       
</div>
</asp:Content>

