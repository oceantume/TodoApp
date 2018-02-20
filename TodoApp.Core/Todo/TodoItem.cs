using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Todo
{
    public class TodoItem
    {
        public TodoItem(int id, string content, bool checkd)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentOutOfRangeException(nameof(content), content, "must be a non-whitespace string");

            if (content.Length > 200)
                throw new ArgumentOutOfRangeException(nameof(content), content, "can't be bigger than 200 characters");

            Id = id;
            Content = content;
            Checked = checkd;
        }

        public int Id { get; }
        public string Content { get; }
        public bool Checked { get; }
    }
}
