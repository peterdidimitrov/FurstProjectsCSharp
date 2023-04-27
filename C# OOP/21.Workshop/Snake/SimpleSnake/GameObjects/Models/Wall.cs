namespace SimpleSnake.GameObjects.Models;
public class Wall : Point
{
    private const char WallSymbol = '\u25A0';
    public Wall(int leftX, int topY)
        : base(leftX, topY)
    {
        DrawWall();
    }
    private void DrawHorizontalLine(int topY)
    {
        for (int leftX = 0; leftX < LeftX; leftX++)
        {
            Draw(leftX, topY, WallSymbol);
        }
    }
    private void DrawVerticalLine(int leftX)
    {
        for (int topY = 0; topY < TopY; topY++)
        {
            Draw(leftX, topY, WallSymbol);
        }
    }
    private void DrawWall()
    {
        DrawHorizontalLine(0);
        DrawHorizontalLine(TopY - 1);

        DrawVerticalLine(0);
        DrawVerticalLine(LeftX - 1);
    }
    public bool IsPointOfWall(Point snake)
       => snake.TopY == 0 || snake.LeftX == 0 || 
          snake.LeftX == LeftX - 1 || snake.TopY == TopY - 1;
}