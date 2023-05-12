using UnityEngine;

public class UI : MonoBehaviour
{
    public BoolVariable GameStarted;
    private void Start()
    {
        GameStarted.Value = false;
    }

    void Update()
    {
        if (!GameStarted.Value && Input.GetKeyDown("space"))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        GameStarted.Value = true;
        this.gameObject.SetActive(false);
    }
}