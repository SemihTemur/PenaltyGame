using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Kalecnini z�plamas� saga sola g�tmes� �k� kalec� kontrolu falan var burda
public class GoalKeeperController : MonoBehaviour
{

    public float speed;
    public float horizontal1;
    public float horizontal2;
    private float minRange = -3.20f;
    private float maxRange = 3.20f;

    public float jump=0.01f;

    private Rigidbody rb;

    private bool jumpingStatus = false;

    public bool kaleciController;

    public GameObject arrows;

    private Button solButton;

    void Start()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody>();
        kaleciController = true;
    }


    void Update()
    {
        GoalKeeperMovement();
    }

    // Kaleci'nin hareketi
    private void GoalKeeperMovement()
    {

    #if UNITY_STANDALONE
        arrows.gameObject.SetActive(false);
        horizontal1 = Input.GetAxis("Horizontal2");
        horizontal2 = Input.GetAxis("Horizontal1");
        if (kaleciController)
        {
            if (Input.GetButtonDown("Jump1") && !jumpingStatus)
            {
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(0.05f * jump * Mathf.Abs(Physics.gravity.y)), rb.velocity.z);
                jumpingStatus = true;
            }
            transform.Translate(Vector3.left * speed * horizontal1 * Time.deltaTime);
        }

        else
        {
            if (Input.GetButtonDown("Jump2") && !jumpingStatus)
            {
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(0.05f * jump * Mathf.Abs(Physics.gravity.y)), rb.velocity.z);
                jumpingStatus = true;
            }
            transform.Translate(Vector3.left * speed * horizontal2 * Time.deltaTime);
        }



    #elif UNITY_ANDROID || UNITY_IOS

        arrows.gameObject.SetActive(true);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

                // Dokunulan noktan�n bir UI eleman� olup olmad���n� kontrol et
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                    // Dokunulan nesneyi bul
                GameObject touchedObject = EventSystem.current.currentSelectedGameObject;

                if (touchedObject != null)
                {
                    string objectName = touchedObject.name;
                    Debug.Log("Dokunulan UI eleman�n�n ad�: " + objectName);

                    if (kaleciController)
                    {
                        if (objectName == "sol")
                        {
                            transform.Translate(Vector3.left * speed * -1 * Time.deltaTime);
                        }

                        else if (objectName == "sa�")
                        {
                            transform.Translate(Vector3.left * speed * 1 * Time.deltaTime);
                        }

                        else if (objectName == "yukar�" && !jumpingStatus)
                        {
                            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(0.05f * jump * Mathf.Abs(Physics.gravity.y)), rb.velocity.z);
                            jumpingStatus = true;
                        }

                    }

                    else
                    {
                        if (objectName == "sol1")
                        {
                            transform.Translate(Vector3.left * speed * -1 * Time.deltaTime);
                        }

                        else if (objectName == "sa�1")
                        {
                            transform.Translate(Vector3.left * speed * 1 * Time.deltaTime);
                        }

                        else if (objectName == "yukar�1" && !jumpingStatus)
                        {
                            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(0.05f * jump * Mathf.Abs(Physics.gravity.y)), rb.velocity.z);
                            jumpingStatus = true;
                        }

                    }
                        
                }

            }

        }

    #endif
        GoalKeeperArea();
    }

    // Burda Kalecinin gidice�i mesafeyi belirliyorum belli mesafeye kadar gidebilsin die
    private void GoalKeeperArea()
    {
        Vector3 temporaryPosition = transform.position;
        temporaryPosition.x = Mathf.Clamp(transform.position.x, minRange, maxRange);

        transform.position = temporaryPosition;
        // en sola ve en sa�a gidince karakter kafay� y�yeb�l�yor onu engellemek �c�n yazd�m bunu
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        jumpingStatus = false;
    }


    private void SolOk()
    {
        Debug.Log("se");
    }

}
