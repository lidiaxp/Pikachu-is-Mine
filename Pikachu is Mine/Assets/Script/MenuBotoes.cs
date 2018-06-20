using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBotoes : MonoBehaviour {
    public Button song;
    public Button music;
    public Sprite songsim;
    public Sprite songnao;
    public Sprite musicsim;
    public Sprite musicnao;
    public AudioSource AS;
    public Text testo;

    void Start () {
        PlayerPrefs.SetInt("dificuldade", 1);
        PlayerPrefs.SetInt("pontos", 0);
        PlayerPrefs.SetInt("vida", 150);
        PlayerPrefs.SetInt("ketchup", 100);
        PlayerPrefs.SetInt("ketchups", 0);
        if (PlayerPrefs.GetInt("musica") == 0) {
            AS.volume = 0;
            music.image.overrideSprite = musicnao;
        } else {
            AS.volume = 1;
            music.image.overrideSprite = musicsim;
        }

        if (PlayerPrefs.GetInt("som") == 0) {
            song.image.overrideSprite = songnao;
        } else {
            song.image.overrideSprite = songsim;
        }
	}
	
	void Update () {
        testo.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    public void play() {
        SceneManager.LoadScene("Run1");
    }

    public void som() {
        if (PlayerPrefs.GetInt("som") == 0) {
            PlayerPrefs.SetInt("som", 1);
            song.image.overrideSprite = songsim;
        }
        else {
            PlayerPrefs.SetInt("som", 0);
            song.image.overrideSprite = songnao;
        }
    }

    public void musica() {
        if (PlayerPrefs.GetInt("musica") == 0) {
            PlayerPrefs.SetInt("musica", 1);
            music.image.overrideSprite = musicsim;
            AS.volume = 1;
        }
        else {
            PlayerPrefs.SetInt("musica", 0);
            music.image.overrideSprite = musicnao;
            AS.volume = 0;
        }
    }
}
