using UnityEngine.UI;
using UnityEngine;

public class PlayCollectibles : MonoBehaviour
{
    public Text textComponent;
    public int gemNumber = 0;
    void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }
    public void GemCollected()
    {
        gemNumber++;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
