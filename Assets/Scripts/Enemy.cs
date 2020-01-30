using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit
{
    private Image enemyImage;
    private Animator animator;
    private Slider hpSlider;
    private Text hpText;

    public Enemy(int num)
    {
        // 적 초기화
        maxHP = 5;
        currentHP = maxHP;
        maxHPStep = 3.5f;
        gold = 1;
        goldStep = 2.8f;
        level = 0;

        enemyImage = GameObject.Find("Enemy-Image").GetComponent<Image>();
        animator = GameObject.Find("Enemy-Image").GetComponent<Animator>();
        enemyImage.overrideSprite = ResourceImages.GetEnemyImage(0);
        
        hpSlider = GameObject.Find("HP-Slider").GetComponent<Slider>();
        hpText = GameObject.Find("HP-Text").GetComponent<Text>();
        Set();
    }
    public override void Set(int currentStageLevel = 0)
    {
        if(currentStageLevel > 0)
        {
            level = currentStageLevel;
            maxHP = Mathf.RoundToInt(maxHP * level * maxHPStep);
            gold = Mathf.RoundToInt(gold * level * goldStep);
            enemyImage.overrideSprite = ResourceImages.GetEnemyImage(level);

        }

        hpSlider.maxValue = maxHP;
        currentHP = maxHP;        
        SetHP();
    }
    public override int Hit(int power)
    {
        // enemy의 hp를 깎는다.
        // 만일 hp가 0보다 작으면 kill 애니메이션 적용
        // prefeb을 삭제하고 재생산한다.
        if (currentHP - power > 0)
        {
            currentHP -= power;
            SetHP();
            return 0;
        }
        else
        {
            animator.SetTrigger("Death");
            currentHP = 0;
            SetHP();
            Set();
            return gold;
        }
    }
    private void SetHP()
    {
        hpSlider.value = currentHP;
        hpText.text = currentHP.ToString();
    }
}
