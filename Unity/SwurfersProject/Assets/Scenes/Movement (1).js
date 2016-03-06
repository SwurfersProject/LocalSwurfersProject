#pragma strict

var forwardRate : float =3;
var turnRate : float = 2;


function Start () {
}

function Update () 
{
	var forwardMoveAmount = Input.GetAxis("Vertical") * forwardRate;

	var turnForce = Input.GetAxis("Horizontal") * turnRate;

	transform.Rotate(0, turnForce, 0);

	transform.position += transform.forward * forwardMoveAmount * Time.deltaTime;

}