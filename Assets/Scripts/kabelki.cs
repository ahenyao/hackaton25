using UnityEngine;
using UnityEngine.UI;

public class kabelki : MonoBehaviour
{
    public string wireColor;

    private Button button;
    private kabelki_manager game;

    void Start()
    {
        button = GetComponent<Button>();
        game = FindObjectOfType<kabelki_manager>();
        button.onClick.AddListener(() => game.ClickWire(this));
    }
	
	/*void Update()
{
    if (zad1.activeInHierarchy)
        Time.timeScale = 0f;
    else
        Time.timeScale = 1f;
}*/



}
