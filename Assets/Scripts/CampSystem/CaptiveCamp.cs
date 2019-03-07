using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CaptiveCamp : ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;


    public CaptiveCamp(GameObject gameObject, string name, string iconSprite, EnemyType enemyType, Vector3 position, float trainTime) : base(gameObject, name, iconSprite,SoldierType.Captive, position, trainTime)
    {
        mEnergyStrategy = new SoldierEnergyCostStrategy();
        mEnemyType = enemyType;
        UpdateEnergyCost();
    }

    public override int level
    {
        get { return 1; }
    }

    public override WeaponType weaponType
    {
        get { return mWeaponType; }
    }

    public override int energyCostCampUpgrade
    {
        get { return 0; }
    }

    public override int energyCostWeaponUpgrade
    {
        get { return 0; }
    }

    public override int energyCostTrain
    {
        get { return mEnergyCostTrain; }
    }

    public override bool isCaptiveCamp { get { return true; } }

    public override void Train()
    {
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mPosition, 1);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
    }

    public override void UpgradeWeapon()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrain = mEnergyStrategy.GetSoldierTrainCost(mSoldierType, 1);
    }
}

