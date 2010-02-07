<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUserBookmarkView.ascx.cs" Inherits="Bookmarking.Views.CreateUserBookmarkView" %>
    <% using (scope(Xhtml.Form(new UserBookmarkListResource { Username = Resource.Username }).Method("post")))
       {%>
    <div>
        <label>
            Url:
            <%= Xhtml.TextBox(() => Resource.PageUrl) %></label>
    </div>
    <div>
        <label>
            Title:
            <%= Xhtml.TextBox(() => Resource.PageTitle) %></label>
    </div>
    <div>
        <label>
            Tags:
            <%= Xhtml.TextBox(() => Resource.Tags) %></label>
    </div>
    <div>
        <input type="submit" value="Submit" />
    </div>
    <%
        }%>