namespace Kapitoshka.Models
{
    public class Node
    {
        public int Id { get; set; }
        public string? name {  get; set; }
        public int quantity { get; set; } = 0;
        public int parentId { get; set; } = 0;
        public List<int> childrenId { get; set; } = new List<int>();

    }
}
