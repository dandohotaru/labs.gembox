namespace Labs.Core.Shared
{
    public interface IReportExporter
    {
        void Export<T>(T data) where T : IReportData;
    }
}