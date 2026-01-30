using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            // Ignorar casos como "aa"
            if (word[0] == word[1])
                continue;

            string reversed = $"{word[1]}{word[0]}";

            if (set.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
                set.Remove(word);
                set.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var dict = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!dict.ContainsKey(c))
                return false;

            dict[c]--;

            if (dict[c] < 0)
                return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double mag = feature.Properties.Mag ?? 0;
            result.Add($"{place} - Mag {mag}");
        }

        return result.ToArray();
    }
}
