using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private ArchievementSystem mArchievementSystem;

    public NewStageObserverAchievement(ArchievementSystem arc)
    {
        mArchievementSystem = arc;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;    
    }

    public override void Update()
    {
        mArchievementSystem.SetMaxStageLevel(mSubject.stageCount);
    }
}

