using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record PersonNameValue : ValueObject
    {
        public string Name { get; }

        public PersonNameValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if(name.Length > 500)
            {
                throw new BussinessRuleValidationException("PersonName can't be more than 500 characters");
            }
            Name = name;
        }

        public static implicit operator string(PersonNameValue value)
        {
            return value.Name;
        }

        public static implicit operator PersonNameValue(string name)
        {
            return new PersonNameValue(name);
        }
    }
}
