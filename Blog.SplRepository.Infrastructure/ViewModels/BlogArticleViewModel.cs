using System;

namespace Blog.SplRepository.Infrastructure.ViewModels
{
    public class BlogArticleViewModel
    {
        public int bID { get; set; }

        public string btitle { get; set; }
        public string bcontent { get; set; }
        public string bsubmitter { get; set; }
        public DateTime bUpdateTime { get; set; }

        public string bRemark { get; set; }
    }
}
