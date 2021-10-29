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
            timer += .5f * Time.deltaTime;
            LighsChange();
        }
    }
    void LighsChange()
    {
        // Sort this out now 
        if (timer >= 1f && timer < 2f)
        {       
            Countdown.text = "3";
            TrafficLight.sprite = Lights[0];
        }
        else if (timer >= 2f && timer < 3f)
        {           
            Countdown.text = "2";
            TrafficLight.sprite = Lights[1];
        }
        else if (timer >= 3f && timer < TimerMax)
        {
            Countdown.text = "1";
            TrafficLight.sprite = Lights[1];
        }
        else if (timer >=TimerMax)
        {
            Speedometre Timer = GameObject.FindGameObjectWithTag("Player").GetComponent<Speedometre>();
            Timer.timersFinished = true;
            Countdown.text = "GO!";
            TrafficLight.sprite = Lights[2];
            StartCoroutine(Disable());
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
