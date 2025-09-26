using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.types
{
    internal abstract class LeetCodeProblem
    {
        protected Difficulty difficulty { get; set; }
        public LeetCodeProblem(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }
    }
}
