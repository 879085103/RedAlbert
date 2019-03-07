using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICamp
{
    public SoldierType soldierType { get { return mSoldierType; } }
    //兵营对应的游戏物体
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    //集合点
    protected Vector3 mPosition;
    //训练时间
    protected float mTrainTime;
    //储存训练命令
    protected List<ITrainCommand> mCommands;
    private float mTrainTimer = 0;
    //能量消耗的策略
    protected IEnergyStrategy mEnergyStrategy;
    protected int mEnergyCostCampUpgrade;
    protected int mEnergyCostWeaponUpgrade;
    protected int mEnergyCostTrain;

    public ICamp(GameObject gameObject,string name,string iconSprite,SoldierType soldierType,Vector3 position,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = iconSprite;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;
        mCommands = new List<ITrainCommand>();
    }

    public virtual void Update()
    {
        UpdateCommand();
     
    }

    //对兵营命令的处理
    private void UpdateCommand()
    {
        if (mCommands.Count <= 0)
            return;
        mTrainTimer -= Time.deltaTime;
        if(mTrainTimer <= 0)
        {
            mCommands[0].Execute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }
    }


    //取消训练的操作
    public void CancelTrainCommand()
    {
        if(mCommands.Count > 0)
        {
            mCommands.RemoveAt(mCommands.Count - 1);
            if(mCommands.Count == 0)
            {
                mTrainTimer = mTrainTime;
            }
        }
    }


    //返回正在训练个数
    public int TrainCount { get { return mCommands.Count; } }
    //返回训练时间
    public float RemainingTrainTime{get { return mTrainTimer; }}

    public string name { get { return mName; } }
    public string iconSprite { get { return mIconSprite; } }

    public abstract int level { get; }
    public abstract WeaponType weaponType { get; }
    public abstract int energyCostCampUpgrade { get; }
    public abstract int energyCostWeaponUpgrade { get; }
    public abstract int energyCostTrain { get; }
    //是否为俘兵营
    public abstract bool isCaptiveCamp { get; }


    public abstract void Train();
    //兵营升级
    public abstract void UpgradeCamp();
    //武器升级
    public abstract void UpgradeWeapon();
    protected abstract void UpdateEnergyCost();
}

