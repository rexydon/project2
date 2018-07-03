using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : baseUnitController
{
    private AudioSource myAudioSource;
    public Animator myAnimator;

    private float lastAttack = 0;
    public float timeToShoot;
    public GameObject fireball;
    public GameObject firePoint;
    public int health = 1;


    private float speedReduction;
    public float moveSpeed = 5;
    public float radiusOfSatisfaction = 2;
    public float radiusOfApproch = 3;
    public float radiusOfAggro = 10;
    public float radiusOfAttack = 5;
    public float attackDelay = 3;
    public int damage = 1;

    private GameObject gameControllerObject;
    private gameController gameController;
    public Vector3 target = Vector3.zero;
    public Vector3 moveDirection = Vector3.zero;

    public bool isSeekTargetSet = false;
    public bool isDead = false;

    // Use this for initialization
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAnimator = transform.parent.GetComponent<Animator>();
        gameControllerObject = GameObject.Find("gameController");
        gameController = gameControllerObject.GetComponent<gameController>();
        gameController.targets += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSeekTargetSet)
        {
            moveDirection = new Vector3(target.x - transform.parent.position.x, 0, target.z - transform.parent.position.z);
            if (Vector3.Distance(target, transform.parent.position) < radiusOfApproch)
            {
                speedReduction = ((Vector3.Distance(target, transform.parent.position)
                    - radiusOfSatisfaction) / (radiusOfApproch - radiusOfSatisfaction) + .1f);
                transform.parent.position = transform.parent.position + moveDirection.normalized
                    * (moveSpeed * speedReduction) * Time.deltaTime;
            }
            else
            {
                transform.parent.position = transform.parent.position + moveDirection.normalized
                    * moveSpeed * Time.deltaTime;
            }

            if (Vector3.Distance(target, transform.parent.position) < radiusOfSatisfaction)
            {
                isSeekTargetSet = false;
                myAnimator.SetBool("IsMoving", false);
            }
        }
        if (moveDirection != Vector3.zero)
            transform.parent.rotation = Quaternion.LookRotation(moveDirection);
    }

    public void Seek(Vector3 position)
    {
        target = position;
        //target.y = transform.parent.position.y;
        isSeekTargetSet = true;
        myAnimator.SetBool("IsMoving", true);
    }

    public override void TakeDamage(int damage)
    {
        if (!isDead)
        {
            health -= damage;
            if (health <= 0)
            {
                myAudioSource.Play();
                gameController.targets -= 1;
                isDead = true;
                isSeekTargetSet = false;
                myAnimator.SetTrigger("IsDead");
            }
        }
    }

    public IEnumerator Shoot()
    {
        if (Time.fixedTime - lastAttack > attackDelay)
        {
            myAnimator.SetTrigger("Attacked");
            lastAttack = Time.fixedTime;
            yield return new WaitForSecondsRealtime(timeToShoot);
            GameObject attack = Instantiate(fireball, firePoint.transform.position, transform.parent.rotation);
            attack.GetComponent<bulletControl>().damage = damage;
        }
    }
}

