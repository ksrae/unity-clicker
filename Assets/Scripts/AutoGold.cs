public class AutoGold : Upgrade<int>
{
    private int autoGold;
    private int autoGoldStep;
    public AutoGold() : base("AutoGold")
    {
        price = 1;
        priceStep = 3;
        autoGold = 1;
        autoGoldStep = 2;

        SetText(autoGold);
    }
    public AutoGold(int initialPrice, int priceStepValue, int initialAutoGold, int autoGoldStepValue) : base("AutoGold")
    {
        price = initialPrice;
        priceStep = priceStepValue;
        autoGold = initialAutoGold;
        autoGoldStep = autoGoldStepValue;

        SetText(autoGold);
    }
    public override int GetPrice()
    {
        // 현재 가격을 리턴
        return price;
    }
    public override int Purchase()
    {
        // 구매하였을 때
        // 레벨 1 증가
        // price 는 priceStep에 따라 증가(곱하기)
        // 값은 값step에 따라 증가(곱하기)
        // 화면에 출력
        // 구매 전 값을 리턴
        int currentValue = autoGold;
        level += 1; //레벨은 1씩 증가
        price *= priceStep;
        autoGold *= autoGoldStep;
        SetText(autoGold);

        return currentValue;
    }
    public override int GetValue()
    {
        return autoGold;
    }

}
