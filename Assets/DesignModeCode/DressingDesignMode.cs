using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DressingDesignMode:MonoBehaviour
{
    void Start()
    {
        Coffee coffee = new Expresso();
        coffee = coffee.AddDressing(new Mocha()).AddDressing(new Whip());
        //coffee = new Mocha(coffee);
        //coffee = new Whip(coffee);
        Debug.Log(coffee.Cost());
    }
}

public abstract class Coffee
{
    public abstract double Cost();
    public Coffee AddDressing(Dressing dress)
    {
        dress.coffee = this;
        return dress;
    }
}

public class Expresso : Coffee
{
    public override double Cost()
    {
        return 2.5f;
    }

}

public class Decal:Coffee
{
    public override double Cost()
    {
        return 2f;
    }
}

public class Dressing:Coffee
{
    protected Coffee mCoffee;
    public Coffee coffee { get { return mCoffee; } set { mCoffee = value; } }

    //public Dressing(Coffee cof)
    //{
    //    coffee = cof;
    //}

    public override double Cost()
    {
        return coffee.Cost();
    }
}

public class Whip:Dressing
{
    //public Whip(Coffee coffee) : base(coffee) { }

    public override double Cost()
    {
        return base.Cost() + 0.5f;
    }
}

public class Mocha:Dressing
{
    //public Mocha(Coffee coffee) : base(coffee) { }

    public override double Cost()
    {
        return base.Cost() + 1f;
    }
}
