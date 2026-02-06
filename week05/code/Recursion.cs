using System.Collections;

public static class Recursion
{
    // Problem 1
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    // Problem 3
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Problem 4
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string before = pattern[..index];
        string after = pattern[(index + 1)..];

        WildcardBinary(before + "0" + after, results);
        WildcardBinary(before + "1" + after, results);
    }

    // Problem 5
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, new List<(int, int)>(currPath));
            }
        }
    }
}
