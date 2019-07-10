using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoubuWebApp.ViewModels
{
    public class SampleViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 名前(必須)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年齢
        /// </summary>
        public DateTime? Birth { get; set; }

        public string Test { get; set; }
    }
}