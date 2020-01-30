using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatisticTab : TabPrefeb
{
    private Dictionary<string, string> contents;

    public delegate void Set(Player player, int stage, int aCount, int pTime);
    public Set set;
    
    public StatisticTab()
    {
        contents = new Dictionary<string, string>()
        {
            { "공격력", "0" },
            { "크리티컬 데미지", "0"},
            { "크리티컬 퍼센트", "0"},
            { "자동 골드", "0"},
            { "총 골드량", "0"},
            { "공격 횟수", "0"},
            { "현재 스테이지", "0"},
            { "플레이 시간", "00:00:00"}
        };

        SetPrefeb(contents.Count);
        items = GameObject.FindGameObjectsWithTag("Statistic");

        set = (Player player, int stage, int aCount, int pTime) =>
        {
            string strTime = SetPlayTime(pTime);
            SetData(player, stage, aCount, strTime);
            Print();
        };
    }
    protected override void SetPrefeb(int length)
    {
        parent = GameObject.Find("StatisticGroup").GetComponent<RectTransform>();
        GameObject temp = Resources.Load("Prefebs/Statistic") as GameObject;

        for (int i = 0; i < length; i++)
        {
            Object.Instantiate(temp, parent);
        }
    }
    public void SetData(Player player, int stage, int aCount, string strTime)
    {
        contents["공격력"] = player.currentPower.ToString();
        contents["크리티컬 데미지"] = player.currentCriticalDamage.ToString();
        contents["크리티컬 퍼센트"] = player.currentCriticalPercentage.ToString() + "%";
        contents["자동 골드"] = player.isAutoGoldStart ? player.currentAutoGold.ToString() : "0";
        contents["총 골드량"] = player.gold.ToString();
        contents["공격 횟수"] = aCount.ToString();
        contents["현재 스테이지"] = stage.ToString();
        contents["플레이 시간"] = strTime;
    }
    protected override void Print()
    {
        int i = 0;
        foreach (KeyValuePair<string, string> pair in contents)
        {
            Text[] textGroup = items[i].GetComponentsInChildren<Text>();
            textGroup[0].text = pair.Key;
            textGroup[1].text = pair.Value;
            i++;
        }
    }
    private string SetPlayTime(int pTime)
    {
        int hour = Mathf.FloorToInt(pTime / 3600);
        int min = Mathf.FloorToInt((pTime % 3600) / 60);
        int sec = pTime % 3600 % 60;

        string hh = hour < 10 ? "0" + hour.ToString() : hour.ToString();
        string mm = min < 10 ? "0" + min.ToString() : min.ToString();
        string ss = sec < 10 ? "0" + sec.ToString() : sec.ToString();

        return hh + ":" + mm + ":" + ss;
    }
}
