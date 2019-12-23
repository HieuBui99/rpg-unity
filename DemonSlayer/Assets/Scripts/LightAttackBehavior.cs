using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackBehavior : MonoBehaviour
{

    public float damage;
    void Awake()
    {
        damage = GetComponentInParent<Player>().currentAttack;
        //damage = Player.baseAttack;
    }
   
}
