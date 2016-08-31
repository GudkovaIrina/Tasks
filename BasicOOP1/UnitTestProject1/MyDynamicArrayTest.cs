namespace MyDynamicArrayTest
{
    using BasicOOP9;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class MyDynamicArrayTest
    {
        [TestMethod]
        public void CreateArray_Capacity()
        {
            //arrange
            int capacity = 5;
            MyDynamicArray<int> arr;

            //act
            arr = new MyDynamicArray<int>(capacity);

            //assert
            Assert.AreEqual(capacity, arr.Capacity, "It should create dynamic array with the specified capacity.");
        }

        [TestMethod]
        public void AddItems()
        {
            //arrange
            MyDynamicArray<int> arr = new MyDynamicArray<int>();
            int firstItem = 10;
            int secondItem = 20;
            int thirdItem = 30;
            int fourthItem = 40;

            //act
            arr.Add(firstItem);
            arr.Add(secondItem);
            arr.Add(thirdItem);
            arr.Add(fourthItem);

            //assert
            Assert.AreEqual(arr.Length, 4, "It should add four Items to array");
            Assert.AreEqual<int>(arr[0], firstItem, "First item should be correct");
            Assert.AreEqual<int>(arr[1], secondItem, "Second item should be correct");
            Assert.AreEqual<int>(arr[2], thirdItem, "Third item should be correct");
            Assert.AreEqual<int>(arr[3], fourthItem, "Fourth item should be correct");
        }

        [TestMethod]
        public void AddRange()
        {
            //arrange
            MyDynamicArray<int> arr = new MyDynamicArray<int>();
            IEnumerable<int> arrayToAdd = new int[] { 70, 80, 90, 100, 110, 120, 130, 140, 150 };

            //act
            arr.AddRange(arrayToAdd);

            //assert
            Assert.AreEqual(arr.Length, arrayToAdd.Count(), "It should add all Items to array from other IEnumerable");
            Assert.AreEqual<int>(arr[0], arrayToAdd.First(), "First item should be correct");
            Assert.AreEqual<int>(arr[arr.Length - 1], arrayToAdd.Last(), "Last item should be correct");
        }

        [TestMethod]
        public void RemoveItem()
        {
            //arrange
            int itemToRemove = 3;
            int[] arrayToCreate = new int[] { 1, 2, itemToRemove, 4, 5, itemToRemove };
            MyDynamicArray<int> arr = new MyDynamicArray<int>(arrayToCreate);
            bool success;
            
            //act
            success = arr.Remove(itemToRemove);

            //assert
            Assert.AreEqual(arr.Length, arrayToCreate.Length - 2, "Length of array must be decreased by two");
            Assert.IsTrue(arr.All(i => i != itemToRemove), "Array should not contain removed item");
            Assert.IsTrue(success, "Remove should return true, when it delete some item");
        }

        [TestMethod]
        public void InsertItem()
        {
            //arrange
            int capacity = 3;
            int index = 2;
            int beforeValue = 2;
            int afterValue = 4;
            int value = 3;
            int[] arrayToCreate = new int[] { 1, beforeValue, afterValue };
            MyDynamicArray<int> arr = new MyDynamicArray<int>(capacity);
            arr.AddRange(arrayToCreate);

            //act
            arr.Insert(index, value);

            //assert
            Assert.AreEqual(arr.Length, arrayToCreate.Length + 1, "Insertion should increase length by one");
            Assert.AreEqual(arr[index], value, "Value should be inserted into specified position");
            Assert.AreEqual(arr[index - 1], beforeValue, "Before insert index elements should be the same as it was");
            Assert.AreEqual(arr[index + 1], afterValue, "After specified position items should be shifted");
            Assert.AreEqual(arr.Capacity, capacity * 2, "Capacity should be doubled");
        }

        [TestMethod]
        public void GetCurrent()
        {
            //arrange
            int[] arrayToCreate = new int[] { 1, 2, 3, 4, 5, 6 };
            MyDynamicArray<int> arr = new MyDynamicArray<int>(arrayToCreate);
            IEnumerator<int> enumerator = arr.GetEnumerator();
            
            //act
            enumerator.MoveNext();

            //assert
            Assert.AreEqual(enumerator.Current, arrayToCreate[0], "Current should return first element of sequence after MoveNext invocation");
        }

        [TestMethod]
        public void IterateAllItems()
        {
            //arrange
            int[] arrayToCreate = new int[] { 1, 2, 3, 4, 5, 6 };
            MyDynamicArray<int> arr = new MyDynamicArray<int>(arrayToCreate);
            IEnumerator<int> enumerator = arr.GetEnumerator();
            int length = arrayToCreate.Length;
            int count = 0;
            int current = -1;

            //act
            while (enumerator.MoveNext())
            {
                count++;
                current = enumerator.Current;
            }

            //assert
            Assert.AreEqual(count, arr.Length, "MoveNext invocation quantity should be equal array length");
            Assert.AreEqual(current, arrayToCreate[length - 1], "Current element should be equal last element of sequence");
        }

        [TestMethod]
        public void ResetEnumerator()
        {
            //arrange
            int[] arrayToCreate = new int[] { 1, 2, 3, 4, 5, 6 };
            MyDynamicArray<int> arr = new MyDynamicArray<int>(arrayToCreate);
            IEnumerator<int> enumerator = arr.GetEnumerator();

            //act
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.Reset();
            enumerator.MoveNext();

            //assert
            Assert.AreEqual(enumerator.Current, arr[0], "Current should be first element of sequence after Reset invocation");
        }

        [TestMethod]
        public void MultipleEnumerators()
        {
            //arrange
            int[] arrayToCreate = new int[] { 1, 2, 3, 4, 5, 6 };
            MyDynamicArray<int> arr = new MyDynamicArray<int>(arrayToCreate);
            IEnumerator<int> firstEnumerator = arr.GetEnumerator();
            IEnumerator<int> secondEnumerator = arr.GetEnumerator();
            int times = 3;

            //act
            for (int i = 0; i < times; i++)
            {
                firstEnumerator.MoveNext();
                secondEnumerator.MoveNext();
            }
            
            //assert
            Assert.AreEqual(firstEnumerator.Current, arrayToCreate[times - 1], "GetEnumerator should return independent enumerator");
        }

        [TestMethod]
        public void IndexOfItem()
        {
            //arrange
            int ItemPositive = 3;
            int ResultPositive;
            int ResultPositiveShouldBe = 2;
            int ItemNegative = 8;
            int ResultNegative;
            int ResultNegativeShouldBe= -1;
            MyDynamicArray<int> arr = new MyDynamicArray<int>(new int[] { 1, 2, 3, 4, 5 });

            //act
            ResultPositive = arr.IndexOf(ItemPositive);
            ResultNegative = arr.IndexOf(ItemNegative);

            //assert
            Assert.AreEqual(ResultPositive, ResultPositiveShouldBe, "Existing item should be get his number in array");
            Assert.AreEqual(ResultNegative, ResultNegativeShouldBe, "Missing item should be get -1");
        }

        [TestMethod]
        public void RemoveAtNumber()
        {
            //arrange
            int Number = 1;
            int length = 4;
            int afterValue = 3;
            int capacity = 10;
            MyDynamicArray<int> arr = new MyDynamicArray<int>(new int[]{1,2,3,4,5});

            //act
            arr.RemoveAt(Number);

            //assert
            Assert.AreEqual(arr[1], afterValue, "Peace of deleted element must be next elements");
            Assert.AreEqual(arr.Length, length, "Length of array should be decrease by one");
            Assert.AreEqual(arr.Capacity, capacity, "Capacity shouldn't to change");
        }
    }
}