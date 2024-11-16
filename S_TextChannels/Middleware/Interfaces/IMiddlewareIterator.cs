namespace S_TextChannels.Middleware.Interfaces
{
    public interface IMiddlewareIterator
    {
        IMiddlaware? GetNext();

        bool IsDone();
    }
}
