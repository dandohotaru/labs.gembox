namespace Labs.Core.Shared
{
    public interface IDataExporter<in T>
        where T : IDataSource
    {
        void Export(T data);
    }
}