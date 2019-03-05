using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();

    private IEnemyState mCurrentState;
    public IEnemyState currentState { get { return mCurrentState; } }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState temp in states)
        {
            AddState(temp);
        }
    }

    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            //第一个状态设置为默认状态
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState temp in mStates)
        {
            if (temp.StateID == state.StateID)
            {
                Debug.LogError("要添加的状态ID[" + temp.StateID + "]已经添加");
                return;
            }
        }
        mStates.Add(state);
    }

    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态ID[" + stateID + "]为空");
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.StateID == stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的状态ID[" + stateID + "]不存在集合中");
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空");
            return;
        }
        //获取要转换为的状态
        EnemyStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.Log("要转换的状态ID[" + nextStateID + "]为空");
            return;
        }
        foreach (IEnemyState state in mStates)
        {
            //如果在集合中找到转换为的状态
            if (state.StateID == nextStateID)
            {
                //执行退出当前状态之前的操作
                mCurrentState.DoBeforeLeaving();
                //将当前状态变为将转换的状态
                mCurrentState = state;
                //执行进入当前状态之前的操作
                mCurrentState.DoBeforeEntering();
                break;
            }
        }

    }
}

