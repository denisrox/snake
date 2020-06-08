using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsulaSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedRotatet;
    private gameManager manager;
    private GameObject capsula;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
        capsula = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        capsula.transform.Rotate(new Vector3(1, 1, 1), -speedRotatet * Time.deltaTime);//поворот налево. Но думаю это бред, это нужно делать анимацией, а не поворотом

    }

    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        if (other.gameObject.tag == "Player")//проверяем, объект, который в нас врезался, имеет ли тег "Player"
        {
            manager.addScore(1); //добавляем счет
            manager.eatFood(); //убавляем количество нынешней еды в менеджере
            other.GetComponent<eatFood>().eat(); //запускаем метод роста змеи (наверное стоит переименовать метод в рост или типа того)
            Destroy(capsula); //уничтожаем капсулу
        }
    }
}
