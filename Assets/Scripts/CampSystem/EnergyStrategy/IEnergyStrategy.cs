using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//能量消耗策略
public abstract class IEnergyStrategy
{
    public abstract  int GetCampUpgradeCost( SoldierType soldierType, int level);
    public abstract  int GetWeaponUpgradeCost(WeaponType weaponType);
    public abstract  int GetSoldierTrainCost( SoldierType soldierType, int level);

}

