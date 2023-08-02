using System;

namespace ArcheroClone
{
    public interface IShootSystem
    {
        Action OnShoot { get; set; }
    }
}