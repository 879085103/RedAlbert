using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AliveCountVisit : ICharacterVisitor
{
    public int enemyCount { get; private set; }
    public int soldierCount { get; private set; }

    public void Reset()
    {
        enemyCount = 0;
        soldierCount = 0;
    }

    public override void VisitorEnemy(IEnemy enemy)
    {
        if(enemy.isKilled == false)
        enemyCount++;
    }

    public override void VisitorSoldier(ISoldier soldier)
    {
        if(soldier.isKilled == false)
        soldierCount++;
    }
}

