using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Acceleration_States
{ 
    Nothing,
    Low,
    Medium,
    High,
    Super
}

public class LaunchBar : MonoBehaviour
{
    public Acceleration_States State;
    bool Accelration_Max_Speed_Reached = false;
    public Image Mask;
    public float BarSpeed;
    public float PlayerSpeed,MaxSpeed;
    public float Acceleration;
    float BarMaxValue = 100;
    float BarCurrentValue;
    bool BarIncreasing, AccelarationActive;
    Rigidbody RB;
    public float SpeedMultiplier, AccelrationMultiplier;
    [System.NonSerialized]
    public bool BarOn;
    // Start is called before the first frame update
    void Start()
    {      
        RB = GetComponent<Rigidbody>();
        BarCurrentValue = 0;
        BarIncreasing = true;
        BarOn = true;
        AccelarationActive = false;
        StartCoroutine(UpdateBar());
    }
    private void Update()
    {
        State = Get_State();      
        Initial_Acceleration_Force(State);
        PlayerActivated_Speed(MaxSpeed, Acceleration);
        print(Acceleration);
    }
    private Acceleration_States Get_State()
    {
        if (BarCurrentValue <= 25f && BarCurrentValue > 0f) return Acceleration_States.Low;
        if (BarCurrentValue <= 50f && BarCurrentValue > 25f) return Acceleration_States.Medium;
        if (BarCurrentValue <= 75f && BarCurrentValue > 50f) return Acceleration_States.High;
        if (BarCurrentValue <= 100f && BarCurrentValue > 75f) return Acceleration_States.Super;
        return Acceleration_States.Nothing;

    }
    public void LaunchPlayer()
    {
        Acceleration = (BarCurrentValue * AccelrationMultiplier);
        AccelarationActive = true;
        BarOn = false;
    }
    IEnumerator UpdateBar()
    {
        while (BarOn)
        {
            if(!BarIncreasing)
            {
                BarCurrentValue -= BarSpeed;
                if(BarCurrentValue<=0)
                {
                    BarIncreasing = true;
                }
            }
            if(BarIncreasing)
            {
                BarCurrentValue += BarSpeed;
                if(BarCurrentValue>=BarMaxValue)
                {
                    BarIncreasing = false;
                }
            }         
            float Fill = BarCurrentValue / BarMaxValue;
            Mask.fillAmount = Fill;
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }
    private void PlayerActivated_Speed(float Maxspeed, float Accelration)
    {
        if (AccelarationActive)
        {
            //add force until certain point and then steady speed
            RB.AddForce((Vector3.forward * Accelration)/100, ForceMode.Acceleration);
            if (RB.velocity.z >= MaxSpeed)
            {
                AccelarationActive = false;
                Accelration_Max_Speed_Reached = true;
            }
        }
        if(!AccelarationActive && Accelration_Max_Speed_Reached)
        {
            RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y, Maxspeed);
        }
    }
    private void Initial_Acceleration_Force(Acceleration_States states)
    {
        switch (states)
        {
            case Acceleration_States.Low:
                //Acceleration boost is low
                AccelrationMultiplier = .5f;
                break;
            case Acceleration_States.Medium:
                //Acceleration boost is Medium
                AccelrationMultiplier = 1f;
                break;
            case Acceleration_States.High:
                //Acceleration boost is High
                AccelrationMultiplier = 1.5f;
                break;
            case Acceleration_States.Super:
                //Acceleration boost is Super
                AccelrationMultiplier = 2f;
                break;
            case Acceleration_States.Nothing:              
                break;
        }
    }
}
