using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;

    public EnemyKilledObserverStageSystem(StageSystem stageSystem)
    {
        mStageSystem = stageSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;
    }

    public override void Update()
    {
        //更新敌人死亡次数
        mStageSystem.countOfEnemyKilled = mSubject.killedEnemyCount;
    }
}

