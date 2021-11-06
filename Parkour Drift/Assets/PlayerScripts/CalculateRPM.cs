using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateRPM : MonoBehaviour
{
    SpeedCalculator Speed;
    public float RevsPerMin;
    public float Diameter;

    // Start is called before the first frame update
    void Start()
    {
        Speed = GetComponent<SpeedCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        RPM();
    }
     public float RPM()
    {
        RevsPerMin = (Speed.Speed * 60) / 2 * Mathf.PI;
        return RevsPerMin;
    }
}
