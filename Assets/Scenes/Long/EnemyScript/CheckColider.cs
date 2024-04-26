using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColider : MonoBehaviour
{
    [SerializeField] bool isAttack = false;
    public CloudEnemy enemy;
    // Update is called once per frame
    void Update()
    {
        enemy.attack(isAttack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("isHit");
            isAttack = true;
        }
    }
}
