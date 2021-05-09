using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Quotation;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Quotation;

namespace Tragate.UI.Services.Quote
{
    public interface IQuotationService
    {
        BaseResponse AddQuotation(QuotationAddViewModel model);

        QuotationResponseMessage GetQuotationList(int page, int pageSize, int quoteStatusId, int? orderStatusId, int? sellerCompanyId, int? buyerUserId);

        QuotationViewResponse GetQuotationById(int quoteId);

        QuotationProductResponse GetQuotationProducts(int quoteId);

        QuotationHistoryResponse GetQuotationHistories(int quoteId);

        BaseResponse AddQuotationHistory(QuotationHistoryAddViewModel model);

        BaseResponse QuotationContactStatusUpdate(int quoteId, int buyerContactStatusId, int sellerContactStatusId);
    }
}
