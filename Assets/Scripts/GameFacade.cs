using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//外观模式 中介者模式
//管理BattleScene的各个子系统
public class GameFacade
{
    private static GameFacade _instance = new GameFacade();
    //私有化构造函数
    private GameFacade() { }

    public static GameFacade Instance { get { return _instance; } }

    private bool mIsGameOver = false;
    public bool IsGameOver
    {
        get { return mIsGameOver; }
        set { mIsGameOver = value; }
    }

    //获取所有的子系统
    private ArchievementSystem mArchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    //初始化各子系统
    public void Init()
    {
        mArchievementSystem = new ArchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mArchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();

        LoadMemento();

    }
    public void Update()
    {
        mArchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }
    public void Release()
    {

        mArchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();

        SaveMemento();
    }

    public Vector3 GetEnemyTargetPosition()
    {
        return mStageSystem.targetPosition;
    }

    public void ShowCampInfo(ICamp camp)
    {
        mCampInfoUI.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }

    //能量系统
    public bool TakeEnergy(int value)
    {
        return mEnergySystem.TakeEnergy(value);
    }

    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }

    //UI系统
    public void ShowMsg(string msg)
    {
        mGameStateInfoUI.ShowMsg(msg);
    }

    public void UpdateEnergySlider(int curretEnergy, int maxEnergy)
    {
        mGameStateInfoUI.UpdateEnergySlider(curretEnergy, maxEnergy);
    }

    //游戏事件系统
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(eventType, observer);
    }

    public void NotifySubject(GameEventType eventType)
    {
        mGameEventSystem.NotifySubject(eventType);
    }

    //加载备忘录
    private void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mArchievementSystem.SetMemento(memento);
    }
    //保存成备忘录
    private void SaveMemento()
    {
        AchievementMemento memento = mArchievementSystem.CreateMemento();
        memento.SaveDate();
    }
    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSystem.RunVisitor(visitor);
    }
}
