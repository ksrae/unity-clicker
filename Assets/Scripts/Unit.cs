using UnityEngine.UI;
public abstract class Unit 
{
    // 이름
    protected string name { get; set; }
    // 레벨
    protected int level { get; set; } = 1;
    // 최대 HP
    protected int maxHP { get; set; }
    // 현재 HP
    protected int currentHP { get; set; }
    // 보유한 골드. 죽으면 뱉음
    protected int gold { get; set; }
    // 레벨 당 증가할 maxHP 값.
    protected float maxHPStep { get; set; }
    // 레벨 당 증가할 골드 값.
    protected float goldStep { get; set; }
    // 이미지
    protected Image image { get; set; }
    // player의 파워에 맞음. 죽으면 골드를 뱉음.
    public abstract int Hit(int power);
    // 레벨이 오르거나 Unit이 죽으면 재생산
    public abstract void Set(int level);
}
