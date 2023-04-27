using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restApi.Data;
using restApi.Data.Dtos;
using restApi.Models;

namespace restApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase {
    private GrapeContext _context;
    private IMapper _mapper;

    public ClientController(GrapeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddClient([FromBody] CreateClientDto clientDto) {
        Client client = _mapper.Map<Client>(clientDto);
        _context.Client.Add(client);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetClientPerId), new { Id = client.Id }, clientDto);
    }

    [HttpGet]
    public IEnumerable<ReadClientDto> GetClients() {
        return _mapper.Map<List<ReadClientDto>>(_context.Client.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetClientPerId(int Id) {
        Client client = _context.Client.FirstOrDefault(client => client.Id == Id);
        if(client != null) {
            ReadClientDto clientDto = _mapper.Map<ReadClientDto>(client);
            return Ok(clientDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClient(int id, [FromBody] UpdateClientDto clientDto) {
        Client client = _context.Client.FirstOrDefault(client => client.Id == id);
        if(client == null) {
            return NotFound();
        }
        _mapper.Map(clientDto, client);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id) {
        Client client = _context.Client.FirstOrDefault(client => client.Id == id);
        if(client == null ) {
            return NotFound();
        }
        _context.Remove(client);
        _context.SaveChanges();
        return NoContent();
    }
}
