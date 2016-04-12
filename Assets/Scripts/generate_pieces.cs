using UnityEngine;
using System.Collections;

public class generate_pieces : MonoBehaviour {
    public GameObject piece;
    public GameObject cube;
    public GameObject scenario;
    private GameObject lastPiece = null;
    public Texture quadTexture;
    public Texture tPieceTexture;
    public Texture lPieceTexture;
    public Texture rPieceTexture;
    public Texture rInvertPieceTexture;
    public Texture longTexture;
    public Texture lInvertTexture;
    private const int differentTypeOfPieces = 7;
    public float waitUntilNewPiece = 0.2f;

    // Use this for initialization
    void Start () {
        StartCoroutine(GeneratePieces());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GeneratePieces()
    {
        while (true)
        {
            if (lastPiece == null || lastPiece.GetComponent<piece_move>().Stopped)
            {
                lastPiece = CreatePiece();
                GameManager.scenario.AddPiece(lastPiece);
            }
            yield return new WaitForSeconds(waitUntilNewPiece);
        }
    }


    private GameObject CreatePiece()
    {
        switch (Random.Range(0, differentTypeOfPieces))
        {
            case 0:
                return CreateLongPiece();
            case 1:
                return CreateQuad();
            case 2:
                return CreateTPiece();
            case 3:
                return CreateLPiece();
            case 4:
                return CreateLInvertPiece();
            case 5:
                return CreateRPiece();
            case 6:
                return CreateInvertRPiece();
            default:
                return null;
        }
    }

    private GameObject CreateLongPiece()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(0, 1.5f, 0);
        cube1.SendMessage("SetCubeNumber", 0, SendMessageOptions.RequireReceiver);
        cube1.GetComponent<Renderer>().material.mainTexture = longTexture;
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(0, 0.5f, 0);
        cube2.SendMessage("SetCubeNumber", 1, SendMessageOptions.RequireReceiver);
        cube2.GetComponent<Renderer>().material.mainTexture = longTexture;
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(0, -0.5f, 0);
        cube3.SendMessage("SetCubeNumber", 2, SendMessageOptions.RequireReceiver);
        cube3.GetComponent<Renderer>().material.mainTexture = longTexture;
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(0, -1.5f, 0);
        cube4.SendMessage("SetCubeNumber", 3, SendMessageOptions.RequireReceiver);
        cube4.GetComponent<Renderer>().material.mainTexture = longTexture;
        newPiece.SendMessage("SetPieceType", "Line");
        return newPiece;
    }

