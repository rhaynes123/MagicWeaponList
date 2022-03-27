using System;
using MagicWeaponList.Models.Enums;
using System.Text.Json.Serialization;
namespace MagicWeaponList.DTOs
{
    public record WeaponSearchRequest
    {
        [JsonPropertyName("id")]
        public int? id { get; init; }
        [JsonPropertyName("name")]
        public string name { get; init; }
        [JsonPropertyName("description")]
        public string description { get; init; }
        public int? attackPoints { get; init; }
        public int? defensePoints { get; init; }
        [JsonPropertyName("category")]
        public Category? category { get; init; }
        [JsonPropertyName("damageType")]
        public DamageType? damageType { get; init; }
    };
}
