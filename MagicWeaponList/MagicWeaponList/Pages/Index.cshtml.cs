using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MagicWeaponList.Repositories;
using MagicWeaponList.Models;
using MagicWeaponList.DTOs;

namespace MagicWeaponList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IWeaponRepository weaponRepository;
        public IEnumerable<Weapon> Weapons { get; set; }

        public IndexModel(ILogger<IndexModel> logger
            , IWeaponRepository weaponRepository)
        {
            _logger = logger;
            this.weaponRepository = weaponRepository;
        }

        public async Task OnGet()
        {
            Weapons =  await weaponRepository.GetWeaponsAsync();
        }

        public async Task<IActionResult> OnPostSearchBy([FromBody]WeaponSearchRequest request)
        {
            var weapons = await weaponRepository.GetWeaponsAsync(request);
            return new OkObjectResult(weapons);
        }
    }
}
