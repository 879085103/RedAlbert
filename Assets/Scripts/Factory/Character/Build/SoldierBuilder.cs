using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int level) : base(character, type, weaponType, spawnPosition, level) { }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttribute attr = new SoldierAttribute(new SoldierAttrStrategy(), mLevel,baseAttr);
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        //创建角色游戏物体
        //1.加载资源 2.实例化 TODO
        GameObject characterGo = FactoryManager.assetFactory.LoadSoldier(mPrefabName);
        characterGo.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGo;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);
    }

    public override void AddWeapon()
    {
        //添加武器
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override ICharacter GerResult()
    {
        return mCharacter;
    }
}

