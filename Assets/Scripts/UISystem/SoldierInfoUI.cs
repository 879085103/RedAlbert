using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoUI:IUISystem
{
    private Image mSoldierIcon;
    private Text mSoldierName;
    private Text mHPText;
    private Slider mHPSlider;
    private Text mLevel;
    private Text mAtk;
    private Text mAtkRange;
    private Text mMoveSpeed;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITools.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITools.FindChild<Text>(mRootUI, "SoldierName");
        mHPText = UITools.FindChild<Text>(mRootUI, "HP");
        mHPSlider = UITools.FindChild<Slider>(mRootUI, "HPSlider");
        mLevel = UITools.FindChild<Text>(mRootUI, "Level");
        mAtk = UITools.FindChild<Text>(mRootUI, "Atk");
        mAtkRange = UITools.FindChild<Text>(mRootUI, "AtkRange");
        mMoveSpeed = UITools.FindChild<Text>(mRootUI, "MoveSpeed");

        Hide();
    }
}
