using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLevel;

    public TrainCaptiveCommand(EnemyType et,WeaponType wt,Vector3 pos, int lv = 1)
    {
        mEnemyType = et;
        mWeaponType = wt;
        mPosition = pos;
        mLevel = lv;
    }

    public override void Execute()
    {
        IEnemy enemy = null;
        switch(mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyEif>(mWeaponType, mPosition, 1) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition, 1) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition, 1) as IEnemy;
                break;
            default:
                Debug.LogError("无法执行命令,无法根据EnemyType:" + mEnemyType + "创建俘兵");
                return;
        }
        //将生成的俘兵从敌人list中移除 并加入士兵list
        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);
        
    }
}

