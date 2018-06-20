using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    public GameObject boss;
    public Slider vida;
    public float speed;
    public float speed2;
    public Text tex;

    private IEnumerator coroutine;
    private IEnumerator coroutine2;
    private float x;
    private float y;
    
    bool descer;
    bool ket;

    void Start () {
        ket = true;
        descer = false;
        coroutine = Wait(4.5f - PlayerPrefs.GetInt("dificuldade"));
        StartCoroutine(coroutine);
        vida.value = PlayerPrefs.GetInt("ketchup");
        tex.text = "Pontos: " + PlayerPrefs.GetInt("pontos").ToString();
    }

    private IEnumerator Wait(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            descer = true;
        }
    }

    IEnumerator tempo(int wait) {
        while (true) {
            yield return new WaitForSeconds(wait);
            if (PlayerPrefs.GetInt("pontos") > PlayerPrefs.GetInt("recorde"))
            {
                PlayerPrefs.SetInt("recorde", PlayerPrefs.GetInt("pontos"));
            }
            SceneManager.LoadScene("Fim1");
        }
    }

    void Update () {
        if (PlayerPrefs.GetInt("ketchup") <= 4) {
            ket = false;
            y = transform.position.y + (speed2 * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, y);
            coroutine2 = tempo(2);
            StartCoroutine(coroutine2);
        }

        vida.value = PlayerPrefs.GetInt("ketchup");
        tex.text = "Pontos: " + PlayerPrefs.GetInt("pontos").ToString();

        if (ket) {
            if (x < -7.7f || x > 7.2f)
            {
                speed = speed * -1;
            }
            x = transform.position.x + ((speed * 1.2f *PlayerPrefs.GetInt("dificuldade")) * Time.deltaTime);
            transform.position = new Vector2(x, transform.position.y);
            if (descer)
            {
                if (y > 7.7f || y < 3.7f)
                {
                    speed2 *= -1;
                }
                y = transform.position.y + ((speed2 * PlayerPrefs.GetInt("dificuldade")) * Time.deltaTime);
                transform.position = new Vector2(x, y);
                if (y > 7.7f)
                {
                    descer = false;
                }
            }
        }
    }
}
