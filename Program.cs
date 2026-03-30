using Retro_Snake_Game;



Coord griddimensions = new Coord(50, 20);
Coord snakePos = new Coord(10, 0);


for (int y = 0; y < griddimensions.Y; y++)
{
    for (int x = 0; x < griddimensions.X; x++)
    {

        Coord currentCoord = new Coord(x, y);

        if (snakePos == currentCoord)
        {
            Console.Write("■");
        }
        else if (x == 0 || y == 0 || x == griddimensions.X - 1 || y == griddimensions.Y - 1)
            Console.Write("#");
        else
            Console.Write(" ");
    }

    Console.WriteLine();
}



