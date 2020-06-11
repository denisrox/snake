using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLogic : MonoBehaviour
{
    public float rotationSpeed;
    public int foodPower;
    protected GameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), -rotationSpeed * Time.deltaTime);//поворот налево. Но думаю это бред, это нужно делать анимацией, а не поворотом
    }


    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        if (other.gameObject.tag == "Player")//проверяем, объект, который в нас врезался, имеет ли тег "Player"
        {
            manager.addScore(foodPower); //добавляем счет
            manager.decreaseFoodCounter(); //убавляем количество нынешней еды в менеджере
            other.GetComponent<OnEatFood>().eat(foodPower); //запускаем метод роста змеи (наверное стоит переименовать метод в рост или типа того)
            Destroy(gameObject); //уничтожаем капсулу
        }
    }
}
