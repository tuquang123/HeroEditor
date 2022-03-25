using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATT : MonoBehaviour
{
    public Fl fl;
    public Animator anm;
    //public bool turnOff = true;

    public float attackRage = 20f;
    public Transform target;
    public float attackSpeed = 2f;
    [HideInInspector] public float attackTimer;
    [HideInInspector]public float targetDis = Mathf.Infinity;
    [HideInInspector] public Vector3 targetDir;

    public bool Wand;
    public bool Bow;
    public bool Sword;
    public bool Hand;
    public bool Axe;

    private void Start()
    {
        attackSpeed = Manager.instace.attackSpeed;
    }
    private void Reset()
    {
        fl = transform.GetComponentInParent<Fl>();
    }
    private void Turning()
    {
        if (target == null) return;
        //if (turnOff)
        {
            targetDir = target.position - transform.position;
            Transform charTrans = fl.transform;
            charTrans.transform.localScale = new Vector3(Mathf.Sign(targetDir.x), 1, 1);
        }
    }
    public void FixedUpdate()
    {
        Turning();
        FindEnemy();
        IsTargetTooFar();
    }
    public virtual void FindEnemy()
    {
        //if (this.target== null) return;
        if (this.target) return;
        float dis;
        foreach (Transform obj in EnemySpawn.instance.objects)
        {
            dis = Vector3.Distance(transform.position, obj.position);
            if (dis <= attackRage)
            {
                SetTaget(obj);

                return;

            }

        }
    }
    public void SetTaget(Transform target)
    {
        this.target = target;
        return;
    }

    public void IsTargetTooFar()
    {
        if (this.target == null) return;
        if (!this.target.gameObject.activeSelf)
        {
            this.target = null;
            return;
        }
        targetDis = Vector3.Distance(transform.position, this.target.position);
        if (targetDis > attackRage) target = null;
    }
    public void Attack()
    {
        if (target == null) return;
        attackTimer += Time.deltaTime;
        if (attackTimer < attackSpeed) return;
        attackTimer = 0;
        //anm.SetTrigger("att");
        anm.SetBool("run", false);
        if (Wand)
        {
            anm.SetTrigger("shoot");
        }
        else if (Bow)
        {
            anm.SetTrigger("bow");
        }
        else if (Sword)
        {
            anm.SetTrigger("att");
        }
        else if (Hand)
        {
            anm.SetTrigger("punch");
        }
        else if (Axe)
        {
            anm.SetTrigger("axe");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRage);
    }

}
