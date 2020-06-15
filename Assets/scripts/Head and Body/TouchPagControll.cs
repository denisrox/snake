using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TouchPagControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public GameObject head;
    public int directionToTurn; // if == 1, turn right, if == -1, turn left
    private bool buttonIsPressed=false;
    void Update()
    {
        if(buttonIsPressed)
            head.GetComponent<HeadControl>().turnHead(directionToTurn);
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        buttonIsPressed = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        buttonIsPressed = false;
    }
    void Start()
    {
        
    }


    
}
