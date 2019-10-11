using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.EntityModels
{
    public class RoomModel
    {
        public int _Id { set; get; }
        public int _Price { set; get; }
        public IEnumerable<FurnitureModel> _FurList { set; get; }
        public int? _InnerId { set; get; }
    }
}
