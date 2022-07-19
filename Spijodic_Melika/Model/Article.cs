using System;
using System.ComponentModel.DataAnnotations;

namespace Spijodic_Melika.Model
{
    /// <summary>
    /// Class that describes articles sold
    /// </summary>
    public class Article
    {
        public int Id { get; set; }

        /// <summary>
        /// Date when the article was sold
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Article number
        /// </summary>
        /// <example>article1</example>
        [DataType(DataType.Text)]
        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string Number { get; set; }

        /// <summary>
        /// Article price
        /// </summary>
        /// <example>150</example>
        [Required]
        [Range(0, 1000000)]
        public double Price { get; set; }
    }
}
