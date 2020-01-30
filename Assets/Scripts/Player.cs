using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    Text txtGold;
    public string name { get; set; }
    public int gold { get; private set; } = 10000;
    public int currentPower { get; private set; }
    public int currentCriticalDamage { get; private set; }
    public float currentCriticalPercentage { get; private set; }
    public int currentAutoGold { get; private set; }
    public bool isAutoGoldStart { get; private set; } = false;
    
    public Player(Status status)
    {
        // 초기값 설정
        txtGold = GameObject.Find("TextGold").GetComponent<Text>();

        currentPower = status.power.GetValue();
        currentCriticalDamage = status.criticalDamage.GetValue();
        currentCriticalPercentage = status.criticalPercentage.GetValue();
        currentAutoGold = status.autoGold.GetValue();
        UpdateInfo();
    }
    public int GetCurrentGold()
    {
        return gold;
    }
    private bool Buy(int price)
    {
        if (gold >= price)
        {
            gold -= price;
            return true;
        }
        return false;
    }
    public void GetPrize(int prize)
    {
        gold += prize;
        UpdateInfo();
    }
    public void StatusUp(string objName, Status status) 
    {
        switch (objName)
        {
            case "PowerUp":
                PowerUp(status.power);
                break;
            case "CriticalDamageUp":
                CriticalDamageUp(status.criticalDamage);
                break;
            case "CriticalPercentageUp":
                CriticalPercentageUp(status.criticalPercentage);
                break;
            case "AutoGoldUp":
                AutoGoldUp(status.autoGold);
                break;
        }

        UpdateInfo();
    }
    private void PowerUp(Power power)
    {
        if (Buy(power.GetPrice()))
        {
            currentPower = power.Purchase();   
        }
    }
    private void CriticalDamageUp(CriticalDamage criticalDamage)
    {
        if (Buy(criticalDamage.GetPrice()))
        {
            currentCriticalDamage = criticalDamage.Purchase();
        }
    }
    private void CriticalPercentageUp(CriticalPercentage criticalPercentage)
    {
        if (Buy(criticalPercentage.GetPrice()))
        {
            currentCriticalPercentage = criticalPercentage.Purchase();
        }
    }
    private void AutoGoldUp(AutoGold autoGold)
    {
        if (Buy(autoGold.GetPrice()))
        {
            currentAutoGold = autoGold.Purchase();
            if (!isAutoGoldStart) isAutoGoldStart = true;
        }
    }
    private void UpdateInfo()
    {
        txtGold.text = gold.ToString();
    }
    public int CalculateDamage()
    {
        // 크리티컬 터졌는지 확인
        // 파워 + (터졌으면)크리티컬 데미지
        // 총 파워값 리턴
        return IsCritical() ? currentPower + currentCriticalDamage : currentPower;
    }
    private bool IsCritical()
    {
        return currentCriticalPercentage >= Random.Range(0f, 100f);
    }
    public IEnumerator AddAutoGoldPerSec()
    {
        // 초당 골드 증가
        while (true)
        {
            if (isAutoGoldStart)
            {
                gold += currentAutoGold;
                UpdateInfo();
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
