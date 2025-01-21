using UnityEngine;
using System.Collections;

public class UsefulObject : MonoBehaviour
{
    public Camera mainCamera;                 
    public GameObject targetObject;            
    public KeyCode disappearKey = KeyCode.E;  
    public GameObject platform;               

    public Canvas canvasWithObject;            
    public Canvas canvasWithoutObject;        

    public bool isPickedUp = false;           
    public bool isOnPlatform = false;        

    public float platformDelay = 2f;           

    private void Start()
    {
        canvasWithObject.gameObject.SetActive(false);
        canvasWithoutObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isPickedUp && IsObjectInView(targetObject))
        {
            if (Input.GetKeyDown(disappearKey))
            {
                Debug.Log(targetObject.name + " is in view, E is pressed, and object is being picked up.");
                targetObject.SetActive(false); 
                isPickedUp = true; 
            }
        }
    }
    bool IsObjectInView(GameObject obj)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(obj.transform.position);
        bool isInView = viewportPoint.z > 0 &&
                        viewportPoint.x > 0 && viewportPoint.x < 1 &&
                        viewportPoint.y > 0 && viewportPoint.y < 1;

        return isInView;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnPlatform = true;
            Debug.Log("Player is on the platform.");
            StartCoroutine(ToggleCanvasWithDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnPlatform = false;
            Debug.Log("Player left the platform.");
        }
    }

    IEnumerator ToggleCanvasWithDelay()
    {
        // Wait for the delay
        yield return new WaitForSeconds(platformDelay);

        if (isOnPlatform)
        {
            if (isPickedUp)
            {
                Debug.Log("Toggling the canvas for having the object.");
                canvasWithObject.gameObject.SetActive(true);
                canvasWithoutObject.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Debug.Log("Toggling the canvas for not having the object.");
                canvasWithObject.gameObject.SetActive(false);
                canvasWithoutObject.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
