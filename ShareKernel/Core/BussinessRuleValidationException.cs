using System;
using System.Runtime.Serialization;

namespace ShareKernel.Core
{
    [Serializable]
    public class BussinessRuleValidationException : Exception
    {

        public IBussinessRule BrokenRule { get; private set; }

        public string Details { get; private set; }


        public BussinessRuleValidationException(IBussinessRule brokenRule)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }



        protected BussinessRuleValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BussinessRuleValidationException(string message) : base(message)
        {
            Details = message;
        }

        public override string ToString()
        {
            string name = BrokenRule == null ? "BussinessRule" : BrokenRule.GetType().FullName;
            return $"{ name }: { Details } ";
        }
    }
}
