using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CampSystem:IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);

    }

    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string iconSprite = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;
        
        switch(soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                iconSprite = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                iconSprite = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                iconSprite = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                Debug.LogError("无法根据战士类型" + soldierType + "初始化兵营");
                break;

        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject, name, iconSprite, soldierType, position,trainTime);
        //添加监听点击脚本
        CampOnClick campOnClick =  gameObject.AddComponent<CampOnClick>();
        campOnClick.Camp = camp;
        mSoldierCamps.Add(soldierType, camp);
    }

    public override void Update()
    {
        //更新兵营状态
        foreach(SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }
    }
}

