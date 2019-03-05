using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DutyLinkDesignMode:MonoBehaviour
{
    void Start()
    {
        ConcreHandler1 handler1 = new ConcreHandler1(new ConcreteHandler2(new ConcreteHandler3(null)));
        handler1.HandlerRequest("ConcreteHandler3");
    }
    
}

public abstract class Handler
{
    //下一个处理者
    protected Handler mNextHandler;
    public Handler nextHandler { get { return mNextHandler; } }

    public Handler(Handler nextHandler)
    {
        mNextHandler = nextHandler;
    }

    public abstract void HandlerRequest(string condition);
    
}

public class ConcreHandler1 : Handler
{
    public ConcreHandler1(Handler nextHandler) : base(nextHandler)
    {
    }

    public override void HandlerRequest(string condition)
    {
        if(condition.Equals("ConcreteHandler1"))
        {
            Debug.Log("ConcreteHandler1 handled");
        }
        else
        {
            Debug.Log("ConcreteHandler1 failed");
            //给下一位处理
            mNextHandler.HandlerRequest(condition);
        }
    }
}

public class ConcreteHandler2 : Handler
{
    public ConcreteHandler2(Handler nextHandler) : base(nextHandler)
    {
    }

    public override void HandlerRequest(string condition)
    {
        if (condition.Equals("ConcreteHandler2"))
        {
            Debug.Log("ConcreteHandler2 handled");
        }
        else
        {
            Debug.Log("ConcreteHandler2 failed");
            //给下一位处理
            mNextHandler.HandlerRequest(condition);
        }
    }
}

public class ConcreteHandler3 : Handler
{
    public ConcreteHandler3(Handler nextHandler) : base(nextHandler)
    {
    }

    public override void HandlerRequest(string condition)
    {
        Debug.Log("ConcreHandler3 handled");
    }
}

