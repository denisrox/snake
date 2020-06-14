using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeedByShift : MonoBehaviour
{
    // Start is called before the first frame update
    public float powerBoost;
    void Start()
    {
        
        if (GetComponent<HeadControl>().staminaCurrent > 0)
            GetComponent<HeadControl>().movementSpeed += GetComponent<HeadControl>().beginMovementSpeed * powerBoost;
        else
            Destroy(GetComponent<BoostSpeedByShift>());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<HeadControl>().staminaCurrent -= Time.deltaTime;
        if (GetComponent<HeadControl>().staminaCurrent <= 0)
        {
            GetComponent<HeadControl>().staminaCurrent = 0;
            deleteBuff();
        }

    }
    public void deleteBuff()
    {
        GetComponent<HeadControl>().movementSpeed -= GetComponent<HeadControl>().beginMovementSpeed * powerBoost;
        Destroy(GetComponent<BoostSpeedByShift>());
    }
}
