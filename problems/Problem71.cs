using CSharpLeetCode.types;
using System.Text;

namespace CSharpLeetCode.problems
{
  /*
   *You are given an absolute path for a Unix-style file system, which always begins with a slash '/'. Your task is to transform this absolute path into its simplified canonical path.
   *
   * The rules of a Unix-style file system are as follows:
   * 
   * A single period '.' represents the current directory.
   * A double period '..' represents the previous/parent directory.
   * Multiple consecutive slashes such as '//' and '///' are treated as a single slash '/'.
   * Any sequence of periods that does not match the rules above should be treated as a valid directory or file name. For example, '...' and '....' are valid directory or file names.
   * 
   * The simplified canonical path should follow these rules:
   * 
   * The path must start with a single slash '/'.
   * Directories within the path must be separated by exactly one slash '/'.
   * The path must not end with a slash '/', unless it is the root directory.
   * The path must not have any single or double periods ('.' and '..') used to denote current or parent directories.
   * 
   * Return the simplified canonical path.
   * 
   */
  internal class Problem71 : LeetCodeProblem, ILeetCodeProblem<string, string>
  {
    public Problem71() : base(Difficulty.Medium) { }

    public string FormatOutput(string result) => result;
    public bool IsEqual(string result, string expected) => result == expected;

    public IEnumerable<(string, string)> GetTests() {
      return new (string, string)[] {
                ("home/", "/home"),
                ("/home//foo/", "/home/foo"),
                ("/home/user/Documents/../Pictures", "/home/user/Pictures"),
                ("/../", "/"),
                ("/.../a/../b/c/../d/./", "/.../b/d"),
                ("/a/./b/../../c/", "/c"),
                ("/a/../../b/../c//.//", "/c"),
                ("/home/../../..", "/")
            };
    }
    public string Test(string testCase) {
      StringBuilder sb = new StringBuilder("/");

      testCase.Split("/").ToList().ForEach(part =>
      {
        if (part == "" || part == ".")
        {
          // no-op
        }
        else if (part == "..")
        {
          if (sb.Length > 1)
          {
            sb.Remove(sb.ToString().LastIndexOf('/'), sb.Length - sb.ToString().LastIndexOf('/'));
          }
        }
        else
        {
          if (sb.Length > 1 || sb.Length == 0)
          {
            sb.Append("/");
          }

          sb.Append(part);
        }
      });

      if (sb.Length == 0)
      {
        sb.Append("/");
      }

      if (sb[0] != '/')
      {
        sb.Insert(0, "/");
      }

      return sb.ToString();
    }
  }
}
