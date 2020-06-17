using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СameraForPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float minHeight;
    public float maxHeight;
    public float heightInitial;
    public float speedChangingHeight;
    public int cameraMode;
    private float heightCurrent;
    private float previousDistancion;
    void Start()
    {
        heightCurrent = heightInitial;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMode == 1)
            modeCamOne();
        else
            modeCamTwo();
        if (Input.GetKey(KeyCode.Alpha1))
        {
            cameraMode = 1;
            transform.eulerAngles = new Vector3(90f, 0, 0);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            cameraMode = 2;
        }

    }
    void modeCamOne()
    {
        transform.position = player.transform.position + new Vector3(0, heightCurrent, 0);
        float changeHeight = Input.GetAxis("Mouse ScrollWheel")*-1;
        Debug.Log(changeHeight);
        heightCurrent += changeHeight * Time.deltaTime * speedChangingHeight; ;
        heightCurrent = Mathf.Clamp(heightCurrent, minHeight, maxHeight);

    }
    void modeCamTwo()
    {
        transform.position = player.transform.position + player.transform.forward * -10  + new Vector3(0, heightCurrent, 0);
        float changeHeight = Input.GetAxis("Mouse ScrollWheel") * -1;

        if (Input.touchCount >= 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            changeHeight=difference * 0.001f;
        }

        Debug.Log(changeHeight);
        heightCurrent += changeHeight * Time.deltaTime * speedChangingHeight; ;
        heightCurrent = Mathf.Clamp(heightCurrent, minHeight, maxHeight);
        transform.LookAt(player.transform);
    }
}
