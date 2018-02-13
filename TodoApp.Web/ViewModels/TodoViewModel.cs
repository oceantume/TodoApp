using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Web.ViewModels
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Done { get; set; }
    }
}