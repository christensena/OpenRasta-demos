<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<HomeResource>" MasterPageFile="Bookmarks.Master" %>

<asp:Content ContentPlaceHolderID="body" ID="content" runat="server">
    <h2>Bookmarking</h2>

    <a href="<%= typeof(SignInResource).CreateUri() %>">Sign In</a>
    <h3>Latest Bookmarks</h3>
    <ul>
        <% foreach (var bookmark in Resource.LatestBookmarks)
           {%>
            <li><a href="<%= bookmark.Url %>"><%= bookmark.Title %></a></li>           
        <% } %>
    </ul>
    <a href="<%= Resource.CreateUri() %>">Home</a>
</asp:Content>
