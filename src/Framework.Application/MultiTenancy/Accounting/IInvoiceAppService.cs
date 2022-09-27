using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Framework.MultiTenancy.Accounting.Dto;

namespace Framework.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
