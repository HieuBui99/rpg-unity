using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public float damage;
    void Awake()
    {
       damage = FindObjectOfType<Player>().currentAttack + 100;
    }
    void DestroyThunder()
    {
        Destroy(gameObject);
    }

}
