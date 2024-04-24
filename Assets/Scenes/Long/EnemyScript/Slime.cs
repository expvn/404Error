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
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
