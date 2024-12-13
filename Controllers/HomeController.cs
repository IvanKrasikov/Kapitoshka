using System.Diagnostics;
using Kapitoshka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kapitoshka.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            NodeContext db = new();
            List<Node> nodes = [.. db.Nodes];
            nodes.Sort((node1, node2) => node1.Id.CompareTo(node2.Id));
            NodeTree zero = new();

            List<NodeTree> trees = [];
            
            foreach (var node in nodes)
            {
                trees.Add(new NodeTree(node));
            }

            for (int i = 0; i < trees.Count; i++)
            {
                if (trees[i].parentId == 0)
                {
                    zero.children.Add(trees[i]);
                    trees[i].parent = zero;
                }
                else
                {
                    trees[trees[i].parentId-1].children.Add(trees[i]);
                    trees[i].parent = trees[trees[i].parentId-1];
                }
            }

            foreach (var tree in trees)
            {
                tree.count = tree.quantity;
                foreach (var c in tree.children)
                {
                    tree.count += c.quantity;
                }
            }
            
                return View(zero);
        }
        public async Task<IActionResult> Add(int id) {

            NodeContext db = new NodeContext();
            Node node = db.Nodes.Find(id);
            node.quantity = node.quantity + 1;
            db.Nodes.Update(node);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
