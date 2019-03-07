using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class StartSceneState:ISceneState
{
   
    public StartSceneState(SceneStateController controller):base("01-StartScene",controller)
    {
        Controller = controller;   
    }

    private Image mLogo;
    //动画播放速度
    private float mSmoothingSpeed = 1;
    //等待的时间
    private float mWaitTime = 2;
  
    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
    }

    public override void StateUpdate()
    {
        //颜色由黑变白
        mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingSpeed * Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if(mWaitTime <= 0)
        {
            Controller.SetState(new MainMenuSceneState(Controller));
        }
    }

    public override void StateEnd()
    {

    }
}

