namespace CSharpLeetCode.types
{
  internal abstract class LeetCodeProblem
  {
    protected Difficulty difficulty { get; set; }
    public LeetCodeProblem(Difficulty difficulty) {
      this.difficulty = difficulty;
    }
  }
}
