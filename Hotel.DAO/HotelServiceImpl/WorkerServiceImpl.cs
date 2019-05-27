using Hotel.DAO.HotelService;
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

        public WorkerServiceImpl(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
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

            } while (dateTime.AddSeconds(10) > DateTime.Now);
            //Task.Run( async() => await SendEmail("p.rafal123@gmail.com", "patrykrafal33@o2.pl", "fdfs"));
        }

        public async Task SendEmail(string from, string to, string descr)
        {
            await _sendEmailService.SendEmail(from, to, descr);
        }
    }
}
