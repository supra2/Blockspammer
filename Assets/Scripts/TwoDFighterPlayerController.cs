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

        public new void Update()
        {
            base.Update();
            ScaleCheck();
        }

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

        public override void ChildClassBehaviour()
        {
            // Fighter Characters don't move while attacking
            if (onGround && (attack[0] || attack[1]))
            {

                movement = Vector3.zero;
            }
        }

    

    }
}
