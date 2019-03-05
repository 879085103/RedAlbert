using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MementoDesignMode:MonoBehaviour
{
    void Start()
    {
        //Originator originator = new Originator();
        //originator.SetState("State1");
        //originator.ShowState();

        ////创建快照
        //Memento memento = originator.CreateMemento();

        //originator.SetState("State2");
        //originator.ShowState();

        //originator.SetMemento(memento);
        //originator.ShowState();

        Caretaker caretaker = new Caretaker();

        Originator originator = new Originator();
        originator.SetState("state1");
        originator.ShowState();

        caretaker.AddMemento("v1.0", originator.CreateMemento());

        originator.SetState("state2");
        originator.ShowState();

        caretaker.AddMemento("v2.0", originator.CreateMemento());

        originator.SetState("state3");
        originator.ShowState();

        caretaker.AddMemento("v3.0", originator.CreateMemento());

        originator.SetMemento(caretaker.GetMemento("v2.0"));
        originator.ShowState();

        originator.SetMemento(caretaker.GetMemento("v3.0"));
        originator.ShowState();
    }
}

public class Originator
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }
    public void ShowState()
    {
        Debug.Log("Originator state :" + mState);
    }
    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }
    public void SetMemento(Memento memento)
    {
        SetState(memento.GetState());
    }
}

public class Memento
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }
    public string GetState()
    {
        return mState;
    }
}

public class Caretaker
{
    private Dictionary<string, Memento> mMementoDic = new Dictionary<string, Memento>();
    public void AddMemento(string version,Memento memento)
    {
            mMementoDic.Add(version, memento);
    }
    public Memento GetMemento(string version)
    {
        if(mMementoDic.ContainsKey(version) == false)
        {
            Debug.LogError("快照字典中不包含key:"+version);
        }
        return mMementoDic[version];
    }

}

