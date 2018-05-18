using System;
using UnityEngine;
using System.Collections;

namespace LSJ
{
    public class ChessPiece : MonoBehaviour
    {
        public float walkSpeed = 0.1f;
        public float stopDistance = 0.12f;

        public Vector3 destinationPosition = new Vector3(0, 0, 0.2f);

        new private Transform transform;

        private const string isWalk = "isWalk";
        private const string isAttack = "isAttack";
        private const string isDie = "isDie";

        Animator animator;

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        public IEnumerator StartMove(bool hasEnemy)
        {
            Debug.Log($"StartMove() / hasEnemy : {hasEnemy}");

            animator.SetBool("isWalk", true);
            animator.speed = 1.5f;

            Vector3 dir = destinationPosition - transform.position;

            if (hasEnemy)
            {
                while(Vector3.Distance(transform.position, destinationPosition / 2) > stopDistance)
                {
                    transform.position += walkSpeed * dir.normalized * Time.deltaTime;

                    yield return new WaitForEndOfFrame();
                }

                animator.SetBool("isAttack", true);
                yield return new WaitForEndOfFrame();

                animator.SetBool("isAttack", false);

                if(transform.position == destinationPosition)
                {
                    animator.SetBool("isWalk", false);
                }
            }
            else
            {
                while (Vector3.Distance(transform.position, destinationPosition) > stopDistance)
                {
                    transform.position += walkSpeed * dir.normalized * Time.deltaTime;

                    yield return new WaitForEndOfFrame();
                }

                transform.position = destinationPosition;
                animator.SetBool("isWalk", false);
            }
        }

    }
}