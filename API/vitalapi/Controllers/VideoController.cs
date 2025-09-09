using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;


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
            .Include(v => v.Tags)
            .Where(v => v.Ativo)
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
    public async Task<ActionResult<Video>> PostVideo(VideoCreateDTO dto)
    {
        var tags = await _context.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();

        var video = new Video
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            Url = dto.Url,
            DuracaoSegundos = dto.DuracaoSegundos,
            Categoria = dto.Categoria,
            Tags = tags,
            Ativo = dto.Ativo,
            Premium = dto.Premium,
            DataCriacao = DateTime.UtcNow
        };

        _context.Videos.Add(video);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVideo), new { id = video.Id }, video);
    }


    [HttpPut("{id}")]

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
