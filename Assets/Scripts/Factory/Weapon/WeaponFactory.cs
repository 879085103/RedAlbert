using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        WeaponBaseAttr baseAttr = FactoryManager.attrFactory.GetWeaponBaseAttr(weaponType);

        //通过资源工厂创建枪的游戏物体
        GameObject weaponGo = FactoryManager.assetFactory.LoadWeapon(baseAttr.assetName);
        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(baseAttr, weaponGo);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(baseAttr, weaponGo);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(baseAttr, weaponGo);
                break;
        }
        return weapon;
    }
}

