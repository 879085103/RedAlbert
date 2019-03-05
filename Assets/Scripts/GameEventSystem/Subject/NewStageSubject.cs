using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//新关卡的事件主题
public class NewStageSubject:IGameEventSubject
{
    private int mStageCount = 1;

    public int stageCount { get { return mStageCount; } }

    public override void NotifyObservers()
    {
        mStageCount++;
        base.NotifyObservers();
    }
}

