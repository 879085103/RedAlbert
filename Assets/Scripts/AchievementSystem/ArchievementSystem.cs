using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ArchievementSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLevel = 1;

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverAchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverAchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievement(this));
    }

    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
        Debug.Log("EnemyKilledCount:" + mEnemyKilledCount);
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldierKilledCount += number;
        Debug.Log("SoldierKilledCount:" + mSoldierKilledCount);
    }

    public void SetMaxStageLevel(int stageLevel)
    {
        if(stageLevel > mMaxStageLevel)
        {
            mMaxStageLevel = stageLevel;
        }
        Debug.Log("MaxStageLevel:" + mMaxStageLevel);
    }
    //创建快照
    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStageLevel;
        return memento;
    }
   public void SetMemento(AchievementMemento memento)
    {
        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStageLevel = memento.maxStageLv;
    }
}

