int currentPosition = 50;
int zeroCount = 0;

string[] input = await File.ReadAllLinesAsync("./input.txt");

foreach (string row in input)
{
  var direction = row[0];
  var distance = int.Parse(row[1..]);

  if (direction == 'L')
  {
    currentPosition = (currentPosition - distance) % 100;

    if (currentPosition < 0)
    {
      currentPosition += 100;
    }
  }
  else if (direction == 'R')
  {
    currentPosition = (currentPosition + distance) % 100;
  }

  if (currentPosition == 0)
  {
    zeroCount++;
  }
}

Console.WriteLine(zeroCount);