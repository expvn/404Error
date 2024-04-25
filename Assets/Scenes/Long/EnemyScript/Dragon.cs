using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;
    [SerializeField] bool isAttack;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayer();
    }

    void checkPlayer()
    {
        Debug.DrawRay(transform.position, Vector2.left * range, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * range, range, mask);
        if (hit.collider != null)
        {
            isAttack = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            anim.Play("RUN");
        }
        else if(hit.collider == null)
        {
            isAttack = false;
            anim.Play("IDLE");
        }
    }
}
