using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrap : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] bool isHit;
    [SerializeField] float graviti;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayer();
        if (isHit)
        {
            rb.gravityScale = graviti;
        }
        Debug.Log(isHit);
    }

    void checkPlayer()
    {
        Debug.DrawRay(transform.position, Vector2.down * range , Color.yellow);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * range, mask);
        Debug.Log(hit.collider);
        if(hit.collider != null)
        {
            isHit = true;
        }
        else
        {
            isHit = false;
        }
    }
}
