using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject head;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
        if((target.transform.position - transform.position).magnitude > 0.8)
            transform.Translate(Vector3.forward * Time.deltaTime * head.GetComponent<HeadControl>().speedMove); //движение вперед. Т.к. змея двигается всегда вперед - то будет выполняться каждый кадр.
    }
}
