using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    public float rotationSpeed;
    public KeyCode left;
    public KeyCode right;
    public KeyCode boostSpeed;
    private GameManager manager;
    private OnEatFood EatFood;
    public Queue<Vector3> pointsTrajectory=new Queue<Vector3>();
    public Vector3 previousVectorDirection;
    public int countPointsTrajectory;
    void Start()
    {
        
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        EatFood = gameObject.GetComponent<OnEatFood>();
        previousVectorDirection = transform.forward; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward + Vector3.down) * movementSpeed * Time.deltaTime;
        GetComponent<CharacterController>().Move(moveDirection);
        //transform.Translate(Vector3.forward * Time.deltaTime*movementSpeed); //движение вперед. Т.к. змея двигается всегда вперед - то будет выполняться каждый кадр.

        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime * movementSpeed);//поворот налево
        }
        if(Input.GetKey(right))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * movementSpeed);//поворот направо
        }
        if (Input.GetKeyDown(boostSpeed))
        {
            movementSpeed += 2;
        }
        if (Input.GetKeyUp(boostSpeed))
        {
            movementSpeed -= 2;
        }

        if (GetComponent<OnEatFood>().lastBody!=gameObject)
        {
            pointsTrajectory.Enqueue(transform.position);
        }
        countPointsTrajectory = pointsTrajectory.Count;
        previousVectorDirection = transform.forward;
    }
    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        //!ПРИ СПАВНЕ ИЗ ХВОСТА ТЕПЕРЬ ТАКАЯ РЕАЛИЗАЦИЯ НЕ ПОДХОДИТ!
        //проверяем, объект, в который мы врезались имеет ли тэг "Body" и так же
        //проверяем, не является ли это первое тело, которое идёт за головой
        //т.к. эта тело всегда контактирует с головой
        /*if (other.gameObject.tag == "Body" && other.gameObject.GetComponent<BodyLogic>().target!=gameObject)
        {                                                                                                   
                                                                                                            
            if (manager.getPlayMode() == 0)
            {
                EatFood.lastBody = other.gameObject.GetComponent<BodyLogic>().target;
                EatFood.sizeSnake--;
                Destroy(other.gameObject);
            }
            if (manager.getPlayMode() == 1)
            {
                 Time.timeScale = 0.5f;
                 Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }*/
    }
}
