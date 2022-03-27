using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicWeaponList.Models;
using MagicWeaponList.Models.Enums;
using MagicWeaponList.DTOs;
using System.Linq;
namespace MagicWeaponList.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly List<Weapon> Weapons;
        public WeaponRepository()
        {
            Weapons = new()
            {
                new Weapon
                {
                    Id = 1,
                    Name = "Fire Sword of Alogram",
                    Description = "The great Fire Sword of Lord Alogram said to have slain 1000 frost giants in a single swing",
                    Image = string.Empty,
                    AttackPoints = 10,
                    DefensePoints = 0,
                    Category = Category.Sword,
                    DamageTypes = new List<DamageType>
                    {
                        DamageType.Fire,
                        DamageType.Slashing,
                        DamageType.Piercing
                    }

                },
                new Weapon
                {
                    Id = 2,
                    Name = "Fire Shield of Alogram",
                    Description = "The great Fire Shield of Lord Alogram designed to protect against the powerful flames of the lords own sword",
                    Image = string.Empty,
                    AttackPoints = 0,
                    DefensePoints = 10,
                    Category = Category.Shield,
                    DamageTypes = new List<DamageType>
                    {
                        DamageType.Fire,
                        DamageType.Bludeoning,
                    }

                },
                new Weapon
                {
                    Id = 3,
                    Name = "Ice Spike Shield",
                    Description = "A type of shield forged from Ice Giant bones",
                    Image = string.Empty,
                    AttackPoints = 3,
                    DefensePoints = 7,
                    Category = Category.Shield,
                    DamageTypes = new List<DamageType>
                    {
                        DamageType.Cold,
                        DamageType.Bludeoning,
                        DamageType.Piercing
                    }

                },
                new Weapon
                {
                    Id = 4,
                    Name = "Heavy Axe",
                    Description = "Just an axe but you can't go wrong with just an axe",
                    Image = string.Empty,
                    AttackPoints = 10,
                    DefensePoints = 0,
                    Category = Category.Axe,
                    DamageTypes = new List<DamageType>
                    {
                        DamageType.Slashing,
                    }

                },
                new Weapon
                {
                    Id = 5,
                    Name = "Elf Spear",
                    Description = "A spear built by elves to be as light as feather but strong than any man made steel",
                    Image = string.Empty,
                    AttackPoints = 20,
                    DefensePoints = 0,
                    Category = Category.Spear,
                    DamageTypes = new List<DamageType>
                    {
                        DamageType.Slashing,
                        DamageType.Piercing
                    }

                },
            };
        }

        public async Task<IEnumerable<Weapon>> GetWeaponsAsync(WeaponSearchRequest weaponSearchRequest = null)
        {
            var weapons = Weapons.AsQueryable(); ;
            if (weaponSearchRequest is not null)
            {
                if (weaponSearchRequest.id.HasValue)
                {
                    weapons = weapons.Where(r => r.Id == weaponSearchRequest.id);
                }
                if(!string.IsNullOrWhiteSpace(weaponSearchRequest.name))
                {
                    weapons = weapons.Where(r => r.Name.Contains(weaponSearchRequest.name));
                }
                if(weaponSearchRequest.category.HasValue)
                {
                    weapons = weapons.Where(r => r.Category == weaponSearchRequest.category);
                }
                if(weaponSearchRequest.damageType.HasValue)
                {
                    weapons = weapons.Where(r => r.DamageTypes.Any(d =>d.Equals(weaponSearchRequest.damageType)));
                }
            }
            return await Task.FromResult(weapons);
        }
    }
}
