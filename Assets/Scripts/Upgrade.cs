using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade<T>
{
    GameObject obj;
    Text[] txtGroup;
    Text txtValue;
    Text txtLevel;
    Text txtPrice;

    protected int level { get; set; } = 1;
    protected int price { get; set; }
    protected int priceStep { get; set; }

    public Upgrade(string objectName)
    {
        obj = GameObject.Find(objectName);
        txtGroup = obj.GetComponentsInChildren<Text>();

        foreach(Text txt in txtGroup)
        {
            switch (txt.gameObject.name) {
                case "Value":
                    txtValue = txt;
                    break;
                case "Level":
                    txtLevel = txt;
                    break;
                case "Price":
                    txtPrice = txt;
                    break;
            }
        }
    }
    public virtual void SetText(T value)
    {
        txtValue.text = value.ToString();
        txtLevel.text = level.ToString();
        txtPrice.text = price.ToString();
    }
    public abstract T Purchase();
    public abstract int GetPrice();
    public abstract T GetValue();

}
