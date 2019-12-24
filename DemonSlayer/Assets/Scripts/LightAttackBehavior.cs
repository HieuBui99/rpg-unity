using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackBehavior : MonoBehaviour
{

    public float damage;
    public AudioSource source;
    public AudioClip slashSFX;
    void Awake()
    {
        if (source == null) source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        damage = GetComponentInParent<Player>().currentAttack;
        //damage = Player.baseAttack;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.gameObject.tag == "Enemy")
        {
            source.PlayOneShot(slashSFX);
        }
    }
   
}
