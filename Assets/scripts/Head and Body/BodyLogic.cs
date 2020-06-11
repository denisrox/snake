using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject head;
    public Queue<Vector3> pointsTrajectory=new Queue<Vector3>();
    public Queue<Vector3> pointsTrajectory2 = new Queue<Vector3>();
    public Vector3 pointTrajectory;
    public bool isRotate = false;

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

        MoveBody();
        //При приближении к target замедляемся (чтобы не въезжать в target на поворотах, при снижении скорости)

    }
    void MoveBody()
    {
        //=========пиздим координаты движения у объекта впереди===//
        if (target == head)
        {
            if (head.GetComponent<HeadControl>().pointsTrajectory.Count != 0)
                pointsTrajectory.Enqueue(head.GetComponent<HeadControl>().pointsTrajectory.Dequeue());
        }
        else 
            if (target.GetComponent<BodyLogic>().pointsTrajectory.Count != 0)
                pointsTrajectory.Enqueue(target.GetComponent<BodyLogic>().pointsTrajectory.Peek());

        //=============Начинаем двигаться вперед в зависимости от того, есть ли у нас очередь//
        if (pointsTrajectory.Count == 0 )
        {
            if ((target.transform.position - transform.position).magnitude > 0.8f)
            {
                transform.LookAt(target.transform.position);
                transform.position = target.transform.position - target.transform.forward * 0.8f;
            }
            /*if ((target.transform.position - transform.position).magnitude > 0.8)
                transform.Translate(Vector3.forward * Time.deltaTime * 2* head.GetComponent<HeadControl>().movementSpeed);*/
            
        }
        else
        {
            
            if (((pointsTrajectory.Peek() - transform.position).magnitude/2f > (head.GetComponent<HeadControl>().movementSpeed * Time.deltaTime)) 
                && (target.transform.position - transform.position).magnitude > 0.8)
            {
                /*transform.LookAt(pointsTrajectory.Peek());  //сделать аналогично 49 строчке
                transform.Translate(Vector3.forward * ((target.transform.position-transform.position).magnitude-0.8f));*/
                transform.LookAt(pointsTrajectory.Peek());  //сделать аналогично 49 строчке
                transform.Translate(Vector3.forward * Time.deltaTime * 2 * head.GetComponent<HeadControl>().movementSpeed);
                /*transform.LookAt(target.transform.position);
                transform.position = target.transform.position - target.transform.forward * 0.8f;*/
            }
            else
            {
                if((target.transform.position - transform.position).magnitude > 0.8)
                    transform.position = pointsTrajectory.Dequeue();
               
                while(pointsTrajectory.Count != 0 && 
                    ((pointsTrajectory.Peek() - transform.position).magnitude * 2f < (head.GetComponent<HeadControl>().movementSpeed * Time.deltaTime)) && 
                    ((target.transform.position - transform.position).magnitude > 0.8f))
                    transform.position = pointsTrajectory.Dequeue();
            }
                
            
        }
    }

}
