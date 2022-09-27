using System.Threading.Tasks;
using Abp.Dependency;

namespace Framework.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}