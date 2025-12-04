int currentPosition = 50;
int zeroCount = 0;

string[] input = await File.ReadAllLinesAsync("./input.txt");

foreach (string row in input)
{
  var direction = row[0];
  var distance = int.Parse(row[1..]);

  zeroCount += GetZeroCrossingCount(currentPosition, distance, direction);

  if (direction == 'L')
  {
    currentPosition = (currentPosition - distance) % 100;
    if (currentPosition < 0) currentPosition += 100;
  }
  else if (direction == 'R')
  {
    currentPosition = (currentPosition + distance) % 100;
  }
}

static int GetZeroCrossingCount(int start, int distance, char direction)
{
  int count = 0;
  
  if (direction == 'L')
  {
    for (int i = 1; i <= distance; i++)
    {
      int pos = (start - i) % 100;
      if (pos < 0) pos += 100;
      if (pos == 0) count++;
    }
  }
  else if (direction == 'R')
  {
    for (int i = 1; i <= distance; i++)
    {
      int pos = (start + i) % 100;
      if (pos == 0) count++;
    }
  }
  
  return count;
}

Console.WriteLine(zeroCount);