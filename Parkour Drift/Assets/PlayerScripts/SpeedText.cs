using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    public GameObject Player;
    public Text Speed_Text;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed_Text.text = "" + Mathf.RoundToInt(rb.velocity.z);
    }
}
