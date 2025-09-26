using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.types
{
    internal static class OutputFormatters
    {
        public static string Output(char[] result) => $"{string.Join(',', result)}]";

        public static string Output(int?[] result) => $"[{string.Join(',', result)}]";

        public static string Output(int[] result) => $"[{string.Join(',', result)}]";

        public static string Output(IList<IList<int>> output)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < output.Count; ++i)
            {
                IList<int> list = output[i];

                sb.Append("[");
                for(int j = 0; j < list.Count; ++j)
                {
                    sb.Append(list[j].ToString());

                    if (j != list.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append("]");

                if (i != output.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }

        public static string Output(int[][] result)
        {
                StringBuilder sb = new StringBuilder();

                sb.Append("[");

                for (int i = 0; i < result.Length; ++i)
                {
                    sb.Append("[");
                    for (int j = 0; j < result[i].Length; ++j)
                    {
                        sb.Append(result[i][j].ToString());

                        if (j != result[i].Length - 1)
                        {
                            sb.Append(", ");
                        }
                    }
                    sb.Append("]");

                    if (i != result.Length - 1)
                    {
                        sb.Append(", ");
                    }
                }

                sb.Append("]");

                return sb.ToString();

        }

        public static string Output(SingleListNode node)
        {
            StringBuilder sb = new StringBuilder("[");
            while (node != null)
            {
                sb.Append(node.val.ToString());

                if (node.next != null)
                {
                    sb.Append(",");
                }
                node = node.next;
            }
            sb.Append(']');
            return sb.ToString();
        }
    }
}
