using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterBuildDirector
{

    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddInCharacterSystem();
        return builder.GerResult();
    }
}

