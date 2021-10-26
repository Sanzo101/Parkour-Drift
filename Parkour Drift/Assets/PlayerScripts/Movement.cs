using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Player;
    public GameObject Bar;
    Rigidbody RB;
    public string s_Player;
    public float Speed;
    LaunchBar PowerBar;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(s_Player);
        RB = Player.GetComponent<Rigidbody>();
        PowerBar = Player.GetComponent<LaunchBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(Vector3.forward * Speed);
            PowerBar.BarOn = false;
            StartCoroutine(BarDisable());
        }
    }
    IEnumerator BarDisable()
    {
        yield return new WaitForSeconds(1.5f);
        Bar.SetActive(false);
    }
}
