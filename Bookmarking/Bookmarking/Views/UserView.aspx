<%@ Page Language="C#" Inherits="ResourceView<UserResource>" MasterPageFile="~/Views/Bookmarks.Master" %>

<asp:Content ContentPlaceHolderID="body" ID="content" runat="server">
    <h1>
        Welcome
        <%= Resource.DisplayName %></h1>
    <h2>
        Latest Bookmarks</h2>
    <%
        Xhtml.RenderResource(new UserBookmarkListResource { Username = Resource.Username }.CreateUri()); %>
    <h2>
        Add new bookmark</h2>
    <%
        Xhtml.RenderResource(new CreateUserBookmarkResource { Username = Resource.Username }.CreateUri()); %>
</asp:Content>
