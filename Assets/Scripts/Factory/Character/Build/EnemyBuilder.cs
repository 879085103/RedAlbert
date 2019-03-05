using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int level) : base(character, type, weaponType, spawnPosition, level) { }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttribute attr = new EnemyAttribute(new EnemyAttrStrategy(), mLevel, baseAttr);
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGo = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
        characterGo.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGo;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
    }

    public override void AddWeapon()
    {
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override ICharacter GerResult()
    {
        return mCharacter;
    }
}

