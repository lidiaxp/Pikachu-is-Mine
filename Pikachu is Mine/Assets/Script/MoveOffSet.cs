using UnityEngine;

public class MoveOffSet : MonoBehaviour {
    private Material currentMaterial;
    public float speed;
    private float offSet;
    
    void Start () {
        currentMaterial = GetComponent<Renderer>().material;
    }
	
	void Update () {
        offSet += speed * Time.deltaTime;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }
}
