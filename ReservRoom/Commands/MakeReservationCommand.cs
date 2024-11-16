using ReservRoom.Exceptions;
using ReservRoom.Models;
using ReservRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReservRoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
            this._makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeReservation(reservation);
            }
            catch (ReservationConflictException)
            {

                MessageBox.Show("This room is already taken.",
                    "Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) 
                && _makeReservationViewModel.FloorNumber > 0 && base.CanExecute(parameter);  
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) || e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnExecuteChanged();
            }
        }


    }
}
