using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        [SerializeField] private Light sunlight;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sunlight.gameObject.SetActive(false);
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            animator.SetTrigger("Hit");
            hitPoints--;
            if (hitPoints <= 0)
            {
                Die();
                sunlight.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }

        private IEnumerator Die()
        {
            animator.SetTrigger("Die");
            yield return new WaitForSeconds(1.3f);
        }


    }

}