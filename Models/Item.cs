namespace DataShopMVC.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {get; set;}
        public int Price {get; set;}
        public bool Available {get; set;}
        public Size Size {get; set;}
        
    }

    public enum Size
    {
        S = 0,
        M = 1,
        L = 2
    }
}