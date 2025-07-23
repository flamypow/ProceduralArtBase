using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //copy player's linear velocity
    [SerializeField] private Rigidbody rb;

    void FixedUpdate()
    { 
        rb.linearVelocity += PlayerMovement.Instance.GetFakeGravity() * Time.fixedDeltaTime;


    }
}
