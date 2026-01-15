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
        var memberPositions = await _context.MemberPositions.Select(memberPosition => new MemberPositionGetVM() 
        {
            Id = memberPosition.Id,
            Name = memberPosition.Name
        }).ToListAsync();
       
        return View(memberPositions);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var memberPosition = await _context.MemberPositions.ToListAsync();
        ViewBag.MemberPositions = memberPosition;
        return View(memberPosition);
    }
    [HttpPost]
    public IActionResult Create(MemberPosition memberPosition)
    {
        if (!ModelState.IsValid) return View(memberPosition);
        _context.MemberPositions.Add(memberPosition);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var memberPosition = _context.MemberPositions.FirstOrDefault(m => m.Id == id);
        if (memberPosition == null) return NotFound();
        _context.MemberPositions.Remove(memberPosition);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Update(int id)
    {
        var memberPosition = _context.MemberPositions.FirstOrDefault(m => m.Id == id);
        if (memberPosition == null) return NotFound();
        return View(memberPosition);
    }
    [HttpPost]
    public IActionResult Update(MemberPosition memberPosition)
    {
        if (!ModelState.IsValid) return View();
        var existMemberPosition = _context.MemberPositions.FirstOrDefault(m => m.Id == memberPosition.Id);
        if (existMemberPosition == null) return NotFound();
        existMemberPosition.Name = memberPosition.Name;
        _context.MemberPositions.Update(existMemberPosition);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}
