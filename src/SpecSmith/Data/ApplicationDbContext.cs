using Microsoft.EntityFrameworkCore;

namespace SpecSmith.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

}