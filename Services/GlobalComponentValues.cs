using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PhotoGalleryMail
{
    public class GlobalComponentValues
    {
        public int? MailsCount { get; private set; }

        public event Action OnChangeMailsCounter;

        public void SetMailCounter(int counter)
        {
            MailsCount = counter;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChangeMailsCounter?.Invoke();
    }
}
