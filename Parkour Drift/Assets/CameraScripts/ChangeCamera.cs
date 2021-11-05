using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Cam_1, Cam_2;
    [SerializeField]
    Animator SpeedoAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StratSpeedoAnim();
    }
    public void CameraSwitch()
    {
        Cam_1.SetActive(false);
    }
    void StratSpeedoAnim()
    {
        if(Cam_1.activeSelf == false)
        {
            SpeedoAnim.SetTrigger("SpeedoAnim");
        }
    }
}
