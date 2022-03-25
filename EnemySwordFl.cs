using Assets.HeroEditor.Common.CharacterScripts;
using Assets.HeroEditor.Common.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordFl : MonoBehaviour
{
    public EnemySword AttackExample;
    public Rigidbody rb;
    public float speed = 5f;

    public Character character;
    public float minimumDistance;
    private void FixedUpdate()
    {
        if (AttackExample.target == null)
        {
            character.SetState(CharacterState.Idle);
        }
        else if (AttackExample.target)
        {
            if (Vector2.Distance(transform.position, AttackExample.target.position) > minimumDistance)
            {
                character.SetState(CharacterState.Run);
                transform.position =
                Vector2.MoveTowards(transform.position, AttackExample.target.position, speed * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, AttackExample.target.position) <= minimumDistance)
            {
                Attack();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(character.transform.position, minimumDistance);
    }
    public virtual void Attack()
    {
        AttackExample.Attack2();
        character.SetState(CharacterState.Idle);
        return;
    }
}
