
namespace Smart.Core
{
    /// <summary>
    /// A type of a discount
    /// </summary>
    public enum DiscountType
    {
        //Types for discounts associated with products
        ProductPercentOne = 0,
        ProductPercentAll = 1,
        ProductGift = 2,

        //Types for discounts associated with whole orders (bills)
        BillPercentMinCount = 3,
        BillPercentBillSumm = 4,
        BillPercentMinProductCount = 5,
        BillPercentBillSummMinProductCount = 6,
        BillGiftMinCount = 7,
        BillGiftBillSumm = 8,
        BillGiftMinProductCount = 9,
        BillGiftBillSummMinProductCount = 10,
        BillSummMinCount = 11,
        BillSummBillSumm = 12,
        BillSummMinProductCount = 13,
        BillSummBillSummMinProductCount = 14

    }


}
