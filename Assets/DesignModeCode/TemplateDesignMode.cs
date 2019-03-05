using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TemplateDesignMode:MonoBehaviour
{
    void Start()
    {
        IPeople people = new NorthPeople();
        people.Eat();
    }
    
   
}

public abstract class IPeople
{
    public void Eat()
    {
        OrderDish();
        EatSomething();
        Pay();
    }
    private void OrderDish()
    {
        Debug.Log("点菜完毕");
    }
    protected virtual void EatSomething()
    {

    }
    private void Pay()
    {
        Debug.Log("买单完毕");
    }
}

public class NorthPeople:IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("北方人爱吃面");
    }
}

public class SouthPeople:IPeople
{
    protected  override void EatSomething()
    {
        Debug.Log("南方人爱吃饭");
    }
}

