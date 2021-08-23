using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public interface IReservation
    {
        int GetReservationTotal(DateTime check_in, DateTime check_out, int guests, int roomtype, int meal);
        void create(ReservationModel model);
    }
}
