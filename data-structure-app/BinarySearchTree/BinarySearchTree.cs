namespace data_structure_app
{
    public class BinaryTree : IDataStructure
    {
        private BinaryTreeNode root;
        public int Count;

        public void Insert(int value)
        {
            BinaryTreeNode node = new BinaryTreeNode(value);

            Insert(node);
        }

        public void Insert(BinaryTreeNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node", "node cannot be null");

            if (root == null)
                root = node;
            else            
                Insert(node, ref root);            

            Count++;
        }

        public void Delete(int value, bool rebalanceTree)
        {
            BinaryTreeNode parentNode;
            BinaryTreeNode foundNode = null;
            BinaryTreeNode tree = parentNode = root;

            while (tree != null)
            {
                if (value.CompareTo(tree.Data) == 0)
                {
                    foundNode = tree;
                    break;
                }
                else if (value.CompareTo(tree.Data) < 0)
                {
                    parentNode = tree;
                    tree = tree.Left;
                }
                else if (value.CompareTo(tree.Data) > 0)
                {
                    parentNode = tree;
                    tree = tree.Right;
                }
            }

            if (foundNode == null)
            {
                throw new Exception("Node not found in binary tree");
            }

            bool leftOrRightNode = false;

            if (foundNode != parentNode.Left)
            {
                leftOrRightNode = true;
            }

            if (foundNode == parentNode)
            {
                if (rebalanceTree)
                {
                    var listOfNodes = new List<BinaryTreeNode>();

                    FillListInOrder(root, listOfNodes);
                    RemoveChildren(listOfNodes);
                    listOfNodes.Remove(parentNode);

                    root = null;
                    int count = Count - 1;
                    Count = 0;

                    BalanceTree(0, count - 1, listOfNodes);
                }
                else
                {
                    BinaryTreeNode leftMost = FindLeftMost(parentNode.Right, true);

                    if (leftMost != null)
                    {
                        leftMost.Left = parentNode.Left;
                        leftMost.Right = parentNode.Right;
                        root = leftMost;
                    }
                }
            }
            else if (foundNode.Left == null && foundNode.Right == null)
            {
                if (leftOrRightNode)
                {
                    parentNode.Right = null;
                }
                else
                {
                    parentNode.Left = null;
                }
            }
            else if (foundNode.Left != null &&
            foundNode.Right != null)
            {
                if (leftOrRightNode)
                {
                    parentNode.Right = foundNode.Right;
                    parentNode.Right.Left = foundNode.Left;
                }
                else
                {
                    parentNode.Left = foundNode.Right;
                    parentNode.Left.Left = foundNode.Left;
                }
            }

            else if (foundNode.Left != null ||
            foundNode.Right != null)
            {
                if (foundNode.Left != null)
                {
                    if (leftOrRightNode)
                    {
                        parentNode.Right = foundNode.Left;
                    }
                    else
                    {
                        parentNode.Left = foundNode.Left;
                    }
                }
                else
                {
                    if (leftOrRightNode)
                    {
                        parentNode.Right = foundNode.Right;
                    }
                    else
                    {
                        parentNode.Left = foundNode.Right;
                    }
                }
            }
        }

        public BinaryTreeNode Search(int value)
        {
            BinaryTreeNode tree = root;

            while (root != null)
            {
                if (value.CompareTo(tree.Data) == 0)
                {
                    return tree;
                }
                else if (value.CompareTo(tree.Data) < 0)
                {
                    tree = tree.Left;
                }
                else if (value.CompareTo(tree.Data) > 0)
                {
                    tree = tree.Right;
                }
            }

            return null;
        }

        public IEnumerable<BinaryTreeNode> InOrder()
        {
            return InOrder(root);
        }

        private IEnumerable<BinaryTreeNode> InOrder(BinaryTreeNode node)
        {
            if (node != null)
            {
                foreach (BinaryTreeNode left in InOrder(node.Left))
                {
                    yield return left;
                }

                yield return node;

                foreach (BinaryTreeNode right in InOrder(node.Right))
                {
                    yield return right;
                }
            }
        }

        public IEnumerable<BinaryTreeNode> PreOrder()
        {
            return PreOrder(root);
        }

        public IEnumerable<BinaryTreeNode> PostOrder()
        {
            return PostOrder(root);
        }

        public IEnumerable<BinaryTreeNode> BreadthFirstTraversal()
        {
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                BinaryTreeNode current = queue.Dequeue();

                if (current != null)
                {
                    queue.Enqueue(current.Left);
                    queue.Enqueue(current.Right);

                    yield return current;
                }
            }
        }

        public IEnumerable<BinaryTreeNode> DepthFirstTraversal()
        {
            Stack<BinaryTreeNode> queue = new Stack<BinaryTreeNode>();

            BinaryTreeNode current;

            queue.Push(root);

            while (queue.Count != 0)
            {
                current = queue.Pop();

                if (current != null)
                {
                    queue.Push(current.Right);
                    queue.Push(current.Left);

                    yield return current;
                }
            }
        }

        public void BalanceTree()
        {
            IList<BinaryTreeNode> listOfNodes = new List<BinaryTreeNode>();

            FillListInOrder(root, listOfNodes);
            RemoveChildren(listOfNodes);

            root = null;
            int count = Count;
            Count = 0;

            BalanceTree(0, count - 1, listOfNodes);
        }

        private void Insert(BinaryTreeNode node, ref BinaryTreeNode parent)
        {
            if (parent == null)
            {
                parent = node;
            }
            else
            {
                if (node.Data.CompareTo(parent.Data) < 0)
                {
                    Insert(node, ref parent.Left);
                }
                else if (node.Data.CompareTo(parent.Data) > 0)
                {
                    Insert(node, ref parent.Right);
                }
                else if (node.Data.CompareTo(parent.Data) == 0)
                {
                    throw new ArgumentException("Duplicate node");
                }
            }
        }

        private void BalanceTree(int min, int max, IList<BinaryTreeNode> list)
        {
            if (min <= max)
            {
                int middleNode = (int)Math.Ceiling(((double)min + max) / 2);

                Insert(list[middleNode]);

                BalanceTree(min, middleNode - 1, list);

                BalanceTree(middleNode + 1, max, list);
            }
        }

        private void FillListInOrder(BinaryTreeNode node, ICollection<BinaryTreeNode> list)
        {
            if (node != null)
            {
                FillListInOrder(node.Left, list);

                list.Add(node);

                FillListInOrder(node.Right, list);
            }
        }

        private void RemoveChildren(IEnumerable<BinaryTreeNode> list)
        {
            foreach (BinaryTreeNode node in list)
            {
                node.Left = null;
                node.Right = null;
            }
        }

        private IEnumerable<BinaryTreeNode> PreOrder(BinaryTreeNode node)
        {
            if (node != null)
            {
                yield return node;

                foreach (BinaryTreeNode left in PreOrder(node.Left))
                {
                    yield return left;
                }

                foreach (BinaryTreeNode right in PreOrder(node.Right))
                {
                    yield return right;
                }
            }
        }

        private IEnumerable<BinaryTreeNode> PostOrder(BinaryTreeNode node)
        {
            if (node != null)
            {
                foreach (BinaryTreeNode left in PostOrder(node.Left))
                {
                    yield return left;
                }

                foreach (BinaryTreeNode right in PostOrder(node.Right))
                {
                    yield return right;
                }

                yield return node;
            }
        }

        private BinaryTreeNode FindLeftMost(BinaryTreeNode node, bool setParentToNull)
        {
            BinaryTreeNode leftMost = null;
            BinaryTreeNode current = leftMost = node;
            BinaryTreeNode parent = null;

            while (current != null)
            {
                if (current.Left != null)
                {
                    parent = current;
                    leftMost = current.Left;
                }

                current = current.Left;
            }

            if (parent != null && setParentToNull)
            {
                parent.Left = null;
            }

            return leftMost;
        }

        [ExcludeFromCodeCoverage]
        public void Run()
        {
            var list = new int[] { 21, 16, 54, 25, 87 };

            foreach (var item in list)
            {
                Insert(item);
            }

            BalanceTree();

            foreach (var item in PreOrder())
            {
                Console.Write(item.Data + " ");
            }
        }
    }

    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value)
        {
            Data = value;
        }

        public int Data { get; set; }
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
    }













}
