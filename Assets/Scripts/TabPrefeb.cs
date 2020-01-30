using UnityEngine;

public abstract class TabPrefeb
{
    protected RectTransform parent { get; set; }
    protected GameObject[] items { get; set; }

    protected abstract void SetPrefeb(int length);
    protected abstract void Print();
}
