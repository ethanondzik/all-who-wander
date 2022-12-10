using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : WeaponSystem {

	public void SetRight() {
	
		BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
		WeaponSpecs specs = gameObject.GetComponent<WeaponSpecs>();

		collider.size = specs.hSize;
		collider.offset = specs.rPosition;

	}

	public void SetLeft() {

		BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
		WeaponSpecs specs = gameObject.GetComponent<WeaponSpecs>();

		collider.size = specs.hSize;
		collider.offset = specs.lPosition;

	}

	public void SetDown() {

		BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
		WeaponSpecs specs = gameObject.GetComponent<WeaponSpecs>();

		collider.size = specs.vSize;
		collider.offset = specs.bPosition;
	
	}

	public void SetUp() {
	
		BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
		WeaponSpecs specs = gameObject.GetComponent<WeaponSpecs>();

		collider.size = specs.vSize;
		collider.offset = specs.tPosition;

	}

	public void Attack() {
		
		GameObject owner = gameObject.transform.parent.gameObject;
		Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
	
        var result = new List<RaycastHit2D>();
        var filter = new ContactFilter2D();
        float offset = 0.0f;

		int collisions = body.Cast(Vector3.zero, filter, result, offset);

		foreach (RaycastHit2D collision in result) {
			
			GameObject target = collision.collider.gameObject;

			if (owner.tag == "Player" && target.tag == "Enemy") {
				base.PlayerAttackEnemy(owner, target);
			}

			if (owner.tag == "Enemy" && target.tag == "Player") {
				// DealDamage(owner, target);
			}

		}

	}

}
