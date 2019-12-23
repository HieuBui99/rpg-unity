using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurHitBox : MonoBehaviour
{
    float damage;
    void Awake()
    {
        damage = gameObject.GetComponentInParent<Minotaur>().damage;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="HurtBox")
        {
            Player player = collision.gameObject.GetComponentInParent<Player>();
            StartCoroutine(player.TakeDamage(damage));
        }
    }
}
