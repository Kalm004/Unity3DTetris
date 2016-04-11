using UnityEngine;
using System.Collections;

public class piece_move : MonoBehaviour {
    public float moveSpeed = 4f;
    private bool checkCanMoveDown = true;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCanMoveDown)
        {
            if (Time.time >= nextMovement)
            {
                nextMovement = Time.time + speed;
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
            float horizontalMove = (Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0);
            if ((horizontalMove > 0 && !GameManager.scenario.CheckPieceCanMoveRight(gameObject) ||
                (horizontalMove < 0 && !GameManager.scenario.CheckPieceCanMoveLeft(gameObject))))
            {
                horizontalMove = 0;
            } else { 
                if (horizontalMove > 0)
                {
                    GameManager.scenario.MoveRight(gameObject);
                }
                else if (horizontalMove < 0)
                {
                    GameManager.scenario.MoveLeft(gameObject);
                }
                transform.Translate(new Vector3(horizontalMove, 0, 0));
            }

        }
	}
}
