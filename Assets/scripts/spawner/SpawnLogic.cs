﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //При создании нового игрового поля вызываем этот метод
        //Берем массив объектов spawnDot
        //Выбираем случайный
        //Проверяем, что он свободен и рядом нет другого элемента (стена может быть[если от стен не отказываемся])
        //Спавним N элементов окружения (камни, шипы, реки(?), подъёмы+мосты+спуски, мосты через реки)
    }

    // Update is called once per frame
    void Update()
    {        
        //При необходимости заспавнить что-то после создания нового игрового поля вызываем этот метод
        //Берем массив объектов spawnDot
        //Выбираем случайный spawnDot
        //Проверяем, что он свободен (нет элементов окружения, нет фруктов)
        //[нужно проверить проходимость змеи в углах и между двух элементов окружения(пример: два камня), если там появится фрукт])
        //Если свободен - спавним фрукт
    }
}
