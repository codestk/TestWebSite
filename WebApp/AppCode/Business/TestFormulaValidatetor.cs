//https://github.com/JeremySkinner/FluentValidation/wiki/a.-Index
using FluentValidation;
using WebApp.Business;
namespace WebApp.AppCode.Business
{
public class TestFormulaValidatetor :  AbstractValidator<TestFormula>
{
public TestFormulaValidatetor(){
// RuleFor(testformula => testformula.TestFormulaID).NotEmpty();
 RuleFor(testformula => testformula.TestFormulaName).NotEmpty();
 RuleFor(testformula => testformula.TestFormulaDetail).NotEmpty();

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
