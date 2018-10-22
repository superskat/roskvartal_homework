namespace DiscountСalculator
{
    public interface IDiscount
    {
        float CalculateDiscountPrice(dynamic discount);
        string GetSellInformation();
    }
}
