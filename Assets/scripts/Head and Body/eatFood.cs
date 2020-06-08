using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatFood : MonoBehaviour
{
    // Start is called before the first frame update
    public int sizeSnake;
    public GameObject bodySnakePrefab; //префаб тела
    public GameObject lastBody; //последний появившийся шар (вначале это приравнивается к голове).
    void Start()
    {
        sizeSnake = 0;
        lastBody = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void eat(int foodPower) //что происходит при еде
    {
        for(int i = 0; i < foodPower; i++) { 
            sizeSnake ++;
            GameObject newBody = Instantiate(bodySnakePrefab, lastBody.transform.position, lastBody.transform.rotation); //создаем тело внутри последней части змеи
            newBody.transform.Translate(Vector3.back*0.7f); //переноси её на 0.7 назад, чтобы она не была внутри. 
            newBody.GetComponent<BodyLogic>().target = lastBody; //даем новому объекту ссылку на последний элемент
            newBody.GetComponent<BodyLogic>().head = gameObject; //даем новому объекту ссылку на голову
            lastBody = newBody;
        }
    }
}
