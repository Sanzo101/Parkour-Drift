using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCalculator : MonoBehaviour
{
    public Transform StartingPoint;
    public Transform CurrentDistanceTravelled;
    public float DistanceTravelled;
    public float Speed;
    bool Moving = false;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Moving = true;
        }
        if(Moving)
        {
            Timer += Time.deltaTime;
            Speed_func();
        }

    }

    public float Speed_func()
    {
        DistanceTravelled =CurrentDistanceTravelled.position.z - StartingPoint.position.z;
        Speed = DistanceTravelled / Timer;
        return Speed;
    }
}
