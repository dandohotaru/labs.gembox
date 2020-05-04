using Labs.Core.Models;

namespace Labs.Core.Exporters
{
    public interface IExporter
    {
        void Export(DataSource data);
    }
}
