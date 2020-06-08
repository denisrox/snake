using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraForPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 10, 0); //камера всегда там же где игрок, но на 10 метров выше
    }
}
