using System;
using System.Collections.Generic; 
using System.Text;

public class SoldierAttribute:ICharacterAttribute
{
    public SoldierAttribute(IAttrStrategy strategy, int level, CharacterBaseAttr baseAttr) : base(strategy, level,baseAttr) { }
}
