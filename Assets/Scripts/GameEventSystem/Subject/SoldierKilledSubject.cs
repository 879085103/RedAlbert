using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierKilledSubject:IGameEventSubject
{
    private int mKilledSoldierCount = 0;

    public int killedSoldierCount { get { return mKilledSoldierCount; } }

    public override void NotifyObservers()
    {
        mKilledSoldierCount++;
        base.NotifyObservers();
    }
}

