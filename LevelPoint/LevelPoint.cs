using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Tysseek
{
    [AddComponentMenu("Projcet/LevelPoint")]
    public class LevelPoint : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] LevelData _level;
        [SerializeField] TextMeshPro _namberText;
        [SerializeField] GameObject _lock;
        [SerializeField] GameObject[] _stars;

        void Start()
        {

        }

        void Instate()
        {
            if (!_level) return;

            _namberText.text = _level.number.ToString();
            _lock.SetActive(_level.isUnlocked);

            if(_level.isUnlocked)
            {
                _stars[0].gameObject.SetActive(true);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("LevelPoint Clic");
        }
    }
}
