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
    public int countPointsTrajectory;
    public int countPointsTrajectory2;

    //переменные для 4 метода
    public Vector3 targetPreviousVectorDirection;
    public Vector3 targetPositionWhenBeginDoTurn;

    void Start()
    {
        targetPreviousVectorDirection = target.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        MoveBodyFour();
        //При приближении к target замедляемся (чтобы не въезжать в target на поворотах, при снижении скорости)

    }
    void MoveBodyOne()
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

    void MoveBodyTwo()
    {
        countPointsTrajectory = pointsTrajectory.Count;
        countPointsTrajectory2 = pointsTrajectory2.Count;
        if (head.GetComponent<OnEatFood>().lastBody==gameObject)
        {
            Debug.Log("1:" + pointsTrajectory.Count);
            Debug.Log("2:" + pointsTrajectory2.Count);
        }
        if (target == head)
        {
            if (head.GetComponent<HeadControl>().pointsTrajectory.Count != 0)
            {
                pointsTrajectory.Enqueue(head.GetComponent<HeadControl>().pointsTrajectory.Dequeue());
                pointsTrajectory2.Enqueue(pointsTrajectory.Peek());
            }

        }
        else
        {
            if (target.GetComponent<BodyLogic>().pointsTrajectory.Count != 0)
            {
                pointsTrajectory.Enqueue(target.GetComponent<BodyLogic>().pointsTrajectory.Dequeue());
                pointsTrajectory2.Enqueue(pointsTrajectory.Peek());
                //if (head.GetComponent<OnEatFood>().lastBody != gameObject)
            }

        }
        if (pointsTrajectory2.Count > 0)
        {
            if ((target.transform.position - transform.position).magnitude > 0.8)
                transform.position = pointsTrajectory2.Dequeue();

            if (pointsTrajectory2.Count != 0 &&
                ((pointsTrajectory2.Peek() - transform.position).magnitude * 2f < (head.GetComponent<HeadControl>().movementSpeed * Time.deltaTime)) &&
                ((target.transform.position - transform.position).magnitude > 0.8f))
                transform.position = pointsTrajectory2.Dequeue();
        }

    }

    void MoveBodyThree()
    {
        if ((target.transform.position - transform.position).magnitude > 0.8f)
        {
            transform.LookAt(target.transform.position);
            transform.position = target.transform.position - target.transform.forward * 0.8f;
        }
    }

    void MoveBodyFour()
    {
       
        if (targetPreviousVectorDirection == target.transform.forward && !isRotate)
        {
            if ((target.transform.position - transform.position).magnitude > 0.8f)
            {
                transform.LookAt(target.transform.position); //по идее, абсолютно бесполезная строчка, которая просто тратит процессорное время. Но вдруг нет? Если будут баги, попробовать всё таки включить эту строчку
                transform.Translate(Vector3.forward * Time.deltaTime * 2 * head.GetComponent<HeadControl>().movementSpeed);
            }
        }
        else
        {
            if (!isRotate)
            {
                isRotate = true;
                targetPositionWhenBeginDoTurn = target.transform.position;
            }

            if ((target.transform.position - transform.position).magnitude > 0.8f)
            {
                if ((target.transform.position - targetPositionWhenBeginDoTurn).magnitude < (Time.deltaTime * 2 * head.GetComponent<HeadControl>().movementSpeed))
                {
                    transform.LookAt(targetPositionWhenBeginDoTurn); //по идее, абсолютно бесполезная строчка, которая просто тратит процессорное время. Но вдруг нет? Если будут баги, попробовать всё таки включить эту строчку
                    transform.Translate(Vector3.forward * Time.deltaTime * 2 * head.GetComponent<HeadControl>().movementSpeed);
                }
                else
                {
                    Debug.Log("log");
                    transform.position = targetPositionWhenBeginDoTurn;
                    isRotate = false;
                }
            }





        }
        targetPreviousVectorDirection = target.transform.forward;//наверное в будущем нужно запихнуть в другео место, которого пока нет
    }
}
