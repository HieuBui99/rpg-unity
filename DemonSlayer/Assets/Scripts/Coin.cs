
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "HurtBox")
        {
            source.PlayOneShot(clip);
            GameManager.gm.CollectCoin(1);
            Destroy(this.gameObject);
        }
       
    }
 }
