using Reservation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class PersonInfo
    {
        public string _Name;
        public int _Balance;
        public IEnumerable<ReservationInfo> _ReservInfo { set; get; }

    }
}
