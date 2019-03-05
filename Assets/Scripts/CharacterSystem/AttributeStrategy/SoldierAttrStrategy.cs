using System;
using System.Collections.Generic;
using System.Text;


public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCritDmgValue(float critRate)
    {
        return 0;        
    }

    public int GetDmgDescValue(int level)
    {
        return (level - 1) * 5;
    }

    public int GetExtraHPVaule(int level)
    {
        return (level - 1) * 10;
    }
}

