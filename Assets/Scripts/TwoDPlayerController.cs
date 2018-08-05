using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwoDPlayerController : MonoBehaviour
{

    public int playerNumber;

    public Rigidbody2D rigidbody;
    public Animator animator;

    protected  float horizontal, vertical, speedmoving , maximumspeed = 25f , jumpDuration =1f , jmpDuration = 0f , jumpforceValue = 10f ;
    protected float currentjumpforce;

    protected Vector3 movement;//, jmpforce;
    protected bool crouch, onGround  , jumpkey ,falling;

    protected float attackRate = 0.3f;

    protected bool[] attack = new bool[2];
    protected float[] attackTimer = new float[2];

    // Use this for initialization
    protected void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
	}

    protected void FixedUpdate()
    {
        //base Behaviour crouch Move & jump 

        horizontal = Input.GetAxis("Horizontal" + playerNumber);
        vertical = Input.GetAxis("Vertical" + playerNumber);
        Vector3 tmpMovement = new Vector3(horizontal, 0, 0);
        crouch = (vertical < -0.1f);
        if (vertical > 0.1f)
        {
            if (onGround)
            {
                jumpkey = true;
                currentjumpforce = jumpforceValue;
                rigidbody.AddForce(new Vector2(0f, currentjumpforce), ForceMode2D.Impulse);
            }
        }
        if (jumpkey)
        {
            jmpDuration += Time.deltaTime;
            if (jmpDuration < jumpDuration)
            {
                //Physics.gravity=
            }
            else
            {
                jumpkey = false;
            }
        }
        if (rigidbody.velocity.y < 0f)
        {
            falling = true;
        }

        ChildClassBehaviour(ref tmpMovement);

        if (!crouch)
        {
            rigidbody.AddForce(tmpMovement * maximumspeed);
        }
        else
            rigidbody.velocity = Vector2.zero;
    }

    protected void Update()
    {
        UpdateAnimator();
    }
    /*
    public void OnGroundCheck()
    {
        if ( OnGroundCheck )
        {

        }
    }*/

    public abstract void ChildClassBehaviour(ref Vector3 tmpMovement);
    public abstract void Damage(AttackDescriptor damageValue);
    protected void UpdateAnimator()
    {
        animator.SetBool("Crouch", crouch);
        animator.SetBool("OnGround", onGround);
        animator.SetBool("Falling", falling);
        animator.SetFloat("Movement", Mathf.Abs(horizontal));
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = true;
            currentjumpforce = jumpforceValue;
            jmpDuration = 0f;
            falling = false;
        }

    }

 

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = false;
        }
    }
}
