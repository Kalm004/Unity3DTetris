using UnityEngine;
using System.Collections;

public class piece_move : MonoBehaviour {
    private bool checkCanMoveDown = false;
    private float nextDownMovement = 0;
    private float nextLateralMovement = 0;
    private static float movementDelayUserAction = 0.1f;
    private static float firstLateralMovementDelay = 0.5f;
    private static float otherLateralMovementDelay = 0.1f;
    private float prevHorizontalMove = 0;
 

    public bool Stopped
    {
        get
        {
            return !checkCanMoveDown;
        }
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCanMoveDown)
        {
            if (Time.time >= nextDownMovement)
            {
                nextDownMovement = Time.time + (Input.GetKey(KeyCode.DownArrow) ? movementDelayUserAction : GameManager.GetMovementDelay());
                if (checkCanMoveDown && GameManager.scenario.CheckPieceCanMoveDown(gameObject))
                {
                    transform.Translate(-Vector3.up);
                    GameManager.scenario.MoveDown(gameObject);
                }
                else
                {
                    checkCanMoveDown = false;
                    GameManager.scenario.CheckLines();
                    return;
                }
            }
            float horizontalMove = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
            if ((horizontalMove > 0 && !GameManager.scenario.CheckPieceCanMoveRight(gameObject) ||
                (horizontalMove < 0 && !GameManager.scenario.CheckPieceCanMoveLeft(gameObject))))
            {
                horizontalMove = 0;
            } else {
                if (horizontalMove != prevHorizontalMove || Time.time > nextLateralMovement)
                {
                    if (horizontalMove > 0)
                    {
                        GameManager.scenario.MoveRight(gameObject);
                    }
                    else if (horizontalMove < 0)
                    {
                        GameManager.scenario.MoveLeft(gameObject);
                    }
                    transform.Translate(new Vector3(horizontalMove, 0, 0));
                    nextLateralMovement = Time.time + (horizontalMove != prevHorizontalMove ? firstLateralMovementDelay : otherLateralMovementDelay);
                }
            }
            prevHorizontalMove = horizontalMove;
        }
	}

    public void StartMovement()
    {
        checkCanMoveDown = true;
    }
}
