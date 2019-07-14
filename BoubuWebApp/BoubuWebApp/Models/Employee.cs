using System;
using System.ComponentModel.DataAnnotations;

namespace BoubuWebApp.Models
{
    public class Employee
    {
        /// 主キー
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 名前(必須)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 年齢
        /// </summary>
        public DateTime? Birth { get; set; }
    }
}