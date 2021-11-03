using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightsSystem : MonoBehaviour
{
    Image TrafficLight;
    Text Countdown;
    public Sprite[] Lights;
    float timer = 3f;
    [System.NonSerialized]
    public bool timerActive = false;
    [SerializeField]
    AudioSource BigHorn;
    [SerializeField]
    AudioSource SmallHorn;
    bool SoundSwitch = false;

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
                timer -= 1f * Time.deltaTime;
                LighsChange();
            }
        print(timerActive);
    }
    void LighsChange()
    {
        // Sort this out now 
        if (timer <= 3f && timer > 2f)
        {          
            Countdown.text = "3";
            TrafficLight.sprite = Lights[0];
            if (!SoundSwitch)
            {
                PlayBigHorn(); 
                SoundSwitch = true;
            }
        }
        else if (timer <= 2f && timer > 1f)
        {
            Countdown.text = "2";
            TrafficLight.sprite = Lights[0];
            if (SoundSwitch)
            {
                PlayBigHorn();
                SoundSwitch = false;
            }
        }
        else if (timer <= 1f && timer > 0f)
        {          
            Countdown.text = "1";
            TrafficLight.sprite = Lights[0];
            if (!SoundSwitch)
            {
                PlayBigHorn();
                SoundSwitch = true;
            }
        }
        else if (timer <=0)
        {
            if(SoundSwitch)
            {
                PlaySmallHorn();
                SoundSwitch = false;
            }
            Speedometre Timer = GameObject.FindGameObjectWithTag("Player").GetComponent<Speedometre>();
            Timer.timersFinished = true;
            Countdown.fontSize = 150;
            Countdown.color = Color.green;
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
        Destroy(TrafficLight);
    }
    void PlayBigHorn()
    {
        BigHorn.Play();
    }
    void PlaySmallHorn()
    {
        SmallHorn.Play();
    }
}
