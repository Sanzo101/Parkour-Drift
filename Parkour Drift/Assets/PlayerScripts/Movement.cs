using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Player;
    public GameObject Bar;
    public string s_Player;
    LaunchBar PowerBar;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(s_Player);
        PowerBar = Player.GetComponent<LaunchBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {           
            PowerBar.LaunchPlayer();
            StartCoroutine(BarDisable());
        }
    }
    IEnumerator BarDisable()
    {
        yield return new WaitForSeconds(1);
        Bar.SetActive(false);
    }
}
