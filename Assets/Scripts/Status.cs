using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public Power power { get; set; }
    public CriticalDamage criticalDamage { get; set; }
    public CriticalPercentage criticalPercentage { get; set; }
    public AutoGold autoGold { get; set; }

    public Status()
    {
        power = new Power(1, 3, 1, 2.0f);
        criticalDamage = new CriticalDamage(1, 3, 1, 2.0f);
        criticalPercentage = new CriticalPercentage(1, 5, 0.1f, 0.1f);
        autoGold = new AutoGold(1, 3, 1, 2);
    }
    public Status(Power pow, CriticalDamage criDamage, CriticalPercentage criPercentage, AutoGold aGold)
    {
        power = pow;
        criticalDamage = criDamage;
        criticalPercentage = criPercentage;
        autoGold = aGold;
    }
    
}
