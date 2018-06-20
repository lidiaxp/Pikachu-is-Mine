using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bunny : MonoBehaviour {
    private float tempo;
    private float tempo1;

    public Animator anime;

    public SpawController1 sc;
    public MoveOffSet mos1;
    public MoveOffSet mos;

    public AudioSource begin;
    public AudioClip dor;
    public AudioClip morte;
    public AudioClip chup;

    public Text pontos;
    public Slider vida;

    void Start() {
        Time.timeScale = 1;
        vida.value = PlayerPrefs.GetInt("vida");
        pontos.text = "Pontos: " + PlayerPrefs.GetInt("pontos").ToString();
        mos1.enabled = true;
        sc.enabled = true;
        mos.enabled = true;
        tempo = 0;
    }

    void Update() {
        if (tempo >= 1) {
            tempo += Time.deltaTime;
            if (tempo > 2.5f) {
                SceneManager.LoadScene("Fim2");
                Destroy(gameObject);
            }
        }

        if (tempo1 >= 1) {
            tempo1 += Time.deltaTime;
            if (tempo1 > 1.8f) {
                anime.SetBool("dor", false);
                tempo1 = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "obstaculo") {
            if (PlayerPrefs.GetInt("vida") <= 1) {
                die();
            } else {
                anime.SetBool("dor", true);
                PlayerPrefs.SetInt("vida", PlayerPrefs.GetInt("vida") - 10);
                tempo1 = 1;
                vida.value = PlayerPrefs.GetInt("vida");
                if (PlayerPrefs.GetInt("som") == 1) {
                    begin.clip = dor;
                    begin.Play();
                }
            }
        }

        if (other.gameObject.tag == "ketchup") {
            PlayerPrefs.SetInt("pontos", PlayerPrefs.GetInt("pontos") + 10);
            PlayerPrefs.SetInt("ketchups", PlayerPrefs.GetInt("ketchups") + 10);
            pontos.text = "Pontos: " + PlayerPrefs.GetInt("pontos").ToString();
            if (PlayerPrefs.GetInt("som") == 1) {
                begin.clip = chup;
                begin.Play();
            }

            if (PlayerPrefs.GetInt("ketchups")%60 == 0) {
                SceneManager.LoadScene("Run2");
            }
        }
    }

    public void die() {
        tempo = 1;
        mos1.enabled = false;
        sc.enabled = false;
        mos.enabled = false;
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