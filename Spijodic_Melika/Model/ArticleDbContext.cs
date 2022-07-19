using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Spijodic_Melika.Model;

namespace Spijodic_Melika.Model
{
    public class ArticleDbContext: DbContext
    {
        public ArticleDbContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }

    }

}