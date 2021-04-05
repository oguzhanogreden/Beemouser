using System;

namespace Beemouser.Domain.Models
{
    public class Click
    {
        public int Id { get; set; }

        public string WindowOwnerName { get; set; }
        public DateTime ClickedAt { get; set; }

        public Click() {
            ClickedAt = DateTime.UtcNow;
        }

        public Click(string windowOwnerName)
        {
            WindowOwnerName = windowOwnerName;
            ClickedAt = DateTime.UtcNow;
        }
    }
}
