
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform respawnPoint;

    [SerializeField]
    Sprite checkedSprite;

    [SerializeField]
    Sprite uncheckedSprite;

    bool passCheckPoint = false;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !passCheckPoint)
        {
            Debug.Log("Set Check Point");
            passCheckPoint = true;
            SetRespawnPoint();
        }
    }
    void SetRespawnPoint()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = checkedSprite;
        respawnPoint.position = gameObject.transform.position;
    }
}
