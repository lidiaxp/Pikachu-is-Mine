using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Run1Botoes : MonoBehaviour {
    public Animator anime;

    public Button pause;
    public Button song;
    public Button music;
    public Canvas canvasPause;
    public Sprite pausesim;
    public Sprite pausenao;
    public Sprite songsim;
    public Sprite songnao;
    public Sprite musicsim;
    public Sprite musicnao;
    public AudioSource AS;
    public GameObject bunny;

    public LayerMask oqechao;
    public Transform groundCheck;
        
    public Rigidbody2D buneary2D;

    public AudioSource begin;
    public AudioClip pulo;
    
    private bool ground;

    void Start () {
        canvasPause.enabled = false;
        pause.image.overrideSprite = pausesim;
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
        ground = Physics2D.OverlapCircle(groundCheck.position, 1.5f, oqechao);
        anime.SetBool("jump", !ground);
    }

    public void Pause() {
        if (canvasPause.enabled) {
            pause.image.overrideSprite = pausesim;
            canvasPause.enabled = false;
            Time.timeScale = 1;
        }
        else {
            pause.image.overrideSprite = pausenao;
            canvasPause.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void Jump() {
        if (ground) {
            float dif;
            if (PlayerPrefs.GetInt("dificuldade") == 3){
                dif = 350;
            }
            else{
                dif = 400;
            }
            buneary2D.AddForce(new Vector2(0, dif));
            if (PlayerPrefs.GetInt("som") == 1) {
                begin.clip = pulo;
                begin.Play();
            }
        }
    }

    public void Som() {
        if (PlayerPrefs.GetInt("som") == 0) {
            PlayerPrefs.SetInt("som", 1);
            song.image.overrideSprite = songsim;
        } else {
            PlayerPrefs.SetInt("som", 0);
            song.image.overrideSprite = songnao;
        }
    }

    public void Music() {
        if (PlayerPrefs.GetInt("musica") == 0) {
            PlayerPrefs.SetInt("musica", 1);
            music.image.overrideSprite = musicsim;
            AS.volume = 1;
        } else {
            PlayerPrefs.SetInt("musica", 0);
            music.image.overrideSprite = musicnao;
            AS.volume = 0;
        }
    }

    public void Restart() {
        SceneManager.LoadScene("Run1");
    }

    public void Resume() {
        canvasPause.enabled = false;
        pause.image.overrideSprite = pausesim;
        Time.timeScale = 1;
    }

    public void Exit() {
        SceneManager.LoadScene("Menu");
    }
}
