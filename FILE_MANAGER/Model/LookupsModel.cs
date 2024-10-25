using System.Collections.Generic;

namespace FILE_MANAGER.Model
{
    public class LookupsModel
    {
        public List<LookupsItemModel> Items { get; set; }
    }

    public class LookUpSource {
        public string Id { get; set; }
        public LookupsModel LookUps { get; set; }
    }

    public class LookupsItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
