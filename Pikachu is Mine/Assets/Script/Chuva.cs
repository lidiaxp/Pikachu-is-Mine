using UnityEngine;

public class Chuva : MonoBehaviour {
    private float y;
    public float speed;

    void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { 
            Destroy(gameObject);
        }
    }

    void Update () {
        y = transform.position.y;
        y += speed * Time.deltaTime * (PlayerPrefs.GetInt("dificuldade"));
        transform.position = new Vector2(transform.position.x, y);

        if (y <= -6) {
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("pontos") >= 0) {
                PlayerPrefs.SetInt("pontos", PlayerPrefs.GetInt("pontos") - 1);
            }
        }
    }
}
