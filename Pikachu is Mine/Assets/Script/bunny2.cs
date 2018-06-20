using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bunny2 : MonoBehaviour {
    private float tempo;
    private float tempo1;

    public Slider vida;

    public SpawnController2 sc;
    public Animator anime;

    public AudioSource begin;
    public AudioClip dor;
    public AudioClip morte;

    void Start () {
        
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "boss") {
            if (anime.GetBool("jump")) {
                PlayerPrefs.SetInt("ketchup", PlayerPrefs.GetInt("ketchup") - 5);
                if (PlayerPrefs.GetInt("ketchup") == 70 || PlayerPrefs.GetInt("ketchup") == 40) {
                    PlayerPrefs.SetInt("dificuldade", PlayerPrefs.GetInt("dificuldade") + 1);
                    SceneManager.LoadScene("Run1");
                }
            }
            else {
                anime.SetBool("dor", true);
                PlayerPrefs.SetInt("vida", PlayerPrefs.GetInt("vida") - 10);
                vida.value = PlayerPrefs.GetInt("vida");
                tempo1 = 1;
                if (PlayerPrefs.GetInt("som") == 1) {
                    begin.clip = dor;
                    begin.Play();
                }
                if (PlayerPrefs.GetInt("vida") <= 0) {
                    die();
                }
            }
        }

        if (other.gameObject.tag == "obstaculo") { 
            tempo1 = 1;
            PlayerPrefs.SetInt("vida", PlayerPrefs.GetInt("vida") - 10);
            anime.SetBool("dor", true);
            if (PlayerPrefs.GetInt("som") == 1)
            {
                begin.clip = dor;
                begin.Play();
            }
            if (PlayerPrefs.GetInt("vida") <= 0)
            {
                die();
            }
        }
    }

    
    void Update () {
        if (tempo >= 1) {
            tempo += Time.deltaTime;
            if (tempo > 2.5f) {
                SceneManager.LoadScene("Fim2");
                Destroy(gameObject);
            }
        }

        if (tempo1 >= 1)
        {
            tempo1 += Time.deltaTime;
            if (tempo1 > 1.5f)
            {
                anime.SetBool("dor", false);
                tempo1 = 0;
            }
        }
    }

    public void die() {
        tempo = 1;
        sc.enabled = false;
        anime.SetBool("dor", false);
        anime.SetBool("jump", false);
        anime.SetBool("andar", false);
        anime.SetBool("morte", true);
        if (PlayerPrefs.GetInt("som") == 1) {
            begin.clip = morte;
            begin.Play();
        }
        if (PlayerPrefs.GetInt("pontos") > PlayerPrefs.GetInt("recorde")) {
            PlayerPrefs.SetInt("recorde", PlayerPrefs.GetInt("pontos"));
        }
    }
}
