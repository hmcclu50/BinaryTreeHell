using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLab
{
    public class BinaryTree
    {
        private Node head = null;
        public void Insert(int key)
        {
            Node toInsert = new Node(key);
            Node cur = head;
            Node prev = null;
            while (cur != null)
            {
                prev = cur;
                if (key < cur.data) cur = cur.left;
                else cur = cur.right;
            }
            if (prev == null) head = toInsert;
            else if (key < prev.data) prev.left = toInsert;
            else prev.right = toInsert;
        }

        public int Find(int key)
        {
            Node cur = head;
            while (cur != null)
            {
                if (key == cur.data) return key;
                else if (key < cur.data) cur = cur.left;
                else cur = cur.right;
            }
            throw new Exception("Key not found");
        }

        public int Remove(int key)
        {
            Node cur = head;
            Node prev = null;
            while (cur != null)
            {
                prev = cur;
                if (key < cur.data && cur.left != null) cur = cur.left;
                else if (key > cur.data && cur.right != null) cur = cur.right;
                if (key == cur.data) break;
            }
            if (cur == null) throw new Exception("Key not found");

            // Head
            if (cur == head)
            {
                if (cur.left == null && cur.right == null) head = null;
                else if (cur.left == null) head = cur.right;
                else if (cur.right == null) head = cur.left;
                else head.data = RemoveLargestSmaller(head);
            }
            // No children
            else if (cur.left == null && cur.right == null)
            {
                if (prev.left == cur) prev.left = null;
                else prev.right = null;
            }
            // One child (right)
            else if (cur.left == null)
            {
                if (prev.left == cur) prev.left = cur.right;
                else prev.right = cur.right;
            }
            // One child (left)
            else if (cur.right == null)
            {
                if (prev.left == cur) prev.left = cur.left;
                else prev.right = cur.left;
            }
            // Two children
            else cur.data = RemoveLargestSmaller(cur);
            return key;
        }

        private int RemoveLargestSmaller(Node cur)
        {
            Node temp = cur;
            while (temp.right != null) temp = temp.right;
            int retVal = temp.data;
            Remove(temp.data);
            return retVal;
        }

        public string Print()
        {
            return Print(head);
        }

        private string Print(Node n)
        {
            if (n == null) return "";
            string result = "{" + n.data + ", ";
            if (n.left != null) result += n.left.data;
            result += ", ";
            if (n.right != null) result += n.right.data;
            result += "}" + Environment.NewLine;
            result += Print(n.left);
            result += Print(n.right);
            return result;
        }

        private void RotateL(Node gp, Node p, Node c, Node gc)
        {
            if (head == p) head = c;
            else gp.right = c;
            p.right = c.left;
            c.left = p;
        }

        private void RotateR(Node gp, Node p, Node c, Node gc)
        {
            if (head == p) head = c;
            else gp.left = c;
            p.left = c.right;
            c.right = p;
        }

        private void RotateRL(Node gp, Node p, Node c, Node gc)
        {
            p.right = gc;
            c.left = gc.right;
            gc.right = c;
            RotateL(gp, p, c, gc);
        }

        private void RotateLR(Node gp, Node p, Node c, Node gc)
        {
            p.left = gc;
            c.right = gc.left;
            gc.left = c;
            RotateR(gp, p, c, gc);
        }
    }
}
