using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AttackDescriptor : MonoBehaviour
{
    
    public float damage;
    public float hitstun;
    public string text;
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag !="Ground")
        {
            collider2D.transform.GetComponent<TwoDPlayerController>().Damage(this);
        }
    }
}
