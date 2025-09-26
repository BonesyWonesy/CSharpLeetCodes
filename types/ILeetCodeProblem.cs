using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.types
{
    internal interface ILeetCodeProblem
    {
        IEnumerable<(object,object)> GetTests();
        object? Test(object testCase);

        string FormatOutput(object result);
    }

    internal interface ILeetCodeProblem<Input, Output> : ILeetCodeProblem
    {
        public IEnumerable<(Input, Output)> GetTests();
        public Output Test(Input testCase);

        public string FormatOutput(Output result);

        IEnumerable<(object, object)> ILeetCodeProblem.GetTests() => GetTests().Select(t=> ((object)t.Item1, (object)t.Item2));
        object? ILeetCodeProblem.Test(object testCase) => Test((Input)testCase);        
        string ILeetCodeProblem.FormatOutput(object result) => FormatOutput((Output)result);
    }

    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}
