using UnityEngine;

public class Power : Upgrade<int>
{
    int power;
    float powerStep;
    public Power() : base("Power")
    {
        price = 1;
        priceStep = 3;
        power = 1;
        powerStep = 2.0f;

        SetText(power);
    }
    public Power(int initialPrice, int priceStepValue, int initialPower, float powerStepValue) : base("Power")
    {
        price = initialPrice;
        priceStep = priceStepValue;
        power = initialPower;
        powerStep = powerStepValue;

        SetText(power);
    }
    public override int GetPrice()
    {
        return price;
    }
    public override int Purchase()
    {
        int currentValue = power;
        level += 1; //레벨은 1씩 증가
        price *= priceStep;
        power = Mathf.RoundToInt(power * powerStep);
        SetText(power);

        return currentValue;
    }
    public override int GetValue()
    {
        return power;
    }
}
