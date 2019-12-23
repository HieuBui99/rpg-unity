using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    ////public float moveSpeed = 2f;
    ////public float damage = 1f;
    //public float health = 5f;

    public GameObject[] wayPoints;
    public float waitAtWavePointTime = 1f;

    Rigidbody2D body;
    Animator animator;

    int wayPointIndex = 0;
    float moveTime;
    float dx = 0f;
    bool moving;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveTime = 0f;
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= moveTime)
        {
            Move();
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            StartCoroutine(player.TakeDamage(damage));
        }
        else if (collision.gameObject.tag=="HurtBox")
        {
            Player player = collision.gameObject.GetComponentInParent<Player>();
            StartCoroutine(player.TakeDamage(damage));
        }

        else if (collision.gameObject.tag=="HitBox" || collision.gameObject.tag=="Tornado")
        {
            float damage = GetComponent<ApplyDamage>().damage;
            TakeDamage(damage);
        }
    }

    public override void Move()
    {
        if (moving)
        {
            Flip();
            dx = wayPoints[wayPointIndex].transform.position.x - gameObject.transform.position.x;
            if (Mathf.Abs(dx) <= 0.05f)
            {
                body.velocity = new Vector2(0, 0);
                wayPointIndex++;
                if (wayPointIndex >= wayPoints.Length) wayPointIndex = 0;
                moveTime = Time.time + waitAtWavePointTime;
            }
            else
            {
                animator.SetBool("Moving", true);
                body.velocity = new Vector2(gameObject.transform.localScale.x * moveSpeed, body.velocity.y);

            }
        }
    }

    public override void Flip()
    {
        Vector3 localScale = transform.localScale;

        if ((dx > 0) && (localScale.x < 0))
        {
            localScale.x *= -1;
        }
        else if ((dx < 0) && (localScale.x > 0))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;

    }

    public override void TakeDamage(float amount)
    {
        animator.Play("SkeletonDamaged");
        health -= amount;
        if (health <= 0)
        {
            StartCoroutine(KillSkeleton());
        }
    }

    IEnumerator KillSkeleton()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        animator.Play("SkeletonDie");
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
