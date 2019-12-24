using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAlly : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform firePoint;
    public GameObject allyPrefab;
    public GameObject thunderFX;
    public AudioSource source;
    public AudioClip thunder;

    float attackTime = 0f;
    float timeBetweenAttack = 10f;
    
    void Awake()
    {
        if (source == null) source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= attackTime)
        {
            attackTime = Time.time + timeBetweenAttack;
            GameObject ally;
            GameObject fx;
            if (GetComponent<Transform>().localScale.x > 0)
            {
                ally = Instantiate(allyPrefab, spawnPoint.position, Quaternion.identity);
                fx = Instantiate(thunderFX, firePoint.position, Quaternion.identity);
            }
            else
            {
                ally = Instantiate(allyPrefab, spawnPoint.position, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                fx = Instantiate(thunderFX, firePoint.position, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
            }
      
            source.PlayOneShot(thunder);
            Destroy(ally, 1f);
            Destroy(fx, 0.5f);
        }
    }
}
