using UnityEngine;

public class Menu
{
    // Start is called before the first frame update
    private GameObject[] tabs;
    private GameObject[] menus;
    private StageTab stageTab;
    private StatisticTab statisticTab;
    private bool isOpened = false;
    public Menu(int maxStages)
    {
        // 탭 패널을 배열화
        tabs = GameObject.FindGameObjectsWithTag("Tab");
        menus = GameObject.FindGameObjectsWithTag("Menu");

        stageTab = new StageTab(maxStages);
        statisticTab = new StatisticTab();

        for (int i = 0; i < tabs.Length; i++)
        {
            int idx = i;
            // 모든 탭 비활성화
            tabs[idx].SetActive(false);
        }
        SetStage(1);
    }
    public void SelectMenu(string name)
    {
        isOpened = false;
        
        for (int i = 0; i < menus.Length; i++)
        {
            int idx = i;

            if (menus[idx].name == name)
            {
                tabs[idx].SetActive(!tabs[idx].activeSelf);
                isOpened = true;
            }
            else
            {
                tabs[idx].SetActive(false);
            }
        }
    }
    public void CloseMenu() {
        if(isOpened) {
            foreach(GameObject t in tabs) {
                t.SetActive(false);
            }
            isOpened = false;
        }
    }
    public void SetStage(int currentStage)
    {
        stageTab.ActiveStage(currentStage);
    }
    public void SetStatisticTab(Player player, int stage, int attackCount, int playTime)
    {
        statisticTab.set(player, stage, attackCount, playTime);
    }

}
