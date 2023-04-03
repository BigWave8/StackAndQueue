using StackAndQueueProject;
using FluentAssertions;

namespace StackAndQueue.UnitTests
{
    public class QueueTests
    {
        [TestCase("")]
        [TestCase("third")]
        [TestCase("maybeveryveryloooooooo0000000000000000ooooooongstring")]
        public void Enqueue_StringElement_AddedElementAtTheEnd(string newElement)
        {
            MyStack<string> result = new(new List<string> { "first", "second" });
            MyStack<string> expected = new(new List<string> { "first", "second", newElement });

            result.Push(newElement);

            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [TestCase(0)]
        [TestCase(3)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void Push_IntElement_AddedElementAtTheEnd(int newElement)
        {
            MyStack<int> result = new(new List<int> { 1, 2 });
            MyStack<int> expected = new(new List<int> { 1, 2, newElement });

            result.Push(newElement);

            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [TestCase(1)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.Epsilon)]
        [TestCase(double.MaxValue)]
        [TestCase(float.MinValue)]
        [TestCase(long.MaxValue)]
        [TestCase("1")]
        [TestCase('1')]
        [TestCase(' ')]
        [TestCase(new[] { 1 })]
        public void Push_AnyObjectTypeToEmptyQueue_ObjectAdded(object newElement)
        {
            MyStack<object> result = new(new List<object> { });
            MyStack<object> expected = new(new List<object> { newElement });

            result.Push(newElement);

            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [Test]
        public void Push_Null_Nothing()
        {
            MyStack<string> result = new(new List<string> { "first", "second" });
            MyStack<string> expected = new(new List<string> { "first", "second" });

            result.Push(null);

            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [Test]
        public void Pop_Strings_RemovedAndReturnedLastElement()
        {
            MyStack<string> result = new(new List<string> { "first", "second", "third" });
            MyStack<string> expected = new(new List<string> { "first", "second" });
            string expectedItem = "third";

            string resultItem = result.Pop();

            resultItem.Should().Be(expectedItem);
            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [Test]
        public void Pop_FloatNumbers_RemovedAndReturnedLastElement()
        {
            MyStack<float> result = new(new List<float> { 1.0f, 1.1f, 10.01f });
            MyStack<float> expected = new(new List<float> { 1.0f, 1.1f });
            float expectedItem = 10.01f;

            float resultItem = result.Pop();

            resultItem.Should().Be(expectedItem);
            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [Test]
        public void Pop_EmptyQueue_ThrowException()
        {
            MyStack<string> result = new();

            Action act = () => result.Pop();

            act.Should().Throw<Exception>().Where(e => e.Message.StartsWith("Stack is empty"));
        }

        [Test]
        public void Peek_Strings_ReturnedLastElementWithoutRemoving()
        {
            MyStack<string> result = new(new List<string> { "first", "second", "third" });
            MyStack<string> expected = new(new List<string> { "first", "second", "third" });
            string expectedItem = "third";

            string resultItem = result.Peek();

            resultItem.Should().Be(expectedItem);
            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [Test]
        public void Peek_FloatNumbers_ReturnedFirstElementWithoutRemoving()
        {
            MyStack<float> result = new(new List<float> { 1.0f, 1.1f, 10.01f });
            MyStack<float> expected = new(new List<float> { 1.0f, 1.1f, 10.01f });
            float expectedItem = 10.01f;

            float resultItem = result.Peek();

            resultItem.Should().Be(expectedItem);
            result.Stack.Should().BeEquivalentTo(expected.Stack);
        }

        [Test]
        public void Peek_EmptyQueue_ThrowException()
        {
            MyStack<string> result = new();

            Action act = () => result.Peek();

            act.Should().Throw<Exception>().Where(e => e.Message.StartsWith("Stack is empty"));
        }

        [Test]
        public void Clear_FewStringElements_EmptyQueue()
        {
            MyStack<string> result = new(new List<string> { "first", "second", "third" });

            result.Clear();

            result.Stack.Should().BeEmpty();
        }

        [Test]
        public void Clear_EmptyQueue_EmptyQueue()
        {
            MyStack<string> result = new();

            result.Clear();

            result.Stack.Should().BeEmpty();
        }
    }
}