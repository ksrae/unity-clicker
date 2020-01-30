using UnityEngine;
using UnityEngine.UI;

public class Stage
{
    private int level = 0;

    private bool enableToNextStage;
    private Image stageImage;

    public Enemy enemy { get; private set; }

    public Stage(int num)
    {
        stageImage = GameObject.Find("Background").GetComponent<Image>();
        enemy = new Enemy(num);
        
        SetNextStage();
    }
    public void SetNextStage()
    {
        stageImage.overrideSprite = ResourceImages.GetStageImage(level);
        enemy.Set(level);
        level += 1;
    }
    public int GetCurrentStage()
    {
        return level;
    }
    public int Hit(int damage)
    {
        // enemy == active
        return enemy.Hit(damage);
        // else if enemy == inactive , boss == active
        // return boss.Hit(damage);
    }
}
