using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utility;

public class MoveAnimation : MonoBehaviour
{
    public GameObject attacker;
    public GameObject defender;

    private Animator attackerAnimator;
    private Animator defenderAnimator;

    private Vector3 startPos;
    private Vector3 endPos;

    private readonly float start = 0;
    private readonly float end = 1;

    private float moveSpeed = 0.015f;

    private void Start()
    {
        attackerAnimator = attacker.GetComponentInChildren<Animator>();
        defenderAnimator = defender.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startPos = attacker.transform.position;
            endPos = defender.transform.position;

            StopAllCoroutines();
            StartCoroutine(StartMove(startPos, endPos, false));
        }
    }

    private IEnumerator StartMove(Vector3 startPos, Vector3 endPos, bool hasEnemy)
    {
        Vector3 pausePos = startPos + ((endPos - startPos) * 0.5f);

        if (hasEnemy)
        {
            
        }
        else
        {
            // todo use tween
            float current = 0;
            attackerAnimator.SetBool("isWalk", true);
            while (current <= 1)
            {
                attacker.transform.LookAt(endPos);
                attacker.transform.position = Vector3.Lerp(startPos, pausePos, current);
                current += moveSpeed;
                yield return new WaitForSecondsRealtime(0.0001f);
            }

            attackerAnimator.SetBool("isWalk", false);
            yield return new WaitForSecondsRealtime(0.5f);

            attackerAnimator.SetBool("isWalk", true);
            attackerAnimator.SetBool("isAttack", true);
            yield return new WaitForSecondsRealtime(2.0f);
            attackerAnimator.SetBool("isAttack", false);

            /*
            attackerAnimator.SetBool("isWalk", true);


            current = 0;
            while (current <= 1)
            {
                attacker.transform.LookAt(endPos);
                attacker.transform.position = Vector3.Lerp(pausePos, endPos, current);
                current += moveSpeed;
                yield return new WaitForSecondsRealtime(0.0001f);
            }
            attacker.transform.position = endPos;
            attackerAnimator.SetBool("isWalk", false);
            Debug.Log($"1");
            attacker.transform.rotation = DataManager.ChessPieceInfo.blackRotation;
            Debug.Log($"rotation : {transform.rotation}");
            Debug.Log($"2");
            */
        }
        yield return null;
    }
}
