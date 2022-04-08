using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.Core
{
    public abstract record ValueObject
    {
        protected void CheckRule(IBussinessRule rule)
        {
            if (rule is null)
            {
                throw new ArgumentException("Rule cannot be null");
            }
            if (!rule.IsValid())
            {
                throw new BussinessRuleValidationException(rule);
            }
        }

    }
}
