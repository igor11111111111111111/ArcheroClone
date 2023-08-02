using System;
using UnityEngine;

namespace ArcheroClone
{
    public interface IController
    {
        Action<Vector3> OnMove { get; set; }
    }
}
