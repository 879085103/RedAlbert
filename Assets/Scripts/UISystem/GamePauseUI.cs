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

        mContinueBtn.onClick.AddListener(() =>
        {
            mRootUI.SetActive(false);
            Time.timeScale = 1;
        });

        mBackMenuBtn.onClick.AddListener(() =>
        {
            if(mFacade.IsGameOver  == false)
            mFacade.IsGameOver = true;
            Time.timeScale = 1;
        });

        Hide();
    }

    public override void Update()
    {
        base.Update();
        ShowStageLevel();
    }

    public void ShowStageLevel()
    {
        mCurretStageLevel.text = mFacade.stageLevel.ToString();
    }
}
