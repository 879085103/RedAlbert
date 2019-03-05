using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IGameEventSubject
{
    //注册了当前主题的所有观察者的集合
    private List<IGameEventObserver> mGameEventObservers = new List<IGameEventObserver>();

    //注册观察者的方法
    public void RegisterObserver(IGameEventObserver ob)
    {
        mGameEventObservers.Add(ob);
    }
    //移除观察者的方法
    public void RemoveObserver(IGameEventObserver ob)
    {
        mGameEventObservers.Remove(ob);
    }
    //调用观察者的Update方法
    public virtual void NotifyObservers()
    {
        foreach(IGameEventObserver ob in mGameEventObservers)
        {
            ob.Update();
        }
    }
}

