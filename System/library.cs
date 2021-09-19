using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tysseek
{
    public interface IAnnihilated
    {
        public void OnHitting();
        public void ToDamage(int amountOfDamage);
        public void Kill();
    }


}