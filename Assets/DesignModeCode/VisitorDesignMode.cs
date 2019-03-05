using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class VisitorDesignMode:MonoBehaviour
{
    void Start()
    {
        DMShpere shpere1 = new DMShpere();
        DMCylinder cylinder1 = new DMCylinder();
        DMCube cube1 = new DMCube();
        DMCube cube2 = new DMCube();

        DMShapeContainer shapeContainer = new DMShapeContainer();
        shapeContainer.AddShape(shpere1);
        shapeContainer.AddShape(cylinder1);
        shapeContainer.AddShape(cube1);
        shapeContainer.AddShape(cube2);

        AmountVisitor amountVisitor = new AmountVisitor();
        shapeContainer.RunVisitor(amountVisitor);

        Debug.Log(amountVisitor.amount);
    }
}

public class DMShapeContainer
{
    private List<IDMShape> mShapes = new List<IDMShape>();
    public void AddShape(IDMShape shape)
    {
        mShapes.Add(shape);
    }
    public void RunVisitor(IShapeVisitor visitor)
    {
        foreach(IDMShape shape in mShapes)
        {
            shape.RunVisitor(visitor);
        }
    }
}

public abstract  class IDMShape
{
    public abstract void RunVisitor(IShapeVisitor visitor);
}

public class DMShpere : IDMShape
{
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}

public class DMCylinder : IDMShape
{
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}

public class DMCube : IDMShape
{
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

public abstract class IShapeVisitor
{
    public abstract void VisitSphere(DMShpere shpere);
    public abstract void VisitCylinder(DMCylinder cylinder);
    public abstract void VisitCube(DMCube cube);
}

public class AmountVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount++;
    }

    public override void VisitSphere(DMShpere shpere)
    {
        amount++;
    }
}

public class CubeAmountVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        return;
    }

    public override void VisitSphere(DMShpere shpere)
    {
        return;  
    }
}

