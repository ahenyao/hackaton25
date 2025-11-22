using TMPro;
using UnityEngine;

public class ItemCounter : MonoBehaviour
{
    public static ItemCounter instance; // singleton
    public TMP_Text counterText;

    private int count = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem()
    {
        count++;
        counterText.text = "Letter fragments: " + count + " / 3";
    }

    // getter dla BrickPull
    public int GetCount()
    {
        return count;
    }
}

