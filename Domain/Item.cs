
using System.Collections.Generic;

namespace Core
{
  public class Item 
  {
    public string Id { get; set; }

    public ICollection<ItemImage> Images { get; set; }
  }

  public class ItemImage
  {
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<ImageAttribute> Attributes { get; set; }
  }

  public class ImageAttribute
  {
    public string Content { get; set; }
  }
}