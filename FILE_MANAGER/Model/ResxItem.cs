using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILE_MANAGER.Model
{

    public class Item
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string XMLTag { get; set; }
    }
	public class ResxItem : Item
	{
        public  List<ResxSubItem> SubItems { get; set;  }
	}

    public class ResxSubItem : Item
    {
        public  List<Item> SuItems { get; set;}
    }
}
