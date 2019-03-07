using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI:IUISystem
{
    public List<GameObject> mHearts = new List<GameObject>();
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurretStage;
    private Button mPauseBtn;
    private Button mBackMenuBtn;
    private GameObject mGameOverUI;
    private Text mMessage;
    private Slider mEnergySlider;
    private Text mEnergyText;

    private GameObject mPauseUI;

    private float mMsgTimer = 0;
    //提示信息显示时间
    private int mMsgTime = 2;
    private AliveCountVisit mAliveCountVisitor = new AliveCountVisit();

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateInfoUI");
        mPauseUI = UnityTool.FindChild(canvas, "GamePauseUI");

        GameObject heart1 = UnityTool.FindChild(mRootUI, "Heart1");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "Heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "Heart3");
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);

        mSoldierCount = UITools.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITools.FindChild<Text>(mRootUI, "EnemyCount");
        mCurretStage = UITools.FindChild<Text>(mRootUI, "StageCount");
        mPauseBtn = UITools.FindChild<Button>(mRootUI, "PauseButton");
        mBackMenuBtn = UITools.FindChild<Button>(mRootUI, "BackMenuButton");
        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOver");
        mMessage = UITools.FindChild<Text>(mRootUI, "Message");
        mEnergySlider = UITools.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITools.FindChild<Text>(mRootUI, "EnergyText");

        mMessage.text = "";
        mGameOverUI.SetActive(false);

        //注册观察者
        mFacade.RegisterObserver(GameEventType.EnemyEscaped, new EnemyEscapedObserverGameStateInfoUI(this));

        //暂停按钮监听事件
        mPauseBtn.onClick.AddListener(() => 
        {
            mPauseUI.SetActive(true);
            Time.timeScale = 0;
        });

        //游戏结束返回菜单按钮监听事件
        mBackMenuBtn.onClick.AddListener(() =>
        {
            if (mFacade.IsGameOver == false)
                mFacade.IsGameOver = true;
            Time.timeScale = 1;
        });
    }

    public override void Update()
    {
        //Debug.Log(mHearts[0].name + mHearts[1].name + mHearts[2].name);
        base.Update();
        UpdateAliveCount();
        UpdateStageLevel();
        if(mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if(mMsgTimer <= 0)
            {
                mMessage.text = null;
            }
        }
    }
    //显示提示信息
    public void ShowMsg(string msg)
    {
        mMessage.text = msg;
        mMsgTimer = mMsgTime;
    }
    //更新能量条
    public void UpdateEnergySlider(int curretEnergy, int maxEnergy)
    {
        mEnergySlider.value = (float)curretEnergy / maxEnergy;
        mEnergyText.text = "(" + curretEnergy + " / " + maxEnergy + ")";
    }
    //更新士兵和敌人存活数量
    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mFacade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.soldierCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.enemyCount.ToString();
    }

    public void UpdateStageLevel()
    {
        mCurretStage.text = mFacade.stageLevel.ToString();
    }

    public void GameOver()
    {
        mGameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}

