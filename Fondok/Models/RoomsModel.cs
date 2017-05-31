using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fondok.Models
{
    public class RoomsModel
    {
        public RoomsModel() { }
        private string _room_id; public string RoomID { get { return _room_id; } set { _room_id = value; } }
        private string _room_type; public string RoomType { get { return _room_type; } set { _room_type = value; } }
        private string _reserved; public string Reserved { get { return _reserved; } set { _reserved = value; } }
        private string _reserved_from; public string ReservedFrom { get { return _reserved_from; } set { _reserved_from = value; } }
        private string _reserved_to; public string ReservedTo { get { return _reserved_to; } set { _reserved_to = value; } }
        private string _reserved_by; public string ReservedBy { get { return _reserved_by; } set { _reserved_by = value; } }
    }
}
