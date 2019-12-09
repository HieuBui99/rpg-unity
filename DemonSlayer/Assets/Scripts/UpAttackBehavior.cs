using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttackBehavior : MonoBehaviour
{
    public float damage;
    void Awake()
    {
        damage = GetComponentInParent<Player>().baseAttack + 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 350));
    }

}