    private GameObject CreateQuad()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(0, 0.5f, 0);
        cube1.GetComponent<Renderer>().material.mainTexture = quadTexture;
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(0, -0.5f, 0);
        cube2.GetComponent<Renderer>().material.mainTexture = quadTexture;
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(1f, 0.5f, 0);
        cube3.GetComponent<Renderer>().material.mainTexture = quadTexture;
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(1f, -0.5f, 0);
        cube4.GetComponent<Renderer>().material.mainTexture = quadTexture;
        newPiece.SendMessage("SetPieceType", "Square");
        return newPiece;
    }

    private GameObject CreateTPiece()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(0, 0.5f, 0);
        cube1.GetComponent<Renderer>().material.mainTexture = tPieceTexture;
        cube1.SendMessage("SetCubeNumber", 0, SendMessageOptions.RequireReceiver);
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(-1f, -0.5f, 0);
        cube2.GetComponent<Renderer>().material.mainTexture = tPieceTexture;
        cube2.SendMessage("SetCubeNumber", 1, SendMessageOptions.RequireReceiver);
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(0, -0.5f, 0);
        cube3.GetComponent<Renderer>().material.mainTexture = tPieceTexture;
        cube3.SendMessage("SetCubeNumber", 2, SendMessageOptions.RequireReceiver);
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(1f, -0.5f, 0);
        cube4.GetComponent<Renderer>().material.mainTexture = tPieceTexture;
        cube4.SendMessage("SetCubeNumber", 3, SendMessageOptions.RequireReceiver);
        newPiece.SendMessage("SetPieceType", "T");
        return newPiece;
    }

    private GameObject CreateLPiece()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(0, 1.5f, 0);
        cube1.GetComponent<Renderer>().material.mainTexture = lPieceTexture;
        cube1.SendMessage("SetCubeNumber", 0, SendMessageOptions.RequireReceiver);
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(0f, 0.5f, 0);
        cube2.GetComponent<Renderer>().material.mainTexture = lPieceTexture;
        cube2.SendMessage("SetCubeNumber", 1, SendMessageOptions.RequireReceiver);
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(0, -0.5f, 0);
        cube3.GetComponent<Renderer>().material.mainTexture = lPieceTexture;
        cube3.SendMessage("SetCubeNumber", 2, SendMessageOptions.RequireReceiver);
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(1f, -0.5f, 0);
        cube4.GetComponent<Renderer>().material.mainTexture = lPieceTexture;
        cube4.SendMessage("SetCubeNumber", 3, SendMessageOptions.RequireReceiver);
        newPiece.SendMessage("SetPieceType", "L");
        return newPiece;
    }
    private GameObject CreateLInvertPiece()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(1f, 1.5f, 0);
        cube1.GetComponent<Renderer>().material.mainTexture = lInvertTexture;
        cube1.SendMessage("SetCubeNumber", 0, SendMessageOptions.RequireReceiver);
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(1f, 0.5f, 0);
        cube2.GetComponent<Renderer>().material.mainTexture = lInvertTexture;
        cube2.SendMessage("SetCubeNumber", 1, SendMessageOptions.RequireReceiver);
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(1f, -0.5f, 0);
        cube3.GetComponent<Renderer>().material.mainTexture = lInvertTexture;
        cube3.SendMessage("SetCubeNumber", 2, SendMessageOptions.RequireReceiver);
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(0f, -0.5f, 0);
        cube4.GetComponent<Renderer>().material.mainTexture = lInvertTexture;
        cube4.SendMessage("SetCubeNumber", 3, SendMessageOptions.RequireReceiver);
        newPiece.SendMessage("SetPieceType", "InvertL");
        return newPiece;
    }

    private GameObject CreateRPiece()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(-1f, 0.5f, 0);
        cube1.GetComponent<Renderer>().material.mainTexture = rPieceTexture;
        cube1.SendMessage("SetCubeNumber", 0, SendMessageOptions.RequireReceiver);
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(0, 0.5f, 0);
        cube2.GetComponent<Renderer>().material.mainTexture = rPieceTexture;
        cube2.SendMessage("SetCubeNumber", 1, SendMessageOptions.RequireReceiver);
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(0, -0.5f, 0);
        cube3.GetComponent<Renderer>().material.mainTexture = rPieceTexture;
        cube3.SendMessage("SetCubeNumber", 2, SendMessageOptions.RequireReceiver);
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(1f, -0.5f, 0);
        cube4.GetComponent<Renderer>().material.mainTexture = rPieceTexture;
        cube4.SendMessage("SetCubeNumber", 3, SendMessageOptions.RequireReceiver);
        newPiece.SendMessage("SetPieceType", "R");
        return newPiece;
    }

    private GameObject CreateInvertRPiece()
    {
        GameObject newPiece = (GameObject)Instantiate(piece, transform.position, transform.rotation);
        GameObject cube1 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube1.transform.SetParent(newPiece.transform);
        cube1.transform.localPosition = new Vector3(-1f, -0.5f, 0);
        cube1.GetComponent<Renderer>().material.mainTexture = rInvertPieceTexture;
        cube1.SendMessage("SetCubeNumber", 0, SendMessageOptions.RequireReceiver);
        GameObject cube2 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube2.transform.SetParent(newPiece.transform);
        cube2.transform.localPosition = new Vector3(0, -0.5f, 0);
        cube2.GetComponent<Renderer>().material.mainTexture = rInvertPieceTexture;
        cube2.SendMessage("SetCubeNumber", 1, SendMessageOptions.RequireReceiver);
        GameObject cube3 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube3.transform.SetParent(newPiece.transform);
        cube3.transform.localPosition = new Vector3(0, 0.5f, 0);
        cube3.GetComponent<Renderer>().material.mainTexture = rInvertPieceTexture;
        cube3.SendMessage("SetCubeNumber", 2, SendMessageOptions.RequireReceiver);
        GameObject cube4 = (GameObject)Instantiate(cube, transform.position, transform.rotation);
        cube4.transform.SetParent(newPiece.transform);
        cube4.transform.localPosition = new Vector3(1f, 0.5f, 0);
        cube4.GetComponent<Renderer>().material.mainTexture = rInvertPieceTexture;
        cube4.SendMessage("SetCubeNumber", 3, SendMessageOptions.RequireReceiver);
        newPiece.SendMessage("SetPieceType", "InvertR");
        return newPiece;
    }
}
