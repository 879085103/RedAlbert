using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class BuilderDesignMode:MonoBehaviour
{
    void Start()
    {
        Director director = new Director();
        IBuilder fatBuilder = new FatPersonBuilder();
        //IBuilder thinBuilder = new ThinPersonBuilder();

        director.Construct(fatBuilder);
        Person person = fatBuilder.GetPerson();
        person.Show();
    }
}

public class Person
{
    List<string> parts = new List<string>();
    public void AddPart(string part)
    {
        parts.Add(part);
    }
    public void Show()
    {
        foreach(string part in parts)
        {
            Debug.Log(part);
        }
    }
}

public interface IBuilder
{
    void BuildHead();
    void BuildBody();
    void BuildHand();
    void BuildFeet();
    Person GetPerson();
}

public class FatPersonBuilder:IBuilder
{
    private Person person ;

    public FatPersonBuilder()
    {
        person = new Person();
    }
    public void BuildHead()
    {
        person.AddPart("胖人头");
    }
    public void BuildBody()
    {
        person.AddPart("胖人身体");
    }
    public void BuildFeet()
    {
        person.AddPart("胖人脚");
    }
    public void BuildHand()
    {
        person.AddPart("胖人手");
    }
    public Person GetPerson()
    {
        return person;
    }
}

public class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new Person();
    }
    public void BuildHead()
    {
        person.AddPart("瘦人头");
    }
    public void BuildBody()
    {
        person.AddPart("瘦人身体");
    }
    public void BuildFeet()
    {
        person.AddPart("瘦人脚");
    }
    public void BuildHand()
    {
        person.AddPart("瘦人手");
    }
    public Person GetPerson()
    {
        return person;
    }
}

public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildHead();
        builder.BuildBody();
        builder.BuildHand();
        builder.BuildFeet();
    }
}



