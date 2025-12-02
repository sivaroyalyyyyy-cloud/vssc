using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text infoText;

    void Awake()
    {
        if (infoText != null) infoText.text = "";
    }

    public void ShowMessage(string message, float duration = 2f)
    {
        if (infoText == null) return;
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(message, duration));
    }

    System.Collections.IEnumerator ShowRoutine(string message, float duration)
    {
        infoText.text = message;
        yield return new WaitForSeconds(duration);
        infoText.text = "";
    }
}
