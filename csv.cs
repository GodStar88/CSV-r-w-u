public void csvUpdate( int lineNumber)
{
    string path = "profile.csv";
    string[] lines = File.ReadAllLines(path);

    string line = lines[lineNumber];
    if (line.Contains(","))
    {
        var split = line.Split(',');

        split[2] = (int.Parse(split[2].ToString()) + 1).ToString();
        line = string.Join(",", split);
    }
    lines[lineNumber] = line;
    File.WriteAllLines(@"profile.csv", lines);
}

public void csvWrite(string name, string str, string url)
{
    string path = "profile.csv";
    var csv = new StringBuilder();
    var newLine = string.Format("{0},{1},{2},{3}", name, str, "0", url);
    csv.AppendLine(newLine);
    File.AppendAllText(path, csv.ToString());
}
public void csvRead()
{
    try
    {
        for (int i = likeUser.Rows.Count - 1; i >= 0; i--)
        {
            likeUser.Rows.RemoveAt(i);
        }
    }
    catch (Exception)
    {
    }

    if (!File.Exists("profile.csv"))
    {
        File.CreateText("profile.csv");
    }

    try
    {
        using (StreamReader readFile = new StreamReader("profile.csv"))
        {
            string line;
            string[] row;
            int count = 1;
            while ((line = readFile.ReadLine()) != null)
            {
                row = line.Split(',');
                likeUser.Rows.Add(false, count.ToString(),row[0], row[1], row[2], row[3]);
                count++;
            }
        }
        likeUser.ClearSelection();
    }
    catch (Exception)
    {
    }
}

public bool csvCheck(string name)
{
    try
    {
        using (StreamReader readFile = new StreamReader("profile.csv"))
        {
            string line;
            string[] row;
            while ((line = readFile.ReadLine()) != null)
            {
                row = line.Split(',');
                if (row[0] == name) return false;
            }
        }
        return true;
    }
    catch (Exception)
    {
    }
    return true;
}