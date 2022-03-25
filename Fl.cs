using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fl : MonoBehaviour
{
    //public Check check;
    public ATT att;
    private Rigidbody rb;

    public float speed = 1f;
    public float minimumDistance = 10;
    private void Reset()
    {
        att = transform.GetComponentInChildren<ATT>();
    }
   /* public Combat combat;
    [HideInInspector] public int dame;*/
    private void Start()
    {
        speed = Manager.instace.speed;
        //combat.dameAdd(dame);
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (att.target == null)
        {
            att.anm.SetBool("run", false);
        }
        else if (att.target)
        {
            if (Vector2.Distance(transform.position, att.target.position) > minimumDistance )//&& check.gg == false)
            {
                att.anm.SetBool("run", true);
                transform.position =
                Vector2.MoveTowards(transform.position, att.target.position, speed * Time.deltaTime );
            }
            if (Vector2.Distance(transform.position,att.target.position) <= minimumDistance ) //&& check.gg == true)
            {
                att.anm.SetBool("run", false);
                Attack();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(att.transform.position, minimumDistance);
    }
    public virtual void Attack()
    {
        att.Attack();
    }
}
