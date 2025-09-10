using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Models.Midia;

[ApiController]
[Route("api/[controller]")]
public class VideoController : ControllerBase
{
    private readonly VitalContext _context;

    public VideoController(VitalContext vitalcontext)
    {
        _context = vitalcontext;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
    {
        return await _context.Videos
            .ToListAsync();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Video>> GetVideo(int id)
    {
        var video = await _context.Videos
            .Include(v => v.Tags)
            .FirstOrDefaultAsync(v => v.Id == id && v.Ativo);

        if (video == null)
            return NotFound();

        return video;
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<Video>> PostVideo(Video video)
    {
        video.DataCriacao = DateTime.UtcNow;
        _context.Videos.Add(video);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVideo), new { id = video.Id }, video);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> PutVideo(int id, Video video)
    {
        if (id != video.Id)
            return BadRequest();

        var existingVideo = await _context.Videos.FindAsync(id);
        if (existingVideo == null)
            return NotFound();

        existingVideo.Titulo = video.Titulo;
        existingVideo.Descricao = video.Descricao;
        existingVideo.Url = video.Url;
        existingVideo.DuracaoSegundos = video.DuracaoSegundos;
        existingVideo.Categoria = video.Categoria;
        existingVideo.Tags = video.Tags;
        existingVideo.Ativo = video.Ativo;
        existingVideo.Premium = video.Premium;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> DeleteVideo(int id)
    {
        var video = await _context.Videos.FindAsync(id);
        if (video == null)
            return NotFound();

        _context.Videos.Remove(video);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
