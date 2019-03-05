using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierAttackState : ISoldierState
{
    
    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm,character) { mStateID = SoldierStateID.Attack; }
    //攻击频率
    private float mAttackTime = 1;
    //计时器
    private float mAttackTimer = 1;

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
            return;
        mAttackTimer += Time.deltaTime;
        if(mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
        }
        else
        {
            float distance = Vector3.Distance(targets[0].position, mCharacter.position);
            if (distance > mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.SeeEnemy);
            }
        }      
    }
}

