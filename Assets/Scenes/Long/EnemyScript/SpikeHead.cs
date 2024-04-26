using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpikeHead : DeathPlayer
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float time;
    [SerializeField] float timeDelay;
    [SerializeField] bool isAttacking;
    [SerializeField] LayerMask PlayerMask;
    Vector3 destitation;
    Vector3[] direction = new Vector3[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            transform.Translate(destitation * speed * Time.deltaTime);
        }
        else
        {
            time += Time.deltaTime;
            if(time > timeDelay)
            {
                followPlayer();
            }
        }
    }

    void followPlayer()
    {
        calculateDirection();
        for(int i = 0; i < direction.Length; i++)
        {
            Debug.DrawRay(transform.position , direction[i] , Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction[i] * range, range, PlayerMask);
            if(hit.collider != null && !isAttacking)
            {
                Debug.Log(hit.collider);
                isAttacking = true;
                time = 0;
                destitation = direction[i];
            }
        }
    }

    void calculateDirection()
    {
        direction[0] = Vector3.right * range;
        direction[1] = Vector3.left * range;
        direction[2] = Vector3.up * range;
        direction[3] = Vector3.down * range;

    }

    private void Stopped()
    {
        isAttacking = false;
        destitation = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stopped();
    }
}
