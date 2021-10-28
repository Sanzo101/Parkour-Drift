using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightsSystem : MonoBehaviour
{
    Image TrafficLight;
    Text Countdown;
    public Sprite[] Lights;
    float timer = 1f;
    bool timerActive = true;
    bool GoingUp;
    public float FontSizeMultiplier;
    float CountdownPercentage;
    float TimerPercentage;
    float TimerMax = 4f;
    // Start is called before the first frame update
    void Start()
    {
        TrafficLight = gameObject.GetComponent<Image>();
        Countdown = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {     
        if (timerActive)
        {
            CountdownPercentage = Countdown.fontSize / 300.0f;
            TimerPercentage = timer / TimerMax;
            print("Time Precentage : "+TimerPercentage + " " + "Countdown Percentage :" + CountdownPercentage);                   
            timer += .5f * Time.deltaTime;
            AssigningFontSize();
            LighsChange();
        }
    }
    void TimerSizeFont()
    {
        switch(GoingUp)
        {
            case true:
                Countdown.fontSize += (int)(100.0f * FontSizeMultiplier * Time.deltaTime);
                break;
            case false:
               Countdown.fontSize -= (int)(100.0f * FontSizeMultiplier * Time.deltaTime);
                break;
        }
    }
    void AssigningFontSize()
    {
        if (Countdown.fontSize <= 0)
        {
            GoingUp = true;
        }
        if (Countdown.fontSize >= 300)
        {
            GoingUp = false;
        }
    }
    void LighsChange()
    {

        // Sort this out now 
        if (timer <= 4f && timer > 3f)
        {
            Countdown.text = "GO!";
            TrafficLight.sprite = Lights[2];
            StartCoroutine(Disable());
        }
        else if (timer <= 3f && timer > 2f)
        {           
            Countdown.text = "1";
            TrafficLight.sprite = Lights[1];
        }
        else if (timer <= 2f && timer > 1.0f)
        {
            Countdown.text = "2";
            TrafficLight.sprite = Lights[1];
        }
        else if (timer >=TimerMax)
        {
            TimerSizeFont();
            Countdown.text = "3";
            TrafficLight.sprite = Lights[0];
        }                                      
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(Countdown);
        timerActive = false;
        yield return new WaitForSeconds(2.0f);
        Destroy(TrafficLight);
    }
}
