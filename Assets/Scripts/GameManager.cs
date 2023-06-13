using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currHole = 0;
    public List<Transform> startPositions;
    public float minDist;

    public GameObject player;
    public Rigidbody ballRB;
    public GameObject scoreboard;
    public GameObject waypoint;
    public GameObject currHoleObj;
    public HoleRefs currHoleRefs;

    public InputActionProperty resetButton;
    public InputActionProperty quitButton;
    public InputActionProperty nextHoleButton;

    public int currHits;
    private List<int> scores = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ballRB.transform.position = startPositions[currHole].position;
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

        currHoleObj = GameObject.Find("Hole0" + (currHole + 1));
        currHoleRefs = currHoleObj.GetComponent<HoleRefs>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || nextHoleButton.action.WasPressedThisFrame())
        {
            nextHole();
        }

        if (resetButton.action.WasPressedThisFrame())
        {
            reset();
            currHits += 1;
        }

        if (quitButton.action.WasPressedThisFrame())
        {
            SceneManager.LoadScene(0);
        }

        // Update waypoint position
        waypoint.transform.position = currHoleRefs.holeTrigger.transform.position + new Vector3(0, 1f, 0);
        float dist = Vector3.Distance(waypoint.transform.position, player.transform.position);
        if (dist > minDist)
        {
            waypoint.SetActive(true);
        }
        else
        {
            waypoint.SetActive(false);
        }

        // Reset ball position


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

            currHoleObj = GameObject.Find("Hole0" + (currHole + 1));
            currHoleRefs = currHoleObj.GetComponent<HoleRefs>();
        }

        scores.Add(currHits);
        currHits = 0;
        showScore();
    }

    public void showScore()
    {
        if (currHole <= 9)
        {
            scoreboard.transform.GetChild(currHole).GetComponent<TMPro.TextMeshPro>().text += scores[currHole - 1].ToString();
            int total = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                total += scores[i];
            }
            scoreboard.transform.GetChild(10).GetComponent<TMPro.TextMeshPro>().text = "Total    - " + total.ToString();
        }

    }

    public void reset()
    {
        ballRB.transform.position = startPositions[currHole].position;
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
    }
}
