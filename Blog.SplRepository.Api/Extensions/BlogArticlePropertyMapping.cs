using AutoMapper;
using Blog.SplRepository.Core.Entities;
using Blog.SplRepository.Infrastructure.ViewModels;

namespace Blog.SplRepository.Infrastructure.Mappings
{
    public class BlogArticlePropertyMapping : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public BlogArticlePropertyMapping()
        {

            CreateMap<BlogArticle, BlogArticleViewModel>();
            CreateMap<BlogArticleViewModel, BlogArticle>();

            //CreateMap<BlogArticleViewModel, BlogArticle>()
            //   .ForMember(back => back.bID, n => n.Ignore())
            //   .ForMember(back => back.bsubmitter, n => n.Ignore())
            //   .ForMember(back => back.bcategory, n => n.Ignore())
            //   .ForMember(back => back.bcommentNum, n => n.Ignore())
            //   .ForMember(back => back.btraffic, n => n.Ignore())
            //   .ForMember(back => back.bUpdateTime, n => n.Ignore())
            //   .ForMember(back => back.bCreateTime, n => n.Ignore())
            //   ;
            CreateMap<BlogArticleAddViewModel, BlogArticle>();
            CreateMap<BlogArticleUpdateViewModel, BlogArticle>();



        }
    }
}
