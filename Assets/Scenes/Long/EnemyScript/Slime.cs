using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] bool isAttack;
    [SerializeField] float distance;
    [SerializeField] float time, timeDelay, force;

    [SerializeField] Transform target;
    [SerializeField] Transform firePos;
    [SerializeField] GameObject bullet;
    private Animator anim;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        if (searchPlayer())
        {
            shoot();
            anim.Play("attack");
        }
        else
        {
            anim.Play("SlimeFlyIdel");
        }
    }

    bool searchPlayer()
    {
        Debug.Log(Vector2.Distance(target.position, transform.position));
        if (Vector2.Distance(target.position, transform.position) <= distance)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
        return isAttack;
    }
    void shoot()
    {
        time += Time.deltaTime;
        if (time > timeDelay)
        {
            bulletPre();
            time = 0;
        }
    }

    void rotation()
    {
        Vector2 angle = target.position - transform.position;
        if(angle.x > 0f)
        {
            sprite.flipX = true;
        }
        if(angle.x < 0f)
        {
            sprite.flipX = false;
        }
    }

    void bulletPre()
    {
        GameObject obj = Instantiate(bullet, firePos.position, Quaternion.identity);
        Vector3 direction = target.position - obj.transform.position;
        Rigidbody2D rigi = obj.GetComponent<Rigidbody2D>();
        if (rigi != null)
        {
            rigi.velocity = new Vector2(direction.x, direction.y).normalized * force;
        }
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0, 0, rotation);
        Destroy(obj, 2f);
    }


}
