using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMove;
    public float speedRotatet;
    public KeyCode left;
    public KeyCode right;

    private GameObject headSnake;
    private gameManager manager;
    private eatFood EatFood;
    void Start()
    {
        headSnake = gameObject;
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
        EatFood = gameObject.GetComponent<eatFood>();
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
    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        if (other.gameObject.tag == "Body" && other.gameObject.GetComponent<BodyLogic>().target!=gameObject)//проверяем, объект, в который мы врезались имеет ли тэг "Body" и так же
        {                                                                                                   //проверяем, не является ли это первое тело, которое идёт за головой
                                                                                                            //т.к. эта тело всегда контактирует с головой
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
        }
    }
}
