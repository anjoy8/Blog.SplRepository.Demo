using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.SplRepository.Api.Helpers;
using Blog.SplRepository.Core.Entities;
using Blog.SplRepository.Core.Interfaces;
using Blog.SplRepository.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.SplRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogArticleRepository _blogArticleRepository;
        private readonly IMapper _mapper;

        public BlogsController(IBlogArticleRepository blogArticleRepository, IMapper mapper)
        {
            _blogArticleRepository = blogArticleRepository;
            _mapper = mapper;
        }


        // GET api/values
        [HttpGet(Name = "GetBlogs")]
        public async Task<IActionResult> GetHateoas()
        {

            var blogList = await _blogArticleRepository.Query();
            var blogViewModels = _mapper.Map<IEnumerable<BlogArticle>, IEnumerable<BlogArticleViewModel>>(blogList);



            return Ok(blogViewModels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost(Name = "CreatePost")]
        public async Task<IActionResult> Post([FromBody] BlogArticleAddViewModel blogArticleAddViewModel)
        {
            if (blogArticleAddViewModel == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new MyUnprocessableEntityObjectResult(ModelState);
            }

            var blog = _mapper.Map<BlogArticleAddViewModel, BlogArticle>(blogArticleAddViewModel);


            blog.bsubmitter = "laozhang";
            blog.bCreateTime = DateTime.Now;
            blog.bUpdateTime = DateTime.Now;

            var blogId = await _blogArticleRepository.Add(blog);

            var resultResource = _mapper.Map<BlogArticle, BlogArticleViewModel>(blog);

            return Ok(resultResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
