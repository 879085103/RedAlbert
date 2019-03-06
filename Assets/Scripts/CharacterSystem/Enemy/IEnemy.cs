using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public abstract class IEnemy:ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy() : base()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        //如果角色死亡,停止更新状态机
        if (mIsKilled) return;
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);
    }

    //构造状态机
    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();

        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mFSMSystem.AddState(chaseState, attackState);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;
        base.UnderAttack(damage);

        //被攻击的特效
        PlayEffect();
        if(mAttr.currentHP <= 0)
        {
            Killed();
        }
    }

    public abstract void PlayEffect();

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitorEnemy(this);
    }
}
