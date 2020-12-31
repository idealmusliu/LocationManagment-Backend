using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCTask.DTO.FluentValidator
{
    public class LocationValidatorPut : AbstractValidator<LocationDTOPUT>
    {
        public LocationValidatorPut()
        {
            RuleFor(location => location.Name).NotEmpty().Length(1, 20).WithMessage("maximum length is 20");
            RuleFor(location => location.Address).NotEmpty().Length(1, 50).WithMessage("maximum length is 50");
        }
    }
}
