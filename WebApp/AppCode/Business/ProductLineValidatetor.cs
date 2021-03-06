//https://github.com/JeremySkinner/FluentValidation/wiki/a.-Index
using FluentValidation;
using WebApp.Business;
namespace WebApp.AppCode.Business
{
public class ProductLineValidatetor :  AbstractValidator<ProductLine>
{
public ProductLineValidatetor(){
 RuleFor(productline => productline.SourceID).NotEmpty();
 RuleFor(productline => productline.LineID).NotEmpty();
 RuleFor(productline => productline.TestFormulaID).NotEmpty();
 RuleFor(productline => productline.ContainID).NotEmpty();
 RuleFor(productline => productline.LineSizeID).NotEmpty();
 RuleFor(productline => productline.CustomerBrandID).NotEmpty();
 RuleFor(productline => productline.ManufacturingDate).NotEmpty();
 RuleFor(productline => productline.ExpectItems).NotEmpty();
 RuleFor(productline => productline.ProcessItems).NotEmpty();
 RuleFor(productline => productline.CreateDate).NotEmpty();

}
} }
//RuleFor(customer => customer.Forename).NotEmpty().WithMessage("Please specify a first name");
//RuleFor(customer => customer.Discount).NotEqual(0).When(customer => customer.HasDiscount);
//RuleFor(customer => customer.Address).Length(20, 250);
// RuleFor(customer => customer.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
//private bool BeAValidPostcode(string postcode) { 
// custom postcode validating logic goes here
//}  
//Customer customer = new Customer();
//CustomerValidator validator = new CustomerValidator();
//ValidationResult results = validator.Validate(customer);
  
//bool validationSucceeded = results.IsValid;
//IList<ValidationFailure> failures = results.Errors;
