using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Suara_V : MonoBehaviour
{


    Suara_MV controller  = new Suara_MV();

    Suara Model ;

    AudioSource audiosource ;

    /// <summary>
    /// Mengatur Mode Untuk Debug
    /// </summary>
    public enum Mode
    {
        Mekatronika,
        Default

    }

    public Mode kondisi;





     List<GameObject> Drum;
    void Start()
    {
        Drum = new List<GameObject>();

        Transform parent = GameObject.Find("Canvas").transform.GetChild(0); 

        Transform[] children = parent.GetComponentsInChildren<Transform>();


        for (int i = 0; i < children.Length; i++)
        {
            Drum.Add(children[i].gameObject);
        }



        audiosource = GetComponent<AudioSource>();


        // Mengambil data dari folder Resources/Suara
        AudioClip[] data =  controller.GetSoundEffect();
        Model  = new Suara(data);
        Debug.Log(Drum.Count);
        controller = new Suara_MV(Model);


    }




    void Update()
    {
        if (kondisi == Mode.Default)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.PlaySoundEffect("kick",audiosource);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                controller.PlaySoundEffect("tom1", audiosource);

            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                controller.PlaySoundEffect("ride", audiosource);

            }
        }
        else
        {

        }
    }
}
