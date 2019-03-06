using System;
using System.Collections.Generic;
using System.Text;

public class EnemyEif : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}

