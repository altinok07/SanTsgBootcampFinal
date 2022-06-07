using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BootcampFinal.Application.Models;

namespace BootcampFinal.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
