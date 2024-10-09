using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarScripts : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;

    public void updateBar(int currentValue, int maxValue){
        Debug.Log("HP Player: " + currentValue.ToString() + " / " + maxValue.ToString());
        fillBar.fillAmount = (float)currentValue/(float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
