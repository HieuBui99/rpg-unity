using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public float damage;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="HitBox")
        {
            if (collision.gameObject.name == "Light Attack Hitbox")
            {
                damage = collision.gameObject.GetComponent<LightAttackBehavior>().damage;
            }
            else if (collision.gameObject.name == "Heavy Attack Hitbox")
            {
                damage = collision.gameObject.GetComponent<HeavyAttackBehavior>().damage;
            }
            else if (collision.gameObject.name == "Up Hitbox")
            {
                damage = collision.gameObject.GetComponent<UpAttackBehavior>().damage;
            }
            else if (collision.gameObject.name == "Skill 1 Hitbox")
            {
                damage = collision.gameObject.GetComponent<Skill1Behavior>().damage;
            }
        }
        else if (collision.gameObject.tag == "Tornado")
        {
            damage = collision.gameObject.GetComponent<Tornado>().damage;
        }
        
    }
}
