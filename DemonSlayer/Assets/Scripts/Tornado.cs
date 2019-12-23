using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float speed;
    public float damage;

    Rigidbody2D body;

    float direction;
    void Awake()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentAttack + 50;
        //damage = Player.baseAttack + 50;
        body = GetComponent<Rigidbody2D>();
        if (transform.rotation.y != 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        StartCoroutine(DestroyTornado(0.5f));
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        body.velocity = new Vector2(speed*direction, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x*50, 400));
        }
        
    }
    IEnumerator DestroyTornado(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
