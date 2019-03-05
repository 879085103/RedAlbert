using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierFSMSystem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();

    private ISoldierState mCurrentState;
    public ISoldierState currentState { get { return mCurrentState; } }

    public void AddState(params ISoldierState[] states)
    {
        foreach(ISoldierState temp in states)
        {
            AddState(temp);
        }
    }

    public void AddState(ISoldierState state)
    {
        if(state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }
        if(mStates.Count == 0)
        {
            mStates.Add(state);
            //第一个状态设置为默认状态
            mCurrentState = state;
            return;
        }
        foreach(ISoldierState temp in mStates)
        {
            if(temp.StateID == state.StateID)
            {
                Debug.LogError("要添加的状态ID[" + temp.StateID + "]已经添加");
                return;
            }
        }
        mStates.Add(state);
    }

    public void DeleteState(SoldierStateID stateID)
    {
        if(stateID == SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态ID[" + stateID+"]为空");
            return;
        }
        foreach(ISoldierState s in mStates)
        {
            if(s.StateID == stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的状态ID[" + stateID + "]不存在集合中");
    }

    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空");
            return;
        }
        //获取要转换为的状态
        SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == SoldierStateID.NullState)
        {
            Debug.Log("要转换的状态ID[" + nextStateID + "]为空");
            return;
        }
        foreach(ISoldierState state in mStates)
        {
            //如果在集合中找到转换为的状态
            if(state.StateID ==nextStateID)
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
