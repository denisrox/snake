using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float beginMovementSpeed;
    public float movementSpeed;
    public float rotationSpeed;
    public KeyCode left;
    public KeyCode right;
    public KeyCode boostSpeed;
    private GameManager manager;
    private OnEatFood onEatFood;
    public Queue<Vector3> pointsTrajectory=new Queue<Vector3>();
    void Start()
    {
        movementSpeed = beginMovementSpeed;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        onEatFood = gameObject.GetComponent<OnEatFood>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward + Vector3.down) * movementSpeed * Time.deltaTime;
        GetComponent<CharacterController>().Move(moveDirection);
        //transform.Translate(Vector3.forward * Time.deltaTime*movementSpeed); //движение вперед. Т.к. змея двигается всегда вперед - то будет выполняться каждый кадр.
        //GetComponent<CharacterController>().velocity.sqrMagnitude; скорось в квадрате

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
            movementSpeed = movementSpeed + beginMovementSpeed * 0.2f;
        }
        if (Input.GetKeyUp(boostSpeed))
        {
            movementSpeed -= 2;
        }

        if (onEatFood.lastBody!=gameObject)
        {
            pointsTrajectory.Enqueue(transform.position);
        }

    }
    /*void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        //!ПРИ СПАВНЕ ИЗ ХВОСТА ТЕПЕРЬ ТАКАЯ РЕАЛИЗАЦИЯ НЕ ПОДХОДИТ!
        //проверяем, объект, в который мы врезались имеет ли тэг "Body" и так же
        //проверяем, не является ли это первое тело, которое идёт за головой
        //т.к. эта тело всегда контактирует с головой
        if (other.gameObject.tag == "Body" && other.gameObject.GetComponent<BodyLogic>().target!=gameObject)
        {                                                                                                   
            if (manager.getPlayMode() == 0)
            {
                     GameOver();         
            }                                                                                                
            /*if (manager.getPlayMode() == 1)
            {
                onEatFood.lastBody = other.gameObject.GetComponent<BodyLogic>().target;
                //OnEatFood.sizeSnake--;
                Destroy(other.gameObject);
            }            
        }        
    }
    private void GameOver()
    {
        movementSpeed = 0;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;    
    }*/
}
