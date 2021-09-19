using System;
using System.Text;

namespace Domain.Entities
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }    
}
