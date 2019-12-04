using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float speed;

    Rigidbody2D body;

    float direction;
    // Start is called before the first frame update
    void Awake()
    {
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

    IEnumerator DestroyTornado(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
