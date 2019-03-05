using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NormalStageHandler:IStageHandler
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mEnemyCount;
    private Vector3 mSpawnPosition;

    private int mSpawnTime = 2;
    private float mSpawnTimer = 0;
    private int mCountSpawned = 0; 

    public NormalStageHandler(StageSystem stageSystem,int level, int countToFinished, EnemyType enemyType,WeaponType weaponType,int enemyCount,Vector3 spawnPosition):base(stageSystem,level,countToFinished)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mEnemyCount = enemyCount;
        mSpawnPosition = spawnPosition;
        mSpawnTimer = mSpawnTime;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
        if(mCountSpawned < mEnemyCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if(mSpawnTimer <= 0)
            {
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }

        //Debug.Log(mStageSystem.GetCountOfEnemyKilled() + " " + mCountToFinished);
    }
    private void SpawnEnemy()
    {
        mCountSpawned++;
        switch(mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.enemyFactory.CreateCharacter<EnemyEif>(mWeaponType, mSpawnPosition);
                break;
            case EnemyType.Ogre:
                FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mSpawnPosition);
                break;
            case EnemyType.Troll:
                FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mSpawnPosition);
                break;
            default:
                Debug.Log("无法生成类型为:" + mEnemyType + "的敌人");
                break;
        }
    }
}

