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
    private GameManager manager;
    private OnEatFood EatFood;
    void Start()
    {
        
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        EatFood = gameObject.GetComponent<OnEatFood>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime*movementSpeed); //движение вперед. Т.к. змея двигается всегда вперед - то будет выполняться каждый кадр.

        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);//поворот налево
        }
        if(Input.GetKey(right))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);//поворот направо
        }
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
