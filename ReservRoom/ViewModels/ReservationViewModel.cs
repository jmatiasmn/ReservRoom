using ReservRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservRoom.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private Reservation _reservation;
        public RoomID RoomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }


        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
