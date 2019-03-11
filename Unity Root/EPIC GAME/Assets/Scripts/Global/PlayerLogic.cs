using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[RequireComponent(typeof(Animator))]

public class PlayerLogic : MonoBehaviour
{
    Animator anim;
    public float animTuning = 0f;
    public float buttonThreshold = 0.5f;
    private int bowState = 0;
    private int swordState = 0;
    public float bowFiringAnimationLength;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (swordState == 0)
            {
                swordState = 1;
                Debug.Log("Drawn Sword");
                bowState = 0;
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
            else if(bowState == 1)
            {
                anim.Play("testBowShot");
                StartCoroutine("FireBow");
            }
            else
            {
                Debug.Log("Bow is already firing or someone be haxing");
            }
        }
    }
    IEnumerator FireBow()
    {
        Debug.Log("Firing Bow");
        yield return new WaitForSeconds(bowFiringAnimationLength);
        Debug.Log("Just Fired Bow");
    }
}
