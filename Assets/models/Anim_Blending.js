#pragma strict

function Start () {
   GetComponent.<Animation>().wrapMode = WrapMode.Loop;

   GetComponent.<Animation>()["Attack"].wrapMode = WrapMode.Once;
   GetComponent.<Animation>()["Defend"].wrapMode = WrapMode.Once;
   GetComponent.<Animation>()["Jump"].wrapMode = WrapMode.Once;

   GetComponent.<Animation>()["Attack"].layer = 1;
   GetComponent.<Animation>()["Defend"].layer = 1;
   GetComponent.<Animation>()["Jump"].layer = 1;

   GetComponent.<Animation>().Stop();
}

function Update (){
   if (Input.GetAxis("Vertical") > 0.1)
      GetComponent.<Animation>().CrossFade("Run");

   else if (Input.GetAxis("Vertical") < -0.1)
      GetComponent.<Animation>().CrossFade("Backstep");

   else if (Input.GetAxis("Horizontal") > 0.1)
      GetComponent.<Animation>().CrossFade("StepRight");

   else if (Input.GetAxis("Horizontal") < -0.1)
      GetComponent.<Animation>().CrossFade("StepLeft");

      else
      GetComponent.<Animation>().CrossFade("Idle");

   if (Input.GetButtonDown ("Fire1"))
      GetComponent.<Animation>().CrossFade("Attack");

   if (Input.GetButtonDown ("Fire2"))
      GetComponent.<Animation>().CrossFade("Defend");

   if (Input.GetButtonDown ("Jump"))
      GetComponent.<Animation>().CrossFade("Jump");
} 