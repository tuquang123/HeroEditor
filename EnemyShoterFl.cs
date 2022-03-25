using Assets.HeroEditor.Common.CharacterScripts;
using Assets.HeroEditor.Common.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoterFl : EnemySwordFl
{
    public override void Attack()
    {
        character.SetState(CharacterState.Idle);
        return;
    }
}
   

