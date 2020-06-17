using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEatFood : MonoBehaviour
{
    // Start is called before the first frame update   
    public GameObject bodySnakePrefab; //префаб тела

    public GameObject head_snake;
    
    public GameObject lastBody; //последний появившийся шар (вначале это приравнивается к голове).
    
    void Start()
    {        
        lastBody = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void eat(int foodPower) //что происходит при еде
    {
        for(int i = 0; i < foodPower; i++) {           
            GameObject newBody = Instantiate(bodySnakePrefab, lastBody.transform.position, lastBody.transform.rotation); //создаем тело внутри последней части змеи
            //OBSOLOTE: перенос на 0.7 назад, чтобы не въезжать в существующие части змеи
            //newBody.transform.Translate(Vector3.back*0.7f);
            newBody.GetComponent<BodyLogic>().target = lastBody; //даем новому объекту ссылку на последний элемент
            newBody.GetComponent<BodyLogic>().head = gameObject; //даем новому объекту ссылку на голову


            /*Material material = newBody.GetComponent<Renderer>().material;
            material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);
            newBody.GetComponent<Renderer>().material = material;*/

            lastBody = newBody;
        }
    }

    private float TimeBetweenSpawnNewBody(float diameter, float movementSpeed) 
    {            
        return   diameter / movementSpeed;
    }
}
