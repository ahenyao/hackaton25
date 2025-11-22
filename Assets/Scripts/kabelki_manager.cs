using UnityEngine;
using UnityEngine.UI;
using System;

public class kabelki_manager : MonoBehaviour
{
    // Singleton instance
    public static kabelki_manager Instance { get; private set; }

    private kabelki first;
    public int liczba = 0;
    public GameObject zad1;
	public GameObject zad2;
	public GameObject zad3;
	public GameObject lampa1;
	public GameObject lampa2;
	public Sprite lampa_off;
	public int liczbaSkrzynek = 0;
	public GameObject reflektor;
	public WireLine wireLine;

    void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ClickWire(kabelki clicked)
    {
        if (first == null)
        {
            first = clicked;
            return;
        }

        if (first.wireColor == clicked.wireColor && first != clicked)
        {
            CorrectMatch(first, clicked);
        }
        else
        {
            WrongMatch();
        }

        first = null;
    }

	void CorrectMatch(kabelki a, kabelki b) {
		wireLine.Draw(a.transform.position, b.transform.position);

		a.GetComponent<Button>().interactable = false;
		b.GetComponent<Button>().interactable = false;

		liczba++;
		HideIfNeeded();
	}

    void WrongMatch()
    {
        Debug.Log("Wrong connection");
    }

    // Public static method accessible from other scripts
    public void HideIfNeeded()
    {
        if (liczba >= 3) {
			liczbaSkrzynek++;
			try {
				lampa1.GetComponent<SpriteRenderer>().sprite = lampa_off;
				lampa2.GetComponent<SpriteRenderer>().sprite = lampa_off;
				Destroy(lampa1.transform.Find("GameObject").gameObject);
				Destroy(lampa2.transform.Find("GameObject").gameObject);
			} catch(Exception ex){}
            zad1.SetActive(false);
			zad2.SetActive(false);
			zad3.SetActive(false);
            Time.timeScale = 1f;
        }
		if(liczbaSkrzynek>=3) {
			Destroy(reflektor);
		}
    }
}
