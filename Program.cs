// See https://aka.ms/new-console-template for more information
using CSharpLeetCode;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml.Linq;


 ILeetCodeProblem[] metaProblems = [
//    new Problem1()
//    new Problem7()
//    new Problem8()
//    new Problem14()
//    new Problem19()
//    new Problem21()
//    new Problem28()
//    new Problem34(),
//    new Problem36(),
//    new Problem48()
//    new Problem50(),
//    new Problem56(),
//    new Problem66()
//    new Problem71(),
//    new Problem88(),
//    new Problem98()
//    new Problem101()
//    new Problem102()
//    new Problem104()
//    new Problem121()
//    new Problem125(),
//    new Problem141()
//    new Problem146(),
//    new Problem162(),
//    new Problem199(),
//    new Problem206()
//    new Problem215(),
//    new Problem227(),
//    new Problem234()
//    new Problem236(),
//    new Problem242()
      new Problem278()
//    new Problem283()
//    new Problem314(),
//    new Problem339(),
//    new Problem344()
//    new Problem347(),
//    new Problem350()
//    new Problem387()
//    new Problem408(),
//    new Problem543(),
//    new Problem560(),
//    new Problem680(),
//    new Problem938(),
//    new Problem973(),
//    new Problem1091(),
//    new Problem1249(),
//    new Problem1570(),
//    new Problem1650(),
//    new Problem1762(),
];

for( int p = 0; p < metaProblems.Length; ++p)
{
    int t = 1;
    metaProblems[p].GetTests().ToList().ForEach(testCase =>
    {
        var result = metaProblems[p].Test(testCase.Item1);
        Console.WriteLine($"Problem {t++} ({metaProblems[p].GetType().Name}): {metaProblems[p].FormatOutput(result)}, expected: {metaProblems[p].FormatOutput(testCase.Item2)}");
    });

}
