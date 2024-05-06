using ITExpert.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITExpert.Persistence.Specifications
{
    internal class ValuesByCodeSpecification : Specification<ValueEntity>
    {
        public ValuesByCodeSpecification(int code)
            : base(value => value.Code.Equals(code))
        {
            
        }
    }
}
