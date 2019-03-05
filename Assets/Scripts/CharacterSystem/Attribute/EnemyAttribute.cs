using System;
using System.Collections.Generic;
using System.Text;

public class EnemyAttribute:ICharacterAttribute
{
    public EnemyAttribute(IAttrStrategy strategy, int level, CharacterBaseAttr baseAttr) : base(strategy,level,baseAttr) { }
}

