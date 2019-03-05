using System;
using System.Collections.Generic;
using System.Text;

public class ISceneState
{
    private string mSceneName;

    public string SceneName
    {
        get { return mSceneName; }
    }
    
    //状态拥有者
    private SceneStateController mController;

    public SceneStateController Controller
    {
        get { return mController; }
        set { mController = value; }
    }


    public ISceneState(string sceneName, SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }
    //进入场景时的操作
    public virtual void StateStart() { }
    //退出场景时的操作
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}
