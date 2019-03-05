using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm,ICharacter character) : base(fsm, character) { mStateID = EnemyStateID.Chase; }

    private Vector3 mTargetPosition;

    public override void DoBeforeEntering()
    {
        //获取敌人没目标时的目标位置
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].position);
        }
        if(targets == null || targets.Count == 0)
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.position, targets[0].position);
            if(distance <= mCharacter.atkRange)
            mFSM.PerformTransition(EnemyTransition.CanAttack);
        }
    }
}

