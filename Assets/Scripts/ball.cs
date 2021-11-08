using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public GUISkin Pisteet1;
    private static int Joukkue1_pisteet = 0;
    string pisteet_1 = "Joukkue 1 Pisteet: " + Joukkue1_pisteet;

    public GUISkin Pisteet2;
    private static int Joukkue2_pisteet = 0;
    string pisteet_2 = "Joukkue 2 Pisteet: " + Joukkue2_pisteet;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUIStyle localStyle = new GUIStyle(GUI.skin.label);
        localStyle.normal.textColor = Color.black;
        localStyle.fontSize = Screen.width / 40;

        GUI.skin = Pisteet1;
        GUI.Label(new Rect(Screen.width / 4, 20, Screen.width / 4, 100), pisteet_1, localStyle);

        GUI.skin = Pisteet2;
        GUI.Label(new Rect(Screen.width / 2, 20, Screen.width / 4, 100), pisteet_2, localStyle);
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 aloituspaikka = new Vector3(0, 0, 0);

        if (other.gameObject.tag == "maali 1")
        {
            print("Ykköset saivat maalin");
            Joukkue1_pisteet += 1;
            pisteet_1 = "Joukkue 1 Pisteet: " + Joukkue1_pisteet;
        }

        if (other.gameObject.tag == "maali 2")
        {
            print("Kakkoset saivat maalin");
            Joukkue2_pisteet += 1;
            pisteet_2 = "Joukkue 2 Pisteet: " + Joukkue2_pisteet;
        }

        transform.position = aloituspaikka;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    }


