using Blog.SplRepository.Core.Entities;
using Blog.SplRepository.Core.Interfaces;

namespace Blog.SplRepository.Infrastructure.Repositories
{
    public class BlogArticleRepository: BaseRepository<BlogArticle>, IBlogArticleRepository
    {
    }
}
