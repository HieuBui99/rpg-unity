using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Viecory");
            collision.gameObject.GetComponent<PlayerVictory>().Victory();
            Destroy(gameObject);
        }
    }
}
