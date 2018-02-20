

using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using TodoApp.Core.Todo;

namespace TodoApp.Core.Tests.Todo
{
    [TestFixture]
    public class TodoItemTest
    {
        [Test]
        public void TodoItem_ValidParams_ReturnedByProperties()
        {
            var expected = new { Id = 1, Content = "test", Checked = true };
            var todo = new TodoItem(expected.Id, expected.Content, expected.Checked);

            Assert.Multiple(() => {
                Assert.AreEqual(expected.Id, todo.Id);
                Assert.AreEqual(expected.Content, todo.Content);
                Assert.AreEqual(expected.Checked, todo.Checked);
            });
        }


        [Test]
        public void TodoItem_IdGreaterThan0_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                new TodoItem(1, "test", false);
            });

            Assert.DoesNotThrow(() => {
                new TodoItem(int.MaxValue, "test", false);
            });
        }

        [Test]
        public void TodoItem_IdEqualsOrLessThan0_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(0, "test", false);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(-1, "test", false);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(int.MinValue, "test", false);
            });
        }


        [Test]
        public void TodoItem_ContentBetween1and200_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                new TodoItem(1, "t", false);
            });

            Assert.DoesNotThrow(() => {
                new TodoItem(1, "test", false);
            });

            var str = new StringBuilder()
                .Append('t', 200)
                .ToString();

            Assert.DoesNotThrow(() => {
                new TodoItem(1, str, false);
            });
        }

        [Test]
        public void TodoItem_ContentNullOrWhitespace_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(1, null, false);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(1, "", false);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(1, "     ", false);
            });
        }

        [Test]
        public void TodoItem_ContentLongerThan200_Throws()
        {
            var str = new StringBuilder()
                .Append('t', 201)
                .ToString();

            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new TodoItem(1, str, false);
            });
        }
    }
}
