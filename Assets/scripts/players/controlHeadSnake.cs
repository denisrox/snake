using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlHeadSnake : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMove;
    public float speedRotatet;
    GameObject headSnake;
    void Start()
    {
        headSnake = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //headSnake.GetComponent<GameObject>().transform.forward;
    }
}
