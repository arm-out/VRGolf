using UnityEngine;

public class ClubCollision : MonoBehaviour
{
    public string targetTag;
    public GameManager gameManager;

    private Collider clubCollider;
    private Vector3 prevPosition;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        clubCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - prevPosition) / Time.deltaTime;
        prevPosition = transform.position;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag(targetTag))
        {
            Vector3 collPosition = clubCollider.ClosestPoint(coll.transform.position);
            Vector3 collNormal = coll.transform.position - collPosition;

            Vector3 projectedVelocity = Vector3.Project(velocity, collNormal);

            Rigidbody rb = coll.attachedRigidbody;
            rb.velocity = projectedVelocity;

            gameManager.currHits++;
        }
    }
}
