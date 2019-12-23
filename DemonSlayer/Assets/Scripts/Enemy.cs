using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float damage;
    public float health;


    public abstract void Flip();
    public abstract void Move();
    public abstract void TakeDamage(float amount);

}
