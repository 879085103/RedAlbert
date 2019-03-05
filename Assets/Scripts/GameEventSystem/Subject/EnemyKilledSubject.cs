using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//敌人死亡主题，敌人死亡时调用NotifyObservers()
public class EnemyKilledSubject:IGameEventSubject
{
    private int mKilledEnemyCount = 0;

    public int killedEnemyCount { get { return mKilledEnemyCount; } }

    public override void NotifyObservers()
    {
        mKilledEnemyCount++;
        base.NotifyObservers();
    }
}

