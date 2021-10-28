using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Acceleration_State
{
    Nothing,
    Low,
    Medium,
    High,
    Super
}

public class Speedometre : MonoBehaviour
{
    public Acceleration_State State;
    private const float Max_Speed_Angle = -100;
    private const float Zerp_Speed_Angle = 200;

    private Transform needleTransform;
    [SerializeField]
    private float Max_Speed;
    [SerializeField]
    private float Speed;
    private void Awake()
    {     
        needleTransform = GameObject.Find("Pointer").transform;
        Speed = 0;
        Max_Speed = 100f;
    }
    // Update is called once per frame
    void Update()
    {
        State = Get_State();
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }
    private float GetSpeedRotation()
    {
        float totalAngleSize = Zerp_Speed_Angle - Max_Speed_Angle;
        float speedNormalized = Speed / Max_Speed;
        return Zerp_Speed_Angle - speedNormalized * totalAngleSize;
    }
    private Acceleration_State Get_State()
    {
        if (Speed <= 35f && Speed>= 0f) return Acceleration_State.Low;
        if (Speed <= 55f && Speed > 35f) return Acceleration_State.Medium;
        if (Speed <= 60f && Speed> 55f) return Acceleration_State.High;
        if (Speed <= 70f && Speed > 60f) return Acceleration_State.Super;
        if (Speed <= 75f && Speed> 70f) return Acceleration_State.High;
        if (Speed <= 85f && Speed > 75f) return Acceleration_State.Medium;
        if (Speed <= 100f && Speed > 85f) return Acceleration_State.Low;
        return Acceleration_State.Nothing;

    }
    public void Player_Input()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            float Acceleration = 100f;
            Speed += Acceleration * Time.deltaTime;
        }
        else
        {
            float Deceleration = 50f;
            Speed -= Deceleration * Time.deltaTime;
        }
        Speed = Mathf.Clamp(Speed, 0f, Max_Speed);
    }    
}
