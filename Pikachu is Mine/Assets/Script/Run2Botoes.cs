using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Run2Botoes : MonoBehaviour {
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
    public Slider vida;

    public LayerMask oqechao;
    public Transform groundCheck;

    public Rigidbody2D buneary2D;

    public AudioSource begin;
    public AudioClip attack;
    public AudioClip morte;

    private float x;

    private float tempo;
    private bool ground;
    private int lado;
    
    void Start () {
        tempo = 0;
        vida.value = PlayerPrefs.GetInt("vida");
        canvasPause.enabled = false;
        pause.image.overrideSprite = pausesim;
        if (PlayerPrefs.GetInt("musica") == 0)
        {
            AS.volume = 0;
            music.image.overrideSprite = musicnao;
        }
        else
        {
            AS.volume = 1;
            music.image.overrideSprite = musicsim;
        }

        if (PlayerPrefs.GetInt("som") == 0)
        {
            song.image.overrideSprite = songnao;
        }
        else
        {
            song.image.overrideSprite = songsim;
        }
    }
	
	void Update () {
        if (bunny.transform.position.x < -15 || bunny.transform.position.x > 15 || bunny.transform.position.y < -7) {
            if (PlayerPrefs.GetInt("pontos") > PlayerPrefs.GetInt("recorde"))
            {
                PlayerPrefs.SetInt("recorde", PlayerPrefs.GetInt("pontos"));
            }
            begin.clip = morte;
            begin.Play();
            SceneManager.LoadScene("Fim2");
        }

        vida.value = PlayerPrefs.GetInt("vida");
        ground = Physics2D.OverlapCircle(groundCheck.position, 1.5f, oqechao);
        anime.SetBool("jump", !ground);

        if (anime.GetBool("andar")) {
            if (bunny.transform.position.x >= -8.7f || bunny.transform.position.x <= 8.7f) {
                bunny.transform.localScale = new Vector3(8 * lado, bunny.transform.localScale.y, bunny.transform.localScale.z);
                x = bunny.transform.position.x + (5 * lado * Time.deltaTime);
                bunny.transform.position = new Vector2(x, bunny.transform.position.y);
            }
        }
    }

    public void Pause()
    {
        if (canvasPause.enabled)
        {
            pause.image.overrideSprite = pausesim;
            canvasPause.enabled = false;
            Time.timeScale = 1;
        }
        else
        {
            pause.image.overrideSprite = pausenao;
            canvasPause.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void Som()
    {
        if (PlayerPrefs.GetInt("som") == 0)
        {
            PlayerPrefs.SetInt("som", 1);
            song.image.overrideSprite = songsim;
        }
        else
        {
            PlayerPrefs.SetInt("som", 0);
            song.image.overrideSprite = songnao;
        }
    }

    public void Music()
    {
        if (PlayerPrefs.GetInt("musica") == 0)
        {
            PlayerPrefs.SetInt("musica", 1);
            music.image.overrideSprite = musicsim;
            AS.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("musica", 0);
            music.image.overrideSprite = musicnao;
            AS.volume = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Run2");
    }

    public void Resume()
    {
        canvasPause.enabled = false;
        pause.image.overrideSprite = pausesim;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void esquerda() {
        if (bunny.transform.position.x >= -8.7f) {
            anime.SetBool("andar", true);
            lado = -1;
        }
    }

    public void esquerdaUp() {
        anime.SetBool("andar", false);
    }

    public void direita() {
        if (bunny.transform.position.x <= 8.7f) {
            anime.SetBool("andar", true);
            lado = 1;
        }
    }

    public void direitaUp() {
        anime.SetBool("andar", false);
    }

    public void puloatack() {
        if (ground) {
            buneary2D.AddForce(new Vector2(0, 350));
            if (PlayerPrefs.GetInt("som") == 1) {
                begin.clip = attack;
                begin.Play();
            }
        }
    }
}
