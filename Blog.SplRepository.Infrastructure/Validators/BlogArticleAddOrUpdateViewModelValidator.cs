using Blog.SplRepository.Infrastructure.ViewModels;
using FluentValidation;

namespace Blog.SplRepository.Infrastructure.Validators
{
    public class BlogArticleAddOrUpdateViewModelValidator<T>: AbstractValidator<T> where T : BlogArticleAddOrUpdateViewModel
    {
        public BlogArticleAddOrUpdateViewModelValidator()
        {
            RuleFor(x => x.btitle)
                .NotNull()
                .WithName("标题")
                .WithMessage("required|{PropertyName}是必填的")
                .MaximumLength(50)
                .WithMessage("maxlength|{PropertyName}的最大长度是{MaxLength}");

            RuleFor(x => x.bcontent)
                .NotNull()
                .WithName("正文")
                .WithMessage("required|{{PropertyName}是必填的")
                .MinimumLength(100)
                .WithMessage("minlength|{PropertyName}的最小长度是{MinLength}");
        }
    }
}
