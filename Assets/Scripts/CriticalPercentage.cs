public class CriticalPercentage : Upgrade<float>
{
    float criticalPercentage;
    float criticalPercentageStep;
    public CriticalPercentage() : base("CriticalPercentage")
    {
        price = 1;
        priceStep = 3;
        criticalPercentage = 0.1f;
        criticalPercentageStep = 0.1f;

        SetText(criticalPercentage);
    }
    public CriticalPercentage(int initialPrice, int priceStepValue, float initialCriticalPercentage, float criticalPercentageStepValue) : base("CriticalPercentage")
    {
        price = initialPrice;
        priceStep = priceStepValue;
        criticalPercentage = initialCriticalPercentage;
        criticalPercentageStep = criticalPercentageStepValue;

        SetText(criticalPercentage);
    }
    public override int GetPrice()
    {
        return price;
    }
    public override float Purchase()
    {
        float currentValue = criticalPercentage;
        level += 1; //레벨은 1씩 증가
        price *= priceStep;
        criticalPercentage += criticalPercentageStep;
        SetText(currentValue);

        return currentValue;
    }
    public override float GetValue()
    {
        return criticalPercentage;
    }
}
