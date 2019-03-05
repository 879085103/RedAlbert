using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnergySystem:IGameSystem
{
    private const int MAX_Energy = 100;

    private float mCurretEnergy = MAX_Energy;
    //能量恢复速率
    private float mRecoverSpeed = 3;

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        base.Update();
        if(mCurretEnergy >= MAX_Energy)
        {
            return;
        }
        mCurretEnergy += mRecoverSpeed * Time.deltaTime;
        mCurretEnergy = mCurretEnergy > MAX_Energy ? MAX_Energy : mCurretEnergy;
        mFacade.UpdateEnergySlider((int)mCurretEnergy, MAX_Energy);
    }
    //消耗能量
    public bool TakeEnergy(int value)
    {
        if(mCurretEnergy >= value)
        {
            mCurretEnergy -= value;
            return true;
        }
        return false;
    }
    //回收能量
    public void RecycleEnergy(int value)
    {
        mCurretEnergy += value;
        mCurretEnergy = mCurretEnergy > MAX_Energy ? MAX_Energy : mCurretEnergy;
    }
}

