using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Services
{
    public class Message : IMessage
    {
        public string WriteMessage(string name)
        {
            return $"Hello {name}";
        }
    }
}
