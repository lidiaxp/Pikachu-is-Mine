using UnityEngine;

public class SpawnController2 : MonoBehaviour {
    public GameObject ketchup;

    public float rateSpawn;
    public float currentTime;

    void Start () {
		
	}
	
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime >= rateSpawn) {
            currentTime = 0;

            rateSpawn = (4 - PlayerPrefs.GetInt("dificuldade"));
            
            GameObject tempPrefab = Instantiate(ketchup) as GameObject;
            tempPrefab.transform.position = new Vector3(Random.Range(-8.7f, 8.7f), 8, tempPrefab.transform.position.z);
        }
    }
}
