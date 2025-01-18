using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject targetObject;  // The object that should disappear, like a door or wall

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            targetObject.SetActive(false);  // Hide the target object
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            targetObject.SetActive(true);  // Show the target object
        }
    }
}
