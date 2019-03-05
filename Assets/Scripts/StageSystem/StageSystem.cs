using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StageSystem:IGameSystem
{
    private  int mLevel = 1;
    private List<Vector3> mSpawnPosList;
    private IStageHandler mRootHandler;
    //敌人的目标位置
    private Vector3 mTargetPosition;
    private int mCountOfEnemyKilled = 0;

    public override void Init()
    {
        base.Init();
        InitPosition();
        InitStageChain();
        //注册观察者
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
    }

    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLevel);
    }

    //获取敌人生成点
    private void InitPosition()
    {
        mSpawnPosList = new List<Vector3>();
        int i = 1;
        while(true)
        {
            GameObject go = GameObject.Find("Position" + i);
            if (go != null)
            {
                mSpawnPosList.Add(go.transform.position);
                go.SetActive(false);
                i++;
            }
            else
            {
                break;
            }
        }
        GameObject target = GameObject.Find("TargetPosition");
        mTargetPosition = target.transform.position;
        
    }

    //得到随机生成敌人的位置
    private Vector3 GetRandomPos()
    {
        return mSpawnPosList[UnityEngine.Random.Range(0, mSpawnPosList.Count)];
    }

    //构造责任链
    private void InitStageChain()
    {
        int level = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, level++, 3, EnemyType.Elf, WeaponType.Gun, 3, GetRandomPos());
        NormalStageHandler handler2 = new NormalStageHandler(this, level++, 6, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomPos());
        NormalStageHandler handler3 = new NormalStageHandler(this, level++, 9, EnemyType.Elf, WeaponType.Rocket, 3, GetRandomPos());
        NormalStageHandler handler4 = new NormalStageHandler(this, level++, 13, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos());
        NormalStageHandler handler5 = new NormalStageHandler(this, level++, 17, EnemyType.Ogre, WeaponType.Rifle,4, GetRandomPos());
        NormalStageHandler handler6 = new NormalStageHandler(this, level++, 21, EnemyType.Ogre, WeaponType.Rocket, 4, GetRandomPos());
        NormalStageHandler handler7 = new NormalStageHandler(this, level++, 26, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos());
        NormalStageHandler handler8 = new NormalStageHandler(this, level++, 31, EnemyType.Troll, WeaponType.Rifle, 5, GetRandomPos());
        NormalStageHandler handler9 = new NormalStageHandler(this, level++, 36, EnemyType.Troll, WeaponType.Rocket, 5, GetRandomPos());

        handler1.SetNextHandler(handler2).SetNextHandler(handler3).
            SetNextHandler(handler4).SetNextHandler(handler5).
            SetNextHandler(handler6).SetNextHandler(handler7).
            SetNextHandler(handler8).SetNextHandler(handler9);
        mRootHandler = handler1;
    }


    public int GetCountOfEnemyKilled() { return mCountOfEnemyKilled; }

    public int countOfEnemyKilled
    {
        set { mCountOfEnemyKilled = value; }
    }

    public void EnterNextStage()
    {
        mLevel++;
        mFacade.NotifySubject(GameEventType.NewStage);
    }

    public Vector3 targetPosition { get {return mTargetPosition; } }
}

