using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IStageHandler
{
    //当前关卡
    protected int mLevel;
    protected int mCountToFinished;
    protected IStageHandler mNextHandler;
    protected StageSystem mStageSystem;

    public IStageHandler(StageSystem stageSystem,int level,int countToFinished)
    {
        mStageSystem = stageSystem;
        mLevel = level;
        mCountToFinished = countToFinished;
    }

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }

    public void Handle(int level)
    {
        if(mLevel == level)
        {
            UpdateStage();
            CheckIsFinished();
        }
        else
        {
            mNextHandler.Handle(level);
        }
    }

    protected virtual void UpdateStage() { }
    //检查关卡是否结束
    private void CheckIsFinished()
    {
        if(mStageSystem.GetCountOfEnemyKilled() >= mCountToFinished)
        {
            mStageSystem.EnterNextStage();
        }
    }
}


