namespace Kapitoshka.Models
{
    public class NodeTree : Node
    {
        public NodeTree? parent { get; set; }
        public List<NodeTree> children { get; set; } = new List<NodeTree>();

        public int count { get; set; } = 0;

        public NodeTree(Node node) 
        {
            this.Id = node.Id;
            this.name = node.name;
            this.quantity = node.quantity;
            this.parentId = node.parentId;
            this.childrenId = node.childrenId;
        }
        public NodeTree()
        {
        }

        public int getAllQ()
        {
            int count = 0;
            count += quantity;
            if (children.Count == 0)
            {
                return count;
            }
            else
            {
                for (int i = 0; i < children.Count; i++)
                {
                     count += children[i].getAllQ();
                }
                return count;
            }
        }

        public List<NodeString> GetAllHTML(int n = 0)
        {
            List <NodeString> html = [];
            for(int i = 0; i < children.Count; i++)
            {
                string str = "";
                for (int y = 0; y < n; y++) str += "    ";
                str += $"{children[i].name}     ";
                str += $"{children[i].getAllQ()}";
                html.Add(new NodeString(children[i].Id, str, n));
                if (children[i].children.Count != 0)
                {
                    html.AddRange(children[i].GetAllHTML(n+1));
                }
            }
            return html;
        }
        public class NodeString {
            public int id;
            public string str;
            public int tab;
            public NodeString(int id, string str, int tab = 0)
            {
                this.id = id;
                this.str = str;
                this.tab = tab;
            }   
        }
    }
}
