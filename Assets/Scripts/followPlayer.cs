using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject childGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = playerGameObject.transform.position;
        childGameObject.transform.localPosition = -transform.position;
    }
}
