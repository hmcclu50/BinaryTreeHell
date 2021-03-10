using BinaryTreeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsert_WhenEmpty()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(1);
            Assert.AreEqual("{1, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestInsert_SeveralEntries()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(2);
            bt.Insert(4);
            bt.Insert(6);
            bt.Insert(8);
            Assert.AreEqual("{5, 3, 7}" + Environment.NewLine +
                "{3, 2, 4}" + Environment.NewLine +
                "{2, , }" + Environment.NewLine +
                "{4, , }" + Environment.NewLine +
                "{7, 6, 8}" + Environment.NewLine +
                "{6, , }" + Environment.NewLine +
                "{8, , }" + Environment.NewLine, bt.Print());

        }

        [TestMethod]
        public void TestFind_WhenEmpty()
        {
            BinaryTree bt = new BinaryTree();
            Assert.ThrowsException<Exception>(() => bt.Find(1));
        }

        [TestMethod]
        public void TestFind_NotFound()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(2);
            bt.Insert(4);
            bt.Insert(6);
            bt.Insert(8);
            Assert.ThrowsException<Exception>(() => bt.Find(1));
        }

        [TestMethod]
        public void TestFind_SeveralEntries()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(2);
            bt.Insert(4);
            bt.Insert(6);
            bt.Insert(8);
            Assert.AreEqual(bt.Find(4), 4);
        }

        [TestMethod]
        public void TestRemove_HasNoChildren_PrevLeft()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Remove(3);
            Assert.AreEqual("{5, , 7}" + Environment.NewLine +
                "{7, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemove_HasNoChildren_PrevRight()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Remove(7);
            Assert.AreEqual("{5, 3, }" + Environment.NewLine +
                "{3, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemove_HasLeftChild_PrevLeft()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(2);
            bt.Remove(3);
            Assert.AreEqual("{5, 2, 7}" + Environment.NewLine +
                "{2, , }" + Environment.NewLine +
                "{7, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemove_HasLeftChild_PrevRight()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(6);
            bt.Remove(7);
            Assert.AreEqual("{5, 3, 6}" + Environment.NewLine +
                "{3, , }" + Environment.NewLine +
                "{6, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemove_HasRightChild_PrevLeft()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(4);
            bt.Remove(3);
            Assert.AreEqual("{5, 4, 7}" + Environment.NewLine +
                "{4, , }" + Environment.NewLine +
                "{7, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemove_HasRightChild_PrevRight()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(8);
            bt.Remove(7);
            Assert.AreEqual("{5, 3, 8}" + Environment.NewLine +
                "{3, , }" + Environment.NewLine +
                "{8, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemove_HasTwoChildren()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Insert(2);
            bt.Insert(4);
            bt.Remove(3);
            Assert.AreEqual("{5, 4, 7}" + Environment.NewLine +
                "{4, 2, }" + Environment.NewLine +
                "{2, , }" + Environment.NewLine +
                "{7, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemoveHead_HasNoChildren()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Remove(5);
            Assert.AreEqual("", bt.Print());
        }

        [TestMethod]
        public void TestRemoveHead_HasLeftChild()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Remove(5);
            Assert.AreEqual("{3, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemoveHead_HasRightChild()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(7);
            bt.Remove(5);
            Assert.AreEqual("{7, , }" + Environment.NewLine, bt.Print());
        }

        [TestMethod]
        public void TestRemoveHead_HasTwoChildren()
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(5);
            bt.Insert(3);
            bt.Insert(7);
            bt.Remove(5);
            Assert.AreEqual("{7, 3, }" + Environment.NewLine +
                "{3, , }" + Environment.NewLine, bt.Print());
        }
    }
}
