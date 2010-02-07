<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserBookmarkListView.ascx.cs"
    Inherits="Bookmarking.Views.UserBookmarkListView" %>
<% 
    if (Resource.BookmarkList.Any())
    {
%>
<ul>
    <%
        foreach (var userBookmark in Resource.BookmarkList)
        {%>
    <li>
        <a href="<%=userBookmark.PageUrl%>"><%=userBookmark.PageTitle%></a>
    </li>
    <%
        }%>
</ul>

<%
    }
%>
