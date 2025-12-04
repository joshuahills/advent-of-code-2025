string[] input = await File.ReadAllLinesAsync("input.txt");

ulong invalidTotal = 0;

foreach (string row in input)
{
  string[] ranges = row.Split(',');

  foreach (string range in ranges)
  {
    string[] splitRange = range.Split('-');
    ulong first = ulong.Parse(splitRange[0]);
    ulong last = ulong.Parse(splitRange[1]);

    for (ulong id = first; id <= last; id++)
    {
      if (!IsValid(id))
      {
        invalidTotal += id;
      }
    }
  }
}

Console.WriteLine(invalidTotal);

static bool IsValid(ulong id)
{
  string idStr = id.ToString();
  int idLen = idStr.Length;

  for (int patternLen = 1; patternLen <= idLen / 2; patternLen++)
  {
    if (idLen % patternLen != 0)
    {
      continue;
    }

    string pattern = idStr.Substring(0, patternLen);
    bool isRepeating = true;

    for (int i = patternLen; i < idLen; i += patternLen)
    {
      if (idStr.Substring(i, patternLen) != pattern)
      {
        isRepeating = false;
        break;
      }
    }

    if (isRepeating)
    {
      return false;
    }
  }

  return true;
}