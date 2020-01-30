using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceImages
{
    public static Object[] stageImages { get; set; }
    public static Object[] enemyImages { get; set; }
    
    public static void SetImages()
    {
        stageImages = Resources.LoadAll("Stages");
        enemyImages = Resources.LoadAll("Enemies");
    }

    public static Sprite GetStageImage(int index)
    {
        return stageImages?.Length > 0 ? stageImages[(index * 2) + 1] as Sprite : null;
    }
    public static Sprite GetEnemyImage(int index)
    {
        return enemyImages?.Length > 0 ? enemyImages[(index * 2) + 1] as Sprite : null;
    }
}
