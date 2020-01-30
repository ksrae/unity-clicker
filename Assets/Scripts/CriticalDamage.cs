using UnityEngine;
public class CriticalDamage : Upgrade<int>
{
    int criticalDamage;
    float criticalDamageStep;
    public CriticalDamage() : base("CriticalDamage")
    {
        price = 1;
        priceStep = 3;
        criticalDamage = 1;
        criticalDamageStep = 2.0f;

        SetText(criticalDamage);
    }
    public CriticalDamage(int initialPrice, int priceStepValue, int initialCriticalDamageValue, float criticalDamageStepValue) : base("CriticalDamage")
    {
        price = initialPrice;
        priceStep = priceStepValue;
        criticalDamage = initialCriticalDamageValue;
        criticalDamageStep = criticalDamageStepValue;

        SetText(criticalDamage);
    }
    public override int GetPrice()
    {
        return price;
    }
    public override int Purchase()
    {
        int currentValue = criticalDamage;
        level += 1; //레벨은 1씩 증가
        price *= priceStep;
        criticalDamage = Mathf.RoundToInt(criticalDamage * criticalDamageStep);
        SetText(currentValue);

        return currentValue;
    }
    public override int GetValue()
    {
        return criticalDamage;
    }
}
