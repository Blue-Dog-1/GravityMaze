using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tysseek
{
    public interface IAnnihilated
    {
        public void OnHitting();
        public void ToDamage(int amountOfDamage);
        public void Kill();
    }

    public interface IInteraction
    {
        public void Interaction();
    }

    [Serializable]
    public struct Coordinates
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 size;

        public void Convert(Transform transform)
        {
            position = transform.position;
            rotation = transform.eulerAngles;
            size = transform.localScale;
        }

        public void Unpack(Transform transform)
        {
            transform.position = position;
            transform.eulerAngles = rotation;
            transform.localScale = size;

        }
    }


}