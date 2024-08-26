using TMPro;

using UnityEngine;

using UnityEngine.UI;

public class PlayerController: MonoBehaviour

{

public float speed;

Rigidbody playerRigidbody;

public float m_Thrust = 20f;//var for jump Force

public TMP_Text textAfisat;

private string litereColectate;

private string litereColectateCorect;

public Button BtnMeniu;

public Button BtnReload;

litereColectateCorect = "ETTI";

void Start()

{

textAfisat.text = "Ai colectat: ";

litereColectate = "";

textAfisat.text = "Următoarea literă: "

litereColectateCorect = litereColectateCorect + 1;

//setare inactivitate butoane la inceput de joc

BtnMeniu.gameObject.SetActive(false);

BtnReload.gameObject.SetActive(false);

//Fetch the Rigidbody from the GameObject with this script attached

playerRigidbody = GetComponent<Rigidbody>();

}

private void FixedUpdate()

{

float movementHorizontal = Input.GetAxis("Horizontal");

float movementVertical = Input.GetAxis("Vertical");

Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

playerRigidbody.AddForce(movement * speed * Time.deltaTime);

//if you press Space bar in Runtime your sphere GameObject jumps

if (Input.GetButton("Jump"))

{

//Apply a force to this Rigidbody in direction of this GameObjects up axis

playerRigidbody.AddForce(transform.up * m_Thrust);

}

}

private void OnTriggerEnter(Collider other)

{

if (other.gameObject.tag == "LiteraColectabila")

{

//dezactivare litera colectata

other.gameObject.SetActive(false);

//asignam elementelor de text UI textul de inceput (textAfisat) si sirul de litere colectate

litereColectate = litereColectate + other.gameObject.GetComponent<TextMeshPro>().text;

textAfisat.text = "Ai colectat: " + litereColectate;

Debug.Log("Am colectat litera: " + litereColectate);

}

Debug.Log("nr litere= " + litereColectate.Length);

if (litereColectate.Equals("ETTI"))

{

BtnMeniu.gameObject.SetActive(true);

BtnMeniu.GetComponentInChildren<Text>().text = "Go to menu!";

//cod mai jos pentru a opri rularea scenei

//Time.timeScale = 0;

}

else

{

if (litereColectate.Length >= 4)

{

BtnReload.gameObject.SetActive(true);

BtnReload.GetComponentInChildren<Text>().text = "Reload Scene!";

//se opresete rularea scenei

// Time.timeScale = 0;

}

}

}

}