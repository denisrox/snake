using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMove;
    public float speedRotatet;
    private GameObject headSnake;
    public KeyCode left;
    public KeyCode right;

    void Start()
    {
        headSnake = gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        
        headSnake.transform.Translate(Vector3.forward * Time.deltaTime*speedMove); //движение вперед. Т.к. змея двигается всегда вперед - то будет выполняться каждый кадр.

        if (Input.GetKey(left))
        {
            headSnake.transform.Rotate(Vector3.up, -speedRotatet * Time.deltaTime);//поворот налево
        }
        if(Input.GetKey(right))
        {
            headSnake.transform.Rotate(Vector3.up, speedRotatet * Time.deltaTime);//поворот направо
        }
    }
}
