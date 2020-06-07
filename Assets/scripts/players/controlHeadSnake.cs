using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlHeadSnake : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMove;
    public float speedRotatet;
    GameObject headSnake;
    public KeyCode left;
    public KeyCode right;

    void Start()
    {
        headSnake = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        headSnake.transform.Translate(Vector3.forward * Time.deltaTime*speedMove);
        if (Input.GetKey(left))
        {
            headSnake.transform.Rotate(Vector3.up, -speedRotatet * Time.deltaTime);
        }
        if(Input.GetKey(right))
        {
            headSnake.transform.Rotate(Vector3.up, speedRotatet * Time.deltaTime);
        }
    }
}
