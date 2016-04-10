using UnityEngine;
using System.Collections;

public class piece_move : MonoBehaviour {
    public float moveSpeed = 4f;
    private bool checkCanMoveDown = true;
    private scenario_model scenarioModel;
    private float nextMovement = 0;
    private float speed = 0.2f;
    private float lastHorizontalAxis = 0;
    public bool Stopped
    {
        get
        {
            return !checkCanMoveDown;
        }
    }

    // Use this for initialization
    void Start () {
        scenarioModel = GameObject.FindGameObjectWithTag("Scenario").GetComponent<scenario_model>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCanMoveDown)
        {
            if (Time.time >= nextMovement)
            {
                nextMovement = Time.time + speed;
                if (checkCanMoveDown && scenarioModel.CheckPieceCanMoveDown(gameObject))
                {
                    transform.Translate(-Vector3.up);
                    scenarioModel.MoveDown(gameObject);
                }
                else
                {
                    checkCanMoveDown = false;
                    scenarioModel.SendMessage("CheckLines");
                    return;
                }
            }
            float horizontalMove = (Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0);
            if ((horizontalMove > 0 && !scenarioModel.CheckPieceCanMoveRight(gameObject) ||
                (horizontalMove < 0 && !scenarioModel.CheckPieceCanMoveLeft(gameObject))))
            {
                horizontalMove = 0;
            } else { 
                if (horizontalMove > 0)
                {
                    scenarioModel.MoveRight(gameObject);
                }
                else if (horizontalMove < 0)
                {
                    scenarioModel.MoveLeft(gameObject);
                }
                transform.Translate(new Vector3(horizontalMove, 0, 0));
            }

        }
	}

    /*
    void OnCubeCollisionEnter(Collider collider)
    {
        print("Collide with " + collider.gameObject.tag);
    }
    */
}
