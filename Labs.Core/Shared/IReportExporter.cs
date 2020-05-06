namespace Labs.Core.Shared
{
    public interface IReportExporter<in T>
        where T : IReportData
    {
        void Export(T data);
    }
}