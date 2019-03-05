using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected Type mType;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPosition;
    protected int mLevel;
    protected string mPrefabName = "";

    public ICharacterBuilder(ICharacter character, Type type,WeaponType weaponType,Vector3 spawnPosition,int level)
    {
        mCharacter = character;
        mType = type;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPosition;
        mLevel = level;
    }

    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract void AddInCharacterSystem();
    public abstract ICharacter GerResult();
}

