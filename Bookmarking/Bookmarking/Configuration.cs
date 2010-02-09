using System;
using Bookmarking.Domain;
using Bookmarking.Handlers;
using Bookmarking.Resources;
using OpenRasta.Configuration;
using OpenRasta.DI;
using OpenRasta.Web;

namespace Bookmarking
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.CustomDependency<IBookmarkRepository, BookmarkRepository>(DependencyLifetime.Transient);
                ResourceSpace.Uses.CustomDependency<IUserRepository, UserRepository>(DependencyLifetime.Transient);

                ResourceSpace.Has.ResourcesOfType<HomeResource>()
                    .AtUri("/home")
                    .And.AtUri("/")
                    .HandledBy<HomeHandler>()
                    .RenderedByAspx("~/Views/HomeView.aspx");

                ResourceSpace.Has.ResourcesOfType<SignInResource>()
                    .AtUri("/signin")
                    .HandledBy<SignInHandler>()
                    .RenderedByAspx("~/Views/SignInView.aspx");

                ResourceSpace.Has.ResourcesOfType<UserResource>()
                    .AtUri("/user/{username}")
                    .HandledBy<UserHandler>()
                    .RenderedByAspx("~/Views/UserView.aspx");

                ResourceSpace.Has.ResourcesOfType<UserBookmarkListResource>()
                    .AtUri("/user/{username}/bookmarks")
                    .HandledBy<UserBookmarkListHandler>()
                    .RenderedByUserControl("~/Views/UserBookmarkListView.ascx");

                ResourceSpace.Has.ResourcesOfType<CreateUserBookmarkResource>()
                    .AtUri("/user/{username}/bookmark/new")
                    .HandledBy<UserBookmarkHandler>()
                    .RenderedByUserControl("~/Views/CreateUserBookmarkView.ascx");

                ResourceSpace.Has.ResourcesOfType<UserBookmarkResource>()
                    .AtUri("/user/{username}/bookmark/{bookmarkId}")
                    .HandledBy<UserBookmarkHandler>()
                    .RenderedByUserControl("~/Views/UserBookmarkView.ascx");


            }
        }
    }
}