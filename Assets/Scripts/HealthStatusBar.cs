using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatusBar : MonoBehaviour
{
    public Player myPlayer;
    public Image bar;
    private Slider mySlider;
    public float myValue;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();  
    }
    // Update is called once per frame
    void Update()
    {
        if(mySlider.value <= mySlider.minValue)
        {
            mySlider.enabled = false;
        }
        myValue = myPlayer.GetCurrentHealth() / myPlayer.GetMaxHealth();
        if (myValue > 0.5f)
        {
            bar.color = Color.green;
        }
        if (myValue < 0.5f)
        {
            bar.color = Color.red;
        }
        mySlider.value = myValue;
    }
}
