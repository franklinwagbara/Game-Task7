public sealed class Game
{
    private static readonly Lazy<Game> _instance = new(() => new Game());
    public static Game Instance => _instance.Value;
    static Game()
    {
    }

    private Game()
    {
        World = new World(10, 10);
    }

    public World? World { get; set; }
}

public record Cell
{
    public string Name { get; init; } = "Empty";
    public int X { get; init; }
    public int Y { get; init; }
}

public class World
{
    public int Width { get; init; }
    public int Height { get; init; }
    public Cell[,] Grid { get; init; }

    public World(int width, int height)
    {
        Width = width;
        Height = height;
        Grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Grid[x, y] = new Cell { X = x, Y = y };
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
        }
        return Grid[x, y];
    }

    public void SetCellName(int x, int y, string name)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
        }
        Grid[x, y] = Grid[x, y] with { Name = name };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var game = Game.Instance;
        var newWorld = new World(10, 8);
        game.World = newWorld;

        int x = 1;
        int y = 1;
        Console.WriteLine("Cell X = {0}, Y = {1}: {2}", x, y, game.World.GetCell(x, y));
    }
}
