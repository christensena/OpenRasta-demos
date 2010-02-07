<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<SignInResource>" MasterPageFile="~/Views/Bookmarks.Master" %>

<asp:Content ContentPlaceHolderID="body" ID="content" runat="server">
    <h1>Sign In</h1>
    <% using (scope(Xhtml.Form(Resource).Method("post")))
       {%>
    
        <%= Xhtml.TextBox(() => Resource.Login) %>
        
        <%= Xhtml.Password(() => Resource.Password) %>
        
        <input type="submit" value="Sign In" />
    
    <% } %>
</asp:Content>
