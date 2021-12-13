using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class player : MonoBehaviour
{
    private CharacterController hahmokontrolleri;
    private Animator anim;

    private float horisontaalinenPyorinta = 0;

    public float painovoima = 10f;

    private float speed = 5f;

    PhotonView pView;


    // Start is called before the first frame update
    void Start()
    {
        hahmokontrolleri = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        pView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pView.IsMine)
        {
            //eteen ja sivulle liikkuminen
            float horizontal = Input.GetAxis("Horizontal") * speed;
            float vertical = Input.GetAxis("Vertical") * speed;
            Vector3 nopeus = new Vector3(horizontal, 0, vertical);

            //kääntyminen
            horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
            transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);
            nopeus = transform.rotation * nopeus;

            //painovoima
            nopeus.y -= painovoima;

            //komento, jolla lopulta liikutaan
            hahmokontrolleri.Move(nopeus * Time.deltaTime);

            //säädetään animaatioita

            //eteenpäin
            if (Input.GetAxis("Vertical") > 0)
            {
                anim.SetBool("Run_F", true);
                speed = 7;
            }
            //taaksepäin
            else if (Input.GetAxis("Vertical") < 0)
            {
                anim.SetBool("Run_B", true);
                speed = 3;
            }
            //sivulle
            else if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("Run_B", true);
                speed = 4;
            }
            else
            {
                anim.SetBool("Run_F", false);
                anim.SetBool("Run_B", false);
            }

        }
    }
}
