namespace BusinessLayer.Provider
{
    public interface IProvider<T>
    {
        void Execute(T model);
    }
}
