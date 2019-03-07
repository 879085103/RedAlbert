using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class CharacterSystem:IGameSystem
{
    //管理场景里的敌人和士兵
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();


    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }

    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();

        RemoveCharacterIsKilled(mEnemys);
        RemoveCharacterIsKilled(mSoldiers);


    }

    private void UpdateEnemy()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldiers);
            e.EnemyEscapeHandle();
        }
    }

    private void UpdateSoldier()
    {
        foreach (ISoldier s in mSoldiers)
        {
            s.Update();
            s.UpdateFSMAI(mEnemys);
        }
    }

    private void RemoveCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> mCanDestroys = new List<ICharacter>();
        foreach(ICharacter character in characters)
        {
            if(character.canDestroy)
            {
                mCanDestroys.Add(character);
            }
        }
        foreach(ICharacter character in mCanDestroys)
        {
            character.Release();
            characters.Remove(character);
        }
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach(ICharacter character in mEnemys)
        {
            character.RunVisitor(visitor);
        }
        foreach(ICharacter character in mSoldiers)
        {
            character.RunVisitor(visitor);
        }
    }
}

