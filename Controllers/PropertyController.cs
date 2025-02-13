[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PropertyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProperties() => Ok(await _context.Properties.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProperty(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null) return NotFound();
        return Ok(property);
    }
}
