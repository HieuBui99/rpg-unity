
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float damage = 2f;
    public float minotaurHealth = 10f;
    public float attackRadius = 2f;

    public Transform[] chaseBoundary;
    public Transform player;

    public GameObject hitBox;

    Rigidbody2D body;
    Animator animator;

    bool moving = false;
    bool attacking = false;
    float distToPlayer;
    float attackTime = 0f;
    float timeBetweenAttack = 2.5f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (hitBox != null) hitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                return;
            }
            //distToPlayer = Vector2.Distance(transform.position, player.position);
            //if (distToPlayer < attackRadius)
            //{
            //    if (Time.time >= attackTime)
            //    {
            //        StartCoroutine(Attack());
            //    }
            //}
            if (player.position.x > chaseBoundary[0].position.x && player.position.x < chaseBoundary[1].position.x && !attacking)
            {
                Flip();
                moving = true;
                animator.SetBool("Moving", moving);
                if (transform.position.x < player.position.x)
                {
                    body.velocity = new Vector2(moveSpeed, 0);
                }
                else if (transform.position.x > player.position.x)
                {
                    body.velocity = new Vector2(-moveSpeed, 0);
                }
            }
            else
            {
                moving = false;
                animator.SetBool("Moving", moving);
                body.velocity = new Vector2(0, 0);
            }
        }
        catch { }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            StartCoroutine(player.TakeDamage(damage));
        }
        else if (collision.gameObject.tag == "HurtBox")
        {
            Player player = collision.gameObject.GetComponentInParent<Player>();
            StartCoroutine(player.TakeDamage(damage));
        }

        else if (collision.gameObject.tag == "HitBox" || collision.gameObject.tag == "Tornado")
        {
            float damage = GetComponent<ApplyDamage>().damage;
            TakeDamage(damage);
        }
    }


    void Flip()
    {
        Vector3 localScale = transform.localScale;
        if (body.velocity.x > 0 && localScale.x < 0)
        {
            localScale.x *= -1;
        }
        else if (body.velocity.x < 0 && localScale.x > 0)
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    public void TakeDamage(float amount)
    {
        animator.Play("MinotaurDamaged");
        minotaurHealth -= amount;
        if (minotaurHealth <= 0)
        {
            StartCoroutine(KillMinotaur());
        }
    }

    IEnumerator Attack()
    {
        if (moving) moving = false;
        body.velocity = new Vector2(0, 0);
        attackTime = Time.time + timeBetweenAttack;
        attacking = true;
        animator.Play("MinotaurAttack");
        yield return new WaitForSeconds(0.7f);
        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitBox.SetActive(false);
        attacking = false;
    }
    IEnumerator KillMinotaur()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        animator.Play("MinotaurDie");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
