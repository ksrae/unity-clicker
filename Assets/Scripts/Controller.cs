using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IPointerClickHandler
{
    private int maxStages = 5;
    private int attackCount = 0;
    private int playTime = 0;

    private Object[] stageImages;
    private Stage stage;

    private Player player;
    private Status status;

    private Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        status = new Status(
            new Power(1, 3, 1, 2.0f),
            new CriticalDamage(1, 3, 1, 2.0f),
            new CriticalPercentage(1, 5, 0.1f, 0.1f),
            new AutoGold(1, 3, 1, 2)
        );

        ResourceImages.SetImages();

        stage = new Stage(maxStages);
        
        player = new Player(status);

        menu = new Menu(maxStages);

        StartCoroutine(player.AddAutoGoldPerSec());
        StartCoroutine(TimeCheck());
    }
    // 모든 이벤트 처리
    public void OnPointerClick(PointerEventData eventData)
    {
        // canvas: 모든 메뉴를 닫고, 공격을 함
        string objName = eventData.pointerEnter.name;
        string objTag = eventData.pointerEnter.tag;

        // Debug.Log(objName + " " + objTag);

        switch (objTag)
        {
            case "Menu":
                // menu: 선택한 메뉴의 탭 활성화
                menu.SelectMenu(objName);
                if (objName == "Menu-Statistic")
                {
                    menu.SetStatisticTab(player, stage.GetCurrentStage(), attackCount, playTime);
                }
                break;
            case "Background":
                menu.CloseMenu();
                Attack();
                break;
            case "Stage":
                StageUp();
                break;
            case "StatusUp":
                player.StatusUp(objName, status);
                break;
            default:
                break;
        }
    }
    private void Attack()
    {
        attackCount++;
        int damage = player.CalculateDamage();
        int prize = stage.Hit(damage);
        player.GetPrize(prize);
    }
    private void StageUp()
    {
        // stage: 스테이지 레벨이 올라감
        stage.SetNextStage();
        Debug.Log("GetCurrentStage:" + stage.GetCurrentStage());
        menu.SetStage(stage.GetCurrentStage());
    }

    public IEnumerator TimeCheck()
    {
        // 초당 골드 증가
        while (true)
        {
            playTime += 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
