using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(FindClosest))]
public class PlayerLogic : MonoBehaviour
{
    #region declare variables
    public Camera cam;
    Animator anim;
    public float animTuning = 0f;
    public float buttonThreshold = 0.5f;
    private int bowState = 0;
    private int swordState = 0;
    public float bowFiringAnimationLength;
    public GameObject focus = null;
    SmoothLookAt smoothLook;
    FolowPlayer folowPlayer;
    CameraControll CameraControll;
    PlayerMovement playerMovement;
    FindClosest FindClosest;
    #endregion declare variables

    void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        smoothLook = cam.GetComponent<SmoothLookAt>();
        folowPlayer = cam.GetComponent<FolowPlayer>();
        CameraControll = cam.GetComponent<CameraControll>();
        playerMovement = GetComponent<PlayerMovement>();
        FindClosest = GetComponent<FindClosest>();
    }

    void FixedUpdate()
    {
        if (focus != null)
            playerMovement.FaceTarget(focus.transform);
    }

    // Update is called once per frame
    void Update()
    {
        #region sword
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
        #endregion sword
        #region bow
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
        #endregion bow
        #region focus
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            swordState = 0;
            bowState = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            NewFocus();
            FocusNow();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            RemoveFocus();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject closestInteractable = FindClosest.FindClosestObject("Interactable");
            Interactable interactableToInteractWith = closestInteractable.GetComponent<Interactable>();
            //interactableToInteractWith.OnInteractionEntry();
        }


        #endregion focus
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
        focus = gameObject.GetComponent<FindClosest>().FindClosestObject("Interactable");
    }

    void FocusNow()
    {
        Debug.Log("focusing on " + focus.name);
        smoothLook.enabled = true;
        smoothLook.SetTarget(cam, focus);
    }

    public void RemoveFocus()
    {
        Debug.Log("removing focus");
        smoothLook.SetTarget(cam, null);
        smoothLook.enabled = false;
        focus = null;
        folowPlayer.cameraControllEnabeled = true;
        
    }



}
