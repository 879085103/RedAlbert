using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI:IUISystem
{
    private Text mCurretStageLevel;
    private Button mContinueBtn;
    private Button mBackMenuBtn;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");

        mCurretStageLevel = UITools.FindChild<Text>(mRootUI, "CurretStageLevel");
        mContinueBtn = UITools.FindChild<Button>(mRootUI, "ContinueButton");
        mBackMenuBtn = UITools.FindChild<Button>(mRootUI, "BackMenuButton");

        Hide();
    }
}
