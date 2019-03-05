using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private SoldierKilledSubject mSubject;
    private ArchievementSystem mArchievementSystem;

    public SoldierKilledObserverAchievement(ArchievementSystem arc)
    {
        mArchievementSystem = arc;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as SoldierKilledSubject;
    }

    public override void Update()
    {
        mArchievementSystem.AddSoldierKilledCount();
    }
}

