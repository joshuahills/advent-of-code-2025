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

  if (idLen % 2 !=0)
  {
    return true;
  }
  
  int half = idLen / 2;
  string firstHalf = idStr.Substring(0, half);
  string secondHalf = idStr.Substring(half);
  
  return firstHalf != secondHalf;
}