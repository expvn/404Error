using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Hit();
        }
    }
}
