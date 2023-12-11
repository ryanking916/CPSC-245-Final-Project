using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeDuration = .5f * 60f;

    private float timer;

    private bool activated = false;

    public GameObject eventManager;

    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && activated == true)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else if (timer < 1/* && activated == true*/)
        {
            //activated = false;
            eventManager.GetComponent<StageController>().Stage3();
            Debug.Log("In Stage " + eventManager.GetComponent<StageController>().stage);
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        activated = false;
        timer = timeDuration;
    }

    public void Begin()
    {
        activated = true;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }
}

//Credit: https://www.youtube.com/watch?v=27uKJvOpdYw