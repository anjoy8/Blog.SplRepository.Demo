using Blog.SplRepository.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Blog.SplRepository.Infrastructure.Seed
{
    public class DBSeed
    {
        /// <summary>
        /// 异步添加种子数据
        /// </summary>
        /// <param name="myContext"></param>
        /// <returns></returns>
        public static async Task SeedAsync(DbContext myContext)
        {
            try
            {
                // 注意！一定要手动先创建要给空的数据库
                // 会覆盖，可以设置为true，来备份数据
                // 如果生成过了，第二次，就不用再执行一遍了,注释掉该方法即可
                myContext.CreateTableByEntity(false,typeof(BlogArticle));

                // 后期单独处理某些表
                //myContext.Db.CodeFirst.InitTables(typeof(sysUserInfo));


                

                #region BlogArticle Guestbook
                if (!await myContext.Db.Queryable<BlogArticle>().AnyAsync())
                {
                    int bid = myContext.GetEntityDB<BlogArticle>().InsertReturnIdentity(
                         new BlogArticle()
                         {
                             bsubmitter = "admins",
                             btitle = "老张的哲学",
                             bcategory = "技术博文",
                             bcontent = "<p>1，ctrl+alt+delete 去修改密码</p><p>2、<span style='color: inherit; '>打开“服务器管理器”，选择“配置”-“本地用户和组”-“用户，</span><span style='color: inherit; '>右击administrator，选择“属性”，在“常规”选项中勾上“密码永不过期”，点击“应用”和“确定”。</span><span style='color: inherit; '><br></span></p><p><span style='color: inherit; '>3、</span><span style='color: inherit; '>在开始菜单中选择“管理工具”-“本地安全策略”，</span><span style='color: inherit; '>选择“安全策略”-“账户策略”-“密码策略”，编辑“密码最短使用期限”和“密码最长使用期限”，天数设置为0，即永不过期，点击“确定”即可。</span><span style='color: inherit; '><br></span></p><p><br></p>",
                             btraffic = 1,
                             bcommentNum = 0,
                             bUpdateTime = DateTime.Now,
                             bCreateTime = DateTime.Now
                         });

                }
                #endregion

            



            }
            catch (Exception ex)
            {
                throw new Exception("注意要先创建空的数据库");
            }
        }
    }
}
