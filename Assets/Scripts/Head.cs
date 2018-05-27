using UnityEngine;

public class Head : MonoBehaviour {

    private GameCode gameComp;

    void Awake()
    {
        gameComp = FindObjectOfType<GameCode>();  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pared"))
        {
            Debug.Log("GAME OVER!");
            Debug.Break();
            Application.Quit();
        }

        if (other.CompareTag("fruta")) {
            Debug.Log("ÑAM!");
            Destroy(other.gameObject);
            gameComp.CreateFruta();
            gameComp.AddSnakePiece();

        }
    }

}
