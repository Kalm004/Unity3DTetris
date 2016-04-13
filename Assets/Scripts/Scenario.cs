using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scenario {
    private GameObject[,] scenario = new GameObject[GameManager.scenario_width, 23];

    public void AddPiece(GameObject gameObject)
    {
        //print("Piece x" + Mathf.Round(gameObject.transform.position.x + 5));
        //print("Piece y" + Mathf.Round(gameObject.transform.position.y));
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject cube = gameObject.transform.GetChild(i).gameObject;
            int x = Mathf.RoundToInt(gameObject.transform.position.x + cube.transform.localPosition.x - 0.5f + GameManager.scenario_width / 2);
            int y = Mathf.RoundToInt(gameObject.transform.position.y + cube.transform.localPosition.y - 0.5f);
            cube.GetComponent<cube_collision>().ScenarioPosition = new Vector2(x, y);
            //print("Cube at " + x + "," + y);
            if (scenario[x,y] != null)
            {
                SceneManager.LoadScene("Final");
            }
            scenario[x, y] = cube;
        }
    }

    public bool CheckPieceCanMoveDown(GameObject piece)
    {
        return CheckPieceCanMoveDirection(piece, new Vector2(0, -1));
    }

    public void MoveDown(GameObject piece)
    {
        MoveDirection(piece, new Vector2(0, -1));
    }

    public bool CheckPieceCanMoveLeft(GameObject piece)
    {
        return CheckPieceCanMoveDirection(piece, new Vector2(-1, 0));
    }

    public void MoveLeft(GameObject piece)
    {
        MoveDirection(piece, new Vector2(-1, 0));
    }

    public bool CheckPieceCanMoveRight(GameObject piece)
    {
        return CheckPieceCanMoveDirection(piece, new Vector2(1, 0));
    }

    public void MoveRight(GameObject piece)
    {
        MoveDirection(piece, new Vector2(1, 0));
    }

    private bool CheckPieceCanMoveDirection(GameObject piece, Vector2 direction)
    {
        bool canMove = true;
        for (int i = 0; i < piece.transform.childCount; i++)
        {
            GameObject cube = piece.transform.GetChild(i).gameObject;
            Vector2 position = cube.GetComponent<cube_collision>().ScenarioPosition;

            Vector2 targetPosition = position + direction;

            //print("Checking if possible to move from " + position + " to " + targetPosition);

            if (targetPosition.y < 0 || targetPosition.x < 0 || targetPosition.x > (GameManager.scenario_width - 1))
            {
                canMove = false;
                break;
            }
            GameObject objectBellow = scenario[(int)targetPosition.x, (int)targetPosition.y];
            if (objectBellow != null && objectBellow.transform.parent != cube.transform.parent)
            {
                canMove = false;
            }
        }

        return canMove;
    }

    public void MoveDirection(GameObject piece, Vector2 direction)
    {
        for (int i = 0; i < piece.transform.childCount; i++)
        {
            GameObject cube = piece.transform.GetChild(i).gameObject;
            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
            Vector2 position = cubeCollision.ScenarioPosition;
            Vector2 targetPosition = position + direction;
            //print("Trying to move from " + position);
            if (scenario[(int)position.x, (int)position.y] == cube)
            {
                scenario[(int)position.x, (int)position.y] = null;
            }
            cubeCollision.ScenarioPosition = targetPosition;
            scenario[(int)targetPosition.x, (int)targetPosition.y] = cube;
            //print("Cube moved from " + position + " to " + targetPosition);
        }
    }

    public void CheckLines()
    {
        ArrayList linesToDelete = new ArrayList();
        for (int i = 0; i < scenario.GetLength(1); i++)
        {
            bool line = true;
            for (int j = 0; j < scenario.GetLength(0); j++)
            {
                if (scenario[j, i] == null)
                {
                    line = false;
                    break;
                }
            }
            if (line)
            {
                linesToDelete.Add(i);
            }
        }
        GameManager.Lines += linesToDelete.Count;
        GameManager.LinesToDelete = linesToDelete;
    }

    public void DeleteLines(ArrayList lines)
    {
        foreach (int i in lines)
        {
            for (int j = 0; j < scenario.GetLength(0); j++)
            {
                GameObject.Destroy(scenario[j, i]);
                scenario[j, i] = null;
            }
        }
    }

    public void MoveLines(ArrayList lines)
    {
        lines.Sort();
        lines.Reverse();
        foreach (int line in lines)
        {
            for (int i = line + 1; i < scenario.GetLength(1); i++)
            {
                for (int j = 0; j < scenario.GetLength(0); j++)
                {
                    GameObject cube = scenario[j, i];
                    scenario[j, i - 1] = scenario[j, i];
                    if (cube != null)
                    {
                        cube.GetComponent<cube_collision>().ScenarioPosition = new Vector2(j, i - 1);
                        cube.transform.Translate(-Vector3.up);
                    }
                }
            }
        }
    }

    public bool CheckTargetPositionIsPossible(GameObject piece)
    {
        bool canMove = true;
        for (int i = 0; i < piece.transform.childCount; i++)
        {
            GameObject cube = piece.transform.GetChild(i).gameObject;
            Vector2 targetPosition = cube.GetComponent<cube_collision>().TargetPosition;

            if (targetPosition.y < 0 || targetPosition.x < 0 || targetPosition.x > (GameManager.scenario_width - 1))
            {
                canMove = false;
                break;
            }
            GameObject targetObject = scenario[(int)targetPosition.x, (int)targetPosition.y];
            if (targetObject != null && targetObject.transform.parent != cube.transform.parent)
            {
                canMove = false;
            }
        }

        return canMove;
    }

    public void MoveToTargetPosition(GameObject piece)
    {
        for (int i = 0; i < piece.transform.childCount; i++)
        {
            GameObject cube = piece.transform.GetChild(i).gameObject;
            cube_collision cubeCollision = cube.GetComponent<cube_collision>();
            Vector2 position = cubeCollision.ScenarioPosition;
            Vector2 targetPosition = cubeCollision.TargetPosition;
            //print("Trying to move from " + position);
            if (scenario[(int)position.x, (int)position.y] == cube)
            {
                scenario[(int)position.x, (int)position.y] = null;
            }
            cubeCollision.ScenarioPosition = targetPosition;
            scenario[(int)targetPosition.x, (int)targetPosition.y] = cube;
        }
    }
}
