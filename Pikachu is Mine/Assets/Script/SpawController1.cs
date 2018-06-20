using UnityEngine;

public class SpawController1 : MonoBehaviour
{
    public GameObject flecha;
    public GameObject ketchup;
    public GameObject espinho;

    public float rateSpawn;
    public float currentTime;
    private int chup;
    private int obstaculo;
    private float y;
    private float z;
    public int chances;
    private bool foi;

    void Start() {
        chances = 100 - ((PlayerPrefs.GetInt("dificuldade") - 1) * 30);
        currentTime = 0;
    }

    void Update() {
        currentTime += Time.deltaTime;
        if (currentTime >= rateSpawn) {
            currentTime = 0;
            chup = Random.Range(1, 100);
            obstaculo = Random.Range(1, 100);

            float dif;
            if (PlayerPrefs.GetInt("dificuldade") == 1) {
                dif = 1;
            } else {
                dif = 0.5f;
            }
            rateSpawn = 1 + dif;

            if (obstaculo < 50) {
                //---------------espinho-----------------------
                GameObject tempPrefab = Instantiate(espinho) as GameObject;
                tempPrefab.transform.position = new Vector3(21, -1.0f, tempPrefab.transform.position.z);
                if (chup < chances) {
                    GameObject tempPrefab1 = Instantiate(ketchup) as GameObject;
                    tempPrefab1.transform.position = new Vector3(21, 2.8f, tempPrefab.transform.position.z);
                }
                foi = true;
            } else {
                //----------------flecha------------------------
                if (!foi) {
                    GameObject tempPrefab = Instantiate(flecha) as GameObject;
                    tempPrefab.transform.position = new Vector3(21, 2.5f, tempPrefab.transform.position.z);
                }
                GameObject tempPrefab2 = Instantiate(flecha) as GameObject;
                tempPrefab2.transform.position = new Vector3(35, 2.5f, tempPrefab2.transform.position.z);
                if (chup < chances) {
                    GameObject tempPrefab1 = Instantiate(ketchup) as GameObject;
                    tempPrefab1.transform.position = new Vector3(21, -0.8f, 11);
                }
                foi = false;
            }
        }
    }
}