using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}

public enum EnemyStateID
{
    NullState = 0,
    Chase,
    Attack
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;
    public EnemyStateID StateID { get { return mStateID; } }

    protected ICharacter mCharacter;

    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm,ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyState Error:trans is null");
            return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error:id is null");
            return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error: " + trans + " is already included");
            return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件时，转换条件 " + trans + " 不存在");
        }
        mMap.Remove(trans);
    }

    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            return EnemyStateID.NullState;
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

