using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ObserverDesignMode:MonoBehaviour
{
    void Start()
    {
        //WeatherStation mWeatherStation = new WeatherStation();

        //BillboardA mBillboardA = new BillboardA();
        //BillboardB mBillboardB = new BillboardB();
        //BillboardC mBillboardC = new BillboardC();

        //mWeatherStation.mBillboardHandler += mBillboardA.Show;
        //mWeatherStation.mBillboardHandler += mBillboardB.Show;
        //mWeatherStation.mBillboardHandler += mBillboardC.Show;

        //mWeatherStation.Update();

        ConcreteSubject1 mConcreteSubject1 = new ConcreteSubject1();
        ConcreteObserver1 mConcreteObserver1 = new ConcreteObserver1(mConcreteSubject1);

        mConcreteSubject1.RegisterObserver(mConcreteObserver1);


        mConcreteSubject1.subjectState = "状态改变";

    }

}

//public class WeatherStation
//{
//    public delegate void billboardHandler();
//    public event billboardHandler mBillboardHandler;

//    public void Update()
//    {
//        mBillboardHandler();
//    }

//}

//public class BillboardA
//{
//    public void Show()
//    {
//        Debug.Log("A布告板显示气象信息");
//    }
//}

//public class BillboardB
//{
//    public void Show()
//    {
//        Debug.Log("B布告板显示气象信息");
//    }
//}

//public class BillboardC
//{
//    public void Show()
//    {
//        Debug.Log("C布告板显示气象信息");
//    }
//}
public abstract class Subject
{
    private List<Observer> mObservers = new List<Observer>();

    public void RegisterObserver(Observer observer)
    {
        mObservers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        mObservers.Remove(observer);
    }

    public void NotifyObserver()
    {
        foreach(Observer ob in mObservers)
        {
            ob.Update();
        }
    }
}

public class ConcreteSubject1:Subject
{
    private string mSubjectState;
    public string subjectState { set { mSubjectState = value; NotifyObserver(); } get { return mSubjectState; } }
}

public abstract class Observer
{
    public abstract void Update();
}

public class ConcreteObserver1:Observer
{
    public ConcreteSubject1 mSub;
    public ConcreteObserver1(ConcreteSubject1 sub)
    {
        mSub = sub;
    }

    public override void Update()
    {
        Debug.Log("Observer1更新显示" + mSub.subjectState);
    }
}


