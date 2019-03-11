using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float buttonThreshold = 0.5f;
    private int bowState = 0;
    private int swordState = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (swordState == 0)
            {
                swordState = 1;
                Debug.Log("Drawn Sword");
                //play sward drawing animation
            }
            else if (swordState == 1)
            {
                swordState = 2;
                Debug.Log("Sword is swinging");
                //play sword swinging animation
                swordState = 1;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (bowState == 0)
            {
                Debug.Log("Drawn bow");
                bowState = 1;
                //play bow drawing animation
            }
            if (bowState != 1 || bowState != 0)
            {
                Debug.Log("Bow is already firing or someone be haxing");
            }
            StartCoroutine(BowFireCheck());
        }
        
        IEnumerator BowFireCheck()
        {
            if (bowState == 1)
            {
            
            }
            else
            {
                yield return (false);
            }
        }
    }

}
