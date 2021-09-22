using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public class ProtectiveField : MonoBehaviour
    {
        [SerializeField] float _fullSize;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == GameManager.PLAYER)
            {
                var player = collision.gameObject.GetComponent<Player>();
                if (player?.isProtected ?? true) return;
                player.isProtected = true;
                player.protectiveField = this;
                transform.localScale *= _fullSize;

                GetComponent<Collider2D>().enabled = false;
            }
        }

        public IEnumerator Disactiv(Player player)
        {
            yield return new WaitForSeconds(1);
            player.isProtected = false;
            gameObject.SetActive(false);

        }
    }
}