using UnityEngine;
using System.Collections;  // Needed for coroutines

public class PressurePlate : MonoBehaviour
{
    public GameObject targetObject;        // The object that should disappear
    public AudioSource audioSource;      
    public AudioClip enterSound;           // Sound to play when entering the trigger
    public AudioClip exitSound;            // Sound to play when exiting the trigger
    public float muteDuration = 2f;       

    private void Start()
    {
        StartCoroutine(MuteForSeconds(muteDuration));
    }

    private IEnumerator MuteForSeconds(float seconds)
    {
        if (audioSource != null)
        {
            // Mute audio at beginning for setup
            audioSource.mute = true;
            yield return new WaitForSeconds(seconds);
            audioSource.mute = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            targetObject.SetActive(false);  // Hide the target object

            if (audioSource != null && enterSound != null && !audioSource.mute)
            {
                audioSource.clip = enterSound;
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            targetObject.SetActive(true);  // Show the target object

            if (audioSource != null && exitSound != null && !audioSource.mute)
            {
                audioSource.clip = exitSound;
                audioSource.Play();
            }
        }
    }
}
