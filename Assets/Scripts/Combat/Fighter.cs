using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class Fighter : MonoBehaviour
    {
        public static void Attack(Object target)
        {
            print("Attacking " + target.name);
        }
    }    
}

