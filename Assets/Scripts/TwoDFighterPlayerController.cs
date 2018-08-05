using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightGameSystem
{
    public class TwoDFighterPlayerController : TwoDPlayerController
    {

        public bool initialised;
        public Transform ennemy;
        public bool damage;
        public float life;

        public IEnumerator Start()
        {
            base.Start();
            while (ennemy == null)
            {
                GameObject[] Players = GameObject.FindGameObjectsWithTag("Players");
                foreach (GameObject player in Players)
                {
                    if (player != this)
                        ennemy = player.transform;
                }

                yield return new WaitForEndOfFrame();

            }
            initialised = true;
        }

        public new void FixedUpdate()
        {
            if (initialised)
                base.FixedUpdate();
        }

        #region public_methods
        public void PushBack(float distance)
        {


        }

        public override void Damage( AttackDescriptor damagedesc )
        {

            life -= damagedesc.damage;
            damage = true;
            StartCoroutine(HitStun(damagedesc.hitstun));

        }

        public IEnumerator HitStun(float hitstun)
        {
            float frameElapsed = 0f;
            while(frameElapsed< hitstun)
            {
                yield return new WaitForEndOfFrame();
                frameElapsed++;
            }
            damage = false;
        }
        #endregion

        #region monobehaviour_callback
        public new void Update()
        {
            AttackInput();
            ScaleCheck();
            animator.SetBool( "Attack1", attack[0] );
                //Damage();
            animator.SetBool( "Attack2", attack[1] );
            animator.SetBool("Damage", damage);

            base.Update();
        }
        #endregion

        public void ScaleCheck()
        {
            if( transform.position.x <ennemy.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }else
            {
                transform.localScale =  Vector3.one;
            }
        }

       

        public override void ChildClassBehaviour(ref Vector3 tmpMovement)
        {
            // Fighter Characters don't move while attacking
            if (onGround && (attack[0] || attack[1]))
            {
                tmpMovement = Vector3.zero;
            }
        }

        protected void AttackInput()
        {
            if (Input.GetButtonDown("Attack1" + playerNumber.ToString()))
            {
                attack[0] = true;
                attackTimer[0] = 0;
            }
            if (attack[0])
            {
                attackTimer[0] += Time.deltaTime;
                if (attackTimer[0] > attackRate)
                {
                    attack[0] = false;
                    attackTimer[0] = 0;
                }
            }
            if (Input.GetButtonDown("Attack2" + playerNumber.ToString()))
            {
                attack[1] = true;
                attackTimer[1] = 0;
            }
            if (attack[1])
            {
                attackTimer[1] += Time.deltaTime;
                if (attackTimer[1] > attackRate)
                {
                    attack[1] = false;
                    attackTimer[1] = 0;
                }
            }
        }
    }
}
