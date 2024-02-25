using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CostumerMovement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sprite;
    private Vector2 target;
    private Vector2 moveDirection;
    private bool isMoving = false;
    private bool isReached = false;

    public bool IsMoving{
        get{return isMoving;}
    }

    public bool IsReached{
        get{return isReached;}
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if(isMoving){
            transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
            checkReachedTarget();
        }
    }

    private void checkReachedTarget(){
        if((moveDirection.x > 0 && transform.position.x >= target.x) || (moveDirection.x < 0 && transform.position.x <= target.x)){
            isMoving = false;
            isReached = true;
            transform.position = new Vector2(target.x,transform.position.y);
        }
    }

    public void setTarget(Vector2 target){
        if(this.target == target) return;
        this.target = target;
        isReached = false;
        getDirection();
        StartCoroutine(flipSprite());
        if(moveDirection.x != 0) isMoving = true;
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
