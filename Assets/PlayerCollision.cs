using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "End")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

}
