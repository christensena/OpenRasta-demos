<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<UserResource>" MasterPageFile="~/Views/Bookmarks.Master" %>

<asp:Content ContentPlaceHolderID="body" ID="content" runat="server">
    <h2>Sign Up</h2>
    
    <%= using (scope(Xhtml.Form(Resource))))
        {
         %>
        
         <input type="submit" value="Sign Up" />
    <% } %>
</asp:Content>
