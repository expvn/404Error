using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] float weightCam;
    private void Update()
    {
       
        transform.position = new Vector3(player.position.x, player.position.y + weightCam, transform.position.z);
    }
}
