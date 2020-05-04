using Labs.Core.Models;

namespace Labs.Core.Providers
{
    public interface IProvider
    {
        DataSource Build();
    }
}