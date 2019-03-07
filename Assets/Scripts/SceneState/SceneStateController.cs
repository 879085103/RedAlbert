using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    public ISceneState mState;
    private AsyncOperation mAO;
    //判断是否执行了StateStart()
    public bool mIsRunStart = false;

    public void SetState(ISceneState state,bool isLoadScene = true)
    {
        if(mState != null)
        {
            mState.StateEnd();
        }
        mState = state;
        //需要加载的情况
        if(isLoadScene)
        {
            //异步加载
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
       
    }

    public void StateUpdate()
    {
        //当场景还在加载时，不执行StateUpdate()
        if (mAO != null && mAO.isDone == false)
            return;

        if(mAO != null && mAO.isDone == true && !mIsRunStart)
        {
            mState.StateStart();
            mIsRunStart = true;
        }
        if(mState != null)
        {
            mState.StateUpdate();
        }
    }

}
