using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.RestartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("TetrisGame");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
