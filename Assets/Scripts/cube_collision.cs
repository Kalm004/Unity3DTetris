using UnityEngine;
using System.Collections;

public class cube_collision : MonoBehaviour {
    private Vector2 scenarioPosition;
    private Vector2 targetPosition;
    private int cubeNumber;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        transform.parent.gameObject.SendMessage("OnCubeDestroy", SendMessageOptions.DontRequireReceiver);
    }
}
