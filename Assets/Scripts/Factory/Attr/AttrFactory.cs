using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    //每一种士兵和敌人对应一类相同属性
    private Dictionary<Type, CharacterBaseAttr> mCharacterBaeAttrDict;
    //每一种武器对应一类相同属性
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict;

    public AttrFactory()
    {
        InitCharacterBaseAttrDict();
        InitWeaponBaseAttrDict();
    }
    //初始化CharacterBaseAttrDict
    private void InitCharacterBaseAttrDict()
    {
        mCharacterBaeAttrDict = new Dictionary<Type, CharacterBaseAttr>();

        mCharacterBaeAttrDict.Add(typeof(SoldierRookie), new CharacterBaseAttr("新手士兵", 80, 2.5f, "RookieIcon", "Soldier2", 0));
        mCharacterBaeAttrDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵", 90, 3f, "SergeantIcon", "Soldier3", 0));
        mCharacterBaeAttrDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵", 100, 3f, "CaptainIcon", "Soldier1", 0));

        mCharacterBaeAttrDict.Add(typeof(EnemyEif), new CharacterBaseAttr("小精灵", 100, 3, "ElfIcon", "Enemy1", 0.2f));
        mCharacterBaeAttrDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("怪物", 120, 2, "OgreIcon", "Enemy2", 0.3f));
        mCharacterBaeAttrDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 200, 1, "TrollIcon", "Enemy3", 0.4f));
    }
    //初始化WeaponBaseAttrDict
    private void InitWeaponBaseAttrDict()
    {
        mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();

        mWeaponBaseAttrDict.Add(WeaponType.Gun, new WeaponBaseAttr("手枪", 20, 5,"WeaponGun"));
        mWeaponBaseAttrDict.Add(WeaponType.Rifle, new WeaponBaseAttr("长枪", 30, 7,"WeaponRifle"));
        mWeaponBaseAttrDict.Add(WeaponType.Rocket, new WeaponBaseAttr("火箭", 40, 8, "WeaponRocket"));
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if(mCharacterBaeAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据类型" + t + "得到角色基础属性(GetCharacterBaseAttr)");
            return null;
        }
        return mCharacterBaeAttrDict[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if(mWeaponBaseAttrDict.ContainsKey(weaponType) == false)
        {
            Debug.LogError("无法根据类型" + weaponType + "得到武器基础属性(GetWeaponBaseAttr)");
            return null;
        }
        return mWeaponBaseAttrDict[weaponType];
    }
}

