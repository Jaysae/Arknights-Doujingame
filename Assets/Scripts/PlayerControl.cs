using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	private Animator attackAnimator, buildAnimator;
	private Transform attackModel,buildModel;
	private MeshRenderer attackMesh, buildMesh;
	private Vector3 velocity = Vector3.zero;
	[SerializeField, Tooltip("移动速度"), Range(10, 50)] 
	private float runSpeed = 25f;
	[SerializeField, Tooltip("运动阻力"), Range(0, .3f)]
	private float movementSmoothing = 0.05f;
	[HideInInspector] public bool mFacingRight = true;
	private bool attack;

	private Rigidbody2D body2D;

	private static readonly int Move = Animator.StringToHash("Move");
	private static readonly int Attack = Animator.StringToHash("Attack");

	private void Awake()
	{
		attackModel = transform;
		attackAnimator = attackModel.GetComponent<Animator>();
		attackMesh = attackModel.GetComponent<MeshRenderer>();
		
		buildModel = attackModel.Find("build");
		buildAnimator = buildModel.GetComponent<Animator>();
		buildMesh = buildModel.GetComponent<MeshRenderer>();
		body2D = GetComponent<Rigidbody2D>();
	}

	private void ActorMove(float horizontal, float vertical)
	{
		horizontal *= Time.fixedDeltaTime * runSpeed;
		vertical *= Time.fixedDeltaTime * runSpeed;
		var moving = Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0;
		attackAnimator.SetBool(Attack,attack);
		buildAnimator.SetBool(Move,moving);
		attackMesh.enabled = !moving;
		buildMesh.enabled = moving;
		var playerPosition = body2D.velocity;
		var targetVelocity = new Vector3(horizontal * 10f, vertical * 10f);
		body2D.velocity = Vector3.SmoothDamp(playerPosition, targetVelocity, ref velocity, movementSmoothing);
		
		if (horizontal > 0 && !mFacingRight || horizontal < 0 && mFacingRight) Flip();
	}
	
	private void Flip()
	{
		mFacingRight = !mFacingRight;
		var theScale = transform.localScale;
		theScale.x *= -1;
		// ReSharper disable once Unity.InefficientPropertyAccess
		transform.localScale = theScale;
	}
}