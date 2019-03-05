using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TrainSoldierCommand : ITrainCommand
{
    SoldierType mSoldierType;
    WeaponType mWeaponType;
    Vector3 mPosition;
    int mLevel;

 
    public TrainSoldierCommand(SoldierType  soldierType,WeaponType weaponType,Vector3 pos,int level)
    {
        mSoldierType = soldierType;
        mWeaponType = weaponType;
        mPosition = pos;
        mLevel = level;
    }

    public override void Execute()
    {
        switch(mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreateCharacter<SoldierRookie>(mWeaponType, mPosition, mLevel);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mPosition, mLevel);
                break;
            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mPosition, mLevel);
                break;
            default:
                Debug.LogError("无法执行命令,无法根据SoldierType:" + mSoldierType + "创建角色");
                break;
        }
        
    }
}

