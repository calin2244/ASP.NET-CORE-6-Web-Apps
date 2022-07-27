using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Scripts
{
    public class CustomAnnotations
    {
        public class ExcludeChar : ValidationAttribute
        {
            private readonly string chars;
            public ExcludeChar(string chars) : base("{0} contains invalid characters")
            {

                this.chars = chars;
            }

            protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    for (int i = 0; i < chars.Length; ++i)
                    {
                        var valueAsString = value.ToString();
                        if (valueAsString != null && valueAsString.Contains(chars[i]))
                        {
                            var errorMsg = FormatErrorMessage(validationContext.DisplayName);
                            return new ValidationResult(errorMsg);
                        }
                    }
                }
                return ValidationResult.Success;
            }

            
        }

        public class HasAt : ValidationAttribute
        {
            private readonly string chars;
            public HasAt(string chars) : base("{0} contains invalid characters")
            {
                this.chars = chars;
            }

            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if(value != null)
                {
                    var valAsString = value.ToString();
                    for(int i = 0; i < chars.Length; ++i)
                    {
                        if(valAsString != null && !valAsString.Contains(chars[i]))
                        {
                            var errMsg = FormatErrorMessage(validationContext.DisplayName);
                            return new ValidationResult(errMsg);
                        }
                    }
                }
                return ValidationResult.Success;
            }   
            
        }
    }
}
