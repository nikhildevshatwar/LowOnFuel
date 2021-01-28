using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text text_fuel, text_distance, text_weight, text_payloads;
    private Button btn_shield, btn_weapons, btn_payloads;
    private GameObject go_shields;
    private List<GameObject> go_payloads = new List<GameObject>();


    private int bonus = 0;
    private float maxHeight = 0;

    void Start()
    {
        text_fuel = GameObject.Find("Fuel").GetComponent<UnityEngine.UI.Text>();
        text_distance = GameObject.Find("Distance").GetComponent<UnityEngine.UI.Text>();
        text_weight = GameObject.Find("Weight").GetComponent<UnityEngine.UI.Text>();
        text_payloads = GameObject.Find("PayloadText").GetComponent<UnityEngine.UI.Text>();

        btn_shield = GameObject.Find("DropShieldingButton").GetComponent<UnityEngine.UI.Button>();
        btn_weapons = GameObject.Find("DropWeaponsButton").GetComponent<UnityEngine.UI.Button>();
        btn_payloads = GameObject.Find("DropPayloadsButton").GetComponent<UnityEngine.UI.Button>();

        go_shields = GameObject.Find("Shields");
        foreach(GameObject payload in GameObject.FindGameObjectsWithTag("Payload")) {
            go_payloads.Add(payload);
        }
        text_payloads.text = "Payloads: (" + go_payloads.Count + ")";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.height > maxHeight) {
            maxHeight = PlayerControl.height;
        }
        int score = Mathf.FloorToInt(maxHeight * 10) + bonus;

        text_fuel.text = "Fuel: " + PlayerControl.fuelLevel.ToString();
        text_distance.text = "Distance: " + score.ToString();
        text_weight.text = "Weight: " + PlayerControl.weight.ToString();
    }

    void Throw_object(GameObject obj) {
        obj.transform.parent = null;
        obj.AddComponent<Rigidbody2D>();
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.drag = 30.0f;

        Object.Destroy(obj, 5.0f);
    }

    public void Drop_Shields() {
        btn_shield.interactable = false;

        Throw_object(go_shields);
        go_shields = null;
    }

    public void Drop_Payloads() {

        if (go_payloads.Count == 0)
            return;

        GameObject payload = go_payloads[0];
        go_payloads.RemoveAt(0);

        payload.transform.localScale = new Vector3(3, 3, 1);
        Throw_object(payload);

        text_payloads.text = "Payloads: (" + go_payloads.Count + ")";
        if (go_payloads.Count == 0) {
            btn_payloads.interactable = false;
        }

    }
}
