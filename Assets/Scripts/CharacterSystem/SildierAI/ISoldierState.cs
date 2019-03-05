using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//转换条件
public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}


public  abstract class ISoldierState
{
    //储存该状态可以转换的状态和条件
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;
    //属于哪个角色
    protected ICharacter mCharacter;

    protected SoldierFSMSystem mFSM;

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public SoldierStateID StateID { get { return mStateID; } }

    public void AddTransition(SoldierTransition trans,SoldierStateID id)
    {
        if(trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierState Error:trans is null");
            return;
        }
        if(id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error:id is null");
            return;
        }
        if(mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error: " + trans + " is already included");
            return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(SoldierTransition trans)
    {
        if(mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件时，转换条件 " + trans + " 不存在");
        }
        mMap.Remove(trans);
    }

    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if(mMap.ContainsKey(trans) == false)
        {
            return SoldierStateID.NullState;
        }
        else
        {
            return mMap[trans];
        }
    }
    //进入状态前的操作
    public virtual void DoBeforeEntering() { }
    //离开状态前的操作
    public virtual void DoBeforeLeaving() { }
    
    //判断是否要转换状态
    public abstract void Reason(List<ICharacter> targets);
    //在该状态应进行的操作
    public abstract void Act(List<ICharacter> targets);
}
