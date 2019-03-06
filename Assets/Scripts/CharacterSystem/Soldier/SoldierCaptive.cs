using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//伏兵类 适配器模式
public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;

        ICharacterAttribute attr = new SoldierAttribute(enemy.Attr.strategy, 1, enemy.Attr.baseAttr);
        this.Attr = attr;

        this.gameObject = mEnemy.gameObject;

        this.weapon = mEnemy.weapon;
    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    protected override void PlaySound()
    {
        //Do nothing
    }
}

