using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int score; //очки
    [SerializeField] private int maxFood;//сколько может быть еды на поле
    [SerializeField] private int countFood;//сколько еды сейчас
    [SerializeField] private GameObject[] foodsPrefabs;//массив возможной еды



    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()//проверяет сколько еды на карте. Если меньше нужного - спавнит
    {
        if (countFood < maxFood)
        {
            spawnFood();
        }
            
    }
    public void addScore(int newScore) //добавка к счету. Эту функцию вызывает еда перед самоуничтожением
    {
        score += newScore;
    }
    public void eatFood() //Просто обратный счетчик количества еды. Когда еда уничтожается, она использует эту функцию
    {
        countFood--;
    }
    private void spawnFood() //спавнит рандомную из массива еду (думаю там будет несколько видов еды для змеи).
    {
        countFood++;
        int random = Random.Range(0, foodsPrefabs.Length); 
        Vector3 position = new Vector3(Random.Range(-13.8f, 13.1f), 0.411f, Random.Range(11.8f, -14.2f)); //рандомная позиция внутри поля
        Instantiate(foodsPrefabs[random], position, Quaternion.identity);//создание нового объекта (параметры: объект, позиция, куда смотрит)
    }
}
