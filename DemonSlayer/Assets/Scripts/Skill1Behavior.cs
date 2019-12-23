using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Behavior : MonoBehaviour
{
    public float damage;
    void Awake()
    {
        damage = GetComponentInParent<Player>().currentAttack + 30;
        //damage = Player.baseAttack + 30;
    }

}
