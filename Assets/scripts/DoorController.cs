using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public bool keyNeeded = false;        
    public bool gotKey;                 
    public GameObject keyGameObject;           
    public GameObject txtToDisplay;             

    private bool playerInZone;                  
    private bool doorOpened;                  

    private Animation doorAnim;
    private BoxCollider doorCollider;           

    enum DoorState
    {
        Closed,
        Opened,
        Jammed
    }

    DoorState doorState = new DoorState();      
    
    private void Start()
    {
        gotKey = false;
        doorOpened = false;                     
        playerInZone = false;                  
        doorState = DoorState.Closed;           

        txtToDisplay.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();

     
        if (keyNeeded && keyGameObject == null)
        {
           
            Debug.LogError("Assign Key GameObject");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        txtToDisplay.SetActive(true);
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (doorState == DoorState.Opened)
            {
                txtToDisplay.GetComponent<Text>().text = "Press 'E' to Close";
                doorCollider.enabled = false;
            }
            else if (doorState == DoorState.Closed || gotKey)
            {
                txtToDisplay.GetComponent<Text>().text = "Press 'E' to Open";
                doorCollider.enabled = true;
            }
            else if (doorState == DoorState.Jammed)
            {
                txtToDisplay.GetComponent<Text>().text = "Needs Key";
                doorCollider.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            doorOpened = !doorOpened;          

            if (doorState == DoorState.Closed && !doorAnim.isPlaying)
            {
                if (!keyNeeded)
                {
                    doorAnim.Play("Door_Open");
                    doorState = DoorState.Opened;
                }
                else if (keyNeeded && !gotKey)
                {
                    doorAnim.Play("Door_Jam");
                    doorState = DoorState.Jammed;
                }
            }

            if (doorState == DoorState.Closed && gotKey && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
            }

            if (doorState == DoorState.Opened && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Close");
                doorState = DoorState.Closed;
            }

            if (doorState == DoorState.Jammed && !gotKey)
            {
                doorAnim.Play("Door_Jam");
                doorState = DoorState.Jammed;
            }
            else if (doorState == DoorState.Jammed && gotKey && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
            }
        }
    }
}
