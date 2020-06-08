using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsulaSystem : MonoBehaviour
{
    public float speedRotatet;
    public int foodPower;
    protected gameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1), -speedRotatet * Time.deltaTime);//поворот налево. Но думаю это бред, это нужно делать анимацией, а не поворотом
    }


    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        if (other.gameObject.tag == "Player")//проверяем, объект, который в нас врезался, имеет ли тег "Player"
        {
            manager.addScore(1); //добавляем счет
            manager.eatFood(); //убавляем количество нынешней еды в менеджере
            other.GetComponent<eatFood>().eat(foodPower); //запускаем метод роста змеи (наверное стоит переименовать метод в рост или типа того)
            Destroy(gameObject); //уничтожаем капсулу
        }
    }
}
