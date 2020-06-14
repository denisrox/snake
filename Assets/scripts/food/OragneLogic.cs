using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OragneLogic : MonoBehaviour
{

    public float rotationSpeed;
    public int foodPower;
    protected GameManager manager;
    public float timeBuff;
    public float powerBoost; 
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        if (other.gameObject.tag == "Player")//проверяем, объект, который в нас врезался, имеет ли тег "Player"
        {
            manager.addScore(foodPower); //добавляем счет
            manager.decreaseFoodCounter(); //убавляем количество нынешней еды в менеджере
            other.GetComponent<OnEatFood>().eat(foodPower); //запускаем метод роста змеи (наверное стоит переименовать метод в рост или типа того)
            if (other.gameObject.GetComponent<FoodAcceleration>())
            {
                Debug.Log("такой баф есть");
                other.gameObject.GetComponent<FoodAcceleration>().restarTheBuff();
            }

            else
            {
                Debug.Log("такого бафа нет");
                FoodAcceleration comp = other.gameObject.AddComponent<FoodAcceleration>();
                comp.timeBuff = timeBuff;
                comp.powerBoost = powerBoost;
            }
            Destroy(gameObject); //уничтожаем капсулу
        }
    }
}
