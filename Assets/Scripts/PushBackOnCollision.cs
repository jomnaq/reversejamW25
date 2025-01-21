using UnityEngine;
using System.Collections;


public class PushBackOnCollision : MonoBehaviour
{
    public float pushBackForce = 15f; 
    public float pushDuration = 0.3f;  
    private Coroutine currentPushCoroutine;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision detected");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                if (currentPushCoroutine != null)
                {
                    StopCoroutine(currentPushCoroutine);
                }
                currentPushCoroutine = StartCoroutine(ApplyPushOverTime(playerRigidbody, collision.transform));
            }
        }
    }

    private IEnumerator ApplyPushOverTime(Rigidbody playerRigidbody, Transform playerTransform)
    {
        Vector3 initialPosition = playerTransform.position;
        Vector3 pushDirection = initialPosition - transform.position;
        pushDirection.y = 0;
        pushDirection.Normalize();

        float elapsedTime = 0f;

        while (elapsedTime < pushDuration)
        {
            float forceToApply = Mathf.Lerp(0, pushBackForce, elapsedTime / pushDuration);
            playerRigidbody.AddForce(pushDirection * forceToApply, ForceMode.Impulse);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        playerRigidbody.AddForce(pushDirection * pushBackForce, ForceMode.Impulse);
    }
}
