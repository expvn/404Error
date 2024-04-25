using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFall : MonoBehaviour
{
    public LayerMask mask;
    public float range;
    [SerializeField] float garity;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.down * range, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * range, range, mask);
        if (hit.collider != null)
        {
            rb.gravityScale = garity;
            Debug.Log("Hit");
        }
    }
}
