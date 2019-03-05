using System;
using System.Collections.Generic;
using System.Text;

//策略模式
public interface IAttrStrategy
{
    //升级增加的HP
    int GetExtraHPVaule(int level);
    //升级减免的伤害
    int GetDmgDescValue(int level);
    //暴击的伤害
    int GetCritDmgValue(float critRate);
}

