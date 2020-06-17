using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject head;
    public Queue<Vector3> pointsTrajectory = new Queue<Vector3>();
    public int countPointsTrajectory;
    //для второго мува
    public int countPointInBody = 0;


    //для третьего мува
    public bool isMovingToTarget;
    public Vector3 wayPoint; //для сферы, которая ровно за головой
    public Vector3 LastWayPoint; //для сферы, которая ровно за головой
    public Vector3 previousMotionVector; //для сферы, которая ровно за головой
    public Vector3 previousPointHead; //для сферы, которая ровно за головой
    public Queue<Vector3> queueWayPoints = new Queue<Vector3>(); //для всего хвоста, за исключением сферы, которая следит за головой
    public float distantion;
    public float TimeWhenChangeWayPoint;
    public int countPoint;


    void Start()
    {
        isMovingToTarget = true;
        if (target == head)
        {
            previousMotionVector = head.transform.forward;
            previousPointHead=head.transform.position;
        }
        TimeWhenChangeWayPoint = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        MoveBodyThree();
        

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
        if (pointsTrajectory.Count == 0)
        {
            if ((target.transform.position - transform.position).magnitude > 0.8f)
            {
                transform.LookAt(target.transform.position);
                transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * head.GetComponent<HeadControl>().movementSpeed);
                //transform.Translate(Vector3.forward * ((target.transform.position - transform.position).magnitude - 0.8f)); //Time.deltaTime * 4 * head.GetComponent<HeadControl>().movementSpeed);
            }

        }
        else
        {

            if (((pointsTrajectory.Peek() - transform.position).magnitude / 2f > (head.GetComponent<HeadControl>().movementSpeed * Time.deltaTime))
                && (target.transform.position - transform.position).magnitude > 0.8)
            {
                transform.LookAt(pointsTrajectory.Peek());  
                transform.Translate(Vector3.forward * Time.deltaTime * 2 * head.GetComponent<HeadControl>().movementSpeed);
            }
            else
            {
                if ((target.transform.position - transform.position).magnitude > 0.8)
                    transform.position = pointsTrajectory.Dequeue();

                while (pointsTrajectory.Count != 0 &&
                    ((pointsTrajectory.Peek() - transform.position).magnitude * 2f < (head.GetComponent<HeadControl>().movementSpeed * Time.deltaTime)) &&
                    ((target.transform.position - transform.position).magnitude > 0.8f))
                    transform.position = pointsTrajectory.Dequeue();
            }


        }

    }
    /*void MoveBodyTwo()
    {
        if (head.GetComponent<HeadControl>().cointPoints==countPointInBody)
        {
            if ((target.transform.position - transform.position).magnitude > 0.8f)
            {
                transform.LookAt(target.transform.position);
                transform.Translate(Vector3.forward * Time.deltaTime * head.GetComponent<HeadControl>().movementSpeed*2);
                //transform.Translate(Vector3.forward * ((target.transform.position - transform.position).magnitude - 0.8f)); //Time.deltaTime * 4 * head.GetComponent<HeadControl>().movementSpeed);
            }

        }
        else
        {
            //transform.LookAt()
        }
    }*/
    void MoveBodyThree() //из-за того, что мы тут смотрим вектор движения головы, а она всегда вперед, даже когда летит вниз, 
    {                    //то когда голова падает, тело не видит, что меняется направление движения и следует без вейтпоинтов
        if (target == head) //для первой сферы, идущей за головой
        {
            if (isMovingToTarget)
            {
                if (previousMotionVector == head.GetComponent<CharacterController>().velocity)//head.transform.forward)
                {
                    movingToPoint(target.transform.position);
                    /*transform.LookAt(target.transform.position);
                    transform.Translate(Vector3.forward * Time.deltaTime * head.GetComponent<HeadControl>().movementSpeed * 2);*/
                }
                else
                {
                    TimeWhenChangeWayPoint = Time.time;
                    wayPoint = previousPointHead;
                    isMovingToTarget = movingToPoint(wayPoint);
                    /*transform.LookAt(wayPoint);
                    transform.Translate(Vector3.forward * Time.deltaTime * head.GetComponent<HeadControl>().movementSpeed * 2);*/
                }
            }
            else
            {
                isMovingToTarget = movingToPoint(wayPoint);
                

            }
            previousPointHead = head.transform.position;
            previousMotionVector = head.GetComponent<CharacterController>().velocity;//head.transform.forward;
        }
        else
        {
            if(!target.GetComponent<BodyLogic>().isMovingToTarget)
            {
                if (queueWayPoints.Count != 0)
                {
                    if (LastWayPoint != target.GetComponent<BodyLogic>().wayPoint)
                    {
                        LastWayPoint = target.GetComponent<BodyLogic>().wayPoint;
                        queueWayPoints.Enqueue(LastWayPoint);
                    }
                }
                else
                {
                    LastWayPoint = target.GetComponent<BodyLogic>().wayPoint;
                    queueWayPoints.Enqueue(LastWayPoint);
                    
                }
            }


            if (queueWayPoints.Count==0)
            {
                isMovingToTarget = true;
                movingToPoint(target.transform.position);
            }
            else
            {
                isMovingToTarget = false;
                wayPoint = queueWayPoints.Peek();
                if (movingToPoint(queueWayPoints.Peek()))
                    queueWayPoints.Dequeue();
            }


        }
        countPoint = queueWayPoints.Count;
    }
    bool movingToPoint(Vector3 point)
    {
        distantion = (transform.position - point).magnitude;
        if ((transform.position - target.transform.position).magnitude > 0.4f)
        {
            if(distantion<(Time.deltaTime* head.GetComponent<HeadControl>().movementSpeed * 2))
            {
                transform.position = point;
            }
            else
            {
                transform.LookAt(point);
                transform.Translate(Vector3.forward * Time.deltaTime * head.GetComponent<HeadControl>().movementSpeed * 2);
            }
        }

        if (transform.position == point)
            return true;
        else
            return false;
    }
}
