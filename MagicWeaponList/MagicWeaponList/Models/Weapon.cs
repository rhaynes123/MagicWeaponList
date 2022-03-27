using System;
using System.Collections.Generic;
using MagicWeaponList.Models.Enums;
namespace MagicWeaponList.Models
{
    public class Weapon
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public Category Category { get; set; }
        public ICollection<DamageType> DamageTypes { get; set; }
    }
}
