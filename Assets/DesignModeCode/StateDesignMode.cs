using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDesignMode : MonoBehaviour
{
    void Start()
    {
        ConText context = new ConText();
        context.SetState(new ConcreteStateA(context));

        context.Handle(5);
        context.Handle(20);
        context.Handle(30);
        context.Handle(4);
    }
}

//状态拥有者
public class ConText
{
    private IState mstate;

    public IState State
    {
        get
        {
            return mstate;
        }
        set
        {
            mstate = value;
        }
    }

    public void SetState(IState state)
    {
        this.State = state;
    }

    public void Handle(int args)
    {
        State.Handle(args);
    }

}

public interface IState
{
    void Handle(int args);
}

public class ConcreteStateA:IState
{
    private ConText mContext;

    public ConcreteStateA(ConText context)
    {
        mContext = context;
    }
    public void Handle(int args)
    {
        Debug.Log("ConcreteStateA.Handle" + args);
        if(args > 10)
        {
            //转换状态B
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateB : IState
{
    private ConText mContext;

    public ConcreteStateB(ConText context)
    {
        mContext = context;
    }
    public void Handle(int args)
    {
        Debug.Log("ConcreteStateB.Handle" + args);
        if(args <= 10)
        {
            //转换状态A
            mContext.SetState(new ConcreteStateA(mContext));
        }
    }
}


