using UnityEngine;

public class CenarioMovimento : MonoBehaviour {
    private float x;
    public float speed;
    public float morte;

    void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }

        void Update () {
        x = transform.position.x;
        x += speed * Time.deltaTime * (PlayerPrefs.GetInt("dificuldade"));
        transform.position = new Vector2(x, transform.position.y);

        if (x <= morte) {
            Destroy(gameObject);
        }
    }
}
