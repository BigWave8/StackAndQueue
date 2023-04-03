using StackAndQueueProject;
using FluentAssertions;

namespace StackAndQueue.UnitTests
{
    public class StackTests
    {
        [TestCase("")]
        [TestCase("third")]
        [TestCase("maybeveryveryloooooooo0000000000000000ooooooongstring")]
        public void Enqueue_StringElement_AddedElementAtTheEnd(string newElement)
        {
            MyQueue<string> result = new(new List<string> { "first", "second" });
            MyQueue<string> expected = new(new List<string> { "first", "second", newElement });

            result.Enqueue(newElement);

            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [TestCase(0)]
        [TestCase(3)]
        [TestCase(-876543234)]
        [TestCase(1234567899)]
        public void Enqueue_IntElement_AddedElementAtTheEnd(int newElement)
        {
            MyQueue<int> result = new(new List<int> { 1, 2 });
            MyQueue<int> expected = new(new List<int> { 1, 2, newElement });

            result.Enqueue(newElement);

            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [Test]
        public void Enqueue_Null_Nothing()
        {
            MyQueue<string> result = new(new List<string> { "first", "second" });
            MyQueue<string> expected = new(new List<string> { "first", "second" });

            result.Enqueue(null);

            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [Test]
        public void Dequeue_Strings_RemovedAndReturnedFirstElement()
        {
            MyQueue<string> result = new(new List<string> { "first", "second", "third" });
            MyQueue<string> expected = new(new List<string> { "second", "third" });
            string expectedItem = "first";

            string resultItem = result.Dequeue();

            resultItem.Should().Be(expectedItem);
            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [Test]
        public void Dequeue_FloatNumbers_RemovedAndReturnedFirstElement()
        {
            MyQueue<float> result = new(new List<float> { 1.0f, 1.1f, 10.01f });
            MyQueue<float> expected = new(new List<float> { 1.1f, 10.01f });
            float expectedItem = 1.0f;

            float resultItem = result.Dequeue();

            resultItem.Should().Be(expectedItem);
            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowException()
        {
            MyQueue<string> result = new();

            Action act = () => result.Dequeue();

            act.Should().Throw<Exception>().Where(e => e.Message.StartsWith("Queue is empty"));
        }

        [Test]
        public void Peek_Strings_ReturnedFirstElementWithoutRemoving()
        {
            MyQueue<string> result = new(new List<string> { "first", "second", "third" });
            MyQueue<string> expected = new(new List<string> { "first", "second", "third" });
            string expectedItem = "first";

            string resultItem = result.Peek();

            resultItem.Should().Be(expectedItem);
            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [Test]
        public void Peek_FloatNumbers_ReturnedFirstElementWithoutRemoving()
        {
            MyQueue<float> result = new(new List<float> { 1.0f, 1.1f, 10.01f });
            MyQueue<float> expected = new(new List<float> { 1.0f, 1.1f, 10.01f });
            float expectedItem = 1.0f;

            float resultItem = result.Peek();

            resultItem.Should().Be(expectedItem);
            result.Queue.Should().BeEquivalentTo(expected.Queue);
        }

        [Test]
        public void Peek_EmptyQueue_ThrowException()
        {
            MyQueue<string> result = new();

            Action act = () => result.Peek();

            act.Should().Throw<Exception>().Where(e => e.Message.StartsWith("Queue is empty"));
        }

        [Test]
        public void Clear_FewStringElements_EmptyQueue()
        {
            MyQueue<string> result = new(new List<string> { "first", "second", "third" });

            result.Clear();

            result.Queue.Should().BeEmpty();
        }

        [Test]
        public void Clear_EmptyQueue_EmptyQueue()
        {
            MyQueue<string> result = new();

            result.Clear();

            result.Queue.Should().BeEmpty();
        }
    }
}