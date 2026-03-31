using Retro_Snake_Game;


Coord griddimensions = new Coord(50, 20);
Coord snakePos = new Coord(10, 1);
Random rand = new Random();
Coord applePos = new Coord(rand.Next(1, griddimensions.X - 1), rand.Next(1, griddimensions.Y - 1));
int frameDelayMilli = 100;
Direction movementDirection = Direction.Down;

List<Coord> snakePosHistory = new List<Coord>();
int tailLength = 1;

while (true)
{
    Console.Clear();
    snakePos.ApplyMovementDirection(movementDirection);
    for (int y = 0; y < griddimensions.Y; y++)
    {
        for (int x = 0; x < griddimensions.X; x++)
        {

            Coord currentCoord = new Coord(x, y);

            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
            {
                Console.Write("■");
            }
            else if (applePos.Equals(currentCoord))
                Console.Write("a");
            else if (x == 0 || y == 0 || x == griddimensions.X - 1 || y == griddimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }

        Console.WriteLine();
    }

    if (snakePos.Equals(applePos))
    {
        tailLength++;
        applePos = new Coord(rand.Next(1, griddimensions.X - 1), rand.Next(1, griddimensions.Y-1));
    }

    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));

    if (snakePosHistory.Count > tailLength)
        snakePosHistory.RemoveAt(0); 

    DateTime time = DateTime.Now;
    while((DateTime.Now-time).Milliseconds < frameDelayMilli)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.up;
                    break;
            }
        }
    }
}


