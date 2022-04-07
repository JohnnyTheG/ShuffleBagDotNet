using Xunit;
using System.Collections.Generic;

namespace ShuffleBagDotNet.Tests
{
    public class ShuffleBagTests
    {
        [Fact]
        public void CreateEmpty()
        {
            ShuffleBag<int> shuffleBag = new ShuffleBag<int>(new List<int>(), false);

            Assert.True(shuffleBag.IsEmpty);
        }

        [Fact]
        public void CreateWithList()
        {
            ShuffleBag<int> shuffleBag = new ShuffleBag<int>(new List<int> { 0, 1, 2, 3, 4 }, false);

            Assert.False(shuffleBag.IsEmpty);
        }

        [Fact]
        public void CreateWithArray()
        {
            ShuffleBag<int> shuffleBag = new ShuffleBag<int>(new int[] { 0, 1, 2, 3, 4 }, false);

            Assert.False(shuffleBag.IsEmpty);
        }

        [Fact]
        public void TestRefill()
        {
            int[] initialValues = new int[] { 0, 1, 2, 3, 4 };

            ShuffleBag<int> shuffleBag = new ShuffleBag<int>(initialValues, false);

            for (int i = 0; i < initialValues.Length; i++)
            {
                shuffleBag.Next();
            }

            Assert.True(shuffleBag.IsEmpty);

            shuffleBag.Refill();

            Assert.False(shuffleBag.IsEmpty);
        }

        [Fact]
        public void TestAutoRefill()
        {
            int[] initialValues = new int[] { 0, 1, 2, 3, 4 };

            ShuffleBag<int> shuffleBag = new ShuffleBag<int>(initialValues, true);

            for (int i = 0; i < initialValues.Length; i++)
            {
                shuffleBag.Next();
            }

            Assert.True(shuffleBag.IsEmpty);

            Assert.True(shuffleBag.Next() >= 0);
        }

        [Fact]
        public void ThrowExceptionNextEmptyShuffleBag()
        {
            ShuffleBag<int> shuffleBag = new ShuffleBag<int>(new List<int>(), false);

            Assert.Throws<ShuffleBagEmptyException>(() => shuffleBag.Next());
        }
    }
}
