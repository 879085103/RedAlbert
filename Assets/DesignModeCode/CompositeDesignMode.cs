using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CompositeDesignMode:MonoBehaviour
{
    void Start()
    {
        DMComposite root = new DMComposite("Root");

        DMLeaf leaf1 = new DMLeaf("GameObject");
        DMLeaf leaf2 = new DMLeaf("GameObject (2) ");
        DMComposite gameObject1 = new DMComposite("GameObject (1) ");

        root.AddChild(leaf1);
        root.AddChild(gameObject1);
        root.AddChild(leaf2);

        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject (1) ");
        gameObject1.AddChild(child1);
        gameObject1.AddChild(child2);

        ReadComponet(root);

    }

    private void ReadComponet(DMComponet componet)
    {
        Debug.Log(componet.name);

        List<DMComponet> children = componet.children;
        if (children == null || children.Count == 0)
            return;
        foreach(DMComponet child in children)
        {
            ReadComponet(child);
        }
    }
}

public abstract class DMComponet
{
    protected string mName;
    public string name { get { return mName; } }
    public DMComponet(string name)
    {
        mName = name;
        mChildren = new List<DMComponet>();
    }
    protected List<DMComponet> mChildren;
    public List<DMComponet> children { get { return mChildren; } }

    public abstract void AddChild(DMComponet c);
    public abstract void RemoveChild(DMComponet c);
    public abstract DMComponet GetChild(int index);
}

public class DMLeaf : DMComponet
{
    public DMLeaf(string name) : base(name) { }

    public override void AddChild(DMComponet c)
    {
        return;
    }

    public override DMComponet GetChild(int index)
    {
        return null;
    }

    public override void RemoveChild(DMComponet c)
    {
        return;
    }
}

public class DMComposite : DMComponet
{
    public DMComposite(string name) : base(name) { }

    public override void AddChild(DMComponet c)
    {
        mChildren.Add(c);
    }

    public override DMComponet GetChild(int index)
    {
        return mChildren[index];
    }

    public override void RemoveChild(DMComponet c)
    {
        mChildren.Remove(c);
    }
}


