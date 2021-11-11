using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    [Header("Effects")]
    [Tooltip ("Ezik Amine")]
    public Transform AppleEffect;
    [Tooltip("Weled Amine")]
    public Transform CookieEffect;
    [Tooltip("Boþ Amine")]
    public Transform PoisonEffect;
    [Tooltip("Kolsuz Amine haha")]
    public Transform CakeEffect;

    [Header("Texts")]
    public GameObject finishtext;

    [Header("Health")]
    public Animator m_Animator;
    public GameObject health;

    float engel1;
    float engel2;

    [ContextMenu("Amine ezik midir? Cevabi Console'da")]

    void Ezik()
    {
        print("Evet dostum Amine Eziktir..");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sagadon = new Vector3(speed * 2 / 3, 0, 0);
        Vector3 soladon = new Vector3(-speed * 2 / 3, 0, 0);
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey("d"))
        {
            transform.Translate(sagadon * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(soladon * Time.deltaTime);
        }

        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if (lane == 3)
                lane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane == -1)
                lane = 0;
        }

        Vector3 targetpos = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lane == 0)
        {
            targetpos += Vector3.left * lanedistance;
        }
        else if (lane == 2)
        {
            targetpos += Vector3.right * lanedistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetpos, 40 * Time.deltaTime);*/

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "applefood")
        {
            Instantiate(AppleEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            health.gameObject.SetActive(true);
            m_Animator.SetTrigger("saglik");
        }

        if (other.transform.tag == "cookiefood")
        {
            Instantiate(CookieEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "poison")
        {
            Instantiate(PoisonEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }


        if (other.transform.tag == "cakefood")
        {
            Instantiate(CakeEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);

        }
        
        if (other.transform.tag == "donus")
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "soladonus")
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "finish")
        {
            finishtext.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
