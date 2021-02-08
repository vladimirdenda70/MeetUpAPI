using FluentValidation;
using MeetUpAPI.Entites;
using MeetUpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MeetUpAPI.Validators
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(MeetupContext meetupContext)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var userAlreadyExists = meetupContext.Users.Any(user => user.Email == value);
                if (userAlreadyExists)
                {
                    context.AddFailure("Email", "That Email address is taken!!");
                }
            });
        }
    }
}
