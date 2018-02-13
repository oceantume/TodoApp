﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Todo
{
    public class TodoItem
    {
        public TodoItem(int id, string content, bool done)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentOutOfRangeException(nameof(content), content, "must be a non-whitespace string");

            Id = id;
            Content = content;
            Done = done;
        }

        public int Id { get; }
        public string Content { get; }
        public bool Done { get; }
    }
}