using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    [SerializeField]
    GameObject TrafficLights;
    ChangeCamera Cam;
    [SerializeField]
    WheelCollider[] WheelCol;
    [SerializeField]
    GameObject[] Wheels;
    [SerializeField]
    float Torque = 200;
    [SerializeField]
    float SteerAngle = 30;
    [SerializeField]
    float MaxSteerAngle;
    [SerializeField]
    float Acceleration_Multiplier;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cam = TrafficLights.GetComponent<ChangeCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Input();
        float A = Input.GetAxis("Vertical")*10;
        float S = Input.GetAxis("Horizontal")*10;
        Ignite(A,S, Acceleration_Multiplier);
        print(rb.velocity);
    }
    public void Player_Input()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Cam.CameraSwitch();
            GameObject.Find("Timer").GetComponent<TrafficLightsSystem>().timerActive = true;              
        }    
    }

    void Ignite(float Acceleration, float Steer, float AccelerationMultiplier)
    {
        Acceleration = Mathf.Clamp(Acceleration, -1, 1) * AccelerationMultiplier;
        Steer = Mathf.Clamp(Steer, -1, 1) * MaxSteerAngle;
        float Thrust = Acceleration * Torque;

        for(int i =0 ; i<4;i++)
        {
            WheelCol[i].motorTorque = Thrust;
            if (i < 2)
            {
                WheelCol[i].steerAngle = Steer;             
            }
        Quaternion Rotation;
        Vector3 Pos;
        WheelCol[i].GetWorldPose(out Pos, out Rotation);
        Wheels[i].transform.position = Pos;
        Wheels[i].transform.rotation = Rotation;
        }
        
    }
}
