using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Web.ViewModels
{
    public class CheckTodoViewModel
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
    }
}