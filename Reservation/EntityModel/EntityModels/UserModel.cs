using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.EntityModels
{
    public class UserModel
    {
        public int _Id { set; get; }
        public string _FirstName { set; get; }
        public string _LastName { set; get; }
        public List<int> _Friends { set; get; }
    }
}
