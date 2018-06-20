using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fim2Botoes : MonoBehaviour {
    public Text pontos;
    public Text bestpontos;

	void Start () {
        pontos.text = PlayerPrefs.GetInt("pontos").ToString();
        bestpontos.text = PlayerPrefs.GetInt("recorde").ToString();
    }

	void Update () {
		
	}

	public void menu(){
		SceneManager.LoadScene ("Menu");
	}

	public void again(){
        PlayerPrefs.SetInt("dificuldade", 1);
        PlayerPrefs.SetInt("pontos", 0);
        PlayerPrefs.SetInt("vida", 150);
        PlayerPrefs.SetInt("ketchup", 100);
        PlayerPrefs.SetInt("ketchups", 0);
        SceneManager.LoadScene ("Run1");
	}
}
