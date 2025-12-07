using FluentValidation;
using Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Valid
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Id) 
                .InclusiveBetween(1, 100);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Last name boş olamaz.")
                .MaximumLength(50);
             
        }
         
    }
}
