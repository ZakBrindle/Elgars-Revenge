using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarScript : MonoBehaviour
{

    public Slider slider;
    public GameObject visualObject;
    bool timed = false;
    float hideHealthBarTimerMax = 10f;
    float timer;
    bool healthBarOn = false;


public void SetHealth(int health)
{
    slider.value = health;
}

public void ShowHealthBarTimed()
{
    if(!healthBarOn)
    {
        print("show enemy healthbar");
        visualObject.SetActive(true);
        timed = true;
        healthBarOn = true;
    }
    else
    {
        timer = hideHealthBarTimerMax;
    }
    
}

public void SetMaxHealth(int health)
{
    slider.maxValue = health;
    slider.value = health;

}

public bool isHealthBarOn()
{    
    return healthBarOn;    
}

    // Start is called before the first frame update
    void Start()
    {
        timer = hideHealthBarTimerMax;        
    }

    // Update is called once per frame
    void Update()
    {
        if(timed)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timed = false;
                timer = hideHealthBarTimerMax;
                visualObject.SetActive(false);

                healthBarOn = false;
            }
        }
    }
}
