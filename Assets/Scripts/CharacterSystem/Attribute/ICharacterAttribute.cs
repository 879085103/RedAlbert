using System;
using System.Collections.Generic;
using System.Text;

public class ICharacterAttribute
{
    protected CharacterBaseAttr mBaseAttr;
    //当前血量
    protected int mCurretHP;
    //角色的等级,随着兵营等级升高
    protected int mLevel;

    //减免的伤害值
    protected int mDmgDescValue;
    //角色升级的处理策略
    protected IAttrStrategy mStrategy;

    public ICharacterAttribute(IAttrStrategy strategy,int level,CharacterBaseAttr baseAttr)
    {
        mBaseAttr = baseAttr;
        mLevel = level;

        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLevel);
        mCurretHP = baseAttr.maxHP + mStrategy.GetExtraHPVaule(mLevel);

    }

    public int critValue
    {
        get { return mStrategy.GetCritDmgValue(mBaseAttr.critRate); }
    }

    public int currentHP { get { return mCurretHP; } }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5)
            damage = 5;
        mCurretHP -= damage;
    }
}

