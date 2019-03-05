using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyKilledObserverAchievement : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private ArchievementSystem mArchievementSystem;

    public EnemyKilledObserverAchievement(ArchievementSystem arc)
    {
        mArchievementSystem = arc;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;
    }

    public override void Update()
    {
        //增加敌人死亡计数
        mArchievementSystem.AddEnemyKilledCount();
    }
}

