// See https://aka.ms/new-console-template for more information
using CSharpLeetCode.problems;
using CSharpLeetCode.types;


ILeetCodeProblem[] metaProblems = [
//    new Problem1()
//    new Problem3()
//    new Problem7()
//    new Problem8()
//    new Problem13()
//    new Problem14()
//    new Problem19()
//    new Problem20()
//    new Problem21()
//    new Problem28()
//    new Problem34(),
//    new Problem36(),
//    new Problem48()
//    new Problem50(),
//    new Problem56(),
//    new Problem66()
//    new Problem70()
//    new Problem71(),
//    new Problem88(),
//    new Problem94()
//    new Problem98()
//    new Problem101()
//    new Problem102()
//    new Problem104()
//    new Problem118()
//    new Problem121()
//    new Problem125(),
//    new Problem141()
//    new Problem146(),
//    new Problem155()
//    new Problem162(),
//    new Problem190()
//    new Problem191()
//    new Problem198()
//    new Problem199(),
//    new Problem204(),
//    new Problem206()
//    new Problem215(),
//    new Problem227(),
//    new Problem234()
//    new Problem236(),
//    new Problem242()
//    new Problem246()
    new Problem247()
//      new Problem248()
//    new Problem268()
//    new Problem278()
//    new Problem283()
//    new Problem314(),
//    new Problem326()
//    new Problem339(),
//    new Problem344()
//    new Problem347(),
//    new Problem350()
//    new Problem384()
//    new Problem387()
//    new Problem408(),
//    new Problem412()
//    new Problem461()
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

string NL = Environment.NewLine; // shortcut
string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";

for (int p = 0; p < metaProblems.Length; ++p)
{
  int t = 1;
  metaProblems[p].GetTests().ToList().ForEach(testCase =>
  {
    var result = metaProblems[p].Test(testCase.Item1);

    string outputStr = metaProblems[p].FormatOutput(result);
    string expected = metaProblems[p].FormatOutput(testCase.Item2);

    string problem = $"Problem {t++} ({metaProblems[p].GetType().Name}):";

    
    if (metaProblems[p].IsEqual(result, testCase.Item2))
    {
      Console.WriteLine($"{GREEN}{problem}{NORMAL} {metaProblems[p].FormatOutput(result)}, expected: {metaProblems[p].FormatOutput(testCase.Item2)}");
    }
    else
    {
      Console.WriteLine($"{RED}{problem}{NORMAL} {metaProblems[p].FormatOutput(result)}, expected: {metaProblems[p].FormatOutput(testCase.Item2)}");
    }
    
    //Console.WriteLine($"{NORMAL}{problem}{NORMAL} {metaProblems[p].FormatOutput(result)}, expected: {metaProblems[p].FormatOutput(testCase.Item2)}");
  });
}
