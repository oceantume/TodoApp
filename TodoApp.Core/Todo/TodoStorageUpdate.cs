using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Todo
{
    public class TodoStorageUpdate
    {
        internal int Id { get; }
        internal OptionalField<string> Content { get; private set; }
        internal OptionalField<bool> Done { get; private set; }

        public TodoStorageUpdate(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "id must be greater than zero.");

            Id = id;
        }

        public TodoStorageUpdate SetContent(string content)
        {
            Content = OptionalField<string>.Create(content);
            return this;
        }

        public TodoStorageUpdate SetDone(bool done)
        {
            Done = OptionalField<bool>.Create(done);
            return this;
        }


        internal struct OptionalField<T>
        {
            public bool HasValue { get; private set; }
            public T Value { get; private set; }

            public T GetValueOr(T orValue)
            {
                return HasValue ? Value : orValue;
            }

            public static OptionalField<T> Create(T value)
            {
                return new OptionalField<T> { HasValue = true, Value = value };
            }
        }
    }
    }
