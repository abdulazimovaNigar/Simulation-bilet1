using System.Threading.Tasks;
using Bilet1.Contexts;
using Bilet1.Models;
using Bilet1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet1.Areas.Admin.Controllers;

[Area("Admin")]
public class TeamMemberController(AppDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var teamMembers = await _context.TeamMembers.Select(teamMember => new TeamMemberGetVM()
        {
            Id = teamMember.Id,
            Name = teamMember.Name,
            Description = teamMember.Description,
            Image = teamMember.Image
        }).ToListAsync();

        return View(teamMembers);
    }

    [HttpGet]
    public IActionResult Create() 
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(TeamMemberCreateVM vm) 
    {
        if (!ModelState.IsValid) return View(vm);
        
        
        
        var teamMember = new TeamMember()
        {
            Name = vm.Name,
            Description = vm.Description,
        };


        await _context.TeamMembers.AddAsync(teamMember);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
        
    }


    public async Task<IActionResult> Delete(int id)
    {
        var teamMember = await _context.TeamMembers.FindAsync(id);

        if (teamMember is null)
            return NotFound();


        _context.TeamMembers.Remove(teamMember);
        await _context.SaveChangesAsync();


        //remove old image
        return RedirectToAction(nameof(Index));
    }
}
