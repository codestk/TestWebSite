using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using WebApp.Code.Business;

namespace WebApp.AppCode.Business
{
     
    public class AccountRegistrationValidator : AbstractValidator<AccountRegistration>
    {
        public AccountRegistrationValidator()
        {
            RuleFor(accountRegistration => accountRegistration.Password).NotEmpty();

           

 
            //RuleFor(customer => customer.Forename).NotEmpty().WithMessage("Please specify a first name");
            //RuleFor(customer => customer.Discount).NotEqual(0).When(customer => customer.HasDiscount);
            //RuleFor(customer => customer.Address).Length(20, 250);
            //RuleFor(customer => customer.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }

        private bool BeAValidPostcode(string postcode)
        {
            // custom postcode validating logic goes here

            return true;
        }
    }




}
