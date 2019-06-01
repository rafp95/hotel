using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelServiceImpl
{
    public class WorkerServiceImpl : IWorkerSendEmailService
    {
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private ISendEmailService _sendEmailService;
        private IReservationService _reservationService;
        private IValidatorService _validatorService;

        public WorkerServiceImpl(ISendEmailService sendEmailService
            , IReservationService reservationService
            , IValidatorService validatorService)
        {
            _sendEmailService = sendEmailService;
            _reservationService = reservationService;
            _validatorService = validatorService;
            _backgroundWorker.RunWorkerAsync();
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;

        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            do
            {

            } while (dateTime.AddSeconds(60) > DateTime.Now);

            //Task<IEnumerable<Reservation>> reservations = _reservationService.GetReservationsAsync();
            //reservations.Wait();
            //var pom = reservations.Result;

            //foreach (var item in pom)
            //{
            //    Task.Run( async() => await SendEmail("p.rafal123@gmail.com", item.Guest.Email, $"Przypomnienie o rezerwacji od {item.ToDate.ToShortDateString() } do {item.ToDate.ToShortDateString()}"));
            //}

            Task.Run(async () => await SendEmailToClients());


        }

        public async Task SendEmail(string from, string title, string descr)
        {
            await _sendEmailService.SendEmail(from, title, descr);
        }

        public async Task SendEmailToClients()
        {
            var nonConfirmedClient = await _reservationService.FindNonConfirmClientByEmailAsync();
            var now = DateTime.Now;
            foreach (var item in nonConfirmedClient)
            {
                if (_validatorService.DateBetweenDays(item.FromDate, now) >= 0 
                    && _validatorService.DateBetweenDays(item.FromDate, now) <= 1)
                {
                    await SendEmail(item.Guest.Email, "Hotel Gościniec"
                        , $"Przypomnienie o rezerwacji w hotelu gościneic dnia {item.FromDate}");
                    item.EmailSend = true;
                    await _reservationService.SetUserIsConfirmedByEmailAsync(item, item.ID);
                    
                }
            }
        }
    }
}
