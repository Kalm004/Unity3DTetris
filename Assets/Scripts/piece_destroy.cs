using UnityEngine;
using System.Collections;

public class piece_destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public void OnCubeDestroy()
    {
        if (transform.childCount == 1)
        {
            print("Piece destroyed");
            Destroy(gameObject);
        }
    }
}
