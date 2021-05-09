namespace Tragate.UI.Common.Enums
{
    public enum StatusType : byte
    {
        All = 0,
        New = 1,
        WaitingApprove = 2,
        Active = 3,
        Deleted = 4,
        Passive = 5,
        Transferred = 6
    }

    public enum UserType : byte
    {
        Person = 1,
        Company = 2
    }

    public enum RegisterType : byte
    {
        Tragate = 1,
        Facebook = 2,
        Google = 3,
        Linkedin = 4
    }

    public enum SearchType
    {
        Product,
        Company
    }
    public enum PlatformType
    {
        Web = 1,
        Admin = 2
    }

    public enum QuotationContactStatus : byte
    {
        WaitingBuyerResponse = 1,
        BuyerRead = 2,
        WaitingSellerResponse = 3,
        SellerRead = 4
    }
}