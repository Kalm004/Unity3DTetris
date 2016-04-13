using UnityEngine;
using System.Collections;

public class cube_collision : MonoBehaviour {
    private Vector2 scenarioPosition = new Vector2(-1, -1);
    private Vector2 targetPosition;
    private int cubeNumber;
    private Renderer renderer;
    private float blinkingTime = 0.1f;
    private float nextBlink = 0;

    public Vector2 ScenarioPosition
    {
        get
        {
            return scenarioPosition;
        }
        set
        {
            scenarioPosition = value;
        }
    }

    public Vector2 TargetPosition
    {
        get
        {
            return targetPosition;
        }
    }

    public void SetTargetPosition(Vector2 value)
    {
        targetPosition = scenarioPosition + value;
    }

    public int CubeNumber
    {
        get
        {
            return cubeNumber;
        }
    }

    public void SetCubeNumber(int value)
    {
        cubeNumber = value;
    }
    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.DeletingLines)
        {
            bool found = false;
            foreach (int line in GameManager.LinesToDelete)
            {
                if (line == scenarioPosition.y)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                if (Time.time > nextBlink)
                {
                    renderer.enabled = !renderer.enabled;
                    nextBlink = Time.time + blinkingTime;
                }
            }
        }
	}

    void OnDestroy()
    {
        transform.parent.gameObject.SendMessage("OnCubeDestroy", SendMessageOptions.DontRequireReceiver);
    }
}
