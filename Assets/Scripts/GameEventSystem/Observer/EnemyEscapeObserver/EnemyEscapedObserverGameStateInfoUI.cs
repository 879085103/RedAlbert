using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyEscapedObserverGameStateInfoUI : IGameEventObserver
{
    private EnemyEscapedSubject mSubject;
    private GameStateInfoUI mGameStateInfoUI;

    public EnemyEscapedObserverGameStateInfoUI(GameStateInfoUI gameStateInfoUI)
    {
        mGameStateInfoUI = gameStateInfoUI;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyEscapedSubject;
    }

    public override void Update()
    {
        //每逃走一个敌人 就扣一点生命值
        mGameStateInfoUI.mHearts[3 - mSubject.escapedEnemy].SetActive(false);
        if(mSubject.escapedEnemy == 3)
        {
            mGameStateInfoUI.GameOver();
        }
    }
}

