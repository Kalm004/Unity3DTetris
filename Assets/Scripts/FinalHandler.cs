using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FinalHandler : MonoBehaviour {
    public Text linesText;

	// Use this for initialization
	void Start () {
        linesText.text = "Lines = " + GameManager.Lines;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGotoMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
