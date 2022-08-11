using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public abstract class ControlledObject : MonoBehaviour
    {
        public abstract void ShootingDisable();

        public abstract void ShootingEnable();
        
    }
}