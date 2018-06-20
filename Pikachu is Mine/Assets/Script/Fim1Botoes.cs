using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fim1Botoes : MonoBehaviour {
    public Text score;
    public Text bestscore;

	void Start () {
        score.text = PlayerPrefs.GetInt("pontos").ToString();
        bestscore.text = PlayerPrefs.GetInt("recorde").ToString();
    }
	
	void Update () {
        
	}

    public void menu() {
        SceneManager.LoadScene("Menu");
    }
}
