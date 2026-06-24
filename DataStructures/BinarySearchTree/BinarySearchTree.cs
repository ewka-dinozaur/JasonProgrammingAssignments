using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeEx
{
    public class BstNode
    {
        public int Value;
        public BstNode Left;
        public BstNode Right;

        public BstNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public BstNode Root;
        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new BstNode(value);
                return;
            }

            InsertRecursive(Root, value);
        }

        private void InsertRecursive(BstNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                    node.Left = new BstNode(value);
                else
                    InsertRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                if (node.Right == null)
                    node.Right = new BstNode(value);
                else
                    InsertRecursive(node.Right, value);
            }
            // jeśli value == node.Value → nic nie robimy (brak duplikatów)
        }

        public bool Contains(int value)
        {
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(BstNode node, int value)
        {
            if (node == null)
                return false;

            if (value == node.Value)
                return true;
            else if (value < node.Value)
                return ContainsRecursive(node.Left, value);
            else
                return ContainsRecursive(node.Right, value);
        }
    }
















}
