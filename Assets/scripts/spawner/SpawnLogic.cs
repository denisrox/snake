using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] foodsPrefabs;//спавн-точка
    private GameObject[] spawnDots;
    // Start is called before the first frame update
    void Start()
    {    
        //При создании нового игрового поля вызываем этот метод
        //Берем массив объектов spawnDot
        spawnDots = GameObject.FindGameObjectsWithTag("SpawnDot");   
        //Выбираем случайный  
        //Проверяем, что он свободен и рядом нет другого элемента (стена может быть[если от стен не отказываемся])
        //Спавним N элементов окружения (камни, шипы, реки(?), подъёмы+мосты+спуски, мосты через реки)
    }

    // Update is called once per frame
    void Update()
    {        
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().maxFood > GameObject.FindGameObjectsWithTag("Food").Length)
        {
            SpawnObject(spawnDots, 1);
        }
        //При необходимости заспавнить что-то после создания нового игрового поля вызываем этот метод
        //Берем массив объектов spawnDot
        //Выбираем случайный spawnDot
        //Проверяем, что он свободен (нет элементов окружения, нет фруктов)
        //[нужно проверить проходимость змеи в углах и между двух элементов окружения(пример: два камня), если там появится фрукт])
        //Если свободен - спавним фрукт
    }

    public void SpawnObject(GameObject[] spawnDots, int countOfSpawn)//, bool isRandomSpawn = true, Object spawnDot = null)
    {
        /*if (isRandomSpawn && spawnDot)
        {
            spawnDot = spawnDots[Random.Range(0, spawnDots.Length)];       
        }    */
        
        GameObject spawnDot = spawnDots[Random.Range(0, spawnDots.Length)];     
        for (int i = 0; i < countOfSpawn; i++)         
        {
            Instantiate(foodsPrefabs[Random.Range(0, foodsPrefabs.Length)], spawnDot.transform.position, Quaternion.identity);
        }        
    }
}
