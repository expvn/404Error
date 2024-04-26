using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;
    Vector2[] direction = new Vector2[2];
    public GameObject lightning;
    float time;
    [SerializeField] float timeDelay;
    
    public void attack(bool check)
    {
        if (check) followPlayer();
    }

    void followPlayer()
    {
        calculateDirection();
        shoot();
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        for(int i = 0; i < direction.Length; i++)
        {
            Debug.DrawRay(transform.position , direction[i] , Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position , direction[i] , range , mask );
            if(hit.collider != null)
            {
                speed *= -1f;
            }
        }
    }

    void calculateDirection()
    {
        direction[0] = Vector2.left * range;
        direction[1] = Vector2.right * range;
    }

    void shoot()
    {
        time += Time.deltaTime;
        if(time > timeDelay)
        {
            time = 0;
            lightning.SetActive(true);
        }
        else
        {
            lightning.SetActive(false);
        }
        
    }
}
