using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour {
    [SerializeField]
	private Vector2 direction;
    public GameObject particle;
    CameraShake cameraShake;

	//[SerializeField]
	readonly float maxSpeed = 150;
    [SerializeField]
	private float speed = 75;

	Rigidbody rb;

	#region Get/Set

	public float Speed {
		get {
			return speed;
		}
		set {
			if (speed > maxSpeed) {
				speed = maxSpeed;
			} else {
				speed = value;
				if (speed > maxSpeed) {
					speed = maxSpeed;
				}
			}
		}
	}

	public Vector3 Direction {
		get {
			return direction;
		}
		set {
			if (value.magnitude > 1) {
                value = new Vector2(value.x, value.y);
			}
			direction = value;
		}
	}
    [SerializeField]
    Vector3 velocity;

	#endregion

	void Start(){
        cameraShake = FindObjectOfType<CameraShake>();
		rb = GetComponent<Rigidbody>();
        StaticData.ActiveBalls += 1;
		
	}

    public void SetDirection(Vector3 startDir){
        Direction = startDir;
    }
	void Update(){
		MoveInDir();
        velocity = rb.velocity;
	}

	void MoveInDir() {
		rb.velocity = Direction.normalized * Speed * Time.deltaTime;
		if (transform.position.z != 0.5f) {
			transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
		}
	}

    void OnCollisionEnter(Collision other) {
	int c = 0;
		if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || 
            other.gameObject.layer == 11 || other.gameObject.layer == 12 || 
            other.gameObject.layer == 13) 
            {
            if (other.gameObject.layer != 9 ) {
                gameObject.layer = 8;
            }
            foreach (ContactPoint contact in other.contacts) {
			c++;
				if (c == 1) {
					Debug.DrawRay(contact.point, contact.normal, Color.white);
					Direction = ChangeDir(contact.normal);
				}
			}
			Speed = Speed + (Speed / 10);
            GameObject temp = Instantiate(particle);
            if (cameraShake) {
                cameraShake.EvokeShake(0.11f, .02f);
            }

            temp.transform.position = new Vector3(transform.position.x, transform.position.y, 2);
		}
	}




    Vector3 ChangeDir(Vector3 normal) {
		Vector3 val = Vector3.Reflect(Direction, normal);
		return val;
	}
}	
