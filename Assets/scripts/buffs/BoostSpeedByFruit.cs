using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeedByFruit : MonoBehaviour
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
            buffEnding();
    }
    public void buffStarting()
    {
        timePassed = 0;
    }
    public void buffEnding()
    {
        GetComponent<HeadControl>().movementSpeed -= GetComponent<HeadControl>().beginMovementSpeed * powerBoost;
        Destroy(GetComponent<BoostSpeedByFruit>());
    }
}
