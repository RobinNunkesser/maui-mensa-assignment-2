using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa
{
    public static class Settings
    {
        private static readonly int StatusDefault = 0;

        public static int Status
        {
            get => Preferences.Get(nameof(Status), StatusDefault);
            set => Preferences.Set(nameof(Status), value);
        }
    }
}
