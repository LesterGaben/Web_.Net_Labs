using MyListLibrary;

namespace Lab2 {
    public class Tests {

        [Fact]
        public void Property_IsReadOnly_False() {

            //Arange
            MyList<int> myList = new MyList<int>(0);

            //Act
            bool myListIsReadOnly = myList.IsReadOnly;

            //Assert
            Assert.False(myListIsReadOnly);
        }

        [Fact]
        public void Constructor_With_Negative_Capacity_ThrowsException() {

            //Arange
            int capacity = -1;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MyList<int>(capacity));
        }

        [Fact]
        public void Constructor_With_Zero_Capacity_InitializesMyList() {

            //Arange
            int capacity = 0;

            //Act
            MyList<int> myList = new MyList<int>(capacity);

            //Assert
            Assert.Equal(capacity, myList.GetCapacity());
            Assert.Empty(myList);
        }

        [Fact]
        public void Construcor_With_Positive_Capacity_InitializesMyList() {

            //Arange
            int capacity = 5;

            //Act
            MyList<int> myList = new MyList<int>(capacity);

            //Assert
            Assert.Equal(capacity, myList.GetCapacity());
            Assert.Equal(0, myList.Count);
        }

        [Fact]
        public void Indexer_Returns_Item_IfItemExiscts() {

            //Arange
            int expectedItem1 = 10;
            int expectedItem2 = 20;
            int expectedItem3 = 30;
            MyList<int> myList = new MyList<int> { expectedItem1, expectedItem2, expectedItem3 };

            //Act
            int item1 = myList[0];
            int item2 = myList[1];
            int item3 = myList[2];

            //Assert
            Assert.Equal(expectedItem1, item1);
            Assert.Equal(expectedItem2, item2);
            Assert.Equal(expectedItem3, item3);
        }

        [Fact]
        public void Indexer_Sets_Item_IfIndexValid() {

            //Arange
            int expectedItem1 = 10;
            MyList<int> myList = new MyList<int> { 500 };

            //Act
            myList[0] = expectedItem1;
            int item1 = myList[0];

            //Assert
            Assert.Equal(expectedItem1, item1);
        }

        [Fact]
        public void Indexer_ThrowsException_IfSetIndexInvalid() {

            //Arange
            MyList<int> myList = new MyList<int>(0);

            //Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => myList[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => myList[200]);
        }

        [Fact]
        public void Add_NewItem_ToFullList_RisezesAndContainsItem() {

            //Arange
            MyList<int> newList = new MyList<int> { 1 };

            //Act
            newList.Add(2);

            //Assert
            Assert.Equal(2, newList.Count);
            Assert.Contains(2, newList);
        }

        [Fact]
        public void Add_NewItem_ToEmptyList_RisezesAndContainsItem() {

            //Arange
            MyList<int> newList = new MyList<int>();

            //Act
            newList.Add(5);

            //Assert
            Assert.Equal(1, newList.Count);
            Assert.Contains(5, newList);
        }

        [Fact]
        public void Clear_EmptyList_ClearsList() {
            
            //Arange
            MyList<int> myList = new MyList<int>();

            //Act
            myList.Clear();

            //Assert
            Assert.Empty(myList);
        }

        [Fact]
        public void Clear_NonEmptyList_ClearsList() {

            //Arange
            MyList<int> myList = new MyList<int> { 1, 2, 3};

            //Act
            myList.Clear();

            //Assert
            Assert.Empty(myList);
        }
    }
}