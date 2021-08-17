namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

    }
}