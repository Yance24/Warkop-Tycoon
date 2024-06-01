using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectsMovement : MonoBehaviour
{
    
    public float speed;
    protected SpriteRenderer sprite;
    protected Vector2 target;
    protected Vector2 moveDirection;
    protected bool isMoving = false;
    protected bool isReached = false;
    protected bool isEndDirection = false;
    protected bool endDirection = false;
    protected Animator animator;

    public bool IsMoving{
        get{return isMoving;}
        set{
            isMoving = value;
            animator.SetBool("isWalking",value);
        }
    }

    public bool IsReached{
        get{return isReached;}
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate(){
        if(isMoving){
            transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
            checkReachedTarget();
        }
    }

    protected void checkReachedTarget(){
        if((moveDirection.x > 0 && transform.position.x >= target.x) || (moveDirection.x < 0 && transform.position.x <= target.x)){
            IsMoving = false;
            isReached = true;
            transform.position = new Vector2(target.x,transform.position.y);
            if(isEndDirection) setFlipX(endDirection);
        }
    }

    public void setTarget(Vector2 target){
        isEndDirection = false;
        // if(this.target == target) {
        //     isReached = true;
        //     return;
        // }
        this.target = target;
        isReached = false;
        getDirection();
        StartCoroutine(flipSprite());
        if(moveDirection.x != 0) IsMoving = true;
    }

    public void setTarget(Transform obj){
        FacilityData facilityData = obj.GetComponent<FacilityData>();
        if(facilityData) {
            isEndDirection = true;
            endDirection = facilityData.isFacingLeft;
        }
        else isEndDirection = false;
        Vector2 target = obj.position;
        // if(this.target == target) {
        //     isReached = true;
        //     return;
        // }
        this.target = target;
        isReached = false;
        getDirection();
        StartCoroutine(flipSprite());
        if(moveDirection.x != 0) IsMoving = true;
    }

    public void setFlipX(bool value){
        sprite.flipX = value;
    }

    void getDirection(){
        float x = transform.position.x;
        if(x < target.x) moveDirection.x = 1;
        else if(x > target.x) moveDirection.x = -1;
    }

    IEnumerator flipSprite(){
        while(!sprite) yield return new WaitForFixedUpdate();
        if(moveDirection.x < 0) sprite.flipX = true;
        else if (moveDirection.x > 0) sprite.flipX = false;
        yield break;
    }
}
