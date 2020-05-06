namespace Labs.Core.Shared
{
    public interface IDataProvider<out T>
        where T : IDataSource
    {
        T Build(string context);
    }
}