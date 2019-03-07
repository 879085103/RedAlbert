using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyEscapedSubject:IGameEventSubject
{
    private int mEscapedEnemy = 0;
    public int escapedEnemy { get { return mEscapedEnemy; } }

    public override void NotifyObservers()
    {
        mEscapedEnemy++;
        base.NotifyObservers();
    }
}

