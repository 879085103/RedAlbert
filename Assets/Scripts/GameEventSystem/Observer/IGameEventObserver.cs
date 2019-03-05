using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IGameEventObserver
{
    public abstract void Update();
    //设置主题的方法
    public abstract void SetSubject(IGameEventSubject sub);
}

