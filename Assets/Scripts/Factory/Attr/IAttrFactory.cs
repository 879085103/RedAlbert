using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//享元模式
public interface IAttrFactory
{
     CharacterBaseAttr GetCharacterBaseAttr( Type t );
     WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}

