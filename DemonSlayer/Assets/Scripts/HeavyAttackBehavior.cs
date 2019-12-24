
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public AudioSource source;
    public AudioClip slashSFX;
    void Awake()
    {
        if (source == null) source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        //damage = GetComponentInParent<Player>().baseAttack + 2;
        damage = Player.baseAttack + 10;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        source.PlayOneShot(slashSFX);
    }

}
