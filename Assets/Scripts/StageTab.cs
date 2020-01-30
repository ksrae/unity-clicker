using UnityEngine;
using UnityEngine.UI;

public class StageTab : TabPrefeb
{
    public StageTab(int num)
    {
        SetPrefeb(num);
        items = GameObject.FindGameObjectsWithTag("Stage");
        Print();
    }
    protected override void SetPrefeb(int length)
    {
        
        parent = GameObject.Find("StageGroup").GetComponent<RectTransform>();
        GameObject temp = Resources.Load("Prefebs/Stage") as GameObject;

        for (int i = 0; i < length; i++)
        {
            Object.Instantiate(temp, parent);
        }
    }
    protected override void Print()
    {
        for (int i = 0; i < items.Length; i++)
        {
            Text t = items[i].GetComponentInChildren<Text>();
            t.text = "Stage " + (i + 1).ToString();
            Image img = items[i].GetComponent<Image>();
            img.overrideSprite = ResourceImages.GetStageImage(i);
        }
    }
    public void ActiveStage(int currentStage)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Image stageImage = items[i].GetComponent<Image>();
            if (i == currentStage)
            {
                stageImage.raycastTarget = true;
                stageImage.color = new Color(52 / 255f, 154 / 255f, 1 / 255f, 255 / 255f);
            } else
            {
                stageImage.raycastTarget = false;
                stageImage.color = Color.gray;
            }
            
        }
    }
}
