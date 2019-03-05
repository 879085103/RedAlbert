using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//管理每个角色不会改变的属性
public class CharacterBaseAttr
{
    protected string mName;
    //最大血量
    protected int mMaxHP;
    //角色的头像 声明string是为了便于用Resource.Load加载
    protected string mIconSprite;
    protected string mPrefabName;
    //暴击率 0~1
    protected float mCritRate;
    protected float mMoveSpeed;

    public CharacterBaseAttr(string name,int maxHP,float moveSpeed, string iconSprite,string prefabName,float critRate)
    {
        mName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        mIconSprite = iconSprite;
        mPrefabName = prefabName;
        mCritRate = critRate;
    }

    public string name { get { return mName; } }
    public int maxHP { get { return mMaxHP; } }
    public float moveSpeed { get { return mMoveSpeed; } }
    public string iconSprite { get { return mIconSprite; } }
    public float critRate { get { return mCritRate; } }
    public string prefabName { get { return mPrefabName; } }
}

