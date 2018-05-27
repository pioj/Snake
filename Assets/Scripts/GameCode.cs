using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCode : MonoBehaviour {

    public Transform head;
    public GameObject prefabPiece;
    public GameObject prefabFruta;

    private int angle = 0;

    private List<Transform> piezas = new List<Transform>();
    private Vector3 lastpiezaPos;

    private float countdown = 1f;
    private float timer = 0f;

	// Use this for initialization
	void Start () {
        timer = 0f;
        lastpiezaPos = head.position;
        CreateFruta();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow)) angle = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow)) angle = 90;
        if (Input.GetKeyDown(KeyCode.DownArrow)) angle = 180;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) angle = 270;

        head.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

        if (timer > countdown)
        {
            timer = 0;
            head.Translate(0f, 0f, 0.2f);
            lastpiezaPos = head.position;
            
        }
        else {
            timer += 0.1f;
        }
    }

    public void CreateFruta() {
        Vector3 newpos = new Vector3(Random.Range(-4f, 4f), 0.25f, Random.Range(-4f, 4f));
        Instantiate(prefabFruta, newpos, Quaternion.identity);

    }

    
    public void AddSnakePiece() {
        GameObject piece = Instantiate(prefabPiece, lastpiezaPos, Quaternion.identity);
        piezas.Add(piece.transform);

    }
    

}
