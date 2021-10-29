using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Acceleration_State
{
    Nothing,
    Low,
    Medium,
    High,
    Super,
    TooFar
}

public enum Gears
{ 
    gear_1,
    gear_2,
    gear_3,
    gear_4
}


public class Speedometre : MonoBehaviour
{
    float Max_RPM;
    float gearNum = 1;

    public Acceleration_State State;
    public Gears Gear;
    private const float Max_Speed_Angle = -100;
    private const float Zerp_Speed_Angle = 200;

    private const float Speed_Angle_Copy = 300;
    private const float Zero_Angle_Copy = 0;

    float AccelVariable = 100f;

    float Acceleration;
    float Deceleration;
    public float AccelerationMultiplier;
    public bool timersFinished;
    Rigidbody RB;

    private Transform needleTransform;
    [SerializeField]
    private float Max_Speed;
    public float Speed;
    private float Needle_Speed;
    private void Awake()
    {     
        needleTransform = GameObject.Find("Pointer").transform;
        Needle_Speed = 0;     
        Max_Speed = 300f;
        timersFinished = false;
    }
    // Update is called once per frame
    void Update()
    {
        State = Get_State();
        Gear = Get_Gear();
        Handle_Gears();
        RB = gameObject.GetComponent<Rigidbody>();
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
        Initial_Acceleration();
        Acceleration_Multiplier();
    }
    private float GetSpeedRotation()
    {
        float totalAngleSize = Zerp_Speed_Angle - Max_Speed_Angle;
        float speedNormalized = Needle_Speed / Max_Speed;
        return Zerp_Speed_Angle - speedNormalized * totalAngleSize;
    }

    public float GetSpeedRotation_Copy()
    {
        float totalAngleSize = Zero_Angle_Copy - Speed_Angle_Copy;
        float speedNormalized = Needle_Speed / Max_Speed;
        return Zero_Angle_Copy - speedNormalized * totalAngleSize;
    }
    private Acceleration_State Get_State()
    {
        if (Needle_Speed <= 50f && Needle_Speed >= 0f) return Acceleration_State.Low;
        if (Needle_Speed <= 180f && Needle_Speed > 50f) return Acceleration_State.Medium;
        if (Needle_Speed <= 200f && Needle_Speed> 180f) return Acceleration_State.High;
        if (Needle_Speed <= 250f && Needle_Speed > 200f) return Acceleration_State.Super;
        if (Needle_Speed <= 300f && Needle_Speed > 250f) return Acceleration_State.TooFar;
        return Acceleration_State.Nothing;

    }

    private Gears Get_Gear()
    {
        if (gearNum == 1) return Gears.gear_1;
        if (gearNum == 2) return Gears.gear_2;
        if (gearNum == 3) return Gears.gear_3;
        if (gearNum == 4) return Gears.gear_4;
        return Gears.gear_1;
    }
    private void Handle_Gears()
    {
        switch (Gear)
        {
            case Gears.gear_1:
                Max_RPM = 200;
                if (Input.GetKeyDown(KeyCode.UpArrow)) gearNum++;
                break;
            case Gears.gear_2:
                Max_RPM = 250;
                if (Input.GetKeyDown(KeyCode.UpArrow)) gearNum++;
                break;
            case Gears.gear_3:
                Max_RPM = 270;
                if (Input.GetKeyDown(KeyCode.UpArrow)) gearNum++;
                break;
            case Gears.gear_4:             
                Max_RPM = 300;
                if (Input.GetKeyDown(KeyCode.DownArrow)) gearNum--;
                break;
        }
    }
    public void Player_Input()
    {
        if(Input.GetKey(KeyCode.Space))
        {         
            Acceleration = AccelVariable * AccelerationMultiplier;
            Needle_Speed += Acceleration * Time.deltaTime;
        }
        else
        {
            Deceleration = 80f;
            Needle_Speed -= Deceleration * Time.deltaTime;
        }
        Needle_Speed = Mathf.Clamp(Needle_Speed, 0f, Max_RPM);
        Speed = Mathf.Clamp(Speed, 0f, Needle_Speed);
    } 
    private void Initial_Acceleration()
    {
        if (timersFinished)
        {
            switch (State)
            {
                case Acceleration_State.Low:
                    //add force until certain point and then steady speed
                    RB.velocity= new Vector3(RB.velocity.x, RB.velocity.y, Speed++);                    
                    //RB.AddForce((Vector3.forward * Acceleration) / 20, ForceMode.Acceleration);
                    //SpeedCap();
                    break;
                case Acceleration_State.Medium:
                    RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y, Speed++);
                    //RB.AddForce((Vector3.forward * Acceleration) / 20, ForceMode.Acceleration);
                    //SpeedCap();
                    break;
                case Acceleration_State.High:
                    RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y, Speed++);
                    //RB.AddForce((Vector3.forward * Acceleration) / 20, ForceMode.Acceleration);
                    //SpeedCap();
                    break;
                case Acceleration_State.Super:
                    RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y, Speed++);
                    //RB.AddForce((Vector3.forward * Acceleration) / 20, ForceMode.Acceleration);
                    //SpeedCap();
                    break;
                case Acceleration_State.TooFar:
                    RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y, Speed++);
                    //RB.AddForce((Vector3.forward * Acceleration) / 20, ForceMode.Acceleration);
                    //SpeedCap();
                    break;
                default:
                    break;
            }
        }
    }
    private void Acceleration_Multiplier()
    {
        switch (State)
        {
            case Acceleration_State.Low:
                //add force until certain point and then steady speed
                AccelerationMultiplier = .5f;
                break;
            case Acceleration_State.Medium:
                AccelerationMultiplier = 2;
                break;
            case Acceleration_State.High:
                AccelerationMultiplier = 4;
                break;
            case Acceleration_State.Super:
                AccelerationMultiplier = 5;
                break;
            case Acceleration_State.TooFar:              
                AccelerationMultiplier = 5f;
                AccelVariable = 50f;
                break;
            default:
                break;
        }
    }
    public void SpeedCap()
    {
        switch (State)
        {
            case Acceleration_State.Low:
                
                break;
            case Acceleration_State.Medium:

                break;
            case Acceleration_State.High:

                break;
            case Acceleration_State.Super:

                break;
            case Acceleration_State.TooFar:

                break;
            default:
                break;
        }
    }
}

