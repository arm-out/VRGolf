using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameManager gameManager;
    public string targetTag = "Ball";

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag(targetTag))
        {
            gameManager.nextHole();
        }
    }
}
