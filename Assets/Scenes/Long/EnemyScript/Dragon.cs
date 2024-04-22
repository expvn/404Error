using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dragon : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float directionToPlayer = Mathf.Atan2(direction.x , direction.y) * Mathf.Rad2Deg;
        Debug.Log(directionToPlayer);
        Quaternion rotation = Quaternion.AngleAxis(directionToPlayer, Vector3.forward);
        transform.rotation = rotation;
    }
}
