using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject fuel;
    public GameObject score;
    public GameObject weight;

    private Text text_fuel;
    private Text text_score;
    private Text text_weight;


    private int bonus = 0;
    private float maxHeight = 0;

    void Start()
    {
        text_fuel = fuel.GetComponent<UnityEngine.UI.Text>();
        text_score = score.GetComponent<UnityEngine.UI.Text>();
        text_weight = weight.GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.height > maxHeight) {
            maxHeight = PlayerControl.height;
        }
        int score = Mathf.FloorToInt(maxHeight * 10) + bonus;

        text_fuel.text = "Fuel: " + PlayerControl.fuelLevel.ToString();
        text_score.text = "Score: " + score.ToString();
        text_weight.text = "Weight: " + PlayerControl.weight.ToString();
    }
}
