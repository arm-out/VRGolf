using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameManager gameManager;
    public string targetTag = "Ball";

    [SerializeField] private int holeNumber;

    private void Start()
    {
        GameObject holeTile = this.transform.parent.gameObject;
        GameObject hole = holeTile.transform.parent.gameObject;

        string holeName = hole.name;
        holeNumber = int.Parse(holeName.Substring(holeName.Length - 1));

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag(targetTag) && gameManager.currHole == holeNumber - 1)
        {
            gameManager.nextHole();
        }
    }
}
