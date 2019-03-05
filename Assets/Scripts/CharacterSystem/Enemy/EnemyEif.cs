using System;
using System.Collections.Generic;
using System.Text;

public class EnemyEif : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}

