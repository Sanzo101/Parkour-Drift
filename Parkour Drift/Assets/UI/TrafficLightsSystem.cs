using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightsSystem : MonoBehaviour
{
    [SerializeField]
    GameObject Light, Light_1, Light_2;
    Image Timer_Image;
    GameObject TrafficLight;
    Text Countdown;
    public Sprite[] Lights;
    [System.NonSerialized]
    public bool timerActive = false;
    [SerializeField]
    AudioSource BigHorn, SmallHorn, Ignition;
    Animator Anim;
    bool SoundSwitch = false;

    private void Awake()
    {
        Light.SetActive(false);
        Light_1.SetActive(false);
        Light_2.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        TrafficLight = GameObject.Find("TrafficLights");
        Countdown = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        Timer_Image = GameObject.Find("TimerBack").GetComponent<Image>();
        Anim =gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
            if (timerActive)
            {
                Anim.SetTrigger("PlayAnim");              
            }
    } 
    void PlayBigHorn()
    {
        BigHorn.Play();
    }
    void PlaySmallHorn()
    {
        SmallHorn.Play();
    }
    void PlayIgnition()
    {
        Ignition.Play();
    }
    public void Countdown_Flag()
    {
        if (!SoundSwitch)
        {
            PlayIgnition();
            SoundSwitch = true;
        }
    }
    public void Countdown_3()
    {
        Countdown.text = "3";
        Countdown.color = Color.HSVToRGB(0, 100, 100);
        TrafficLight.GetComponent<Image>().sprite = Lights[0];
        Light.SetActive(true);
        if (SoundSwitch)
        {
            PlayBigHorn();
            SoundSwitch = false;
        }
    }
    public void Countdown_2()
    {
        Countdown.text = "2";
        Countdown.color = Color.HSVToRGB(0, 100, 100);
        TrafficLight.GetComponent<Image>().sprite = Lights[0];
        Light_1.SetActive(true);
        if (!SoundSwitch)
        {
            PlayBigHorn();
            SoundSwitch = true;
        }
    }
    public void Countdown_1()
    {
        Countdown.text = "1";
        Countdown.color = Color.HSVToRGB(0, 100, 100);
        TrafficLight.GetComponent<Image>().sprite = Lights[0];
        Light_2.SetActive(true);
        if (SoundSwitch)
        {
            PlayBigHorn();
            SoundSwitch = false;
        }
    }
    public void Countdown_GO()
    {
        if (!SoundSwitch)
        {
            PlaySmallHorn();
            SoundSwitch = true;
        }
        Speedometre Timer = GameObject.FindGameObjectWithTag("Player").GetComponent<Speedometre>();
        Timer.timersFinished = true;
        Countdown.fontSize = 150;
        Countdown.color = new Color32(8, 255, 0, 255);
        Timer_Image.color = new Color32(8,255,0,255);
        Timer_Image.GetComponent<Light>().color = new Color32(8, 255, 0, 255);
        Light.GetComponent<Light>().color = new Color32(8, 255, 0, 255);
        Light_1.GetComponent<Light>().color = new Color32(8, 255, 0, 255);
        Light_2.GetComponent<Light>().color = new Color32(8, 255, 0, 255);
        Countdown.text = "GO!";
        TrafficLight.GetComponent<Image>().sprite = Lights[2];
        StartCoroutine(Disable());
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(Countdown);
        timerActive = false;
        Destroy(TrafficLight);
        Destroy(Timer_Image.gameObject);
    }
}
