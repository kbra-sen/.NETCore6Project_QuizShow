using FluentValidation;

namespace QuizShow.Models.FluentValidator
{
    public class QuestionsValidator : AbstractValidator<Questions>
    {
        public QuestionsValidator()
        {
            RuleFor(q => q.QuestDesc).NotEmpty().WithMessage("Zorunlu Alan");
            RuleFor(q => q.Degree).NotEmpty().WithMessage("Zorunlu Alan");
            RuleFor(q => q.Order).NotNull().WithMessage("Zorunlu Alan").GreaterThan(0).WithMessage("0 dan büyük olmalı");
        }
    }
}
