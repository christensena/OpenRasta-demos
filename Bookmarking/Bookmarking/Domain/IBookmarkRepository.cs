namespace Bookmarking.Domain
{
    public interface IBookmarkRepository : IRepository<Bookmark>
    {
        Bookmark FindByUrl(string url);
    }
}