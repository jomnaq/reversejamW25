using UnityEngine;

public class PlatformBug : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 2.0f;

    Vector3 target = Vector3.zero;

    bool _crouching = false;

    public bool Crouching {
        get => _crouching;
        set {
            if(Crouching != value) {
                _crouching = value;
                if(_crouching) {
                    Crouch();
                } else {
                    Stand();
                }
            }
        }
    }

    public bool AtTarget => Vector3.Distance(transform.position, target) < 0.1f;

    void Start() {
        target = transform.position;
    }

    public void MoveTo(Vector3 target) {
        this.target = target;
        Crouching = false;
    }

    public void CancelMove(){
        target = transform.position;
    }

    void Crouch(){
        animator.SetBool("crouching", true);
        CancelMove();
    }

    void Stand(){
        animator.SetBool("crouching", false);
    }

    void FixedUpdate() {
        if(!AtTarget) {
            Vector3 direction = (target - transform.position).normalized;
            rb.linearVelocity = direction * speed;
            animator.SetBool("walking", true);
        } else {
            rb.linearVelocity = Vector3.zero;
            animator.SetBool("walking", false);
        }
    }
}
