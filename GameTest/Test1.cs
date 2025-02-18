using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class GameTests
{
    [TestMethod]
    public void Game_SingletonInstance_NotNull()
    {
        Assert.IsNotNull(Game.Instance);
    }

    [TestMethod]
    public void World_Initialization_CreatesGridWithCorrectDimensions()
    {
        int width = 10;
        int height = 5;
        World world = new(width, height);

        Assert.AreEqual(width, world.Width);
        Assert.AreEqual(height, world.Height);
        Assert.AreEqual(width, world.Grid.GetLength(0));
        Assert.AreEqual(height, world.Grid.GetLength(1));
    }

    [TestMethod]
    public void World_Initialization_CellsHaveCorrectCoordinates()
    {
        int width = 3;
        int height = 2;
        World world = new(width, height);

        Assert.AreEqual(0, world.Grid[0, 0].X);
        Assert.AreEqual(0, world.Grid[0, 0].Y);

        Assert.AreEqual(1, world.Grid[1, 0].X);
        Assert.AreEqual(0, world.Grid[1, 0].Y);

        Assert.AreEqual(2, world.Grid[2, 0].X);
        Assert.AreEqual(0, world.Grid[2, 0].Y);

        Assert.AreEqual(0, world.Grid[0, 1].X);
        Assert.AreEqual(1, world.Grid[0, 1].Y);

        Assert.AreEqual(1, world.Grid[1, 1].X);
        Assert.AreEqual(1, world.Grid[1, 1].Y);

        Assert.AreEqual(2, world.Grid[2, 1].X);
        Assert.AreEqual(1, world.Grid[2, 1].Y);
    }

    [TestMethod]
    public void World_GetCell_ReturnsCorrectCell()
    {
        int width = 5;
        int height = 5;
        World world = new(width, height);

        Cell cell = world.GetCell(2, 3);

        Assert.AreEqual(2, cell.X);
        Assert.AreEqual(3, cell.Y);
    }

    [TestMethod]
    public void World_GetCell_OutOfBounds_ThrowsException()
    {
        int width = 5;
        int height = 5;
        World world = new(width, height);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.GetCell(-1, 0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.GetCell(0, -1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.GetCell(width, 0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.GetCell(0, height));
    }

    [TestMethod]
    public void World_SetCellName_ChangesCellName()
    {
        int width = 2;
        int height = 2;
        World world = new(width, height);

        string newName = "Mountain";
        world.SetCellName(1, 0, newName);

        Assert.AreEqual(newName, world.GetCell(1, 0).Name);
    }

    [TestMethod]
    public void World_SetCellName_OutOfBounds_ThrowsException()
    {
        int width = 2;
        int height = 2;
        World world = new(width, height);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.SetCellName(-1, 0, "Test"));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.SetCellName(0, -1, "Test"));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.SetCellName(width, 0, "Test"));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => world.SetCellName(0, height, "Test"));
    }
}