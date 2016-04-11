using UnityEngine;
using System;
using System.Collections;

public class piece_rotate : MonoBehaviour {
    private piece_move pieceMove;
    private enum PiecesTypes
    {
        Line,
        T,
        L,
        InvertL,
        R,
        InvertR,
        Square
    }

    private PiecesTypes pieceType;
    private int status = 0;
    private int targetStatus = 0;

    public void SetPieceType(String value)
    {
        pieceType = (PiecesTypes)Enum.Parse(typeof(PiecesTypes), value);
    }

	// Use this for initialization
	void Start () {
        pieceMove = gameObject.GetComponent<piece_move>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!pieceMove.Stopped && Input.GetKeyDown(KeyCode.UpArrow))
        {
            CalculateNewPositions();
            if (GameManager.scenario.CheckTargetPositionIsPossible(gameObject))
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    GameObject cube = gameObject.transform.GetChild(i).gameObject;
                    cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                    Vector2 delta = cubeCollision.TargetPosition - cubeCollision.ScenarioPosition;
                    cube.transform.Translate(delta.x * cube.transform.localScale.x, delta.y * cube.transform.localScale.y, 0);
                }
                GameManager.scenario.MoveToTargetPosition(gameObject);
                status = targetStatus;
            }
        }
    }

    void CalculateNewPositions()
    {
        switch (pieceType)
        {
            case PiecesTypes.Line:
                if (status == 0)
                {
                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(0, 0));
                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(1, -1));
                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(2, -2));
                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(3, -3));
                    targetStatus = 1;
                } else
                {
                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(0, 0));
                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-2, 2));
                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-3, 3));
                    targetStatus = 0;
                }
                break;
            case PiecesTypes.T:
                switch (status)
                {
                    case 0:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                            default:
                                    break;
                            }
                        }
                        targetStatus = 1;
                        break;
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 2;
                        break;
                    case 2:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 3;
                        break;
                    case 3:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 0;
                        break;
                    default:
                        break;
                }
                break;
            case PiecesTypes.L:
                switch (status)
                {
                    case 0:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-2, -2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 1;
                        break;
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(2, -2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 2;
                        break;
                    case 2:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(2, 2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 3;
                        break;
                    case 3:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-2, 2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 0;
                        break;
                    default:
                        break;
                }
                break;
            case PiecesTypes.InvertL:
                switch (status)
                {
                    case 0:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(2, -2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 1;
                        break;
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-2, -2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 2;
                        break;
                    case 2:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-2, 2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 3;
                        break;
                    case 3:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(2, 2));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 0;
                        break;
                    default:
                        break;
                }
                break;
            case PiecesTypes.R:
                switch (status)
                {
                    case 0:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    cube.SendMessage("SetTargetPosition", new Vector2(-2, 0));
                                    break;
                                case 2:
                                    cube.SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 1:
                                    cube.SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 0:
                                    cube.SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 1;
                        break;
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(2, 0));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 0;
                        break;
                    default:
                        break;
                }
                break;
            case PiecesTypes.InvertR:
                switch (status)
                {
                    case 0:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(0, -2));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(1, -1));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(1, 1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 1;
                        break;
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            GameObject cube = gameObject.transform.GetChild(i).gameObject;
                            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                            switch (cubeCollision.CubeNumber)
                            {
                                case 3:
                                    gameObject.transform.GetChild(3).SendMessage("SetTargetPosition", new Vector2(0, 2));
                                    break;
                                case 2:
                                    gameObject.transform.GetChild(2).SendMessage("SetTargetPosition", new Vector2(-1, 1));
                                    break;
                                case 1:
                                    gameObject.transform.GetChild(1).SendMessage("SetTargetPosition", new Vector2(0, 0));
                                    break;
                                case 0:
                                    gameObject.transform.GetChild(0).SendMessage("SetTargetPosition", new Vector2(-1, -1));
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetStatus = 0;
                        break;
                    default:
                        break;
                }
                break;
            case PiecesTypes.Square:
                //Nothing to do
                for (int i = 0; i < 4; i++)
                {
                    GameObject cube = gameObject.transform.GetChild(i).gameObject;
                    cube_collision cubeCollision = cube.GetComponent<cube_collision>();
                    gameObject.transform.GetChild(i).SendMessage("SetTargetPosition", cubeCollision.ScenarioPosition);
                }
                break;
            default:
                break;
        }
    }
}
