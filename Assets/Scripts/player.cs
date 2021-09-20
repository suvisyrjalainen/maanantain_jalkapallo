using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController hahmokontrolleri;
    
    private float horisontaalinenPyorinta = 0;

    public float painovoima = 10f;

    // Start is called before the first frame update
    void Start()
    {
        hahmokontrolleri = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //eteen ja sivulle liikkuminen
        float horizontal = Input.GetAxis("Horizontal") * 5;
        float vertical = Input.GetAxis("Vertical") * 5;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        //k‰‰ntyminen
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);
        nopeus = transform.rotation * nopeus;

        nopeus.y -= painovoima;

        //komento, jolla lopulta liikutaan
        hahmokontrolleri.Move(nopeus * Time.deltaTime);

    }
}
