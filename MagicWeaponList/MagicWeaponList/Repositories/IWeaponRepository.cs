using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MagicWeaponList.Models;
using MagicWeaponList.DTOs;
namespace MagicWeaponList.Repositories
{
    public interface IWeaponRepository
    {
        Task<IEnumerable<Weapon>> GetWeaponsAsync(WeaponSearchRequest weaponSearchRequest = null);
    }
}
