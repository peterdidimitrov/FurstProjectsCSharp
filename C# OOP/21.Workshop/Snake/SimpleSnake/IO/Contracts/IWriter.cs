namespace SimpleSnake.IO.Contracts;

public interface IWriter<T>
{
    void Write(T text);
    void WriteLine(T text);
}
