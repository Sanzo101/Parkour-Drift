using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Player;
    public GameObject Bar;
    public string s_Player;
    Speedometre Input;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(s_Player);
        Input = Player.GetComponent<Speedometre>();
    }

    // Update is called once per frame
    void Update()
    {
        Input.Player_Input();
        //if (Input.GetKeyDow(KeyCode.Space))
        //{           
            
        //    StartCoroutine(BarDisable());
        //}
    }
    //IEnumerator BarDisable()
    //{
    //    yield return new WaitForSeconds(1);
    //    Bar.SetActive(false);
    //}
}
