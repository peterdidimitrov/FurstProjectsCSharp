using BankSafe;
using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item testItem;
        private BankVault testBankVault;

        [SetUp]
        public void Setup()
        {
            testItem = new Item("Test Owner", "Test Item ID");
            testBankVault = new BankVault();
        }

        [Test]
        public void AddItem_ShouldAddItemToVaultCell()
        {
            // Arrange
            string testCell = "A1";

            // Act
            string result = testBankVault.AddItem(testCell, testItem);

            // Assert
            Assert.AreEqual($"Item:{testItem.ItemId} saved successfully!", result);
            Assert.AreEqual(testItem, testBankVault.VaultCells[testCell]);
        }

        [Test]
        public void AddItem_ShouldThrowArgumentException_WhenCellDoesNotExist()
        {
            // Arrange
            string testCell = "Z9";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => testBankVault.AddItem(testCell, testItem));
        }

        [Test]
        public void AddItem_ShouldThrowArgumentException_WhenCellIsAlreadyTaken()
        {
            // Arrange
            string testCell = "A1";
            Item existingItem = new Item("Existing Owner", "Existing Item ID");
            testBankVault.AddItem(testCell, existingItem);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => testBankVault.AddItem(testCell, testItem));
        }

        [Test]
        public void AddItem_ShouldThrowInvalidOperationException_WhenItemIsAlreadyInCell()
        {
            // Arrange
            string testCell = "A1";
            testBankVault.AddItem(testCell, testItem);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => testBankVault.AddItem("A2", testItem));
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemFromVaultCell()
        {
            // Arrange
            string testCell = "A1";
            testBankVault.AddItem(testCell, testItem);

            // Act
            string result = testBankVault.RemoveItem(testCell, testItem);

            // Assert
            Assert.AreEqual($"Remove item:{testItem.ItemId} successfully!", result);
            Assert.IsNull(testBankVault.VaultCells[testCell]);
        }

        [Test]
        public void RemoveItem_ShouldThrowArgumentException_WhenCellDoesNotExist()
        {
            // Arrange
            string testCell = "Z9";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => testBankVault.RemoveItem(testCell, testItem));
        }

        [Test]
        public void RemoveItem_ShouldThrowArgumentException_WhenItemInCellDoesNotExist()
        {
            // Arrange
            string testCell = "A1";
            Item nonExistingItem = new Item("Non-existing Owner", "Non-existing Item ID");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => testBankVault.RemoveItem(testCell, nonExistingItem));
        }

        //[Test]
        //public void RemoveItem_ShouldThrowArgumentException_WhenTryingToRemoveNull()
        //{
        //    // Arrange
        //    string testCell = "A1";

        //    // Act & Assert
        //    Assert.Throws<ArgumentException>(() => testBankVault.RemoveItem(testCell, null));
        //}
    }
}
