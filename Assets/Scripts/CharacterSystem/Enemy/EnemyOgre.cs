using System;
using System.Collections.Generic;
using System.Text;

public class EnemyOgre : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}