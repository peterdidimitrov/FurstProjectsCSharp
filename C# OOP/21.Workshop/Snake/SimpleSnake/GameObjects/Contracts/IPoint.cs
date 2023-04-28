namespace SimpleSnake.GameObjects.Contracts;

public interface IPoint
{
    public int LeftX { get; }
    public int TopY { get; }
    void Draw(char symbol);
    void Draw(int leftX, int topY, char symbol);
}
