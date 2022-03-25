using System;
using Assets.HeroEditor.Common.CharacterScripts;
using Assets.HeroEditor.Common.CharacterScripts.Firearms;
using Assets.HeroEditor.Common.CharacterScripts.Firearms.Enums;
using HeroEditor.Common.Enums;
using UnityEngine;

namespace Assets.HeroEditor.Common.ExampleScripts
{
    /// <summary>
    /// Rotates arms and passes input events to child components like FirearmFire and BowExample.
    /// </summary>
    public class EnemySword : MonoBehaviour
    {
        //public float attackSpeed = 0.5f;
        public Character charactor;
        public float attackRage = 2f;
        public Transform target;
        public float attackSpeed = 1f;
        public float attackTimer;
        public float targetDis = Mathf.Infinity;
        public Vector3 targetDir;
        public bool ad;

        public void Turning()
        {
            if (target == null) return;
            //if (turnOff)
            {
                targetDir = target.position - transform.position;
                Transform charTrans = charactor.transform;
                charTrans.transform.localScale = new Vector3(Mathf.Sign(targetDir.x), 1, 1);
            }
        }
        public void FixedUpdate()
        {
            charactor.Animator.SetBool("Ready", true);
            Turning();
            FindEnemy();
        }
        public void FindEnemy()
        {
            if (this.target) return;
            float dis;
            //var tar = target2.gameObject.transform;
            foreach (Transform obj in PlayerSpawn.instance.objects)
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
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(charactor.transform.position, attackRage);
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
        public void Attack2()
        {
            if (target == null) return;
            attackTimer += Time.deltaTime;
            if (attackTimer < attackSpeed) return;
            attackTimer = 0;
            if (ad)
            {
                charactor.Animator.SetTrigger("skill1");
            }
            else
            {
                charactor.Slash();
            }
        }

    }
}