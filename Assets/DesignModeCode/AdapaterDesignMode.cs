using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AdapaterDesignMode:MonoBehaviour
{
    void Start()
    {
        Target target = new Adapter();

        target.Request();
    }

}
public class Target
{
    public virtual void Request()
    {
        Debug.Log("This is Target Request");
    }
}

public class Adaptee
{
    public void AdapteeRequest()
    {
        Debug.Log("This is Adaptee Request");
    }
}

public class Adapter:Target
{
    Adaptee adaptee = new Adaptee();

    public override void Request()
    {
        adaptee.AdapteeRequest();
    }
}

