using Unity.VisualScripting;
using UnityEngine;

public class RotateField : Code.Scripts.Managers.Singleton<RotateField>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject field;

    private float RotateX;
    private float RotateZ;
    private float TargetX;
    private float TargetZ;
    private float smooth = 5.0f;
    [SerializeField] private float RotationSpeed;

    private bool buttonDownUpDown;
    private bool buttonDownLeftRIght;

    void Start()
    {
        TargetX = field.transform.rotation.x;
        TargetZ = field.transform.rotation.z;
        buttonDownUpDown = false;
        buttonDownLeftRIght = false;
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (buttonDownLeftRIght)
        {
            TargetX += RotateX * RotationSpeed;
            TargetX = Mathf.Clamp(TargetX, -10f, 10f);
        }
        if (buttonDownUpDown)
        {
            TargetZ += RotateZ * RotationSpeed;
            TargetZ = Mathf.Clamp(TargetZ, -10f, 10f);
        }

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(TargetX, 0, TargetZ);

        // Dampen towards the target rotation
        field.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }*/

    public void UpDown(float value)
    {
        buttonDownUpDown = true;
        RotateZ = value;
    }

    public void LeftRight(float value)
    {
        buttonDownLeftRIght = true;
        RotateX = value;
    }

    public void UpDownFinished()
    {
        buttonDownUpDown = false;
    }
    public void LeftRightFinished()
    {
        buttonDownLeftRIght = false;
    }
}
