using System;
using UnityEngine;

namespace ArcheroClone
{
    public class IdleController : IController
    {
        public Action<Vector3> OnMove { get; set; }
    }
}
