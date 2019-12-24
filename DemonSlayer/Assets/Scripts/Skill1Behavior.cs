using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Behavior : MonoBehaviour
{
    public float damage;
    public AudioSource source;
    public AudioClip slashSFX;
    void Awake()
    {
        if (source == null) source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        damage = GetComponentInParent<Player>().currentAttack + 30;
        //damage = Player.baseAttack + 30;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        source.PlayOneShot(slashSFX);
      
    }


}
