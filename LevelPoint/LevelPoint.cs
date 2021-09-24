using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Tysseek
{
    [AddComponentMenu("Projcet/LevelPoint")]
    public class LevelPoint : MonoBehaviour, IInteraction
    {
        public const float height = 1.5f;
        [SerializeField] LevelData _level;
        [SerializeField] TextMeshPro _namberText;
        [SerializeField] GameObject _lock;
        [SerializeField] GameObject[] _stars;

        public LevelData level => _level;
        public static LevelPoint selectPoint { get; set; }
        void Start()
        {
            Instate();
        }
        public void Unlocked()
        {
            _level.isUnlocked = true;
            _lock.SetActive(false);
        }
        public void Instate()
        {
            var pos = transform.position;
            if (_level?.isUnlocked ?? false)
                StartCoroutine(Hoisting());

            transform.position = pos;

            if (!_level) return;

            _namberText.text = _level.number.ToString();
            _lock.SetActive(!_level.isUnlocked);
            
            if (_level.stars > 0)
            {
                _stars[0].transform.parent.gameObject.SetActive(_level.isUnlocked);
                for (int i = 0; i < _level.stars; i++)
                    _stars[i].gameObject.SetActive(true);
            }
        }
        IEnumerator Hoisting()
        {
            while (transform.position.y < height)
            {
                transform.position += Vector3.up * Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
        }    

        public void Interaction()
        {
            Debug.LogFormat("LevelPoint Clic {0}", name);
            if (!level.isUnlocked) return;
            selectPoint = this;
            GameManager.levelData = level;
        }
       
    }
}
