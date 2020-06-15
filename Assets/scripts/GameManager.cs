using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Тестовый коммент, чтобы как-то убрать дубликат GameManager
    [SerializeField] private int score; //очки
    [SerializeField] public int maxFood;//сколько может быть еды на поле
    [SerializeField] private int countFood;//сколько еды сейчас
    [SerializeField] private int rangeBetweenDots;//расстояние между точками спавна
    [SerializeField] private GameObject prefabSpawnDot;//спавн-точка
    [SerializeField] private GameObject[] foodsPrefabs;//массив возможной еды
    [SerializeField] private int playMode;
    [SerializeField] private GameObject plane;
    //Tuple<string, float>[] tuple1 = { new Tuple<string, float>(x_min, 0.0),  new Tuple<string, float>(x_max, 10.0) };

    void Start()
    {
        if (rangeBetweenDots == 0)
            rangeBetweenDots = 1;
        score = 0;
        createGridSpawn();        
    }

    // Update is called once per frame
    void Update()//проверяет сколько еды на карте. Если меньше нужного - спавнит
    {
        if (countFood < maxFood)
        {
            //var a = new SpawnLogic.SpawnObject();
            //spawnFood();
        }
            
    }
    
    public void addScore(int newScore) //добавка к счету. Эту функцию вызывает еда перед самоуничтожением
    {
        score += newScore;
    }

    public void decreaseFoodCounter() //Просто обратный счетчик количества еды. Когда еда уничтожается, она использует эту функцию
    {
        countFood--;
    }

    public int getPlayMode()
    {
        return playMode;
    }

    private void spawnFood() //спавнит рандомную из массива еду (думаю там будет несколько видов еды для змеи).
    {
        countFood++;
        int random = Random.Range(0, foodsPrefabs.Length);

        //Не доделали (нужно нижнюю реализовать)
        Vector3 position = new Vector3(Random.Range(-13.8f, 13.1f), 0.411f, Random.Range(11.8f, -14.2f)); //рандомная позиция внутри поля
        //Vector3 position = new Vector3(Random.Range(mapSizeHorizontal.x, mapSizeHorizontal.y), 0.411f, Random.Range(mapSizeVertical.x, mapSizeVertical.y));
        
        Instantiate(foodsPrefabs[random], position, Quaternion.identity);//создание нового объекта (параметры: объект, позиция, куда смотрит)
    }

    private void createGridSpawn() //создает сетку из раноудаленных невидимых точек
    {
        Vector3 boundsPlaneMax = plane.GetComponent<Collider>().bounds.max;
        Vector3 boundsPlaneMin = plane.GetComponent<Collider>().bounds.min;

        for (float  x= boundsPlaneMin.x+1; x < boundsPlaneMax.x-1; x += rangeBetweenDots) //!!!если поле будет не ровным - переделать
        {
            for (float z = boundsPlaneMin.z+1; z < boundsPlaneMax.z-1; z += rangeBetweenDots)
            {                
                Instantiate(prefabSpawnDot, new Vector3(x, boundsPlaneMax.y+0.5f, z), Quaternion.identity);
            }
        }

    }
}
