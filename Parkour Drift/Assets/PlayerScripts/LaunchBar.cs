using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchBar : MonoBehaviour
{
    public Image Mask;
    public float Speed = 1;
    float BarMaxValue = 100;
    float BarCurrentValue;
    bool BarIncreasing; 
    [System.NonSerialized]
    public bool BarOn;
    // Start is called before the first frame update
    void Start()
    {
        BarCurrentValue = 0;
        BarIncreasing = true;
        BarOn = true;
        StartCoroutine(UpdateBar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator UpdateBar()
    {
        while (BarOn)
        {
            if(!BarIncreasing)
            {
                BarCurrentValue -= Speed;
                if(BarCurrentValue<=0)
                {
                    BarIncreasing = true;
                }
            }
            if(BarIncreasing)
            {
                BarCurrentValue += Speed;
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
