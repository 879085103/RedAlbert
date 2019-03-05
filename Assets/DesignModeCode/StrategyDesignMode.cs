using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class StrategyDesignMode:MonoBehaviour 
{
    void Start()
    {
        StrategyContext strategyContext = new StrategyContext();
        strategyContext.strategy = new ConcreteStrategyA();
        strategyContext.Cal();
    }
    
   
}
//状态拥有者
public class StrategyContext
{
    public IStrategy strategy;

    public void Cal()
    {
        strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}

public class ConcreteStrategyA:IStrategy
{
    public void Cal()
    {
        Debug.Log("使用A策略计算");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用B策略计算");
    }
}

