using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GearChanging : MonoBehaviour
{
    Speedometre Getting_Speed;
    float Speed_Reference;

    private void Awake()
    {
        Getting_Speed = gameObject.GetComponent<Speedometre>();       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Speed_Reference = Getting_Speed.Speed;
    }
    private void Automatic_Gear_Change()
    {

    }
}
