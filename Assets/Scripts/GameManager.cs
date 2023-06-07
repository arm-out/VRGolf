using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private int currHole = 0;
    public List<Transform> startPositions;
    public Rigidbody ballRB;

    public int currHits;
    private List<int> scores = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ballRB.transform.position = startPositions[currHole].position;
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            nextHole();
        }
    }

    public void nextHole()
    {
        currHole += 1;
        if (currHole >= startPositions.Count)
        {
            Debug.Log("Game Over");
        }
        else
        {
            ballRB.transform.position = startPositions[currHole].position;
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;
        }

        scores.Add(currHits);
        currHits = 0;
        showScore();
    }

    public void showScore()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            Debug.Log("Hole " + (i + 1) + ": " + scores[i]);
        }
    }
}
