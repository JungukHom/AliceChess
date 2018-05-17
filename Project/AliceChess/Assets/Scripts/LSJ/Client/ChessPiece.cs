using System;
using UnityEngine;
using System.Collections;

namespace LSJ
{
    public class ChessPiece : MonoBehaviour
    {
        public float walkSpeed = 0.1f;
        public float stopDistance = 0.1f;

        public Vector3 desPos = new Vector3(0, 0, 0.2f);

        new private Transform transform;

        private readonly string isWalk = "isWalk";
        private readonly string isAttack = "isAttack";
        private readonly string isDie = "isDie";

        Animator anim;

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        public IEnumerator StartMove(bool hasEnemy)
        {
            Debug.Log($"StartMove() / hasEnemy : {hasEnemy}");

            anim.SetBool("isWalk", true);
            anim.speed = 1.5f;

            Vector3 dir = desPos - transform.position;

            if (hasEnemy)
            {
                while(Vector3.Distance(transform.position, desPos / 2) > stopDistance)
                {
                    transform.position += walkSpeed * dir.normalized * Time.deltaTime;

                    yield return new WaitForEndOfFrame();
                }

                anim.SetBool("isAttack", true);
                yield return new WaitForEndOfFrame();

                anim.SetBool("isAttack", false);

                if(transform.position == desPos)
                {
                    anim.SetBool("isWalk", false);
                }
            }
            else
            {
                while (Vector3.Distance(transform.position, desPos) > stopDistance)
                {
                    transform.position += walkSpeed * dir.normalized * Time.deltaTime;

                    yield return new WaitForEndOfFrame();
                }

                transform.position = desPos;
                anim.SetBool("isWalk", false);
            }
        }

    }
}