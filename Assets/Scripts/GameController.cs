using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float missileDamage = 20;
    public GameObject endScreenParent;

    private Transform rocket;
    private Transform goal;

    private Text text_endscreenPayload;
    private Text text_endscreenFuel;
    private Text text_endscreenTotal;
    private Text text_endscreenGameTotal;

    private Text text_fuel, text_distance, text_weight, text_payloads;
    private Button btn_shield, btn_weapons, btn_radar, btn_payloads;
    private GameObject obj_shields, obj_weapons, obj_radar, obj_radarcam;
    private List<GameObject> obj_payloads = new List<GameObject>();

    private static GameController _instance;
    public static GameController Instance {  get { return _instance; } }
    public static int levelNum = 1;
    public static float prevScore = 0;

    private int bonus = 0;
    private float maxHeight = 0;
    private float goalCompleteDist = 20;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        rocket = GameObject.Find("Rocket").transform;
        goal = GameObject.Find("Goal").transform;

        text_fuel = GameObject.Find("Fuel").GetComponent<UnityEngine.UI.Text>();
        text_distance = GameObject.Find("Distance").GetComponent<UnityEngine.UI.Text>();
        text_weight = GameObject.Find("Weight").GetComponent<UnityEngine.UI.Text>();
        text_payloads = GameObject.Find("PayloadText").GetComponent<UnityEngine.UI.Text>();

        btn_shield = GameObject.Find("DropShieldingButton").GetComponent<UnityEngine.UI.Button>();
        btn_weapons = GameObject.Find("DropWeaponsButton").GetComponent<UnityEngine.UI.Button>();
        btn_radar = GameObject.Find("DropRadarButton").GetComponent<UnityEngine.UI.Button>();
        btn_payloads = GameObject.Find("DropPayloadsButton").GetComponent<UnityEngine.UI.Button>();

        obj_radarcam = GameObject.Find("RadarCanvas");
        obj_radar = GameObject.Find("Radar");
        obj_shields = GameObject.Find("Shields");
        obj_weapons = GameObject.Find("MissileLauncher");
        foreach(GameObject payload in GameObject.FindGameObjectsWithTag("Payload")) {
            obj_payloads.Add(payload);
        }
        text_payloads.text = "Payloads: (" + obj_payloads.Count + ")";

        
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

        float dist = Vector3.Distance(rocket.position, goal.position);
        if (dist < goalCompleteDist)
        {
            FinishLevel();
        }

    }

    void Throw_object(GameObject obj) {
        obj.transform.parent = null;
        obj.AddComponent<Rigidbody2D>();
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.drag = 30.0f;

        Object.Destroy(obj, 5.0f);
    }

    public void Drop_Shields() {
        AudioManager.Instance.Play("click");
        btn_shield.interactable = false;

        Throw_object(obj_shields);
        obj_shields = null;
    }

    public void Drop_Weapons() {
        AudioManager.Instance.Play("click");
        btn_weapons.interactable = false;

        Throw_object(obj_weapons);
        obj_weapons = null;
    }

    public void Drop_Radar() {
        AudioManager.Instance.Play("click");
        btn_radar.interactable = false;

        Throw_object(obj_radar);
        obj_radar = null;
        obj_radarcam.SetActive(false);
    }

    public void Drop_Payloads() {

        if (obj_payloads.Count == 0)
            return;

        AudioManager.Instance.Play("click");
        GameObject payload = obj_payloads[0];
        obj_payloads.RemoveAt(0);

        payload.transform.localScale = new Vector3(3, 3, 1);
        Throw_object(payload);

        text_payloads.text = "Payloads: (" + obj_payloads.Count + ")";
        if (obj_payloads.Count == 0) {
            btn_payloads.interactable = false;
        }

    }

    void FinishLevel()
    {
        if (endScreenParent.activeSelf) {
            return;
        }
        endScreenParent.SetActive(true);
        float score = (PlayerControl.fuelLevel + (obj_payloads.Count * 10000f));
        text_endscreenPayload = GameObject.Find("PayloadsDeliveredText").GetComponent<UnityEngine.UI.Text>();
        text_endscreenFuel = GameObject.Find("RemainingFuelBonus").GetComponent<UnityEngine.UI.Text>();
        text_endscreenTotal = GameObject.Find("LevelTotal").GetComponent<UnityEngine.UI.Text>();
        text_endscreenGameTotal = GameObject.Find("GameTotal").GetComponent<UnityEngine.UI.Text>();
        text_endscreenFuel.text = "Fuel Bonus: " + PlayerControl.fuelLevel;
        text_endscreenPayload.text = "Payloads Delivered: " + obj_payloads.Count;
        text_endscreenTotal.text = "Score this level: " + score;
        text_endscreenGameTotal.text = "Total Score: " + (prevScore + score);
        prevScore += score;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}
