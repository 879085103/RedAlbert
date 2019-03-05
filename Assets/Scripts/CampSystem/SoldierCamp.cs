using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierCamp:ICamp
{
    //最大兵营等级
    const int mMaxLevel = 4;
    private int mLevel = 1;
    private WeaponType mWeaponType = WeaponType.Gun;
    

    public SoldierCamp(GameObject gameObject, string name, string iconSprite, SoldierType soldierType, Vector3 position, float trainTime, WeaponType weaponType = WeaponType.Gun,int level = 1):base(gameObject,name,iconSprite,soldierType,position,trainTime)
    {
        mLevel = level;
        mWeaponType = weaponType;
        mEnergyStrategy = new SoldierEnergyCostStrategy();
        //初始化能量消耗
        UpdateEnergyCost();
    }

    public override int level { get { return mLevel; } }

    public override WeaponType weaponType { get { return mWeaponType; } }

    //计算兵营升级所需能量操作 如果达到最大等级就返回-1
    public override int energyCostCampUpgrade
    {
        get { if (mLevel == mMaxLevel) return -1;else return mEnergyCostCampUpgrade; }
    }
    //计算武器升级所需能量操作 如果达到最大等级就返回-1
    public override int energyCostWeaponUpgrade
    {
        get { if (mWeaponType + 1 == WeaponType.MAX) return -1; else return mEnergyCostWeaponUpgrade; }
    }
    //计算训练士兵所需要的能量
    public override int energyCostTrain
    {
        get { return mEnergyCostTrain; }
    }

    public override void Train()
    {
        //向mCommands添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLevel);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        mLevel++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        mWeaponType = mWeaponType + 1;
        UpdateEnergyCost();
    }
    //在兵营升级和武器升级之后都要调用 重新初始化能量消耗
    protected override void UpdateEnergyCost()
    {
        mEnergyCostCampUpgrade = mEnergyStrategy.GetCampUpgradeCost(mSoldierType, mLevel);
        mEnergyCostWeaponUpgrade = mEnergyStrategy.GetWeaponUpgradeCost(mWeaponType);
        mEnergyCostTrain = mEnergyStrategy.GetSoldierTrainCost(mSoldierType, mLevel);
    }
}

