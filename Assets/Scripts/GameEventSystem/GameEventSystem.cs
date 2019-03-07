using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//定义一个枚举类型对应各个主题
public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage,
    EnemyEscaped
}

public class GameEventSystem:IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        //InitGameEvents();
    }
    //初始化mGameEvents
    private void InitGameEvents()
    {
        mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
        mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
        mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
    }

    public void RegisterObserver(GameEventType eventType,IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub == null)
            return;
        sub.RegisterObserver(observer);
        observer.SetSubject(mGameEvents[eventType]);
    }

    public void RemoveObserver(GameEventType eventType,IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub == null)
            return;
        sub.RegisterObserver(observer);
        observer.SetSubject(null);
    }

    //在获取时初始化mGameEvent
    private IGameEventSubject GetGameEvent(GameEventType eventType)
    {
        if (mGameEvents.ContainsKey(eventType) == false)
        {
            switch(eventType)
            {
                case GameEventType.EnemyKilled:
                    mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                    mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.NewStage:
                    mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                case GameEventType.EnemyEscaped:
                    mGameEvents.Add(GameEventType.EnemyEscaped, new EnemyEscapedSubject());
                    break;
                default:
                    Debug.LogError("没有对应事件类型" + eventType + "的主题类");
                    break;
            }
        }
        return mGameEvents[eventType];
    }

    public void NotifySubject(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub == null)
            return;
        sub.NotifyObservers();
    }
}

