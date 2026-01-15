using System.Threading.Tasks;
using Bilet1.Contexts;
using Bilet1.Models;
using Bilet1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet1.Areas.Admin.Controllers;
[Area("Admin")]
public class MemberPositionController(AppDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var memberPositions =  await _context.MemberPositions.Select(memberPosition => new MemberPositionGetVM()
        {
            Id = memberPosition.Id,
            Name = memberPosition.Name
        }).ToListAsync();


        return View(memberPositions);
    }

    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MemberPositionCreateVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);
        var memberPosition = new MemberPosition()
        {
            Name = vm.Name
        };
        await _context.MemberPositions.AddAsync(memberPosition);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        var memberPosition = await _context.MemberPositions.FirstOrDefaultAsync(m => m.Id == id);
        if (memberPosition == null) return NotFound();
        _context.MemberPositions.Remove(memberPosition);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var memberPosition = await _context.MemberPositions.FirstOrDefaultAsync(m => m.Id == id);
        if (memberPosition == null) return NotFound();

        var vm = new MemberPositionUpdateVM()
        {
            Id = memberPosition.Id,
            Name = memberPosition.Name
        };
        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(MemberPositionUpdateVM vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var existMemberPosition = await _context.MemberPositions.FirstOrDefaultAsync(m => m.Id == vm.Id);
        if (existMemberPosition == null) return NotFound();
        existMemberPosition.Name = vm.Name;
        //_context.MemberPositions.Update(existMemberPosition);
       
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
