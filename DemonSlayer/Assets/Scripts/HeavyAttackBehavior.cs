
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    void Awake()
    {
        damage = GetComponentInParent<Player>().baseAttack + 2;
    }

}
