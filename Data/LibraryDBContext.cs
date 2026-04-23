using LibraryManagementSystemWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemWebApplication.Data
{
    public class LibraryDBContext:DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {
            
        }
        public DbSet<Admin> adminTble {  get; set; }
        public DbSet<Books> bookTble {  get; set; }
        public DbSet<Student> studentTble {  get; set; }

    }
}
