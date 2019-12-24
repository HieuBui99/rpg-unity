using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttackBehavior : MonoBehaviour
{
    public float damage;
    public AudioSource source;
    public AudioClip slashSFX;
    void Awake()
    {
        if (source == null) source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        damage = GetComponentInParent<Player>().currentAttack + 10;
        //damage = Player.baseAttack + 10;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        source.PlayOneShot(slashSFX);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 350));
    }

}
