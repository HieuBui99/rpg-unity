using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("abc");
        if (other.gameObject.tag == "HitBox")
        {
            Destroy(gameObject);
        }
    }
}
