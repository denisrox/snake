using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAcceleration : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBuff;
    public float timePassed;
    public float powerBoost;
    void Start()
    {
        GetComponent<HeadControl>().movementSpeed += GetComponent<HeadControl>().beginMovementSpeed * powerBoost;
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > timeBuff)
            deleteBuff();
    }
    public void restarTheBuff()
    {
        timePassed = 0;
    }
    public void deleteBuff()
    {
        GetComponent<HeadControl>().movementSpeed -= GetComponent<HeadControl>().beginMovementSpeed * powerBoost;
        Destroy(GetComponent<FoodAcceleration>());
    }
}
