using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVictory : MonoBehaviour
{
    public GameObject crow;
    public void Victory()
    {
        Vector3 playerPos = transform.position;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Instantiate(crow, new Vector3(playerPos.x+6, playerPos.y+1, 0), Quaternion.identity);
        gameObject.GetComponent<Animator>().SetTrigger("Victory");
        gameObject.GetComponent<Player>().canMove = false;
        GameManager.gm.LoadVictoryScreen();
    }
}
