using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchBar : MonoBehaviour
{
    public Image Mask;
    public float BarSpeed = 1;
    public float PlayerSpeed;
    float BarMaxValue = 10;
    float BarCurrentValue;
    bool BarIncreasing;
    Rigidbody RB;
    public float Multiplier;
    [System.NonSerialized]
    public bool BarOn;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        BarCurrentValue = 0;
        BarIncreasing = true;
        BarOn = true;
        StartCoroutine(UpdateBar());
    }

    public void LaunchPlayer()
    {
        PlayerSpeed = BarCurrentValue * Multiplier;
        RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y, PlayerSpeed);
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
}
