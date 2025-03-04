using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private float disableTime = 2f;

    [SerializeField]
    private float rotationSpeed = 20.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.IncrementScore();
            Invoke(nameof(ReenableCollectable), disableTime);
            gameObject.SetActive(false);
        }
    }

    private void ReenableCollectable()
    {
        gameObject.SetActive(true);
        Debug.Log("Collectable re-enabled.");
    }
    
    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * rotationSpeed, 0));

    }
}
