﻿using UnityEngine;


[RequireComponent(typeof(Animator))]

public class PlayerLogic : MonoBehaviour
{
    Animator anim;
    public float animTuning = 0f;
    public float buttonThreshold = 0.5f;
    private int bowState = 0;
    private int swordState = 0;
    public float bowFiringAnimationLength;
    public GameObject focus = null;
    bool hasFocused = false;


    void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (swordState == 0)
            {
                //play sword drawing animation
                swordState = 1;
                bowState = 0;
                Debug.Log("Drawn Sword");
            }
            else if (swordState == 1)
            {
                swordState = 2;
                Debug.Log("Sword is swinging");
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
            Debug.Log("finished bow logic");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            swordState = 0;
            bowState = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            NewFocus();
        }

        if (focus != null && !hasFocused)
        {
            Debug.Log("we focused on " + focus.name);
            hasFocused = true;
        }
        else if (focus != null && hasFocused)
            Debug.Log("already focused on " + focus.name);
    }
    /*
    IEnumerator FireBow()
    {
        Debug.Log("Firing Bow");
        yield return new WaitForSeconds(bowFiringAnimationLength);
        Debug.Log("Just Fired Bow");
    }
    */

    public void NewFocus()
    {
        hasFocused = false;
        focus = gameObject.GetComponent<FindClosest>().FindClosestObject("Interactable");
    }

    void FocusNow()
    {

    }

    public void RemoveFocus()
    {
        focus = null;
        hasFocused = false;
    }



}
