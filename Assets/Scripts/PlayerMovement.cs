using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerMovement : Code.Scripts.Managers.Singleton<PlayerMovement>
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject fieldMeshPivot;
    private bool buttonDownUpDown;
    private bool buttonDownLeftRIght;
    private float upDownValue;
    private float leftRightValue;

    private Vector3 fakeGravity;
    private Vector3 cameraAngle;
    private float VectorX;
    private float VectorZ;

    [SerializeField] private float ballSpeed;
    [SerializeField] private float cameraSpeed;
    public void UpDown(float value)
    {
        buttonDownUpDown = true;
        upDownValue = value;
    }

    public void LeftRight(float value)
    {
        buttonDownLeftRIght = true;
        leftRightValue = value;
    }

    public void UpDownFinished()
    {
        buttonDownUpDown = false;
    }
    public void LeftRightFinished()
    {
        buttonDownLeftRIght = false;
    }

    void Start()
    {
        VectorX = 0;
        VectorZ = 0;
    }

    void OnLevelWasLoaded(int level)
    { 
        rb =  GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        playerCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        fieldMeshPivot = GameObject.FindWithTag("Pivot");
    }

    void FixedUpdate()
    {
        if (buttonDownUpDown)
        {
            VectorZ += upDownValue * ballSpeed;
            VectorZ = Mathf.Clamp(VectorZ, -10f, 10f);
        }

        if (buttonDownLeftRIght)
        {
            VectorX += leftRightValue * ballSpeed;
            VectorX = Mathf.Clamp(VectorX, -10f, 10f);
        }

        fakeGravity = new Vector3(VectorX, 0, VectorZ);
        
        rb.linearVelocity += fakeGravity * Time.fixedDeltaTime;

        //rotate the field mesh
        Quaternion target = Quaternion.Euler(VectorZ *5, 0, -VectorX *5);

        // Dampen towards the target rotation
        fieldMeshPivot.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);

    }

    public Vector3 GetFakeGravity()
    { 
        return fakeGravity;
    }
}
