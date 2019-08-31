using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoubuWebApp.ViewModels
{
    public class ResponseViewModel<T>
    {
        public IReadOnlyList<T> ResponseObj { get; set; }
        public int Count { get; set; }
        public bool ResultFlg { get; set; }
        public string Message { get; set; }
    }
}