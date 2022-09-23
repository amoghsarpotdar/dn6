using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaImprovementsInNet6
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExampleAttribute : Attribute
    {
        private string name;
        public double version;

        public ExampleAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
}
