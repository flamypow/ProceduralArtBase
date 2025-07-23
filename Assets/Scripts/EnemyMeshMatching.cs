using UnityEngine;

public class EnemyMeshMatching : MonoBehaviour
{
    [SerializeField] private GameObject enemyColliderGameObject;

    void FixedUpdate()
    {
        transform.localPosition = new Vector3(enemyColliderGameObject.transform.position.x, 0.114f, enemyColliderGameObject.transform.position.z);
        
    }
}
