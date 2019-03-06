using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierEnergyCostStrategy : IEnergyStrategy
{
    //升级兵营的策略
    public override int GetCampUpgradeCost(SoldierType soldierType, int level)
    {
        int energy = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                Debug.Log("无法获取" + soldierType + "类型兵营升级所消耗的能量值");
                break;
        }
        energy += (level - 1) * 2;
        if (energy > 100)
            energy = 100;
        return energy;
    }
    //生产士兵的策略
    public override int GetSoldierTrainCost(SoldierType soldierType, int level)
    {
        int energy = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            case SoldierType.Captive:
                return 10;
            default:
                Debug.Log("无法获取" + soldierType + "类型士兵升级所消耗的能量值");
                break;
        }
        energy += (level - 1) * 2;
        return energy;
    }
    //升级武器的策略
    public override int GetWeaponUpgradeCost(WeaponType weaponType)
    {
        int energy = 0;
        switch (weaponType)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
            default:
                Debug.Log("无法获取" + weaponType +"类型武器升级所消耗的能量值");
                break;
        }
        return energy;
    }
}

