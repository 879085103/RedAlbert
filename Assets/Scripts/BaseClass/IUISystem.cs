using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IUISystem
{
    protected GameFacade mFacade;

    //每一个界面对应的游戏物体
    public GameObject mRootUI;
    public virtual void Init() {
        mFacade = GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }

    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}
