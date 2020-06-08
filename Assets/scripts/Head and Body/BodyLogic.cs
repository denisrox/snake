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
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //При приближении к target замедляемся (чтобы не въезжать в target на поворотах, при снижении скорости)
        transform.LookAt(target.transform.position);
        if((target.transform.position - transform.position).magnitude > 0.8)
            transform.Translate(Vector3.forward * Time.deltaTime * head.GetComponent<HeadControl>().movementSpeed); 
    }
}
