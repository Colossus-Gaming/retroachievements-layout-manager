using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Models
{
    class NotificationRequest
    {
        public Achievement Achievement { get; set; }
        public GameInfo GameInfoAndProgress { get; set; }
    }
}
